using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
using Cinema_Desktop.Class;
using Cinema_Desktop.Pages;
using Cinema_Desktop.Pages.AuthReg;

namespace Cinema_Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.Seans());
            ThisInfo.MainFrame = MainFrame;
            //Manager.MainFrame = MainFrame;
        }
        private void WorkersZall(object sender, RoutedEventArgs e)
        {
            //Autorization Auth = new Autorization();
            //this.Hide();
            //Auth.Show();

        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            if (ThisInfo.idUser != 0)
            {
                MainFrame.Navigate(new Pages.ForClient.ProsmPage());
            }
            else
            {
                MessageBox.Show("Пожалуйста войдите в аккаунт");
            }
        }
        private void controller_Click(object sender, RoutedEventArgs e)
        {
            //controller Controller = new controller();
            //this.Hide();
            //Controller.Show();
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
           
                ThisInfo.MainFrame.Navigate(new AuthorizationPage());
       
}
        private void Seans_Click(object sender, RoutedEventArgs e)
        {
            
                ThisInfo.MainFrame.Navigate(new Seans());
           
        }
    }
}
