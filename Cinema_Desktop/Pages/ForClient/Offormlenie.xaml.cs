using Cinema_Desktop.Class;
using Cinema_Desktop.Pages.ForControler;
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

namespace Cinema_Desktop.Pages.ForClient
{
    /// <summary>
    /// Логика взаимодействия для Offormlenie.xaml
    /// </summary>
    public partial class Offormlenie : Page
    {
        public Offormlenie()
        {
            InitializeComponent();
            try
            {
                if (ThisInfo.saveR1 != 0 & ThisInfo.saveM1 != 0)
                {
                    r1.Content = "Ряд " + ThisInfo.saveR1;
                    m1.Content = "Место " + ThisInfo.saveM1;
                }
                if (ThisInfo.saveR2 != 0 & ThisInfo.saveM2 != 0)
                {
                    Brd2.Visibility = Visibility.Visible;
                    r2.Content = "Ряд " + ThisInfo.saveR2;
                    m2.Content = "Место " + ThisInfo.saveM2;
                }
                if (ThisInfo.saveR3 != 0 & ThisInfo.saveM3 != 0)
                {
                    Brd3.Visibility = Visibility.Visible;
                    r3.Content = "Ряд " + ThisInfo.saveR3;
                    m3.Content = "Место " + ThisInfo.saveM3;
                }
                if (ThisInfo.saveR4 != 0 & ThisInfo.saveM4 != 0)
                {
                    Brd4.Visibility = Visibility.Visible;
                    r4.Content = "Ряд " + ThisInfo.saveR4;
                    m4.Content = "Место " + ThisInfo.saveM4;
                }
                if (ThisInfo.saveR5 != 0 & ThisInfo.saveM5 != 0)
                {
                    Brd5.Visibility = Visibility.Visible;
                    r5.Content = "Ряд " + ThisInfo.saveR5;
                    m5.Content = "Место " + ThisInfo.saveM5;
                }

                using (var db = new CinemaEntities())
                {

                    foreach (Session ses in db.Session)
                    {
                        if (ThisInfo.idSesion == ses.session_id)
                        {
                            foreach (Films film in db.Films)
                            {
                                if (film.film_id == ses.film_id)
                                {
                                    NameFilm.Content = film.name;
                                    Date.Content = "Дата  " + ses.date_time.ToString("dd.MM.yyyy HH:mm");
                                    Prise1.Content = ses.price.ToString("#") + "₽";
                                    Prise2.Content = ses.price.ToString("#") + "₽";
                                    Prise3.Content = ses.price.ToString("#") + "₽";
                                    Prise4.Content = ses.price.ToString("#") + "₽";
                                    Prise5.Content = ses.price.ToString("#") + "₽";
                                    FinalPrise.Content = "ИТОГО:" + (Convert.ToInt32(ses.price) * ThisInfo.colmest) + "₽";
                                    try
                                    {
                                        if (film.image != null)
                                            PhotoFilm.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/image/" + film.image));
                                    }
                                    catch
                                    {
                                        PhotoFilm.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/image/nophoto1.png"));
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки, пожалйста перезагрузите приложение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
   

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {


            //MainWindow Session = new MainWindow();
            //this.Hide();
            //Session.Show();

        }

        private void Bron_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CinemaEntities())
                {
                    var tikets = new Tickets()
                    {
                        session_id = ThisInfo.idSesion,
                        row_number = ThisInfo.saveR1,
                        seat_number = ThisInfo.saveM1,
                        user_id = ThisInfo.idUser,
                        check_control= false
                    };
                    db.Tickets.Add(tikets);
                    db.SaveChanges();

                    if (ThisInfo.saveR2 != 0 & ThisInfo.saveM2 != 0)
                    {
                        tikets = new Tickets()
                        {
                            session_id = ThisInfo.idSesion,
                            row_number = ThisInfo.saveR2,
                            seat_number = ThisInfo.saveM2,
                            user_id = ThisInfo.idUser,
                            check_control = false

                        };
                        db.Tickets.Add(tikets);
                        db.SaveChanges();
                    }
                    if (ThisInfo.saveR3 != 0 & ThisInfo.saveM3 != 0)
                    {
                        tikets = new Tickets()
                        {
                            session_id = ThisInfo.idSesion,
                            row_number = ThisInfo.saveR3,
                            seat_number = ThisInfo.saveM3,
                            user_id = ThisInfo.idUser,
                            check_control = false
                        };
                        db.Tickets.Add(tikets);
                        db.SaveChanges();
                    }
                    if (ThisInfo.saveR4 != 0 & ThisInfo.saveM4 != 0)
                    {
                        tikets = new Tickets()
                        {
                            session_id = ThisInfo.idSesion,
                            row_number = ThisInfo.saveR4,
                            seat_number = ThisInfo.saveM4,
                            user_id = ThisInfo.idUser,
                            check_control = false
                        };
                        db.Tickets.Add(tikets);
                        db.SaveChanges();
                    }
                    if (ThisInfo.saveR5 != 0 & ThisInfo.saveM5 != 0)
                    {
                        tikets = new Tickets()
                        {
                            session_id = ThisInfo.idSesion,
                            row_number = ThisInfo.saveR5,
                            seat_number = ThisInfo.saveM5,
                            user_id = ThisInfo.idUser,
                            check_control = false
                        };
                        db.Tickets.Add(tikets);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Билет успешно забронирован");
                    foreach (Session ses in db.Session)
                    {
                        if (ThisInfo.idSesion == ses.session_id)
                        {
                        foreach (Films film in db.Films)
                        {
                            if (film.film_id == ses.film_id)
                            {
                                var word = new WordGeneration("biletcinema.docx");
                                var items = new Dictionary<string, string>
                                {
                                    {"<Number>", tikets.tickets_id.ToString()},
                                    {"<NameFilm>", film.name},
                                    {"<Date>", ses.date_time.ToString("dd.MM.yyyy HH:mm")},
                                    {"<Prise>", ses.price.ToString("#")},
                                    {"<Zal>", ses.number_zal.ToString()},
                                    {"<Read>", ThisInfo.saveR1.ToString()},
                                    {"<Mest>", ThisInfo.saveM1.ToString()},
                                };
                                word.Process(items);

                                ThisInfo.MainFrame.Navigate(new ProsmPage());
                                //this.Hide();
                                //Session.Show();

                            }
                        }
                    }
                    }
               }
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки, пожалйста перезагрузите приложение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow Session = new MainWindow();
                //this.Hide();
                //Session.Show();
            }
        }

    }
}
