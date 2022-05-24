using System;
using System.Collections.Generic;
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

namespace Download_Speed_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double size;
            double speed;
            long sizeByte = 0;
            long speedByte = 0;
            long seconds;
            string sizeUnit;
            string speedUnit;

            size = double.Parse(this.SizeText.Text);
            speed = double.Parse(this.SpeedText.Text);
            sizeUnit = this.SizeUnitBox.Text;
            speedUnit = this.SpeedUnitBox.Text;
            
            if (sizeUnit == "MB")
            {
                sizeByte = Convert.ToInt64(size * Math.Pow(10, 6));
            }
            else if (sizeUnit == "GB")
            {
                sizeByte = Convert.ToInt64(size * Math.Pow(10, 9));
            }
            else if (sizeUnit == "TB")
            {
                sizeByte = Convert.ToInt64(size * Math.Pow(10, 12));
            }

            if (speedUnit == "KBps")
            {
                speedByte = Convert.ToInt64(speed * Math.Pow(10, 3));
            }
            else if (speedUnit == "MBps")
            {
                speedByte = Convert.ToInt64(speed * Math.Pow(10, 6));
            }
            else if (speedUnit == "GBps")
            {
                speedByte = Convert.ToInt64(speed * Math.Pow(10, 9));
            }

            seconds = sizeByte / speedByte;

            // Result formating
            long minutes = 0;
            long hours = 0;
            long days = 0;
            string result = "";
            if (seconds > 60)
            {
                minutes = seconds / 60;
                seconds = seconds % 60;
            }
            if (minutes > 60)
            {
                hours = minutes / 60;
                minutes = minutes % 60;
            }
            if (hours > 24)
            {
                days = hours / 24;
                hours = hours % 24;
            }

            if (days > 0)
            {
                result += Convert.ToString(days) + " d. ";
            }
            if (hours > 0)
            {
                result += Convert.ToString(hours) + " h. ";
            }
            if (minutes > 0)
            {
                result += Convert.ToString(minutes) + " m. ";
            }
            result += Convert.ToString(seconds) + " s.";

            this.ResultText.Text = result;
        }

        private void Text_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Dispatcher.BeginInvoke(new Action(() => textBox.SelectAll()));
        }
    }
}
