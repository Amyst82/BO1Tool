using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bo1tool
{
    /// <summary>
    /// Логика взаимодействия для Dial.xaml
    /// </summary>
    public partial class Dial : UserControl, INotifyPropertyChanged
    {
        public Dial()
        {
            InitializeComponent();
            this.DataContext = this;
            var alpha = (Math.Abs(this.Min) + this.Value) / (Math.Abs(this.Min) + Math.Abs(this.Max));
            this.Angle = Interpolate(0, 360, alpha);
        }

        private double alphaoffset = 0.75d;

        double m_angle = default(double);
        public double Angle
        {
            get { return m_angle; }
            set { SetProperty(ref m_angle, value, "Angle"); }
        }

        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Dial), new PropertyMetadata(0d));
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {

                var alpha = (Math.Abs(this.Min) + value) / (Math.Abs(this.Min) + Math.Abs(this.Max));
                this.Angle = Interpolate(0, 360, (alpha - alphaoffset) % 1d);
                SetValue(ValueProperty, value);
            }
        }

        public static DependencyProperty MinProperty = DependencyProperty.Register("Min", typeof(double), typeof(Dial), new PropertyMetadata(0d));
        public double Min
        {
            get { return (double)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public static DependencyProperty MaxProperty = DependencyProperty.Register("Max", typeof(double), typeof(Dial), new PropertyMetadata(360d));
        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ValueChanged;

        void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        double Interpolate(double start, double end, double alpha)
        {
            double i = 0;
            if (start > end)
            {
                double difference = start - end;
                double interpolated = (alpha * difference);
                return start - interpolated;
            }
            else if (end > start)
            {
                double difference = end - start;
                double interpolated = alpha * difference;
                return interpolated + start;
            }
            return i;
        }

        private double getAngle(Point clickPoint, Size circleSize)
        {
            var _x = (circleSize.Width / 2d);
            var _y = (circleSize.Height / 2d);
            double angle = Math.Atan2(clickPoint.Y - _y, clickPoint.X - _x) * 180 / Math.PI;
            return angle + 90;
        }

        private void MyThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            double alpha = getAngle(Mouse.GetPosition(this), this.RenderSize) / 360;

            if (alpha < 0)
                alpha = 1 + alpha;

            alpha = (alpha + alphaoffset) % 1;

            this.Value = Interpolate(this.Min, this.Max, alpha);

            ValueChanged?.Invoke(this, new EventArgs());
        }
    }
}
