using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bo1tool
{
    public static class sky_sun
    {
        public static void removeFlare(bool? state)
        {

            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                if (state == true)
                {
                    MemoryHelper.mem.WriteBoolean(Addresses.sunFlareProptection, true);
                    MemoryHelper.mem.WriteFloat(Addresses.sunFlare, 0);
                }
                else
                {
                    MemoryHelper.mem.WriteBoolean(Addresses.sunFlareProptection, false);
                    MemoryHelper.mem.WriteFloat(Addresses.sunFlare, 1);
                }
            }
           
        }
    }//
}
