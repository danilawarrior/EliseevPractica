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
using System.Windows.Shapes;

namespace EliseevPractica
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow() //da
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (loginTxtBl.Text == "admin" && passwordtxtTxtBl.Text == "12345")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                //открытие окна админа
            }
            else MessageBox.Show("Введите логин и пароль");
        }

        private void guest_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow();
            Close();
            userWindow.Show();   
        }
    }
}
