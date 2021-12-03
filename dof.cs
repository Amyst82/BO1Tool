using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace bo1tool
{
    public class dofSettings : json<dofSettings>
    {
        public double r_dof_farBlur { get; set; }
        public double r_dof_farStart { get; set; }
        public double r_dof_farEnd { get; set; }
        public double r_dof_nearBlur { get; set; }
        public double r_dof_nearStart { get; set; }
        public double r_dof_nearEnd { get; set; }
        public double r_dof_viewModelStart { get; set; }
        public double r_dof_viewModelEnd { get; set; }
        public double r_dof_bias { get; set; }

    }
    public static class dof
    {

        public static void updateDofFromSlider(IEnumerable<UIElement> sliders)
        {
            //TODO
        }

        public static void toggleDof(bool state)
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                dvars.setDvarValueByName("r_dof_enable", state ? (byte)1 : (byte)0);
                dvars.setDvarValueByName("r_dof_tweak", state ? (byte)1 : (byte)0);
            }
        }

        public static bool checkIfEnabled()
        {
            bool res = false;
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                dvar_s dvar = dvars.getDvarByName("mvm_fog_custom");
                if(dvar != null)
                {
                    res = (byte)dvar.Value == (byte)1 ? true : false;
                }
            }  
            return res;
        }

        public static void resetDof(IEnumerable<UIElement> sliders)
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                foreach (Slider s in sliders)
                {
                    dvar_s dofDvar =  dvars.getDvarByName(s.Name);
                    dofDvar.Reset();
                    s.Value = (double)((float)dofDvar.Value);
                }
            }
        }

        public static bool loadDof(IEnumerable<UIElement> sliders)
        {
            OpenFileDialog loadCFG = new OpenFileDialog();
            loadCFG.Filter = "dof file(*.dof)|*.dof|All files(*.*)|*.*";
            DialogResult result = loadCFG.ShowDialog();
            if (result == DialogResult.OK)
            {
                dofSettings ds = dofSettings.Load(loadCFG.FileName);
                if (ds != null)
                {
                    PropertyInfo[] properties = typeof(dofSettings).GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                        ((Slider)sliders.ToList()[i]).Value = (double)properties[i].GetValue(ds);
                    return true;
                }
            }
            return false;
        }
        public static void saveDof(IEnumerable<UIElement> sliders)
        {
            dofSettings ds = new dofSettings();
            PropertyInfo[] properties = typeof(dofSettings).GetProperties();
            for (int i = 0; i < properties.Length; i++)
                properties[i].SetValue(ds, ((Slider)sliders.ToList()[i]).Value);
            SaveFileDialog saveCFG = new SaveFileDialog();
            saveCFG.Filter = "dof file(*.dof)|*.dof|All files(*.*)|*.*";
            DialogResult result = saveCFG.ShowDialog();
            if (result == DialogResult.OK)
            {
                ds.Save(saveCFG.FileName);
            }
        }
    }
}
