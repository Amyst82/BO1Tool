using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace bo1tool
{
    public class aTextBox : TextBox
    {
        [Description("Show clear button on the right side of the textBox"), Category("Amyst")]
        public bool ShowClearButton
        {
            get => (bool)GetValue(ShowClearButtonProperty);
            set => SetValue(ShowClearButtonProperty, value);
        }
        public static readonly DependencyProperty ShowClearButtonProperty =
            DependencyProperty.Register("ShowClearButton", typeof(bool), typeof(aTextBox),
                new PropertyMetadata(default(bool)));

        [Description("Hint text to be shown while the textBox is empty"), Category("Amyst")]
        public string HintText
        {
            get => (string)GetValue(HintTextProperty);
            set => SetValue(HintTextProperty, value);
        }

        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.Register("HintText", typeof(string), typeof(aTextBox),
                new PropertyMetadata(default(string)));


        [Description("Brush that will be used to outline the textBox when it is in focus"), Category("Brush")]
        public SolidColorBrush FocusedBrush
        {
            get => (SolidColorBrush)GetValue(FocusedBrushProperty);
            set => SetValue(FocusedBrushProperty, value);
        }

        public static readonly DependencyProperty FocusedBrushProperty =
            DependencyProperty.Register("FocusedBrush", typeof(SolidColorBrush), typeof(aTextBox),
                new PropertyMetadata(default(SolidColorBrush)));
    }

    public class linkButton : Button
    {

    }

    public class uiTest : TextBox
    {
        public bool SetBackGroundRed
        {
            get => (bool)GetValue(dependencyProperty);
            set => SetValue(dependencyProperty, value);
        }
        public static readonly DependencyProperty dependencyProperty =
            DependencyProperty.Register("SetBackGroundRed", typeof(bool), typeof(uiTest),
                new PropertyMetadata(default(bool)));
    }
}
