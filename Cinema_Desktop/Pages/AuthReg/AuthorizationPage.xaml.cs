using Cinema_Desktop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
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
using Cinema_Desktop.Pages.ForControler;
using Cinema_Desktop.Pages.ForAdmin;
namespace Cinema_Desktop.Pages.AuthReg
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void Registr(object sender, RoutedEventArgs e)
        {
            ThisInfo.MainFrame.Navigate(new RegistrationPage());

        }

        private void entrance(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CinemaEntities())
                {

                    foreach (Users user in db.Users)
                    {

                        if (Convert.ToInt64(Phone.Text) == user.phone_numb && GetHashString(Password.Password) == user.password)
                        {
                            MessageBox.Show("Вы вошли под учетноой записью " + user.name + " " + user.surname);
                            ThisInfo.idUser = user.user_id;
                            ThisInfo.AdminCheck = user.admin_check;


                            switch (ThisInfo.AdminCheck)
                            {
                                case 1:
                                    ThisInfo.MainFrame.Navigate(new Seans());
                                    break;
                                case 2:
                                    ThisInfo.MainFrame.Navigate(new Controler());
                                    break;
                                case 3:
                                    ThisInfo.MainFrame.Navigate(new FilmCrudPage());
                                    break;
                            }
                            return;

                        }

                    }
                    MessageBox.Show("Логин или пароль указан неверно!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки, пожалйста перезагрузите приложение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new
            MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }



        private void Exit(object sender, RoutedEventArgs e)
        {
            if (ThisInfo.idUser != 0)
            {

                MessageBoxResult result = MessageBox.Show(
                    "Вы точно хотите выйти из аккаунта?",
                    "Сообщение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                    );

                if (result == MessageBoxResult.Yes)
                {
                    ThisInfo.saveR1 = 0; ThisInfo.saveR2 = 0; ThisInfo.saveR3 = 0; ThisInfo.saveR4 = 0; ThisInfo.saveR5 = 0;
                    ThisInfo.saveM1 = 0; ThisInfo.saveM2 = 0; ThisInfo.saveM3 = 0; ThisInfo.saveM4 = 0; ThisInfo.saveM5 = 0;
                    ThisInfo.idUser = 0;
                    ThisInfo.AdminCheck = 0;
                    ThisInfo.idSesion = 0;
                    ThisInfo.colmest = 0;

                    MessageBox.Show("Вы вышли из аккаунта!");
                    //MainWindow Home = new MainWindow();
                    //this.Hide();
                    //Home.Show();
                    //this.Hide();
                    return;
                }
            }
        }

        private void IfnotNumber(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
            if (Phone.Text.Length > 10)
                Phone.Text = Phone.Text.Remove(10, 1);
        }
    }
}
