﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace bo1tool
{
    public static class fog
    {
        public struct fog_struct
        {
            public dvars.dvarVec3 nearColor;
            public float nearExposure;
            public float fogStart; //0x4C

            public float padding1; //0x50
            public float padding2; //0x54
            public float padding3; //0x58

            public float fogHeight;
            public dvars.dvarVec3 farColor;
            public float farExposure;
        }
        public static void writeFog(Slider slider)
        {
            try
            {
                Address address = (Address)slider.DataContext;

                //Write Type based on sender
                switch (Type.GetTypeCode(address.type))
                {
                    case TypeCode.Int32:
                        for (int i = 0; i < address.address.Length; i++)
                            MemoryHelper.mem.WriteInt((IntPtr)address.address[i], (int)Math.Round(slider.Value));
                        break;
                    case TypeCode.Single:
                        for (int i = 0; i < address.address.Length; i++)
                        {
                            MemoryHelper.mem.WriteFloat((IntPtr)address.address[i], (float)slider.Value);
                        }
                        break;
                    case TypeCode.Double:
                        for (int i = 0; i < address.address.Length; i++)
                            MemoryHelper.mem.WriteDouble((IntPtr)address.address[i], slider.Value);
                        break;
                }
            }
            catch { }
        }
    }
}