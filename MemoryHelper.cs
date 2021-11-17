using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bo1tool
{
    public static class MemoryHelper
    {
        public static AiryzMemory mem;
        public static bool initizlized = false;
        public static void initMem()
        {
            mem = new AiryzMemory("BlackOpsMP");
            if(mem.pHandle != IntPtr.Zero)
            {
                initizlized = true;
            }
        }
    }
}
