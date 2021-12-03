using ColorWheel.Controls;
using ColorWheel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace bo1tool
{
    public static class GreenScreen
    {
        public static Palette Palette
        {
            get
            {
                Palette p = Palette.Create(new RGBColorWheel(), Colors.Green, PaletteSchemaType.Analogous, 1);
                p.Colors[0].RgbColor = Colors.Green;
                p.Colors[0].Brightness255 = 255;
                return p;
            }
        }
        private static byte bloomsTemp = 0;
        private static int mLimitTemp = 0;
        public static void toggleGS(bool? state, Palette clearColor)
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                if (state == true) //if green screen is enabled
                {
                    updateClearColor(clearColor);
                    bloomsTemp = (byte)dvars.getDvarByName("r_bloomTweaks").Value;
                    mLimitTemp = (int)dvars.getDvarByName("r_modelLimit").Value;
                    dvars.setDvarValueByName("r_bloomTweaks", (bool)true);
                    dvars.setDvarValueByName("r_modelLimit", (int)0);
                    dvars.setDvarValueByName("r_lockPvs", (bool)true);
                    MemoryHelper.mem.WriteFloat(Addresses.gsDistance_1, -2000);
                    MemoryHelper.mem.WriteFloat(Addresses.gsDistance_2, -2000);
                    MemoryHelper.mem.WriteFloat(Addresses.gsDistance_3, -2000);
                    dvars.setDvarValueByName("r_zfar", (float)1);
                    dvars.setDvarValueByName("r_skipPvs", (bool)true);
                    MemoryHelper.mem.WriteByteArray(Addresses.lightSpritesOpacity, new byte[] { 0xC7, 0x47, 0x0C, 0x00, 0x00, 0x00, 0x00 });
                }
                else //if green screen is disabled 
                {
                    dvars.setDvarValueByName("r_bloomTweaks", bloomsTemp);
                    dvars.setDvarValueByName("r_modelLimit", 1024);
                    dvars.setDvarValueByName("r_skipPvs", (bool)false);
                    dvars.setDvarValueByName("r_lockPvs", (bool)false);
                    dvars.setDvarValueByName("r_zfar", (float)0);
                    MemoryHelper.mem.WriteFloat(Addresses.gsDistance_1, 0);
                    MemoryHelper.mem.WriteFloat(Addresses.gsDistance_2, 0);
                    MemoryHelper.mem.WriteFloat(Addresses.gsDistance_3, 0);
                    MemoryHelper.mem.WriteByteArray(Addresses.lightSpritesOpacity, "F3 0F 11 47 0C 76 04");
                }
            }
        }
        static int skyBoxPrev = 0;
        public static void toggleGreenSky(bool? state)
        {
            if (state == true) //if green screen is enabled
            {
                skyBoxPrev = MemoryHelper.mem.ReadInt(Addresses.skyBoxObj);
                MemoryHelper.mem.WriteInt(Addresses.skyBoxObj, 0);
            }
            else
            {
                if(skyBoxPrev != 0)
                {
                    MemoryHelper.mem.WriteInt(Addresses.skyBoxObj, skyBoxPrev);
                }    
            }
        }

        #region set clear color overloads
        public static void updateClearColor(Palette clearColor)
        {
            dvar_s.dvarColor dv = new dvar_s.dvarColor
            {
                r = (byte)clearColor.Colors[0].R,
                g = (byte)clearColor.Colors[0].G,
                b = (byte)clearColor.Colors[0].B,
                a = 255
            };
            dvars.setDvarValueByName("r_clearColor", dv);
            dvars.setDvarValueByName("r_clearColor2", dv);
        }

        public static void updateClearColor(ColorWheelControl wheel)
        {
            Palette p = wheel.Palette;
            dvar_s.dvarColor dv = new dvar_s.dvarColor 
            {
                r = (byte)p.Colors[0].R,
                g = (byte)p.Colors[0].G,
                b = (byte)p.Colors[0].B,
                a = 255
            };
            dvars.setDvarValueByName("r_clearColor", dv);
            dvars.setDvarValueByName("r_clearColor2", dv);
        }

        public static void updateClearColor(byte[] colour)
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                for (int i = 0; i < colour.Length; i++)
                {
                    if (colour[i] > 255)
                        colour[i] = 255;
                    else if (colour[i] < 0)
                        colour[i] = 0;
                }
                dvar_s.dvarColor dv = new dvar_s.dvarColor
                {
                    r = colour[0],
                    g = colour[1],
                    b = colour[2],
                    a = 255
                };
                dvars.setDvarValueByName("r_clearColor", dv);
                dvars.setDvarValueByName("r_clearColor2", dv);
            }
        }

        public static void updateClearColor(byte r, byte g, byte b)
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                if (r > 255)
                    r = 255;
                if (g > 255)
                    g = 255;
                if (b > 255)
                    b = 255;

                if (r < 0)
                    r = 0;
                if (g < 0)
                    g = 0;
                if (b < 0)
                    b = 0;
                dvar_s.dvarColor dv = new dvar_s.dvarColor
                {
                    r = r,
                    g = g,
                    b = b,
                    a = 255
                };
                dvars.setDvarValueByName("r_clearColor", dv);
                dvars.setDvarValueByName("r_clearColor2", dv);
            }
        }
        #endregion
    }//
}
