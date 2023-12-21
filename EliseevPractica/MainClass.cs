using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EliseevPractica
{
    static class MainClass
    {
        static public bool checkGeometricProgression(List<double> sequence)
        {
           

            bool isGeometricProgression = false;
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
                return true;
              
            }
            else
            {
                return false;
            }
        }
    }
}
