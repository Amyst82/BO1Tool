using ColorWheel.Controls;
using ColorWheel.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace bo1tool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UIColors.defaultHightligght = (SolidColorBrush)this.Resources["DefaultHighlightColor"];
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            gsColorWheel.Palette = GreenScreen.Palette;
        }

        private void bo1tool_Loaded(object sender, RoutedEventArgs e)
        {
            MemoryHelper.initMem();
            Addresses.ReadAllAddresses();
            dvars.initDvarList();
            setDataContext();
        }

        void setDataContext()
        {
            singleCfg.DataContext = new String("".ToCharArray()); //used for "to cfg box" function on context menu
            tScaleBox.DataContext = new String("timescale ".ToCharArray());

            cg_drawGun.DataContext = new checkBoxStates { checkedValue = (bool)false, unCheckedValue = (bool)true };
            r_dobjlimit.DataContext = new checkBoxStates {checkedValue = (int)0, unCheckedValue = (int)1024 };
            fx_draw.DataContext = new checkBoxStates { checkedValue = (bool)false, unCheckedValue = (bool)true };
            r_bloomTweaks.DataContext = new checkBoxStates { checkedValue = (bool)true, unCheckedValue = (bool)false };
            rmvBarrier.DataContext = new checkBoxAddress { address = new IntPtr[] { Addresses.theatre_barrier }, type = typeof(bool),
                desciption = "Removes theatre barrier", checkedValue = (bool)false, unCheckedValue = (bool)true };
            r_skyTransition.DataContext = new checkBoxStates { checkedValue = (float)1, unCheckedValue = (float)0 };

            slider2.DataContext = new Address() { address = new IntPtr[] { MemoryHelper.mem.GetStructMemberAddress<fog.fog_struct>(Addresses.fog, fog => fog.nearExposure, 0) }, type = typeof(float), desciption = "" };
        }
        #region cfg
        private void loadCfg_Click(object sender, RoutedEventArgs e)
        {
            cfg.setCfgBoxText(cfgBox, cfg.loadCfg());
        }

        private void saveCfg_Click(object sender, RoutedEventArgs e)
        {
            string cfgToSave = new TextRange(cfgBox.Document.ContentStart, cfgBox.Document.ContentEnd).Text;
            cfg.saveCfg(cfgToSave);
        }

        private void sendCfg_Click(object sender, RoutedEventArgs e)
        {
            string cfgToSend = new TextRange(cfgBox.Document.ContentStart, cfgBox.Document.ContentEnd).Text;
            cfg.Send(cfgToSend);
        }

        private void sendSingle_Click(object sender, RoutedEventArgs e)
        {
            cfg.Send(singleCfg.Text);
            updateSingleCfgToolTip();
        }
        private void singleCfg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sendSingle_Click(sendSingle, null);
            }
        }
        private void sendTscale_Click(object sender, RoutedEventArgs e)
        {
            cfg.Send("timescale " + tScaleBox.Text);
        }

        private async void DvarSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
                    {
                        cfg.updateDvarFromSlider((Slider)sender);
                    }
                });
            });
        }

       

        void setFromCheckBox(object sender, RoutedEventArgs e)
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                CheckBox control = (CheckBox)sender;
                if (control.DataContext != null)
                {
                    if(control.DataContext is checkBoxAddress)
                    {
                        checkBoxAddress a = (checkBoxAddress)control.DataContext;
                        IntPtr address = a.address[0];
                        foreach(IntPtr addy in a.address)
                        {
                            object value = control.IsChecked == true ? a.checkedValue : a.unCheckedValue;
                            MemoryHelper.mem.WriteGen(addy, value);
                        }
                    }
                    else if(control.DataContext is checkBoxStates)
                    {
                        checkBoxStates valuesToWrite = (checkBoxStates)control.DataContext;
                        object value = control.IsChecked == true ? valuesToWrite.checkedValue : valuesToWrite.unCheckedValue;
                        dvars.getDvarByName(control.Name).Value = value;
                    }  
                }
                else
                {
                    dvars.getDvarByName(control.Name).Value = (bool)control.IsChecked;
                }
            }
        }

        #endregion

        #region UI Behavior
        public static Palette Palette
        {
            get
            {
                Palette p = Palette.Create(new RGBColorWheel(), Colors.White, PaletteSchemaType.Analogous, 1);
                p.Colors[0].RgbColor = Colors.White;
                p.Colors[0].Brightness255 = 255;
                return p;
            }
        }

        private static void TabItem_OnChanged(object sender) //method to update the rectangle that is used for highlighting selected tab on tabControl
        {
            if (System.Windows.Input.Mouse.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Window win = Application.Current.Windows[0];
                Point relativePoint = (sender as TabItem).TransformToAncestor(win).Transform(new Point(0, 0));
                double oldX = (win as MainWindow).Indicator.TransformToAncestor(win).Transform(new Point(0, 0)).X;
                double newX = relativePoint.X; // + ((TabItem)((FrameworkElement)sender).TemplatedParent).ActualWidth / 2;
                ThicknessAnimation anim = new ThicknessAnimation();
                anim.From = new Thickness(oldX, relativePoint.Y - 2, 0, 0);
                anim.To = new Thickness(newX, relativePoint.Y - 2, 0, 0);
                anim.Duration = TimeSpan.FromMilliseconds(200);

                DoubleAnimation anim2 = new DoubleAnimation();
                anim2.From = (sender as TabItem).ActualWidth;
                anim2.To = (sender as TabItem).ActualWidth;
                anim2.Duration = TimeSpan.FromMilliseconds(300);

                (win as MainWindow).Indicator.BeginAnimation(TabItem.MarginProperty, anim);
                (win as MainWindow).Indicator.BeginAnimation(TabItem.WidthProperty, anim2);
            }
        }

        private void ColorWheel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ColorWheelControl clr = (ColorWheelControl)sender;
            clr.Palette.Colors[0].RgbColor = Colors.White;
        }
        void clearTextBox(object sender, RoutedEventArgs e)
        {
            ((TextBox)this.FindName(((Button)sender).Tag.ToString())).Clear();
        }

        void CopyAll(object sender, RoutedEventArgs e)
        {
            var parent = ((MenuItem)sender).Parent;
            var control = ((ContextMenu)parent).PlacementTarget;
            if (control is TextBox)
                Clipboard.SetText(((TextBox)control).Text);
            else if (control is RichTextBox)
            {
                RichTextBox ctrl = (RichTextBox)control;
                string ToCopy = new TextRange(ctrl.Document.ContentStart, ctrl.Document.ContentEnd).Text;
                Clipboard.SetText(ToCopy);
            }

        }
        void CopySelection(object sender, RoutedEventArgs e)
        {
            var parent = ((MenuItem)sender).Parent;
            var control = ((ContextMenu)parent).PlacementTarget;
            if (control is TextBox)
                Clipboard.SetText(((TextBox)control).SelectedText);
            else if (control is RichTextBox)
                Clipboard.SetText(((RichTextBox)control).Selection.Text);
        }
        void PasteMenuItem(object sender, RoutedEventArgs e)
        {
            var parent = ((MenuItem)sender).Parent;
            var control = ((ContextMenu)parent).PlacementTarget;
            if (control is TextBox)
            {
                ((TextBox)control).Text += " " + Clipboard.GetText();
            }
            else if (control is RichTextBox)
            {
                cfg.appendCfgBoxText((RichTextBox)control, Clipboard.GetText());
            }
        }

        void ClearMenuItem(object sender, RoutedEventArgs e)
        {
            var parent = ((MenuItem)sender).Parent;
            var control = ((ContextMenu)parent).PlacementTarget;
            if (control is TextBox)
            {
                ((TextBox)control).Clear();
            }
            else if (control is RichTextBox)
            {
                ((RichTextBox)control).Document.Blocks.Clear();
            }
        }

        void appendToCfg(object sender, RoutedEventArgs e)
        {
            var parent = ((MenuItem)sender).Parent;
            var control = ((ContextMenu)parent).PlacementTarget;
            string content = "";
            if (((TextBox)control).Text != "")
            {
                if (((string)((TextBox)control).DataContext) != null)
                {
                    content = ((string)((TextBox)control).DataContext).ToString() + ((TextBox)control).Text;
                }
                else
                {
                    content = ((TextBox)control).Text;
                }
                cfg.appendCfgBoxText((RichTextBox)control, content);
            }
        }
        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int index = ((TextBox)sender).CaretIndex;
            if (e.Key == Key.OemComma || e.Key == Key.OemPeriod)
            {
                try
                {
                    if (((TextBox)sender).Text[index] == '.' || ((TextBox)sender).Text[index] == ',')
                    {
                        ((TextBox)sender).CaretIndex++;
                        e.Handled = true;
                    }
                    if (((TextBox)sender).Text.IndexOf('.') == 1 || ((TextBox)sender).Text.IndexOf(',') == 1)
                    {
                        ((TextBox)sender).CaretIndex = 2;
                    }
                }
                catch { }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            string result = "";
            int dotCounter = 0;
            char[] validChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '.', '-' };
            foreach (char c in txtBox.Text)
            {
                if (Array.IndexOf(validChars, c) != -1)
                {
                    if (c == validChars[10] || c == validChars[11])
                    {
                        dotCounter++;
                    }
                    if (dotCounter < 2)
                    {
                        result += c;
                    }
                }
            }
            if (txtBox.Text.IndexOf('.') == 0 || txtBox.Text.IndexOf(',') == 0)
            {
                result = result.Insert(0, "0");
                txtBox.CaretIndex = 2;
            }
            txtBox.Text = result;
        }

        private void onExpander_Expanded(object sender, RoutedEventArgs e)
        {
            Expander exp = (Expander)sender;
            if (exp.IsExpanded == true)
            {
                exp.Height = exp.MaxHeight;
                exp.Width = exp.MaxWidth;
            }
            else
            {
                exp.Height = exp.MinHeight;
                exp.Width = exp.MinWidth;
            }
        }

        void updateSingleCfgToolTip()
        {
            string[] dv = singleCfg.Text.Split(' ');
            if (dv[0] != "" && dv.Length > 1)
            {
                dvar_s dvar = dvars.getDvarByName(dv[0]);
                if (dvar != null)
                    singleCfg.ToolTip = (string)($"Dvar: {dvar.Name}\nType: {dvar.dvarTypeString}\nDesc: {dvar.Description}\nCurrent value: {dvar.Value}\nDefault value: {dvar.defaultValue}");
            }
        }
        private void singleCfg_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSingleCfgToolTip();
        }

        #endregion

        #region On Pages Change
        
        private void AllPages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.OriginalSource is TabControl) //if this event fired from TabControl then enter
            {
                var selected = AllPages.SelectedItem as TabItem;
                TabItem_OnChanged(selected);
                DoubleAnimation anim = new DoubleAnimation();
                anim.From = 0;
                anim.To = 1;
                anim.Duration = TimeSpan.FromMilliseconds(200);
                menuGrid.BeginAnimation(OpacityProperty, anim);
                ((Grid)selected.Content).BeginAnimation(OpacityProperty, anim);
                if (selected.Header.ToString() == "MENU")
                { 
                    this.Width = this.MinWidth = 536;
                    this.Height = this.MinHeight = 333;
                    this.MaxWidth = 536;
                    this.MaxHeight = 333;
                }
                if (selected.Header.ToString() == "CFG")
                {
                    this.Width = this.MinWidth = 416;
                    this.Height = this.MinHeight = 305;
                    this.MaxWidth = 1920;
                    this.MaxHeight = 1080;
                }
                if (selected.Header.ToString() == "THEATRE")
                {
                    this.Width = this.MinWidth = this.MaxWidth = 416;
                    this.Height = this.MinHeight = this.MaxHeight = 440;
                }
                if (selected.Header.ToString() == "SUN")
                {
                    dvars.setDvarValueByName("r_sky_intensity_useDebugValues", (bool)true);
                    this.Width = this.MinWidth = 602;
                    this.Height = this.MinHeight = this.MaxHeight = 405;
                    this.MaxWidth = 1920;
                }
                if (selected.Header.ToString() == "DOF")
                {
                    this.Width = this.MinWidth = 416;
                    this.Height = this.MinHeight = this.MaxHeight = 494;
                    this.MaxWidth = 1920;
                    bool isDofEnabled = dof.checkIfEnabled();
                    if (dofToggle.IsChecked != isDofEnabled)
                    {
                        dofToggle.IsChecked = isDofEnabled;
                    }
                }
            }
        }
        #endregion

        #region Theatre
        void clearColorPresetChange(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Brush newColor = rb.Background;
            Color color = ((SolidColorBrush)newColor).Color;
            if (gsColorWheel.Palette != null)
            {
                gsColorWheel.Palette.Colors[0].RgbColor = color;
                gsColorWheel_ColorUpdated(gsColorWheel, null);
            }
        }
        //green screen
        private void gsToggle_Checked(object sender, RoutedEventArgs e)
        {
            GreenScreen.toggleGS(gsToggle.IsChecked, gsColorWheel.Palette);
        }
        //green sky
        private void greenSkyToggle_Checked(object sender, RoutedEventArgs e)
        {
            GreenScreen.toggleGreenSky(greenSkyToggle.IsChecked);
        }
        // green screen color (r_clearColor)
        bool?[] gsRaiosStates = { false, true, false, false };
        PaletteColor colorBack = null;
        private void cancelClearColor_Click(object sender, RoutedEventArgs e)
        {
            gsR.IsChecked = gsRaiosStates[0]; gsG.IsChecked = gsRaiosStates[1]; gsB.IsChecked = gsRaiosStates[2]; gsP.IsChecked = gsRaiosStates[3];
            gsColorWheel.Palette.Colors[0].RgbColor = colorBack.RgbColor;
            gsColorEx.IsExpanded = false;
            onExpander_Expanded(gsColorEx, e);
        }

        private void okClearColor_Click(object sender, RoutedEventArgs e)
        {
            gsColorEx.IsExpanded = false;
            onExpander_Expanded(gsColorEx, e);
        }

        private void gsColorEx_expand(object sender, RoutedEventArgs e)
        {
            onExpander_Expanded(sender, e);
            Expander exp = (Expander)sender;
            if (exp.IsExpanded == true)
            {
                gsRaiosStates = new bool?[] { gsR.IsChecked, gsG.IsChecked, gsB.IsChecked, gsP.IsChecked };
                colorBack = new PaletteColor();
                colorBack.RgbColor = gsColorWheel.Palette.Colors[0].RgbColor;
            }
        }

        private async void gsColorWheel_ColorUpdated(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (MemoryHelper.initizlized)
                    {
                        GreenScreen.updateClearColor((ColorWheelControl)sender);
                    }
                });
            });
        }
        //depth
        private void depthToggle_Checked(object sender, RoutedEventArgs e)
        {
            depth.toggleDepth(depthToggle.IsChecked, (float)(depthDistanceSlider.Value));
            if(depthToggle.IsChecked == true)
            {
                greenSkyToggle.IsChecked = false;
                gsToggle.IsChecked = false;
                fx_draw.IsChecked = true;
                r_bloomTweaks.IsChecked = true;
            }
            else
            {
                fx_draw.IsChecked = false;
            }
        }

        private async void depthDistanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
                    {
                        depth.changeDistance((float)(depthDistanceSlider.Value));
                    }
                });
            });
            
        }
        //r_debugShader
        private void debugShaderChange(object sender, RoutedEventArgs e)
        {
            if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
            {
                RadioButton rb = (RadioButton)sender;
                if (rb != null && rb.Tag != null)
                {
                    byte state = (byte)(byte.Parse((string)rb.Tag));
                    dvars.getDvarByName("r_debugShader").Value = state;
                    dvars.getDvarByName("r_debugShader").Modified = true;
                }
            }
        }

        #endregion

        #region dof

        private void dof_ToCfg_Click(object sender, RoutedEventArgs e)
        {
            string res = "//DOF\n";
            byte state = ((bool)dofToggle.IsChecked) ? (byte)1 : (byte)0;
            res += $"r_dof_enable {state}";
            res += $"r_dof_tweak {state}";
            foreach (Slider c in dofGrid.Children.Cast<UIElement>().Where(x => x is Slider))
            {
                res += $"{c.Name} {Math.Round(c.Value, 2)}\n";
            }
            cfg.appendCfgBoxText(cfgBox, res);
        }

        private void dofToggle_Checked(object sender, RoutedEventArgs e)
        {
            dof.toggleDof((bool)dofToggle.IsChecked);
        }

        private void saveDof_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<UIElement> sss = dofGrid.Children.Cast<UIElement>().Where(x => x is Slider);
            dof.saveDof(sss);
        }

        private void loadDof_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<UIElement> sss = dofGrid.Children.Cast<UIElement>().Where(x => x is Slider);
            if (dof.loadDof(sss))
            {
                dofToggle.IsChecked = true;
            }
        }

        private void resetDof_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<UIElement> sss = dofGrid.Children.Cast<UIElement>().Where(x => x is Slider);
            dof.resetDof(sss);
        }
        #endregion

        #region sky and sun
        private void rmvFlare_Checked(object sender, RoutedEventArgs e)
        {
            sky_sun.removeFlare(rmvFlare.IsChecked);
        }
        private async void sunColorWheel_ColorsUpdated(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (MemoryHelper.initizlized)
                    {
                        sky_sun.updateSunColor((ColorWheelControl)sender);
                    }
                });
            });
        }
        private async void sunDir_ValueChanged(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (MemoryHelper.initizlized)
                    {
                        sky_sun.updateSunDir((float)sunDirX.Value, (float)sunDirY.Value);
                    }
                });
            });
        }
        private void sun_ToCfg_Click(object sender, RoutedEventArgs e)
        {
            string res = "//SUN\n";
            byte state = ((bool)r_skyTransition.IsChecked) ? (byte)1 : (byte)0;
            res += $"r_skyTransition {state} \n";
            res += $"r_skyColorTemp {r_skyColorTemp.Value} \n";
            res += $"r_sky_intensity_factor0 {r_sky_intensity_factor0.Value} \n";
            res += $"r_lightTweakSunColor {sunColorWheel.Palette.Colors[0].DoubleColor.R/255}  {sunColorWheel.Palette.Colors[0].DoubleColor.G/255} {sunColorWheel.Palette.Colors[0].DoubleColor.B/255} \n";
            res += $"r_lightTweakSunLight {r_lightTweakSunLight.Value} \n";
            res += $"r_lightTweakSunDirection {sunDirX.Value} {sunDirY.Value} \n";
            cfg.appendCfgBoxText(cfgBox, res);
        }

        private void resetSun_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<UIElement> sss = sunGrid.Children.Cast<UIElement>().Where(x => x is Slider);
            sky_sun.resetSun(sss, sunDirX, sunDirY);
            r_skyTransition.IsChecked = false;
            rmvFlare.IsChecked = false;
            sunColorWheel.Palette.Colors[0].RgbColor = Colors.White;
        }
        #endregion

        #region fog
        private async void fogSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (MemoryHelper.mem != null && MemoryHelper.mem.ProcessIsRunning())
                    {
                        fog.writeFog((Slider)sender);
                    }
                });
            });
        }

        private async void fogNearColorWheel_ColorUpdated(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (MemoryHelper.initizlized)
                    {
                        
                    }
                });
            });
        }
        #endregion
        private void reloadGame_Click(object sender, RoutedEventArgs e)
        {
            //if(UIColors.getTheme(this) == "Light")
            //{
            //    UIColors.changeThemeColor(this, "Dark");
            //}
            //else
            //{
            //    UIColors.changeThemeColor(this, "Light");
            //}
            Random rnd = new Random();
            byte r = (byte)rnd.Next((byte)0, (byte)255);
            Color rndColor = Color.FromArgb(255, (byte)rnd.Next((byte)0, (byte)255), (byte)rnd.Next((byte)0, (byte)255), (byte)rnd.Next((byte)0, (byte)255));
            UIColors.changeStyleColor(this, rndColor);
        }

       
    }//
}
