using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace bo1tool
{
    public static class dvars
    {
        #region offsets
        public static int descOffset = 0x04;
        public static int hashOffset = 0x08;
        public static int flagsOffset = 0x0C;
        public static int typeOffset = 0x10;
        public static int modifiedOffset = 0x14;
        public static int valueOffset = 0x18;
        public static int defaultValueOffset = 0x38;
        public static int minOffset = 0x58;
        public static int maxOffset = 0x5C;
        #endregion

        #region structs
        public enum dvar_Types
        {
            BOOL, //0
            FLOAT, //1
            FLOAT_2, //2
            FLOAT_3, //3
            FLOAT_4, //4
            INT, //5
            ENUM,  //6
            STRING, //7
            COLOR, //8
            DEVTWEAK, //9
            FLOAT3, //10
            FLOAT3_ //11
        }

        public struct dvarVec2
        {
            public float x, y;

            public override string ToString()
            {
                string res = $"{x} {y}";
                return res;
            }
        }
        public struct dvarVec3
        {
            public float x, y, z;
            public override string ToString()
            {
                string res = $"{x} {y} {z}";
                return res;
            }
        }
        public struct dvarVec4
        {
            public float x, y, z, w;
            public override string ToString()
            {
                string res = $"{x} {y} {z} {w}";
                return res;
            }
        }
        public struct dvarColor
        {
            public byte r, g, b, a;
            public override string ToString()
            {
                string res = $"R: {r} G: {g} B: {b} A: {a}";
                return res;
            }
        }
        #endregion

        #region initialization
        private static Dictionary<string, IntPtr> dvarList = new Dictionary<string, IntPtr>();
        private static string getText(IntPtr address, int offset)
        {
            string res = "";
            IntPtr ptr = (IntPtr)MemoryHelper.mem.ReadInt(address + offset); //pointer to a name or description
            res = MemoryHelper.mem.ReadString(ptr, 256).Split('\0')[0]; //get string til the first new line mark
            return res;
        }

        public struct addressesList
        {
           public IntPtr addy;
        }

        ///<summary>
        ///Initializer. Recommended to call once on application boot up or reload.
        ///</summary>
        public static async void initDvarList()
        {
            await Task.Run(() =>
            {
                IntPtr dvarBase = Addresses.dvarBase;
                List<addressesList> dvarList_ = MemoryHelper.mem.ReadStructArray<addressesList>(dvarBase, 3150).ToList();
                dvarList.Clear();
                foreach (addressesList a in dvarList_)
                {
                    if(a.addy != IntPtr.Zero)
                        dvarList.Add(getText(a.addy, 0x00).ToLower(), a.addy);
                }
            });
        }
        #endregion

        #region public methods
        ///<summary>
        ///Returns an instance of dvar_s class.
        ///</summary>
        public static dvar_s getDvarByName(string name)
        {
            try
            {
                dvar_s res = new dvar_s(dvarList[name.ToLower()]);
                res?.getValues();
                return res;
            }
            catch
            { 

            }
            return null;
        }

        ///<summary>
        ///Returns the address of a certain dvar.
        ///</summary>
        public static IntPtr getDvarAddressByName(string name)
        {
            return dvarList[name.ToLower()];
        }

        public static float getDvarValueByName(string name)
        {
            return MemoryHelper.mem.ReadFloat(getDvarAddressByName(name.ToLower()));
        }

        ///<summary>
        ///Fast one because it doesn't create an instance of dvar_s, it just writes to an address directly.
        ///</summary>
        public static void setDvarValueByName(string name, object value)
        {
            if (MemoryHelper.initizlized)
            {
                if (dvarList.Count > 0)
                {
                    setDvar(dvarList[name.ToLower()], value);
                    MemoryHelper.mem.WriteBoolean(dvarList[name.ToLower()] + modifiedOffset, true);

                }
            }
        }

        static void setDvar(IntPtr Address, object value)
        {
            if (value is byte)
                MemoryHelper.mem.WriteByte(Address + valueOffset, (byte)value);
            if (value is Boolean)
                MemoryHelper.mem.WriteBoolean(Address + valueOffset, (bool)value);
            if (value is float)
                MemoryHelper.mem.WriteFloat(Address + dvars.valueOffset, (float)value);
            if (value is int)
                MemoryHelper.mem.WriteInt(Address + dvars.valueOffset, (int)value);
            if (value is dvarVec2)
                MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvarVec2)value);
            if (value is dvarVec3)
                MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvarVec3)value);
            if (value is dvarVec4)
                MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvarVec4)value);
            if (value is dvarColor)
                MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvarColor)value);

        }
        #endregion
    }
    public class dvar_s
    {
        #region structs
        
        public IntPtr Address;
        private string name; //0x00
        private string desc;
        private int hash;
        private int flags;
        private int dvarType;
        public string dvarTypeString; //is used for representing type enum value readable as string
        private bool modified;
        private object currentValue;
        public object defaultValue;
        private object minValue;
        private object maxValue;

        #endregion

        private IntPtr dvarBase = Addresses.dvarBase; //this is for me
        public dvar_s(IntPtr address) //class init method
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.winHandle != IntPtr.Zero)
            {
                Address = address;
                name = getText(Address, 0x00);
                desc = getText(Address, dvars.descOffset);
                hash = MemoryHelper.mem.ReadInt(Address + dvars.hashOffset); //hash (idk what is used for but lets keep it :D)
                flags = MemoryHelper.mem.ReadInt(Address + dvars.flagsOffset); //flags (DVAR_CHEAT, DVAR_EXTERNAL and etc. but i got no enum for it)
                dvarType = MemoryHelper.mem.ReadInt(Address + dvars.typeOffset); //dvar type value of types enum
                dvarTypeString = ((dvars.dvar_Types)dvarType).ToString(); //representing type value from enum as string
            }
        }
        #region properties
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                IntPtr dvarNameAddy = (IntPtr)MemoryHelper.mem.ReadInt(Address);
                MemoryHelper.mem.WriteStringASCII(dvarNameAddy, name);
            }
        }
        public string Description
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
                IntPtr dvarDescAddy = (IntPtr)MemoryHelper.mem.ReadInt(Address + dvars.descOffset);
                MemoryHelper.mem.WriteStringASCII(dvarDescAddy, desc);
            }
        }
        public int Hash
        {
            get
            {
                return hash;
            }
            set
            {
                hash = value;
                MemoryHelper.mem.WriteInt(Address + dvars.hashOffset, value);
            }
        }
        public int Flags
        {
            get
            {
                return flags;
            }
            set
            {
                flags = value;
                MemoryHelper.mem.WriteInt(Address + dvars.flagsOffset, value);
            }
        }
        public int Type
        {
            get
            {
                return dvarType;
            }
            set
            {
                dvarType = value;
                MemoryHelper.mem.WriteInt(Address + dvars.typeOffset, value);
            }
        }
        public bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                MemoryHelper.mem.WriteBoolean(Address + dvars.modifiedOffset, value);
            }
        }

        public object Value
        {
            get
            {
                getValues();
                return currentValue;
            }
            set
            {
                currentValue = value;
                
                switch (dvarTypeString)
                {
                    case "BOOL":
                        if(value is byte)
                        {
                            MemoryHelper.mem.WriteByte(Address + dvars.valueOffset, (byte)value);
                        }
                        else if(value is Boolean)
                        {
                            MemoryHelper.mem.WriteBoolean(Address + dvars.valueOffset, (bool)value);
                        }
                        break;
                    case "FLOAT":
                        MemoryHelper.mem.WriteFloat(Address + dvars.valueOffset, (float)value);
                        break;
                    case "INT":
                        MemoryHelper.mem.WriteInt(Address + dvars.valueOffset, (int)value);
                        break;
                    case "ENUM":
                        MemoryHelper.mem.WriteByte(Address + dvars.valueOffset, (byte)value);
                        break;
                    case "FLOAT_2":
                        MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvars.dvarVec2)value);
                        break;
                    case "FLOAT_3":
                        MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvars.dvarVec3)value);
                        break;
                    case "FLOAT3":
                        MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvars.dvarVec3)value);
                        break;
                    case "FLOAT3_":
                        MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvars.dvarVec3)value);
                        break;
                    case "FLOAT_4":
                        MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvars.dvarVec4)value);
                        break;
                    case "COLOR":
                        MemoryHelper.mem.WriteStruct(Address + dvars.valueOffset, (dvars.dvarColor)value);
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
        #region methods
        public void getValues()
        {
            if (dvarType == 0)
            {
                currentValue = (byte)MemoryHelper.mem.ReadByte(Address + dvars.valueOffset);
                minValue = (byte)0;
                maxValue = (byte)1;
                defaultValue = MemoryHelper.mem.ReadByte(Address + dvars.defaultValueOffset);
            }
            if (dvarType == 1)
            {
                currentValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.maxOffset);
                defaultValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.defaultValueOffset);
            }
            else if (dvarType == 2)
            {
                currentValue = MemoryHelper.mem.ReadStruct<dvars.dvarVec2>(Address + dvars.valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.maxOffset);
                defaultValue = MemoryHelper.mem.ReadStruct<dvars.dvarVec2>(Address + dvars.defaultValueOffset);
            }
            else if (dvarType == 3 || dvarType == 10 || dvarType == 11)
            {
                currentValue = MemoryHelper.mem.ReadStruct<dvars.dvarVec3>(Address + dvars.valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.maxOffset);
                defaultValue = MemoryHelper.mem.ReadStruct<dvars.dvarVec3>(Address + dvars.defaultValueOffset);
            }
            else if (dvarType == 4)
            {
                currentValue = MemoryHelper.mem.ReadStruct<dvars.dvarVec4>(Address + dvars.valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.maxOffset);
                defaultValue = MemoryHelper.mem.ReadStruct<dvars.dvarVec4>(Address + dvars.defaultValueOffset);
            }
            else if (dvarType == 5)
            {
                currentValue = (int)MemoryHelper.mem.ReadInt(Address + dvars.valueOffset);
                minValue = (int)MemoryHelper.mem.ReadInt(Address + dvars.minOffset);
                maxValue = (int)MemoryHelper.mem.ReadInt(Address + dvars.maxOffset);
                defaultValue = (int)MemoryHelper.mem.ReadInt(Address + dvars.defaultValueOffset);
            }
            else if (dvarType == 6)
            {
                currentValue = (byte)MemoryHelper.mem.ReadByte(Address + dvars.valueOffset);
                defaultValue = MemoryHelper.mem.ReadByte(Address + dvars.defaultValueOffset);
            }

            else if (dvarType == 8)
            {
                currentValue = MemoryHelper.mem.ReadStruct<dvars.dvarColor>(Address + dvars.valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + dvars.maxOffset);
                defaultValue = MemoryHelper.mem.ReadStruct<dvars.dvarColor>(Address + dvars.defaultValueOffset);
            }
        }
        private string getText(IntPtr address, int offset)
        {
            string res = "";
            IntPtr ptr = (IntPtr)MemoryHelper.mem.ReadInt(address + offset); //pointer to a name or description
            res = MemoryHelper.mem.ReadString(ptr, 256).Split('\0')[0]; //get string til the first new line mark
            return res;
        }
        public void Reset()
        {
            getValues();
            currentValue = defaultValue;
            Value = defaultValue;
            modified = true;
        }

        public string getDvarAddress()
        {
            IntPtr sub = (IntPtr)((uint)Address - (uint)Addresses.BaseAddress); //getting address without the proc name
            string res = "BlackOpsMP.exe + " + sub.ToInt32().ToString("X"); //returning string like procName.exe + offset
            return res;
        }
        #endregion
    }//
}
