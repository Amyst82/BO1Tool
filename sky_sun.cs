using ColorWheel.Controls;
using ColorWheel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        public static void updateSunColor(ColorWheelControl wheel)
        {
            Palette p = wheel.Palette;
            dvars.dvarVec3 dv = new dvars.dvarVec3
            {
                x = (float)p.Colors[0].R / 255,
                y = (float)p.Colors[0].G / 255,
                z = (float)p.Colors[0].B / 255
            };
            dvars.setDvarValueByName("r_lighttweaksuncolor", dv);
        }

        public static void updateSunDir(float x, float y)
        {
            dvars.dvarVec2 dv = new dvars.dvarVec2
            {
                x = x,
                y = y,
            };
            dvars.setDvarValueByName("r_lighttweaksundirection", dv);
        }

        public static void resetSun(IEnumerable<UIElement> sliders, Dial x, Dial y)
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                dvar_s dialDvar = dvars.getDvarByName("r_lightTweakSunDirection");
                dialDvar.Reset();
                x.Value = (double)((dvars.dvarVec3)dialDvar.Value).x;
                y.Value = (double)((dvars.dvarVec3)dialDvar.Value).y;

                foreach (Slider s in sliders)
                {
                    dvar_s sunDvar = dvars.getDvarByName(s.Name);
                    sunDvar.Reset();
                    s.Value = (double)((float)sunDvar.Value);
                }

                dvar_s sunColorDvar = dvars.getDvarByName("r_lightTweakSunColor");
                sunColorDvar.Reset();

                dvars.dvarVec3 sunColor = new dvars.dvarVec3() { x = ((dvars.dvarVec3)sunColorDvar.Value).x * 14, y = ((dvars.dvarVec3)sunColorDvar.Value).y * 14, z = ((dvars.dvarVec3)sunColorDvar.Value).z * 14 };
                MemoryHelper.mem.WriteStruct(Addresses.SunColor, sunColor);
                MemoryHelper.mem.WriteStruct(Addresses.SunColor-0x10, sunColor);
            }
        }
    }//
}
