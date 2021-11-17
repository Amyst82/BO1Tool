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
        #region initialization
        private static List<dvar_s> dvarList2 = new List<dvar_s>();
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

        public static async void initDvarList()
        {
            await Task.Run(() =>
            {
                IntPtr dvarBase = Addresses.dvarBase;
                List<addressesList> dvarList = MemoryHelper.mem.ReadStructArray<addressesList>(dvarBase, 3150).ToList();
                foreach(addressesList a in dvarList)
                {
                    dvarList2.Add(new dvar_s(a.addy));
                }
            });
        }
        #endregion

        #region public methods
        public static dvar_s getDvarByName(string name)
        {
            dvar_s res = dvarList2.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            res?.getValues();
            return res;
        }
        public static void setDvarValueByName(string name, object value)
        {
            if (MemoryHelper.initizlized)
            {
                if (dvarList2.Count > 0)
                {
                    dvarList2.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault().Value = value;
                    dvarList2.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault().Modified = true;
                }
            }
        }
        #endregion
    }
    public class dvar_s
    {
        #region structs
        private enum dvar_Types
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

        private struct dvarVec2
        {
            public float x, y;

            public override string ToString()
            {
                string res = $"{x} {y}";
                return res;
            }
        }
        private struct dvarVec3
        {
            public float x, y, z;
            public override string ToString()
            {
                string res = $"{x} {y} {z}";
                return res;
            }
        }
        private struct dvarVec4
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

        public IntPtr Address;
        private string name; //0x00
        private string desc;
        private int hash;
        private int flags;
        private int dvarType;
        public string dvarTypeString; //is used for representing type enum value readable as string
        private bool modified;
        private object currentValue = (byte)0;
        public object defaultValue;
        private object minValue;
        private object maxValue;

        #endregion

        #region offsets
        private int descOffset = 0x04;
        private int hashOffset = 0x08;
        private int flagsOffset = 0x0C;
        private int typeOffset = 0x10;
        private int modifiedOffset = 0x14;
        private int valueOffset = 0x18;
        private int defaultValueOffset = 0x38;
        private int minOffset = 0x58;
        private int maxOffset = 0x5C;
        #endregion

        private IntPtr dvarBase = Addresses.dvarBase; //this is for me
        public dvar_s(IntPtr address) //class init method
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.winHandle != IntPtr.Zero)
            {
                Address = address;
                name = getText(Address, 0x00);
                desc = getText(Address, descOffset);
                hash = MemoryHelper.mem.ReadInt(Address + hashOffset); //hash (idk what is used for but lets keep it :D)
                flags = MemoryHelper.mem.ReadInt(Address + flagsOffset); //flags (DVAR_CHEAT, DVAR_EXTERNAL and etc. but i got no enum for it)
                dvarType = MemoryHelper.mem.ReadInt(Address + typeOffset); //dvar type value of types enum
                dvarTypeString = ((dvar_Types)dvarType).ToString(); //representing type value from enum as string
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
                IntPtr dvarDescAddy = (IntPtr)MemoryHelper.mem.ReadInt(Address + descOffset);
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
                MemoryHelper.mem.WriteInt(Address + hashOffset, value);
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
                MemoryHelper.mem.WriteInt(Address + flagsOffset, value);
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
                MemoryHelper.mem.WriteInt(Address + typeOffset, value);
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
                MemoryHelper.mem.WriteBoolean(Address + modifiedOffset, value);
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
                            MemoryHelper.mem.WriteByte(Address + valueOffset, (byte)value);
                        }
                        else if(value is Boolean)
                        {
                            MemoryHelper.mem.WriteBoolean(Address + valueOffset, (bool)value);
                        }
                        break;
                    case "FLOAT":
                        MemoryHelper.mem.WriteFloat(Address + valueOffset, (float)value);
                        break;
                    case "INT":
                        MemoryHelper.mem.WriteInt(Address + valueOffset, (int)value);
                        break;
                    case "ENUM":
                        MemoryHelper.mem.WriteByte(Address + valueOffset, (byte)value);
                        break;
                    case "FLOAT_2":
                        MemoryHelper.mem.WriteStruct(Address + valueOffset, (dvarVec2)value);
                        break;
                    case "FLOAT_3":
                        MemoryHelper.mem.WriteStruct(Address + valueOffset, (dvarVec3)value);
                        break;
                    case "FLOAT3":
                        MemoryHelper.mem.WriteStruct(Address + valueOffset, (dvarVec3)value);
                        break;
                    case "FLOAT3_":
                        MemoryHelper.mem.WriteStruct(Address + valueOffset, (dvarVec3)value);
                        break;
                    case "FLOAT_4":
                        MemoryHelper.mem.WriteStruct(Address + valueOffset, (dvarVec4)value);
                        break;
                    case "COLOR":
                        MemoryHelper.mem.WriteStruct(Address+valueOffset, (dvarColor)value);
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
                currentValue = (byte)MemoryHelper.mem.ReadByte(Address + valueOffset);
                minValue = (byte)0;
                maxValue = (byte)1;
                defaultValue = MemoryHelper.mem.ReadByte(Address + defaultValueOffset);
            }
            if (dvarType == 1)
            {
                currentValue = (float)MemoryHelper.mem.ReadFloat(Address + valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + maxOffset);
                defaultValue = (float)MemoryHelper.mem.ReadFloat(Address + defaultValueOffset);
            }
            else if (dvarType == 2)
            {
                currentValue = MemoryHelper.mem.ReadStruct<dvarVec2>(Address + valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + maxOffset);
                defaultValue = MemoryHelper.mem.ReadStruct<dvarVec2>(Address + defaultValueOffset);
            }
            else if (dvarType == 3 || dvarType == 10 || dvarType == 11)
            {
                currentValue = MemoryHelper.mem.ReadStruct<dvarVec3>(Address + valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + maxOffset);
                defaultValue = MemoryHelper.mem.ReadStruct<dvarVec3>(Address + defaultValueOffset);
            }
            else if (dvarType == 4)
            {
                currentValue = MemoryHelper.mem.ReadStruct<dvarVec4>(Address + valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + maxOffset);
                defaultValue = MemoryHelper.mem.ReadStruct<dvarVec4>(Address + defaultValueOffset);
            }
            else if (dvarType == 5)
            {
                currentValue = (int)MemoryHelper.mem.ReadInt(Address + valueOffset);
                minValue = (int)MemoryHelper.mem.ReadInt(Address + minOffset);
                maxValue = (int)MemoryHelper.mem.ReadInt(Address + maxOffset);
                defaultValue = (int)MemoryHelper.mem.ReadInt(Address + defaultValueOffset);
            }
            else if (dvarType == 6)
            {
                currentValue = (byte)MemoryHelper.mem.ReadByte(Address + valueOffset);
                defaultValue = MemoryHelper.mem.ReadByte(Address + defaultValueOffset);
            }

            else if (dvarType == 8)
            {
                currentValue = MemoryHelper.mem.ReadStruct<dvarColor>(Address + valueOffset);
                minValue = (float)MemoryHelper.mem.ReadFloat(Address + minOffset);
                maxValue = (float)MemoryHelper.mem.ReadFloat(Address + maxOffset);
                defaultValue = MemoryHelper.mem.ReadStruct<dvarColor>(Address + defaultValueOffset);
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
