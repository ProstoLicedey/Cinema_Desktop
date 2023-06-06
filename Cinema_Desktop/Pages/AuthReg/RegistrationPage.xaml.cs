using Cinema_Desktop.Class;
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

namespace Cinema_Desktop.Pages.AuthReg
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void Registr_click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Surname.Text == "" || Name.Text == "" || Phone.Text == "" || Password.Password == "" || Date.Text == "" || Phone.Text.Length > 10)

                {
                    MessageBox.Show("Пожалуйста заполните все поля  и проверьте правильность их заполнения");
                }
                else if (Phone.Text.Length < 10)
                {
                    MessageBox.Show("Пожалуйста проверьте данные, номер телефона введен не верно");
                }
                else
                {
                    using (var db = new CinemaEntities())
                    {
                        var users = new Users()
                        {
                            surname = Surname.Text,
                            name = Name.Text,
                            phone_numb = Convert.ToInt64(Phone.Text),
                            date_birthday = DateTime.Parse(Date.Text),
                            password = GetHashString(Password.Password),
                            admin_check = 0
                        };

                        db.Users.Add(users);
                        db.SaveChanges();

                    }

                    MessageBox.Show("Аккаунт зарегестрирован)");
                    Surname.Clear(); Name.Clear(); Phone.Clear(); Password.Clear();

                    ThisInfo.MainFrame.Navigate(new AuthorizationPage());

                }
            }
            catch
            {
                MessageBox.Show("ОШибка регистрации");
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

        private void IfnotNumber(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
            if (Phone.Text.Length > 10)
            {
                Phone.Text = Phone.Text.Remove(10, 1);
            }
        }
    }
}
