using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace EliseevPractica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<double> sequence = new List<double>();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void CheckProgression_Click(object sender, RoutedEventArgs e)
        {
            sequence.Clear();
            graphCanvas.Children.Clear();

            string input = inputBox.Text.Trim();
            string[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string numStr in numbers)
            {
                if (double.TryParse(numStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    sequence.Add(num);
                }
            }

            DrawSequenceGraph();
            CheckGeometricProgression();
        }

        private void DrawSequenceGraph()
        {
            if (sequence.Count < 2)
                return;

            double maxX = sequence.Count - 1;
            double maxY = sequence.Max();
            double minY = sequence.Min();

            double xStep = graphCanvas.ActualWidth / maxX;
            double yStep = graphCanvas.ActualHeight / (maxY - minY);

            Polyline polyline = new Polyline
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            for (int i = 0; i < sequence.Count; i++)
            {
                double x = i * xStep;
                double y = graphCanvas.ActualHeight - ((sequence[i] - minY) * yStep);

                polyline.Points.Add(new Point(x, y));
            }

            graphCanvas.Children.Add(polyline);
        }
        private void CheckGeometricProgression()
        {
            if (sequence.Count < 3)
            {
                MessageBox.Show("Недостаточно элементов для проверки геометрической прогрессии.");
                return;
            }

            bool isGeometricProgression = true;
            double ratio = sequence[1] / sequence[0]; 

            for (int i = 2; i < sequence.Count; i++)
            {
                if (sequence[i] / sequence[i - 1] != ratio)
                {
                    isGeometricProgression = false;
                    break;  
                }
            } //сравниваем по парно разделенные друг на друга элементы

            if (isGeometricProgression)
            {
                MessageBox.Show("Последовательность является геометрической прогрессией.");
            }
            else
            {
                MessageBox.Show("Последовательность не является геометрической прогрессией.");
            }
        }
    }
}
