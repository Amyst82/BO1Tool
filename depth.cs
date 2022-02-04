using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bo1tool
{
    public static class depth
    {
        static float farBlur, farStart, farEnd, nearBlur, nearStart, nearEnd, WMS, WME; //backups
        public static void toggleDepth(bool? state, float distance)
        {
            if(state == true)
            {
                farBlur = dvars.getDvarValueByName("r_dof_farBlur");
                farStart = dvars.getDvarValueByName("r_dof_farStart");
                farEnd = dvars.getDvarValueByName("r_dof_farEnd");
                nearBlur = dvars.getDvarValueByName("r_dof_nearBlur");
                nearStart = dvars.getDvarValueByName("r_dof_nearStart");
                nearEnd = dvars.getDvarValueByName("r_dof_nearEnd");
                WMS = dvars.getDvarValueByName("r_dof_viewModelStart");
                WME = dvars.getDvarValueByName("r_dof_viewModelEnd");

                dvars.setDvarValueByName("r_exposureTweak", (bool)true);
                dvars.setDvarValueByName("r_exposureValue", (float)9999f);
                dvars.setDvarValueByName("r_dof_enable", (bool)true);
                dvars.setDvarValueByName("r_dof_tweak", (bool)true);
                dvars.setDvarValueByName("r_dof_farBlur", (float)9f);
                dvars.setDvarValueByName("r_dof_farStart", (float)-500f);
                dvars.setDvarValueByName("r_dof_farEnd", distance);
                dvars.setDvarValueByName("r_dof_nearBlur", (float)2f);
                dvars.setDvarValueByName("r_dof_nearStart", (float)1f);
                dvars.setDvarValueByName("r_dof_nearEnd", (float)1);
                dvars.setDvarValueByName("r_dof_viewModelStart", (float)0.1f);
                dvars.setDvarValueByName("r_dof_viewModelEnd", (float)0.1);
                dvars.setDvarValueByName("r_dof_bias", (float)0);
            }
            else
            {
                dvars.setDvarValueByName("r_exposureTweak", (bool)false);
                dvars.setDvarValueByName("r_exposureValue", (float)1f);
                dvars.setDvarValueByName("r_dof_enable", (bool)false);
                dvars.setDvarValueByName("r_dof_tweak",  (bool)false);
                dvars.setDvarValueByName("r_dof_farBlur", farBlur);
                dvars.setDvarValueByName("r_dof_farStart", farStart);
                dvars.setDvarValueByName("r_dof_farEnd", farEnd);
                dvars.setDvarValueByName("r_dof_nearBlur", nearBlur);
                dvars.setDvarValueByName("r_dof_nearStart", nearStart);
                dvars.setDvarValueByName("r_dof_nearEnd", nearEnd);
                dvars.setDvarValueByName("r_dof_viewModelStart", WMS);
                dvars.setDvarValueByName("r_dof_viewModelEnd", WME);
                dvars.setDvarValueByName("r_dof_bias", (float)0.5f);
            }
        }

        public static void changeDistance(float distance)
        {
            dvars.setDvarValueByName("r_dof_farEnd", distance);
        }
    }
}
