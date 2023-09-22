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

namespace work02_4b1g0162
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private class Triangle
        {
            private double a;
            private double b;
            private double c;
            public bool isTriangle = false;

            public Triangle(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;

                if (a > b && a > c && b + c > a)
                    this.isTriangle = true;
                else if (b > a && b > c && a + c > b)
                    this.isTriangle = true;
                else if (c > a && c > b && a + b > c)
                    this.isTriangle = true;
            }
        }
        List<Triangle> triangles = new List<Triangle>();

        public MainWindow()
        {
            InitializeComponent();
            resultLbl.Content = "";
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            double[] result = new double[3];
            Double.TryParse(a.Text, out result[0]);
            Double.TryParse(b.Text, out result[1]);
            Double.TryParse(c.Text, out result[2]);

            if (result[0] == 0 || result[1] == 0 || result[2] == 0)
            {
                MessageBox.Show("轉換錯誤，請重新輸入!", "Error");
                return;
            }

            
            triangles.Add(new Triangle(result[0], result[1], result[2]));

            if (triangles[triangles.Count - 1].isTriangle)
            {
                resultLbl.Background = new SolidColorBrush(Colors.Green);
                resultLbl.Content = $"邊長{result[0]}, {result[1]}, {result[2]}可構成三角形";
                resultBox.Text += $"三角形: {result[0]}, {result[1]}, {result[2]}\r\n";
            }
            else
            {
                resultLbl.Background = new SolidColorBrush(Colors.Red);
                resultLbl.Content = $"邊長{result[0]}, {result[1]}, {result[2]}不可構成三角形";
                resultBox.Text += $"非三角形: {result[0]}, {result[1]}, {result[2]}\r\n";
            }
        }
    }
}
