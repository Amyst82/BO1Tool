﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace bo1tool
{
    public class AiryzMemory
    {
        #region Flags
        [Flags]
        public enum ProcessAccessFlags
        {
            PROCESS_ALL_ACCESS = 0x001F0FFF,
            Terminate = 1,
            CreateThread = 2,
            VMOperation = 8,
            VMRead = 0x00000010, 
            VMWrite = 0x00000020, 
            DupHandle = 0x00000040,
            SetInformation = 0x00000200, 
            QueryInformation = 0x00000400, 
            Synchronize = 0x00100000,
        }

        public enum VirtualMemoryProtection
        {
            PAGE_NOACCESS = 1,
            PAGE_READONLY = 2,
            PAGE_READWRITE = 4,
            PAGE_WRITECOPY = 8,
            PAGE_EXECUTE = 0x010,
            PAGE_EXECUTE_READ = 0x20,
            PAGE_EXECUTE_READWRITE = 0x40,
            PAGE_EXECUTE_WRITECOPY = 0x80, 
            PAGE_GUARD = 0x100,
            PAGE_NOCACHE = 0x200, 
        }

        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        public enum FreeType
        {
            Decommit = 0x4000,
            Release = 0x8000,
        }
        #endregion

        #region Variables

        public string processName;  //string containing process name
        public Process process;
        public bool ShowErrors = false;
        public bool BreakOnErrors = false;
        public int DefaultStringLength = 50;
        public IntPtr pHandle;
        public IntPtr winHandle;

        private bool doRestore = true;
      
        

        //Lists of shit for restore function, i would reccomend against using restore stuff tho
        List<byte[]> OriginalBytes = new List<byte[]> { };
        List<IntPtr> ChangedAddresses = new List<IntPtr> { };

        #endregion

        #region Imports
        [DllImport("kernel32.dll")]     //import the openProcess method from the kernel
        private static extern IntPtr OpenProcess(int AccessType, bool doHandleInherit, int ProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, ref int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, VirtualMemoryProtection flProtect);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("USER32.DLL")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        #endregion

        public AiryzMemory(string ProcessName, bool EnableRestore)
        {
            try
            {
                processName = ProcessName;      //get process name and apply it to the variable
                CheckProcess();                 
                doRestore = EnableRestore;
            }
            catch
            {
                Console.WriteLine("Process not Found...");
            }
        }

        public AiryzMemory(string ProcessName)
        {
            try
            {
                processName = ProcessName;      //get process name and apply it to the variable
                CheckProcess();                 
                doRestore = false;
            }
            catch
            {
                Console.WriteLine("Process not Found...");
            }
        }

        public AiryzMemory()
        {
            try
            {
                processName = "";      //get process name and apply it to the variable
                CheckProcess();
                doRestore = false;
            }
            catch
            {
                Console.WriteLine("Process not Found...");
            }
        }

        private void CheckProcess()
        {
            if ((Process.GetProcessesByName(processName).Length != 0))
            {
                process = Process.GetProcessesByName(processName)[0];
                winHandle = process.MainWindowHandle;
                pHandle = OpenProcess((int)ProcessAccessFlags.PROCESS_ALL_ACCESS, false, process.Id);
            }
        } //Check if process is running and update handles 

        public List<string> ListModules()
        {
            List<string> Modules = new List<string> { };
            if ((Process.GetProcessesByName(processName).Length != 0))
            {
                Process proc = Process.GetProcessesByName(processName).FirstOrDefault();
                ProcessModuleCollection procColl = process.Modules;
                foreach (ProcessModule module in procColl)
                {
                    Console.WriteLine(module.ModuleName);
                    Modules.Add(module.ModuleName);
                }
            }
            return Modules;
        }

        public ProcessModuleCollection Modules()
        {
            return process.Modules;
        }

        public ProcessModule MainModule()
        {
            return process.MainModule;
        }
        public void SendMessage(uint Msg, int wParam, int lParam)
        {
            PostMessage(winHandle, Msg, wParam, lParam);
        }

        public bool ProcessIsRunning()
        {
            return (Process.GetProcessesByName(processName).Length != 0);
        }

        public bool ProcessIsRunning(string ProcessName)
        {
            return (Process.GetProcessesByName(ProcessName).Length != 0);
        }

        public IntPtr GetBaseAddress()
        {
            if ((Process.GetProcessesByName(processName).Length != 0))
            {
                Process proc = Process.GetProcessesByName(processName).FirstOrDefault();
                return proc.MainModule.BaseAddress;
            }
            else
            {
                if (ShowErrors)
                    Console.WriteLine("Process Module not found");
                if (BreakOnErrors)
                    throw new Exception("Process Module does not exist");
                return (IntPtr)0x0;
            }   //method to read the base address of the attatched program;
        }

        public IntPtr GetBaseAddress(string ModuleName)
        {
            if ((Process.GetProcessesByName(processName).Length != 0))
            {
                Process proc = Process.GetProcessesByName(processName).FirstOrDefault();
                ProcessModuleCollection procColl = process.Modules;
                ProcessModule procModule = null;
                foreach (ProcessModule module in procColl)
                {
                    if (module.ModuleName.Length == ModuleName.Length &&  module.ModuleName == ModuleName)
                    {
                        procModule = module;
                        break;
                    }
                }

                if (procModule != null)
                {
                    return procModule.BaseAddress;
                }
                else
                {
                    if (ShowErrors)
                        Console.WriteLine("Process Module not found");
                    if (BreakOnErrors)
                        throw new Exception("Process Module does not exist");
                    return (IntPtr)0x0;
                }
            }
            else
            {
                if (ShowErrors)
                    Console.WriteLine("Process Not Running");
                if (BreakOnErrors)
                    throw new Exception("Process not running");
                return (IntPtr)0x0;
            }
        }

        #region Conversion
        public  byte[] StructToByteArray(object obj)
        {
            int len = Marshal.SizeOf(obj);
            byte[] arr = new byte[len];
            IntPtr ptr = Marshal.AllocHGlobal(len);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, len);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public dynamic ByteArrayToType(Type type, byte[] data)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Single:
                    return BitConverter.ToSingle(data, 0);
                case TypeCode.Int32:
                    return BitConverter.ToInt32(data, 0);
                case TypeCode.Int64:
                    return BitConverter.ToInt64(data, 0);
                case TypeCode.Int16:
                    return BitConverter.ToInt16(data, 0);
                case TypeCode.Boolean:
                    return BitConverter.ToBoolean(data, 0);
                case TypeCode.Byte:
                    return data[0];
                case TypeCode.Char:
                    return (char)data[0];
                case TypeCode.Double:
                    return BitConverter.ToDouble(data, 0);
                default:
                    throw new NotImplementedException("ReadStructMember: Type not yet implemented - " + type);
            }
        }

        public  T ByteArrayToStructure<T>(byte[] bytes)
        {
            T data;
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
            return data;
        }

        private  T[] ByteArrayToStructureArray<T>(byte[] bytes) where T : struct
        {
            if (bytes.Length % Marshal.SizeOf(typeof(T)) != 0)
                throw new Exception("Byte array does not fit into array of type T");
            int tSize = Marshal.SizeOf(typeof(T));
            T[] arr = new T[bytes.Length / tSize];

            for (int i = 0; i < arr.Length; i++)
            {
                byte[] pbuf = new byte[arr.Length * tSize];
                Buffer.BlockCopy(bytes, i * tSize, pbuf, 0, tSize);
                arr[i] = ByteArrayToStructure<T>(pbuf);
            }
            return arr;
        }

        private  byte[] StructureArrayToByteArray<T>(T[] objs) where T : struct
        {
            int Size = Marshal.SizeOf(objs[0]);
            byte[] buffer = new byte[Size * objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                Buffer.BlockCopy(StructToByteArray(objs[i]),
                    0, buffer, i * Size, Size
                    );
            }
            return buffer;
        }
        #endregion

        #region Reading
        public IntPtr getPointer(IntPtr address, long offset)
        {
            int finalAdress = 0;
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                finalAdress = ReadInt(address) + (int)offset;
            }
            return (IntPtr)(finalAdress);
        }

        public IntPtr getLotsPointer(IntPtr address, IntPtr[] offset)
        {
            int finalAdress = 0;
            if (Process.GetProcessesByName("BlackOpsMP").Length != 0)
            {
                //this.VAM = new VAMemory("PointBlank");
                for (int i = 0; i < offset.Count(); i++)
                {
                    finalAdress = ReadInt(address) + (int)offset[i];
                    address = (IntPtr)finalAdress;
                }
            }
            return (IntPtr)(finalAdress);
        }
        public byte[] ReadByteArray(IntPtr Address, int Length)
        {
            try
            {
                byte[] buffer = new byte[Length];
                int bytesRead = 0;

                ReadProcessMemory(pHandle, Address, buffer, Length, ref bytesRead);
                return buffer;
            }
            catch (Exception e)
            {
                if (ShowErrors)
                    Console.WriteLine(e.ToString());
                if (BreakOnErrors)
                    throw e;
                return new byte[] { 0x0 };
            }
        }

        public IntPtr ReadPointer(string ModuleName, int BaseOffset)
        {
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                IntPtr Base = GetBaseAddress(ModuleName);
                return (IntPtr)((long)Base + BaseOffset);
            }
            else
            {
                return (IntPtr)0x0;
            }
        }


        public IntPtr ReadPointer(string ModuleName, long BaseOffset, long Offset1)
        {
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                IntPtr ModuleBase = GetBaseAddress(ModuleName);
                long BaseAddress = (long)ModuleBase + BaseOffset;
                IntPtr ReadBase = (IntPtr)ReadInt((IntPtr)BaseAddress);
                long FinalAddress = (long)ReadBase + Offset1;
                return (IntPtr)FinalAddress;
            }
            else
            {
                return (IntPtr)0x0;
            }
        }

        public IntPtr ReadPointer(string ModuleName, long BaseOffset, long Offset1, long Offset2)
        {
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                IntPtr ModuleBase = GetBaseAddress(ModuleName);
                long BaseAddress = (long)ModuleBase + BaseOffset;
                IntPtr ReadBase = (IntPtr)ReadInt((IntPtr)BaseAddress);
                long Address1 = (long)ReadBase + Offset1;
                IntPtr Address1Read = (IntPtr)ReadInt((IntPtr)Address1);
                long FinalAddress = (long)Address1Read + Offset2;
                return (IntPtr)FinalAddress;
            }
            else
            {
                return (IntPtr)0x0;
            }
        }

        public IntPtr ReadPointer(long Base, long Offset1)
        {
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                IntPtr ReadBase = (IntPtr)ReadInt((IntPtr)Base);
                long FinalAddress = (long)ReadBase + Offset1;
                return (IntPtr)FinalAddress;
            }
            else
            {
                return (IntPtr)0x0;
            }
        }

        public IntPtr ReadPointer64(string ModuleName, int BaseOffset)
        {
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                IntPtr Base = GetBaseAddress(ModuleName);
                return (IntPtr)((long)Base + BaseOffset);
            }
            else
            {
                return (IntPtr)0x0;
            }
        }

        public IntPtr ReadPointer64(string ModuleName, long BaseOffset, long Offset1)
        {
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                IntPtr ModuleBase = GetBaseAddress(ModuleName);
                long BaseAddress = (long)ModuleBase + BaseOffset;
                IntPtr ReadBase = (IntPtr)ReadLong((IntPtr)BaseAddress);
                long FinalAddress = (long)ReadBase + Offset1;
                return (IntPtr)FinalAddress;
            }
            else
            {
                return (IntPtr)0x0;
            }
        }

        public IntPtr ReadPointer64(string ModuleName, long BaseOffset, long Offset1, long Offset2)
        {
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                IntPtr ModuleBase = GetBaseAddress(ModuleName);
                long BaseAddress = (long)ModuleBase + BaseOffset;
                IntPtr ReadBase = (IntPtr)ReadLong((IntPtr)BaseAddress);
                long Address1 = (long)ReadBase + Offset1;
                IntPtr Address1Read = (IntPtr)ReadLong((IntPtr)Address1);
                long FinalAddress = (long)Address1Read + Offset2;
                return (IntPtr)FinalAddress;
            }
            else
            {
                return (IntPtr)0x0;
            }
        }

        public IntPtr ReadPointer64(long Base, long Offset1)
        {
            if (Process.GetProcessesByName(processName).Length != 0)
            {
                IntPtr ReadBase = (IntPtr)ReadLong((IntPtr)Base);
                long FinalAddress = (long)ReadBase + Offset1;
                return (IntPtr)FinalAddress;
            }
            else
            {
                return (IntPtr)0x0;
            }
        }

        public short ReadShort(IntPtr Address)
        {
            byte[] buffer = ReadByteArray(Address, sizeof(short));
            return BitConverter.ToInt16(buffer, 0);
        }   

        public int ReadInt(IntPtr Address)
        {
            byte[] buffer = ReadByteArray(Address, sizeof(int));
            return BitConverter.ToInt32(buffer, 0);
        }  

        public long ReadLong(IntPtr Address)
        {
            byte[] buffer = ReadByteArray(Address, sizeof(long));
            return BitConverter.ToInt64(buffer, 0);
        }  

        public float ReadFloat(IntPtr Address)
        {

            byte[] buffer = ReadByteArray(Address, sizeof(float));
            return BitConverter.ToSingle(buffer, 0);
        }   

        public double ReadDouble(IntPtr Address)
        {
            byte[] buffer = ReadByteArray(Address, sizeof(double));
            return BitConverter.ToDouble(buffer, 0);
        }

        public bool ReadBool(IntPtr Address)
        {
            byte[] buffer = ReadByteArray(Address, 1);
            return BitConverter.ToBoolean(buffer, 0);
        }       

        public string ReadStringUTF8(IntPtr Address)
        {
            byte[] buffer = ReadByteArray(Address, DefaultStringLength * 2);
            return System.Text.Encoding.UTF8.GetString(buffer).Split('\0')[0];
        }

        public string ReadStringASCII(IntPtr Address)
        {
            byte[] buffer = ReadByteArray(Address, DefaultStringLength);
            return System.Text.Encoding.ASCII.GetString(buffer).Split('\0')[0];
        }

        public string ReadString(IntPtr Address, int Length)
        {

            try
            {
                byte[] buffer = new byte[Length];
                int bytesRead = 0;

                ReadProcessMemory(pHandle, Address, buffer, buffer.Length, ref bytesRead);
                return Encoding.ASCII.GetString(buffer);
            }
            catch (Exception e)
            {
                if (ShowErrors)
                    Console.WriteLine(e.ToString());
                if (BreakOnErrors)
                    throw e;
                return "";
            }
        }   

        public string ReadStringUTF8(IntPtr Address, int Length)
        {
            try
            {
                byte[] buffer = new byte[Length * 2];
                int bytesRead = 0;

                ReadProcessMemory(pHandle, Address, buffer, buffer.Length, ref bytesRead);
                return Encoding.UTF8.GetString(buffer);
            }
            catch (Exception e)
            {
                if (ShowErrors)
                    Console.WriteLine(e.ToString());
                if (BreakOnErrors)
                    throw e;
                return "";
            }
        }   

        public char ReadChar(IntPtr Address)
        {
            try
            {
                return Convert.ToChar(ReadByte(Address));
            }
            catch (Exception e)
            {
                if (ShowErrors)
                    Console.WriteLine(e.ToString());
                if (BreakOnErrors)
                    throw e;
                return '\0';
            }
        }   

        public byte ReadByte(IntPtr Address)
        {
            if ((Process.GetProcessesByName(processName).Length != 0))   //if process is running
            {
                try
                {
                    CheckProcess();
                    byte[] buffer = new byte[1];
                    int bytesRead = 0;

                    ReadProcessMemory(pHandle, Address, buffer, 1, ref bytesRead);
                    byte b = buffer[0];
                    return b;
                }
                catch (Exception e)
                {
                    if (ShowErrors)
                        Console.WriteLine(e.ToString());
                    if (BreakOnErrors)
                        throw e;
                    return 0;
                }
            }
            else
            {
                if (ShowErrors)
                    Console.WriteLine("Process Not Running");
                if (BreakOnErrors)
                    throw new Exception("Process not running");
                return 0x0;
            }
        }   

        public T[] ReadStructArray<T>(IntPtr Address, int Length) where T : struct
        {
            int bSize = Length * Marshal.SizeOf(typeof(T));
            byte[] bytes = ReadByteArray(Address, bSize);
            return ByteArrayToStructureArray<T>(bytes);
        }

        public T ReadStruct<T>(IntPtr Address) where T : struct
        {
            T data = new T();
            byte[] b = ReadByteArray(Address, Marshal.SizeOf(data));
            return ByteArrayToStructure<T>(b);
        }

        public T ReadStruct<T>(IntPtr Address, int index) where T : struct
        {
            T data = new T();
            int size = Marshal.SizeOf(data);
            int offset = index * Marshal.SizeOf(data);
            byte[] b = ReadByteArray(IntPtr.Add(Address, offset), size);
            
            
            return ByteArrayToStructure<T>(b);
        }

        public IntPtr GetStructMemberAddress<TStruct>(IntPtr Address, Expression<Func<TStruct, Object>> expr, int index)
        {
            var memberExpression = (MemberExpression)(((UnaryExpression)expr.Body).Operand);
            int offset = (int)Marshal.OffsetOf<TStruct>(memberExpression.Member.Name);
            int size = Marshal.SizeOf(memberExpression.Type);
            offset += Marshal.SizeOf(memberExpression.Member.ReflectedType) * index;
            return IntPtr.Add(Address, offset);
        }

        public dynamic ReadStructMember<TStruct>(IntPtr Address, Expression<Func<TStruct, Object>> expr)
        {
            var memberExpression = (MemberExpression)(((UnaryExpression)expr.Body).Operand);
            int offset = (int)Marshal.OffsetOf<TStruct>(memberExpression.Member.Name);
            int size = Marshal.SizeOf(memberExpression.Type);

            byte[] data = ReadByteArray(IntPtr.Add(Address, offset), size);
            return ByteArrayToType(memberExpression.Type, data);
        }

        public dynamic ReadStructMember<TStruct>(IntPtr Address, Expression<Func<TStruct, Object>> expr, int index)
        {
            var memberExpression = (MemberExpression)(((UnaryExpression)expr.Body).Operand);
            int offset = (int)Marshal.OffsetOf<TStruct>(memberExpression.Member.Name);
            int size = Marshal.SizeOf(memberExpression.Type);
            offset += Marshal.SizeOf(memberExpression.Member.ReflectedType) * index;

            byte[] data = ReadByteArray(IntPtr.Add(Address, offset), size);
            return ByteArrayToType(memberExpression.Type, data);
        }
        #endregion

        #region Writing
        public void WriteByteArray(IntPtr Address, byte[] Bytes)
        {
            try
            {
                //if (doRestore && !ChangedAddresses.Contains(Address))
                //{
                //    ChangedAddresses.Add(Address);
                //    OriginalBytes.Add(ReadByteArray(Address, Bytes.Length));
                //}
                int bytesWritten = 0;
                if(ProcessIsRunning())
                    WriteProcessMemory(pHandle, Address, Bytes, Bytes.Length, ref bytesWritten);

            }
            catch (Exception e)
            {
                if (ShowErrors)
                    Console.WriteLine(e.ToString());
                if (BreakOnErrors)
                    throw e;
            }
        }

        public void WriteByteArray(IntPtr Address, string bytes)
        {
            try
            {
                string[] splitted = bytes.Split(' ');
                byte[] bytesToWrite = new byte[splitted.Length];
                for (int i = 0; i < splitted.Length; i++)
                {
                    bytesToWrite[i] = byte.Parse(splitted[i], System.Globalization.NumberStyles.HexNumber);
                }
                int bytesWritten = 0;
                if (ProcessIsRunning())
                    WriteProcessMemory(pHandle, Address, bytesToWrite, bytesToWrite.Length, ref bytesWritten);

            }
            catch (Exception e)
            {
                if (ShowErrors)
                    Console.WriteLine(e.ToString());
                if (BreakOnErrors)
                    throw e;
            }
        }

        public void WriteByteArray(IntPtr Address, byte[] Bytes, bool removeProtection)
        {
            if ((Process.GetProcessesByName(processName).Length != 0))
            {
                try
                {
                    if (doRestore && !ChangedAddresses.Contains(Address))
                    {
                        ChangedAddresses.Add(Address);
                        OriginalBytes.Add(ReadByteArray(Address, Bytes.Length));
                    }

                    int bytesWritten = 0;
                    uint lpflOldProtect = (uint)VirtualMemoryProtection.PAGE_EXECUTE_READWRITE;

                    if(removeProtection)
                        VirtualProtectEx(pHandle, (IntPtr)Address, (UIntPtr)((ulong)Bytes.Length), (uint)VirtualMemoryProtection.PAGE_EXECUTE_READWRITE, out lpflOldProtect);

                    WriteProcessMemory(pHandle, Address, Bytes, Bytes.Length, ref bytesWritten);

                    if(removeProtection)
                     VirtualProtectEx(pHandle, (IntPtr)Address, (UIntPtr)((ulong)Bytes.Length), lpflOldProtect, out lpflOldProtect);

                }
                catch (Exception e)
                {
                    if (ShowErrors)
                        Console.WriteLine(e.ToString());
                    if (BreakOnErrors)
                        throw e;
                }
            }
            else
            {
                if (ShowErrors)
                    Console.WriteLine("Process Not Running");
                if (BreakOnErrors)
                    throw new Exception("Process not running");
            }
        }

        public void WriteGen(IntPtr Address, object Value)
        {
            if(Value is byte)
            {
                WriteByte(Address, (byte)Value);
            }
            else
            {
                var bytes = typeof(BitConverter).GetMethod("GetBytes", new Type[] { Value.GetType() }).Invoke(null, new object[] { Value });
                WriteByteArray(Address, (byte[])bytes);
            }
        }

        public void WriteShort(IntPtr Address, short Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            WriteByteArray(Address, bytes);
        }

        public void WriteByte(IntPtr Address, byte Value)
        {
            byte[] bytes = new byte[1] { Value };
            WriteByteArray(Address, bytes);
        }

        public void WriteByte(IntPtr[] Address, byte Value)
        {
            byte[] bytes = new byte[1] { Value };
            foreach(IntPtr a in Address)
            {
                WriteByteArray(a, bytes);
            }
        }

        public void WriteInt(IntPtr Address, int Value)
        {
            CheckProcess();
            byte[] bytes = BitConverter.GetBytes(Value);
            WriteByteArray(Address, bytes);
        }

        public void WriteLong(IntPtr Address, long Value)
        {
            CheckProcess();
            byte[] bytes = BitConverter.GetBytes(Value);
            WriteByteArray(Address, bytes);
        }

        public void WriteFloat(IntPtr Address, float Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            WriteByteArray(Address, bytes);
        }
        public void WriteFloat(IntPtr Address, float Value, bool protection)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            WriteByteArray(Address, bytes, protection);
        }

        public void WriteDouble(IntPtr Address, double Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            WriteByteArray(Address, bytes, true);
        }

        public void WriteStringASCII(IntPtr Address, string Value)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(Value);
            WriteByteArray(Address, bytes);
        }

        public void WriteChar(IntPtr Address, char Character)
        {
            byte[] bytes = BitConverter.GetBytes(Character);
            WriteByteArray(Address, bytes);
        }

        public void WriteBoolean(IntPtr Address, bool Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            WriteByteArray(Address, bytes);
        }

        public void WriteStruct(IntPtr Address, object structure)
        {
            byte[] b = StructToByteArray(structure);
            WriteByteArray(Address, b);
        }

        public void WriteStructArray<T>(IntPtr address, T[] structs) where T : struct
        {
            byte[] b = StructureArrayToByteArray(structs);
            WriteByteArray(address, b);
        }

        public void WriteStructMember<TStruct>(IntPtr Address, Expression<Func<TStruct, Object>> expr, object Value)
        {

            var memberExpression = (MemberExpression)(((UnaryExpression)expr.Body).Operand);
            int offset = (int)Marshal.OffsetOf<TStruct>(memberExpression.Member.Name);
            int size = Marshal.SizeOf(memberExpression.Type);
            byte[] data = StructToByteArray(Value);
            if (data.Length == size)
            {
                WriteByteArray(IntPtr.Add(Address, offset), data);
            }
        }

        public void WriteStructMember<TStruct>(IntPtr Address, Expression<Func<TStruct, Object>> expr, int index, object Value)
        {
            var memberExpression = (MemberExpression)(((UnaryExpression)expr.Body).Operand);
            int offset = (int)Marshal.OffsetOf<TStruct>(memberExpression.Member.Name);
            int size = Marshal.SizeOf(memberExpression.Type);
            int structSize = Marshal.SizeOf(memberExpression.Member.ReflectedType);
            offset += index * structSize;

            byte[] data = StructToByteArray(Value);
            if (data.Length == size)
            {
                WriteByteArray(IntPtr.Add(Address, offset), data);
            }
        }
            #endregion

            #region Misc
            public bool InjectDLL(string dllPath)
        {
            // privileges
            try
            {
                const int PROCESS_CREATE_THREAD = 0x0002;
                const int PROCESS_QUERY_INFORMATION = 0x0400;
                const int PROCESS_VM_OPERATION = 0x0008;
                const int PROCESS_VM_WRITE = 0x0020;
                const int PROCESS_VM_READ = 0x0010;

                Process targetProcess = Process.GetProcessesByName(processName)[0];

                // geting the handle of the process - with required privileges
                IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);

                // searching for the address of LoadLibraryA and storing it in a pointer
                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                // name of the dll we want to inject

                // alocating some memory on the target process - enough to store the name of the dll
                // and storing its address in a pointer
                IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))), AllocationType.Commit | AllocationType.Reserve, VirtualMemoryProtection.PAGE_READWRITE);

                // writing the name of the dll there
                int bytesWritten = 0;
                WriteProcessMemory((IntPtr)procHandle, allocMemAddress, Encoding.Default.GetBytes(dllPath), (int)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))), ref bytesWritten);

                // creating a thread that will call LoadLibraryA with allocMemAddress as argument
                CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IntPtr AllocateMemory(uint dwSize)
        {
            return VirtualAllocEx(pHandle, IntPtr.Zero, dwSize, AllocationType.Commit | AllocationType.Reserve, VirtualMemoryProtection.PAGE_READWRITE);
        }

        public void NOP(IntPtr Address, int NumberofBytes)
        {
            List<byte> NopCodes = new List<byte> { };
            for (int i = 0; i < NumberofBytes; i++)
            {
                NopCodes.Add(0x90);
            }
            byte[] nop = NopCodes.ToArray();
            WriteByteArray(Address, nop, true);
        }
        #endregion

        #region Restore Function (I Recommend not to use)
        public void Restore(IntPtr Address)
        {
            if (ChangedAddresses.Contains(Address))
            {
                WriteByteArray(Address, OriginalBytes[ChangedAddresses.IndexOf(Address)]);
                OriginalBytes.RemoveAt(ChangedAddresses.IndexOf(Address));
                ChangedAddresses.RemoveAt(ChangedAddresses.IndexOf(Address));
            }
        }

        public void RestoreAll()
        {
            foreach (IntPtr Address in ChangedAddresses)
            {
                WriteByteArray(Address, OriginalBytes[ChangedAddresses.IndexOf(Address)]);
            }
            OriginalBytes = new List<byte[]> { };
            ChangedAddresses = new List<IntPtr> { };
        }
        #endregion

    }


    //Stole and modified this code from here: https://www.unknowncheats.me/forum/c-/215248-sigscansharp-fast-pattern-finder-individual-parallel.html
    class SigScanSharp
    {
        public IntPtr g_hProcess { get; set; }
        public byte[] g_arrModuleBuffer { get; set; }
        public ulong g_lpModuleBase { get; set; }
        public ulong offset = 0;
        public Dictionary<string, string> g_dictStringPatterns { get; }

        public SigScanSharp(IntPtr hProc)
        {
            g_hProcess = hProc;
            g_dictStringPatterns = new Dictionary<string, string>();
        }

        public bool SelectModule(ProcessModule targetModule)
        {
            g_lpModuleBase = (ulong)targetModule.BaseAddress;
            g_arrModuleBuffer = new byte[targetModule.ModuleMemorySize];
            
            g_dictStringPatterns.Clear();

            return Win32.ReadProcessMemory(g_hProcess, g_lpModuleBase, g_arrModuleBuffer, targetModule.ModuleMemorySize);
        }

        public void AddPattern(string szPatternName, string szPattern)
        {
            g_dictStringPatterns.Add(szPatternName, szPattern);
        }

        private bool PatternCheck(int nOffset, byte[] arrPattern)
        {
            for (int i = 0; i < arrPattern.Length; i++)
            {
                if (arrPattern[i] == 0x0)
                {
                    continue;
                }

                if (arrPattern[i] != this.g_arrModuleBuffer[nOffset + i])
                    return false;
            }

            return true;
        }

        public IntPtr FindPattern(string szPattern)
        {
            if (g_arrModuleBuffer == null || g_lpModuleBase == 0)
                throw new Exception("Selected module is null");

            Stopwatch stopwatch = Stopwatch.StartNew();

            byte[] arrPattern = ParsePatternString(szPattern);

            for (int nModuleIndex = 0; nModuleIndex < g_arrModuleBuffer.Length; nModuleIndex++)
            {
                if (this.g_arrModuleBuffer[nModuleIndex] != arrPattern[0])
                    continue;

                if (PatternCheck(nModuleIndex, arrPattern))
                {
                    return (IntPtr)(g_lpModuleBase + (ulong)nModuleIndex + offset);
                }
            }
            return IntPtr.Zero;
        }

        public Dictionary<string, ulong> FindPatterns()
        {
            if (g_arrModuleBuffer == null || g_lpModuleBase == 0)
                throw new Exception("Selected module is null");

            Stopwatch stopwatch = Stopwatch.StartNew();

            byte[][] arrBytePatterns = new byte[g_dictStringPatterns.Count][];
            ulong[] arrResult = new ulong[g_dictStringPatterns.Count];

            // PARSE PATTERNS
            for (int nIndex = 0; nIndex < g_dictStringPatterns.Count; nIndex++)
                arrBytePatterns[nIndex] = ParsePatternString(g_dictStringPatterns.ElementAt(nIndex).Value);

            // SCAN FOR PATTERNS
            for (int nModuleIndex = 0; nModuleIndex < g_arrModuleBuffer.Length; nModuleIndex++)
            {
                for (int nPatternIndex = 0; nPatternIndex < arrBytePatterns.Length; nPatternIndex++)
                {
                    if (arrResult[nPatternIndex] != 0)
                        continue;

                    if (this.PatternCheck(nModuleIndex, arrBytePatterns[nPatternIndex]))
                        arrResult[nPatternIndex] = g_lpModuleBase + (ulong)nModuleIndex;
                }
            }

            Dictionary<string, ulong> dictResultFormatted = new Dictionary<string, ulong>();

            // FORMAT PATTERNS
            for (int nPatternIndex = 0; nPatternIndex < arrBytePatterns.Length; nPatternIndex++)
                dictResultFormatted[g_dictStringPatterns.ElementAt(nPatternIndex).Key] = arrResult[nPatternIndex];

            return dictResultFormatted;
        }

        private byte[] ParsePatternString(string szPattern)
        {
            List<byte> patternbytes = new List<byte>();

            foreach (var szByte in szPattern.Split(' '))
                patternbytes.Add((szByte == "?" || szByte == "!") ? (byte)0x0 : Convert.ToByte(szByte, 16));

            string[] split = szPattern.Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] == "!")
                {
                    offset = (ulong)i;
                    break;
                }

            }

            return patternbytes.ToArray();
        }

        private static class Win32
        {
            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(IntPtr hProcess, ulong lpBaseAddress, byte[] lpBuffer, int dwSize, int lpNumberOfBytesRead = 0);
        }
    }
}
