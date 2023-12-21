using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EliseevPractica
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        public List<double> sequence = new List<double>();
        private void CheckProgression_Click(object sender, RoutedEventArgs e)
        {

            sequence.Clear();
            graphCanvas.Children.Clear();

            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                double randomValue = Math.Round((rnd.NextDouble() * 20.0) - 10.9, 2);
                sequence.Add(randomValue);
            }
            string numbers = string.Join("; ", sequence);
            inputBox.Text = numbers;

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

                // Добавление меток на оси X
                TextBlock label = new TextBlock
                {
                    Text = i.ToString(),
                    Margin = new Thickness(x - 10, graphCanvas.ActualHeight + 5, 0, 0)
                };
                graphCanvas.Children.Add(label);
            }

            graphCanvas.Children.Add(polyline);

            // Добавление меток на оси Y

            for (int i = (int)minY; i <= maxY; i++)
            {
                double y = graphCanvas.ActualHeight - ((i - minY) * yStep);

                TextBlock label = new TextBlock
                {
                    Width = 20,
                    TextAlignment = TextAlignment.Right,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Text = i.ToString(),
                    Margin = new Thickness(-25, y - 10, -45, -20) // Измененное значение отступа
                };
                graphCanvas.Children.Add(label);
            }
        }

        private void CheckGeometricProgression()
        {
            if (sequence.Count < 3)
            {
                MessageBox.Show("Недостаточно элементов для проверки геометрической прогрессии.");
                return;
            }
            if (MainClass.checkGeometricProgression(sequence))
            {
                MessageBox.Show("Последовательность является геометрической прогрессией.");
            }
            else MessageBox.Show("Последовательность не является геометрической прогрессией.");
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Задание: Определить является ли введенная последовательность чисел геометрической прогрессией. Построить график изменения последовательности (график строится по мере ввода данных).\nРазработчик: Елисеев Данила");
        }
    }
}

