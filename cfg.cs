using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using MessageBox = System.Windows.Forms.MessageBox;

namespace bo1tool
{
    public static class cfg
    {
        #region Mem Functions & Defines
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [Flags]
        public enum FreeType
        {
            Decommit = 0x4000,
            Release = 0x8000,
        }

        [Flags]
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

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, FreeType dwFreeType);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        private static byte[] cbuf_addtext_wrapper =
        {
        0x55,
        0x8B, 0xEC,
        0x83, 0xEC, 0x8,
        0xC7, 0x45, 0xF8, 0x0, 0x0, 0x0, 0x0,
        0xC7, 0x45, 0xFC, 0x0, 0x0, 0x0, 0x0,
        0xFF, 0x75, 0xF8,
        0x6A, 0x0,
        0xFF, 0x55, 0xFC,
        0x83, 0xC4, 0x8,
        0x8B, 0xE5,
        0x5D,
        0xC3
        };

        #endregion
        private static byte[] callbytes;
        private static IntPtr cbuf_addtext_alloc = IntPtr.Zero;
        private static byte[] commandbytes;
        private static IntPtr commandaddress;
        public static void Send(string command)
        {
            try
            {
                callbytes = BitConverter.GetBytes((uint)Addresses.cbuf_address);
                if (command == "")
                {

                }
                else
                {
                    if (cbuf_addtext_alloc == IntPtr.Zero)
                    {
                        cbuf_addtext_alloc = VirtualAllocEx(MemoryHelper.mem.process.Handle, IntPtr.Zero, (IntPtr)cbuf_addtext_wrapper.Length, AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ExecuteReadWrite);
                        commandbytes = System.Text.Encoding.ASCII.GetBytes(command);
                        commandaddress = VirtualAllocEx(MemoryHelper.mem.process.Handle, IntPtr.Zero, (IntPtr)(commandbytes.Length), AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ExecuteReadWrite);
                        int bytesWritten = 0;
                        int bytesWritten2 = commandbytes.Length;
                        WriteProcessMemory(MemoryHelper.mem.process.Handle, commandaddress, commandbytes, commandbytes.Length, out bytesWritten2);

                        Array.Copy(BitConverter.GetBytes(commandaddress.ToInt64()), 0, cbuf_addtext_wrapper, 9, 4);
                        Array.Copy(callbytes, 0, cbuf_addtext_wrapper, 16, 4);

                        WriteProcessMemory(MemoryHelper.mem.process.Handle, cbuf_addtext_alloc, cbuf_addtext_wrapper, cbuf_addtext_wrapper.Length, out bytesWritten);

                        IntPtr bytesOut;
                        CreateRemoteThread(MemoryHelper.mem.process.Handle, IntPtr.Zero, 0, cbuf_addtext_alloc, IntPtr.Zero, 0, out bytesOut);

                        if (cbuf_addtext_alloc != IntPtr.Zero && commandaddress != IntPtr.Zero)
                        {
                            VirtualFreeEx(MemoryHelper.mem.process.Handle, cbuf_addtext_alloc, cbuf_addtext_wrapper.Length, FreeType.Release);
                            VirtualFreeEx(MemoryHelper.mem.process.Handle, commandaddress, cbuf_addtext_wrapper.Length, FreeType.Release);
                        }
                        //Console.WriteLine("Cbuf_Addtext alloc = " + cbuf_addtext_alloc.ToString("X"));
                    }
                    cbuf_addtext_alloc = IntPtr.Zero;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static string loadCfg()
        {
            OpenFileDialog loadCFG = new OpenFileDialog();
            loadCFG.Filter = "Config file(*.cfg)|*.cfg|All files(*.*)|*.*";
            DialogResult result = loadCFG.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamReader fileReader = new StreamReader(loadCFG.OpenFile());
                return fileReader.ReadToEnd();
            }
            return "";
        }

        public static void saveCfg(string cfg)
        {
            SaveFileDialog saveCFG = new SaveFileDialog();
            saveCFG.Filter = "Config file(*.cfg)|*.cfg|All files(*.*)|*.*";
            DialogResult result = saveCFG.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamWriter fileWriter = new StreamWriter(saveCFG.OpenFile());
                fileWriter.Write(cfg);
                fileWriter.Close();
            }    
        }

        public static void updateDvarFromSlider(Slider slider)
        {
            dvars.setDvarValueByName(slider.Name, (float)slider.Value);
        }

        public static void resetFromDC(IntPtr address)
        {
            byte[] defaultValue = new byte[16];
            defaultValue = MemoryHelper.mem.ReadByteArray(address+0x20, 16);
            MemoryHelper.mem.WriteByteArray(address, defaultValue);
        }

        public static void setCfgBoxText(System.Windows.Controls.RichTextBox textBox, string text)
        {
            textBox.Document.Blocks.Clear();
            textBox.Document.Blocks.Add(new Paragraph(new Run(text)));
        }
        public static void appendCfgBoxText(System.Windows.Controls.RichTextBox textBox, string text)
        {
            textBox.Document.Blocks.Add(new Paragraph(new Run(text)));
        }
    }//
}
