using Microsoft.Office.Interop.Word;
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
using System.Xml.Linq;

namespace Cinema_Desktop.Pages.ForControler
{
    /// <summary>
    /// Логика взаимодействия для Controler.xaml
    /// </summary>
    public partial class Controler : System.Windows.Controls.Page
    {
        CinemaEntities db;
        int Number_tiket = 0;
        public Controler()
        {
            InitializeComponent();
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {

            int messege = 0;
            Number_tiket = Convert.ToInt32(wwodkode.Text);
            using (var db = new CinemaEntities())
            {
                foreach (Tickets tiket in db.Tickets)
                {
                    if (wwodkode.Text == tiket.tickets_id.ToString())
                    {
                        
                        foreach (Session ses in db.Session)
                        {
                            if (tiket.session_id == ses.session_id)
                            {
                                messege++;
                                Information.Visibility = Visibility.Visible;
                                Dateinfo.Content = "Дата: " + ses.date_time.ToString("HH:mm dd.MM.yyyy");
                                Zalinfo.Content = "Зал: " + ses.number_zal.ToString();
                                Readinfo.Content = "Ряд: " + tiket.row_number.ToString();
                                Mestoinfo.Content = "Место: " + tiket.seat_number.ToString();
                                foreach (Users user in db.Users)
                                {
                                    if (tiket.user_id == user.user_id)
                                    {
                                        Surnamrinfo.Content = "Фамилия: " + user.surname;
                                    }
                                }
                                foreach (Films film in db.Films)
                                {
                                    if (ses.film_id == film.film_id)
                                    {
                                        FilmInfo.Content = "Фильм: " + film.name;
                                    }
                                }
                                if ((bool)tiket.check_control == false)
                                {
                                    Btn_Proshel.IsEnabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Отметка проедена уде поставлена");
                                }

                            }
                        }

                    }

                }

            }
            if (messege == 0)
                MessageBox.Show("Билет не найден");
            messege++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AdminDedactFilms gos = new AdminDedactFilms();
            //this.Hide();
            //gos.Show();
        }
        private void Proshel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db = new CinemaEntities();
                Tickets tiket = db.Tickets.Find(Number_tiket);
                tiket.check_control = true;
                db.SaveChanges();
                Btn_Proshel.IsEnabled = false;
                MessageBox.Show("Отметка посталвена");
                //  Btn_Proshel.Enabled = false;
            }
            catch(Exception ex) {
                MessageBox.Show("Erorr" + ex, "Erorr");
            }
          
        }
    }
}

