using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bo1tool
{
    class Address
    {
        public Type type;
        public IntPtr[] address;
        public string desciption;
    }
    class checkBoxStates
    {
        public object checkedValue;
        public object unCheckedValue;
    }
    class checkBoxAddress
    {
        public Type type;
        public IntPtr[] address;
        public object checkedValue;
        public object unCheckedValue;
        public string desciption;
    }
    public static class Addresses
    {

        public static IntPtr BaseAddress;
        public static IntPtr cbuf_address;
        public static IntPtr nop_address;
        public static IntPtr hProcess = IntPtr.Zero;
        private static IntPtr dvarUnlock;
        public static IntPtr dvarCount;
        public static IntPtr dvarBase;
        public static IntPtr ingameConsoleUnlock;

        public static IntPtr AspectRatio;
        public static IntPtr theatre_barrier;
        public static IntPtr gsDistance_1;
        public static IntPtr gsDistance_2;
        public static IntPtr gsDistance_3;
        public static IntPtr lightSpritesOpacity;
        public static IntPtr sunFlareProptection;
        public static IntPtr sunFlare;
        public static IntPtr skyBoxObj;

        public static IntPtr fog;

        #region dvar addresses
        public static IntPtr r_clearColor;
        public static IntPtr r_clearColor2;

        public static IntPtr SunColor;
        #endregion

        public static void ReadAllAddresses()
        {
            if (Process.GetProcessesByName("BlackOpsMP").Length > 0)
            {
                Process p = Process.GetProcessesByName("BlackOpsMP").FirstOrDefault();
                MemoryHelper.mem = new AiryzMemory("BlackOpsMP");
                BaseAddress = p.MainModule.BaseAddress;
                hProcess = MemoryHelper.mem.pHandle;

                //cbuf addresses
                cbuf_address = BaseAddress + 0x16EF70;
                nop_address = BaseAddress + 0x4B5A37;
                MemoryHelper.mem.NOP(nop_address, 2);

                //dvar unlocking
                dvarUnlock = BaseAddress + 0x4B5BC1;
                MemoryHelper.mem.WriteByteArray(dvarUnlock, new byte[] { 0xE9, 0x89, 0x00, 0x00, 0x00, 0x90 });
                dvarCount = BaseAddress + 0x345BE74;
                dvarBase = BaseAddress + 0x345BE88;
                ingameConsoleUnlock = BaseAddress + 0x2B58F7;
                MemoryHelper.mem.WriteByteArray(ingameConsoleUnlock, "81 48");
                readDvarAddresses();

                AspectRatio = BaseAddress + 0x7DD88C;
                theatre_barrier = BaseAddress + 0x312F38C;
                gsDistance_1 = BaseAddress + 0x42F4744;
                gsDistance_2 = BaseAddress + 0x42F4750;
                gsDistance_3 = BaseAddress + 0x42F47B0;
                lightSpritesOpacity = BaseAddress + 0x2FF2D1;
                sunFlareProptection = BaseAddress + 0x33FEE2;
                sunFlare = BaseAddress + 0x4F5327C;
                skyBoxObj = BaseAddress + 0x4F6FAEC;

                fog = MemoryHelper.mem.getPointer(BaseAddress + 0x319714, 0xE0);
                SunColor = MemoryHelper.mem.getLotsPointer(BaseAddress + 0x42EC4CC, new IntPtr[]{ (IntPtr)0xEC, (IntPtr)0x5C } );


            }
        }
        private static void readDvarAddresses()
        {
            r_clearColor = MemoryHelper.mem.getPointer(BaseAddress + 0x44A4DEC, 0x18);
            r_clearColor2 = MemoryHelper.mem.getPointer(BaseAddress + 0x44A4DB8, 0x18);
            SunColor = MemoryHelper.mem.getLotsPointer(BaseAddress + 0x42EC4CC, new IntPtr[] { (IntPtr)0xEC, (IntPtr)0x5C });
        }
    }//
}
