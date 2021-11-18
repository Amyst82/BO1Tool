using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace bo1tool
{
    public class SolidColorAnimation : ColorAnimation
    {
        public SolidColorBrush ToBrush
        {
            get { return To == null ? null : new SolidColorBrush(To.Value); }
            set 
            {
                To = value?.Color; 
            }
        }
    }

    partial class Style 
    {
        public Style()
        {
            InitializeComponent();
        }

        private void StatusBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (System.Windows.Input.Mouse.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                ((Window)((FrameworkElement)sender).TemplatedParent).DragMove();
            }
            e.Handled = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox t = ((TextBox)((FrameworkElement)sender).TemplatedParent);
            t.Clear();
            t.ToolTip = null;

        }

        private void control_OnFocus(object sender, RoutedEventArgs e)
        {
            //TextBox t = ((TextBox)((FrameworkElement)sender).TemplatedParent);
            Control t = ((FrameworkElement)sender).TemplatedParent as Control;
            if(t.IsFocused)
                t.BorderBrush = new SolidColorBrush();
            Window win = Application.Current.Windows[0];
            ColorAnimation anim = new ColorAnimation();
            anim.To = ((SolidColorBrush)((win as MainWindow).Resources[t.IsFocused ? "DefaultHighlightColor" : "BackgroundOpaque"])).Color;
            anim.Duration = TimeSpan.FromMilliseconds(400);
            t.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, anim);
        }
       
    }
}
