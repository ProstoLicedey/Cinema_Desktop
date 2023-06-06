using Cinema_Desktop.Class;
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
    /// Логика взаимодействия для Zal.xaml
    /// </summary>
    public partial class Zal : Page
    {
        ThisInfo sm = new ThisInfo();
        public Zal()
        {
            InitializeComponent();
            try
            {
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
                                    Prise.Content = "Цена  " + ses.price.ToString("#") + "₽";
                                    zal.Content = "Зал  " + ses.number_zal;
                                    Age.Content = film.age_restriction.ToString() + "+";
                                    try
                                    {
                                        if (film.image != null)
                                            ImageFilm.ImageSource = BitmapFrame.Create(new Uri(@"pack://application:,,,/image/" + film.image));
                                    }
                                    catch
                                    {
                                        ImageFilm.ImageSource = BitmapFrame.Create(new Uri(@"pack://application:,,,/image/nophoto1.png"));
                                    }
                                }
                            }
                        }
                    }

                    foreach (Tickets tiket in db.Tickets)
                    {

                        if (ThisInfo.idSesion == tiket.session_id)
                        {
                            int HelpR = tiket.row_number;
                            int HelpM = tiket.seat_number;

                            if (HelpR == 1 & HelpM == 1)
                                r1m1.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 2)
                                r1m2.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 3)
                                r1m3.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 4)
                                r1m4.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 5)
                                r1m5.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 6)
                                r1m6.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 7)
                                r1m7.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 8)
                                r1m8.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 9)
                                r1m9.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 10)
                                r1m10.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 11)
                                r1m11.Background = Brushes.DarkRed;
                            if (HelpR == 1 & HelpM == 12)
                                r1m12.Background = Brushes.DarkRed;


                            if (HelpR == 2 & HelpM == 1)
                                r2m1.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 2)
                                r2m2.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 3)
                                r2m3.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 4)
                                r2m4.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 5)
                                r2m5.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 6)
                                r2m6.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 7)
                                r2m7.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 8)
                                r2m8.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 9)
                                r2m9.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 10)
                                r2m10.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 11)
                                r2m11.Background = Brushes.DarkRed;
                            if (HelpR == 2 & HelpM == 12)
                                r2m12.Background = Brushes.DarkRed;


                            if (HelpR == 3 & HelpM == 1)
                                r3m1.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 2)
                                r3m2.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 3)
                                r3m3.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 4)
                                r3m4.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 5)
                                r3m5.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 6)
                                r3m6.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 7)
                                r3m7.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 8)
                                r3m8.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 9)
                                r3m9.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 10)
                                r3m10.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 11)
                                r3m11.Background = Brushes.DarkRed;
                            if (HelpR == 3 & HelpM == 12)
                                r3m12.Background = Brushes.DarkRed;


                            if (HelpR == 4 & HelpM == 1)
                                r4m1.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 2)
                                r4m2.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 3)
                                r4m3.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 4)
                                r4m4.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 5)
                                r4m5.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 6)
                                r4m6.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 7)
                                r4m7.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 8)
                                r4m8.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 9)
                                r4m9.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 10)
                                r4m10.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 11)
                                r4m11.Background = Brushes.DarkRed;
                            if (HelpR == 4 & HelpM == 12)
                                r4m12.Background = Brushes.DarkRed;


                            if (HelpR == 5 & HelpM == 1)
                                r5m1.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 2)
                                r5m2.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 3)
                                r5m3.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 4)
                                r5m4.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 5)
                                r5m5.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 6)
                                r5m6.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 7)
                                r5m7.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 8)
                                r5m8.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 9)
                                r5m9.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 10)
                                r5m10.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 11)
                                r5m11.Background = Brushes.DarkRed;
                            if (HelpR == 5 & HelpM == 12)
                                r5m12.Background = Brushes.DarkRed;


                            if (HelpR == 6 & HelpM == 1)
                                r6m1.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 2)
                                r6m2.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 3)
                                r6m3.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 4)
                                r6m4.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 5)
                                r6m5.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 6)
                                r6m6.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 7)
                                r6m7.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 8)
                                r6m8.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 9)
                                r6m9.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 10)
                                r6m10.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 11)
                                r6m11.Background = Brushes.DarkRed;
                            if (HelpR == 6 & HelpM == 12)
                                r6m12.Background = Brushes.DarkRed;


                            if (HelpR == 7 & HelpM == 1)
                                r7m1.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 2)
                                r7m2.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 3)
                                r7m3.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 4)
                                r7m4.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 5)
                                r7m5.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 6)
                                r7m6.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 7)
                                r7m7.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 8)
                                r7m8.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 9)
                                r7m9.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 10)
                                r7m10.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 11)
                                r7m11.Background = Brushes.DarkRed;
                            if (HelpR == 7 & HelpM == 12)
                                r7m12.Background = Brushes.DarkRed;


                            if (HelpR == 8 & HelpM == 1)
                                r8m1.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 2)
                                r8m2.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 3)
                                r8m3.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 4)
                                r8m4.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 5)
                                r8m5.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 6)
                                r8m6.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 7)
                                r8m7.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 8)
                                r8m8.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 9)
                                r8m9.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 10)
                                r8m10.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 11)
                                r8m11.Background = Brushes.DarkRed;
                            if (HelpR == 8 & HelpM == 12)
                                r8m12.Background = Brushes.DarkRed;


                            if (HelpR == 9 & HelpM == 1)
                                r9m1.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 2)
                                r9m2.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 3)
                                r9m3.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 4)
                                r9m4.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 5)
                                r9m5.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 6)
                                r9m6.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 7)
                                r9m7.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 8)
                                r9m8.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 9)
                                r9m9.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 10)
                                r9m10.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 11)
                                r9m11.Background = Brushes.DarkRed;
                            if (HelpR == 9 & HelpM == 12)
                                r9m12.Background = Brushes.DarkRed;


                            if (HelpR == 10 & HelpM == 1)
                                r10m1.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 2)
                                r10m2.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 3)
                                r10m3.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 4)
                                r10m4.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 5)
                                r10m5.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 6)
                                r10m6.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 7)
                                r10m7.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 8)
                                r10m8.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 9)
                                r10m9.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 10)
                                r10m10.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 11)
                                r10m11.Background = Brushes.DarkRed;
                            if (HelpR == 10 & HelpM == 12)
                                r10m12.Background = Brushes.DarkRed;
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Критическая ошибка. Пожалуйста перезаупстите приложение!");
            }
        }

        private void mesto_click(object sender, RoutedEventArgs e)
        {

            var this_mest = e.OriginalSource as Button;
            if (this_mest.Background == Brushes.Green & ThisInfo.colmest < 5)
            {
                this_mest.Background = Brushes.Gold;
                ThisInfo.colmest++;
                LabelCol.Content = "Выбраных мест: " + ThisInfo.colmest;

                int HelpR = 0;
                int HelpM = 0;

                //обработчики ряда вспомогательные добовление
                if (this_mest.Name == "r1m1" | this_mest.Name == "r1m2" | this_mest.Name == "r1m3" | this_mest.Name == "r1m4" | this_mest.Name == "r1m5" | this_mest.Name == "r1m6" | this_mest.Name == "r1m7" | this_mest.Name == "r1m8" | this_mest.Name == "r1m9" | this_mest.Name == "r1m10" | this_mest.Name == "r1m11" | this_mest.Name == "r1m12")
                {
                    HelpR = 1;
                }
                else if (this_mest.Name == "r2m1" | this_mest.Name == "r2m2" | this_mest.Name == "r2m3" | this_mest.Name == "r24" | this_mest.Name == "r2m5" | this_mest.Name == "r2m6" | this_mest.Name == "r2m7" | this_mest.Name == "r2m8" | this_mest.Name == "r2m9" | this_mest.Name == "r2m10" | this_mest.Name == "r2m11" | this_mest.Name == "r2m12")
                {
                    HelpR = 2;
                }
                else if (this_mest.Name == "r3m1" | this_mest.Name == "r3m2" | this_mest.Name == "r3m3" | this_mest.Name == "r3m4" | this_mest.Name == "r3m5" | this_mest.Name == "r3m6" | this_mest.Name == "r3m7" | this_mest.Name == "r3m8" | this_mest.Name == "r3m9" | this_mest.Name == "r3m10" | this_mest.Name == "r3m11" | this_mest.Name == "r3m12")
                {
                    HelpR = 3;
                }
                else if (this_mest.Name == "r4m1" | this_mest.Name == "r4m2" | this_mest.Name == "r4m3" | this_mest.Name == "r4m4" | this_mest.Name == "r4m5" | this_mest.Name == "r4m6" | this_mest.Name == "r4m7" | this_mest.Name == "r4m8" | this_mest.Name == "r4m9" | this_mest.Name == "r4m10" | this_mest.Name == "r4m11" | this_mest.Name == "r4m12")
                {
                    HelpR = 4;
                }
                else if (this_mest.Name == "r5m1" | this_mest.Name == "r5m2" | this_mest.Name == "r5m3" | this_mest.Name == "r5m4" | this_mest.Name == "r5m5" | this_mest.Name == "r5m6" | this_mest.Name == "r5m7" | this_mest.Name == "r5m8" | this_mest.Name == "r5m9" | this_mest.Name == "r5m10" | this_mest.Name == "r5m11" | this_mest.Name == "r5m12")
                {
                    HelpR = 5;
                }
                else if (this_mest.Name == "r6яm1" | this_mest.Name == "r6m2" | this_mest.Name == "r6m3" | this_mest.Name == "r6m4" | this_mest.Name == "r6m5" | this_mest.Name == "r6m6" | this_mest.Name == "r6m7" | this_mest.Name == "r6m8" | this_mest.Name == "r6m9" | this_mest.Name == "r6m10" | this_mest.Name == "r6m11" | this_mest.Name == "r6m12")
                {
                    HelpR = 6;
                }
                else if (this_mest.Name == "r7m1" | this_mest.Name == "r7m2" | this_mest.Name == "r7m3" | this_mest.Name == "r7m4" | this_mest.Name == "r7m5" | this_mest.Name == "r7m6" | this_mest.Name == "r7m7" | this_mest.Name == "r7m8" | this_mest.Name == "r7m9" | this_mest.Name == "r7m10" | this_mest.Name == "r7m11" | this_mest.Name == "r7m12")
                {
                    HelpR = 7;
                }
                else if (this_mest.Name == "r8m1" | this_mest.Name == "r8m2" | this_mest.Name == "r8m3" | this_mest.Name == "r8m4" | this_mest.Name == "r8m5" | this_mest.Name == "r8m6" | this_mest.Name == "r8m7" | this_mest.Name == "r8m8" | this_mest.Name == "r8m9" | this_mest.Name == "r8m10" | this_mest.Name == "r8m11" | this_mest.Name == "r8m12")
                {
                    HelpR = 8;
                }
                else if (this_mest.Name == "r9m1" | this_mest.Name == "r9m2" | this_mest.Name == "r9m3" | this_mest.Name == "r9m4" | this_mest.Name == "r9m5" | this_mest.Name == "r9m6" | this_mest.Name == "r9m7" | this_mest.Name == "r9m8" | this_mest.Name == "r9m9" | this_mest.Name == "r9m10" | this_mest.Name == "r9m11" | this_mest.Name == "r9m12")
                {
                    HelpR = 9;
                }
                else if (this_mest.Name == "r10m1" | this_mest.Name == "r10m2" | this_mest.Name == "r10m3" | this_mest.Name == "r10m4" | this_mest.Name == "r10m5" | this_mest.Name == "r10m6" | this_mest.Name == "r10m7" | this_mest.Name == "r10m8" | this_mest.Name == "r10m9" | this_mest.Name == "r10m10" | this_mest.Name == "r10m11" | this_mest.Name == "r10m12")
                {
                    HelpR = 10;
                }



                //обработчики места вспогательный добовление
                if (this_mest.Name == "r1m1" | this_mest.Name == "r2m1" | this_mest.Name == "r3m1" | this_mest.Name == "r4m1" | this_mest.Name == "r5m1" | this_mest.Name == "r6m1" | this_mest.Name == "r7m1" | this_mest.Name == "r8m1" | this_mest.Name == "r9m1" | this_mest.Name == "r10m1")
                {
                    HelpM = 1;
                }
                else if (this_mest.Name == "r1m2" | this_mest.Name == "r2m2" | this_mest.Name == "r3m2" | this_mest.Name == "r4m2" | this_mest.Name == "r5m2" | this_mest.Name == "r6m2" | this_mest.Name == "r7m2" | this_mest.Name == "r8m2" | this_mest.Name == "r9m2" | this_mest.Name == "r10m2")
                {
                    HelpM = 2;
                }
                else if (this_mest.Name == "r1m3" | this_mest.Name == "r2m3" | this_mest.Name == "r3m3" | this_mest.Name == "r4m3" | this_mest.Name == "r5m3" | this_mest.Name == "r6m3" | this_mest.Name == "r7m3" | this_mest.Name == "r8m3" | this_mest.Name == "r9m3" | this_mest.Name == "r10m3")
                {
                    HelpM = 3;
                }
                else if (this_mest.Name == "r1m4" | this_mest.Name == "r2m4" | this_mest.Name == "r3m4" | this_mest.Name == "r4m4" | this_mest.Name == "r5m4" | this_mest.Name == "r6m4" | this_mest.Name == "r7m4" | this_mest.Name == "r8m4" | this_mest.Name == "r9m4" | this_mest.Name == "r10m4")
                {
                    HelpM = 4;
                }
                else if (this_mest.Name == "r1m5" | this_mest.Name == "r2m5" | this_mest.Name == "r3m5" | this_mest.Name == "r4m5" | this_mest.Name == "r5m5" | this_mest.Name == "r6m5" | this_mest.Name == "r7m5" | this_mest.Name == "r8m5" | this_mest.Name == "r9m5" | this_mest.Name == "r10m5")
                {
                    HelpM = 5;
                }
                else if (this_mest.Name == "r1m6" | this_mest.Name == "r2m6" | this_mest.Name == "r3m6" | this_mest.Name == "r4m6" | this_mest.Name == "r5m6" | this_mest.Name == "r6m6" | this_mest.Name == "r7m6" | this_mest.Name == "r8m6" | this_mest.Name == "r9m6" | this_mest.Name == "r10m6")
                {
                    HelpM = 6;
                }
                else if (this_mest.Name == "r1m7" | this_mest.Name == "r2m7" | this_mest.Name == "r3m7" | this_mest.Name == "r4m7" | this_mest.Name == "r5m7" | this_mest.Name == "r6m7" | this_mest.Name == "r7m7" | this_mest.Name == "r8m7" | this_mest.Name == "r9m7" | this_mest.Name == "r10m7")
                {
                    HelpM = 7;
                }
                else if (this_mest.Name == "r1m8" | this_mest.Name == "r2m8" | this_mest.Name == "r3m8" | this_mest.Name == "r4m8" | this_mest.Name == "r5m8" | this_mest.Name == "r6m8" | this_mest.Name == "r7m8" | this_mest.Name == "r8m8" | this_mest.Name == "r9m8" | this_mest.Name == "r10m8")
                {
                    HelpM = 8;
                }
                else if (this_mest.Name == "r1m9" | this_mest.Name == "r2m9" | this_mest.Name == "r3m9" | this_mest.Name == "r4m9" | this_mest.Name == "r5m9" | this_mest.Name == "r6m9" | this_mest.Name == "r7m9" | this_mest.Name == "r8m9" | this_mest.Name == "r9m9" | this_mest.Name == "r10m9")
                {
                    HelpM = 9;
                }
                else if (this_mest.Name == "r1m10" | this_mest.Name == "r2m10" | this_mest.Name == "r3m10" | this_mest.Name == "r4m10" | this_mest.Name == "r5m10" | this_mest.Name == "r6m10" | this_mest.Name == "r7m10" | this_mest.Name == "r8m10" | this_mest.Name == "r9m10" | this_mest.Name == "r10m10")
                {
                    HelpM = 10;
                }
                else if (this_mest.Name == "r1m11" | this_mest.Name == "r2m11" | this_mest.Name == "r3m11" | this_mest.Name == "r4m11" | this_mest.Name == "r5m11" | this_mest.Name == "r6m11" | this_mest.Name == "r7m11" | this_mest.Name == "r8m11" | this_mest.Name == "r9m11" | this_mest.Name == "r10m11")
                {
                    HelpM = 11;
                }
                else if (this_mest.Name == "r1m12" | this_mest.Name == "r2m12" | this_mest.Name == "r3m12" | this_mest.Name == "r4m12" | this_mest.Name == "r5m12" | this_mest.Name == "r6m12" | this_mest.Name == "r7m12" | this_mest.Name == "r8m12" | this_mest.Name == "r9m12" | this_mest.Name == "r10m12")
                {
                    HelpM = 12;
                }

                //добовление в переменные хранения
                if (ThisInfo.saveR1 == 0 & ThisInfo.saveM1 == 0)
                {
                    ThisInfo.saveR1 = HelpR;
                    ThisInfo.saveM1 = HelpM;

                }
                else if (ThisInfo.saveR2 == 0 & ThisInfo.saveM2 == 0)
                {
                    ThisInfo.saveR2 = HelpR;
                    ThisInfo.saveM2 = HelpM;
                }
                else if (ThisInfo.saveR3 == 0 & ThisInfo.saveM3 == 0)
                {
                    ThisInfo.saveR3 = HelpR;
                    ThisInfo.saveM3 = HelpM;
                }
                else if (ThisInfo.saveR4 == 0 & ThisInfo.saveM4 == 0)
                {
                    ThisInfo.saveR4 = HelpR;
                    ThisInfo.saveM4 = HelpM;
                }
                else if (ThisInfo.saveR5 == 0 & ThisInfo.saveM5 == 0)
                {
                    ThisInfo.saveR5 = HelpR;
                    ThisInfo.saveM5 = HelpM;
                }




            }
            else if (this_mest.Background == Brushes.Gold)
            {
                this_mest.Background = Brushes.Green;
                ThisInfo.colmest--;
                LabelCol.Content = "Выбраных мест: " + ThisInfo.colmest;

                int HelpR = 0;
                int HelpM = 0;

                //обработчики ряда вспомогательные удаление
                if (this_mest.Name == "r1m1" | this_mest.Name == "r1m2" | this_mest.Name == "r1m3" | this_mest.Name == "r1m4" | this_mest.Name == "r1m5" | this_mest.Name == "r1m6" | this_mest.Name == "r1m7" | this_mest.Name == "r1m8" | this_mest.Name == "r1m9" | this_mest.Name == "r1m10" | this_mest.Name == "r1m11" | this_mest.Name == "r1m12")
                {
                    HelpR = 1;
                }
                else if (this_mest.Name == "r2m1" | this_mest.Name == "r2m2" | this_mest.Name == "r2m3" | this_mest.Name == "r214" | this_mest.Name == "r2m5" | this_mest.Name == "r2m6" | this_mest.Name == "r2m7" | this_mest.Name == "r2m8" | this_mest.Name == "r2m9" | this_mest.Name == "r2m10" | this_mest.Name == "r2m11" | this_mest.Name == "r2m12")
                {
                    HelpR = 2;
                }
                else if (this_mest.Name == "r3m1" | this_mest.Name == "r3m2" | this_mest.Name == "r3m3" | this_mest.Name == "r3m4" | this_mest.Name == "r3m5" | this_mest.Name == "r3m6" | this_mest.Name == "r3m7" | this_mest.Name == "r3m8" | this_mest.Name == "r3m9" | this_mest.Name == "r3m10" | this_mest.Name == "r3m11" | this_mest.Name == "r3m12")
                {
                    HelpR = 3;
                }
                else if (this_mest.Name == "r4m1" | this_mest.Name == "r4m2" | this_mest.Name == "r4m3" | this_mest.Name == "r4m4" | this_mest.Name == "r4m5" | this_mest.Name == "r4m6" | this_mest.Name == "r4m7" | this_mest.Name == "r4m8" | this_mest.Name == "r4m9" | this_mest.Name == "r4m10" | this_mest.Name == "r4m11" | this_mest.Name == "r4m12")
                {
                    HelpR = 4;
                }
                else if (this_mest.Name == "r5m1" | this_mest.Name == "r5m2" | this_mest.Name == "r5m3" | this_mest.Name == "r5m4" | this_mest.Name == "r5m5" | this_mest.Name == "r5m6" | this_mest.Name == "r5m7" | this_mest.Name == "r5m8" | this_mest.Name == "r5m9" | this_mest.Name == "r5m10" | this_mest.Name == "r5m11" | this_mest.Name == "r5m12")
                {
                    HelpR = 5;
                }
                else if (this_mest.Name == "r6яm1" | this_mest.Name == "r6m2" | this_mest.Name == "r6m3" | this_mest.Name == "r6m4" | this_mest.Name == "r6m5" | this_mest.Name == "r6m6" | this_mest.Name == "r6m7" | this_mest.Name == "r6m8" | this_mest.Name == "r6m9" | this_mest.Name == "r6m10" | this_mest.Name == "r6m11" | this_mest.Name == "r6m12")
                {
                    HelpR = 6;
                }
                else if (this_mest.Name == "r7m1" | this_mest.Name == "r7m2" | this_mest.Name == "r7m3" | this_mest.Name == "r7m4" | this_mest.Name == "r7m5" | this_mest.Name == "r7m6" | this_mest.Name == "r7m7" | this_mest.Name == "r7m8" | this_mest.Name == "r7m9" | this_mest.Name == "r7m10" | this_mest.Name == "r7m11" | this_mest.Name == "r7m12")
                {
                    HelpR = 7;
                }
                else if (this_mest.Name == "r8m1" | this_mest.Name == "r8m2" | this_mest.Name == "r8m3" | this_mest.Name == "r8m4" | this_mest.Name == "r8m5" | this_mest.Name == "r8m6" | this_mest.Name == "r8m7" | this_mest.Name == "r8m8" | this_mest.Name == "r8m9" | this_mest.Name == "r8m10" | this_mest.Name == "r8m11" | this_mest.Name == "r8m12")
                {
                    HelpR = 8;
                }
                else if (this_mest.Name == "r9m1" | this_mest.Name == "r9m2" | this_mest.Name == "r9m3" | this_mest.Name == "r9m4" | this_mest.Name == "r9m5" | this_mest.Name == "r9m6" | this_mest.Name == "r9m7" | this_mest.Name == "r9m8" | this_mest.Name == "r9m9" | this_mest.Name == "r9m10" | this_mest.Name == "r9m11" | this_mest.Name == "r9m12")
                {
                    HelpR = 9;
                }
                else if (this_mest.Name == "r10m1" | this_mest.Name == "r10m2" | this_mest.Name == "r10m3" | this_mest.Name == "r10m4" | this_mest.Name == "r10m5" | this_mest.Name == "r10m6" | this_mest.Name == "r10m7" | this_mest.Name == "r10m8" | this_mest.Name == "r10m9" | this_mest.Name == "r10m10" | this_mest.Name == "r10m11" | this_mest.Name == "r10m12")
                {
                    HelpR = 10;
                }



                //обработчики места вспогательный удаление
                if (this_mest.Name == "r1m1" | this_mest.Name == "r2m1" | this_mest.Name == "r3m1" | this_mest.Name == "r4m1" | this_mest.Name == "r5m1" | this_mest.Name == "r6m1" | this_mest.Name == "r7m1" | this_mest.Name == "r8m1" | this_mest.Name == "r9m1" | this_mest.Name == "r10m1")
                {
                    HelpM = 1;
                }
                else if (this_mest.Name == "r1m2" | this_mest.Name == "r2m2" | this_mest.Name == "r3m2" | this_mest.Name == "r4m2" | this_mest.Name == "r5m2" | this_mest.Name == "r6m2" | this_mest.Name == "r7m2" | this_mest.Name == "r8m2" | this_mest.Name == "r9m2" | this_mest.Name == "r10m2")
                {
                    HelpM = 2;
                }
                else if (this_mest.Name == "r1m3" | this_mest.Name == "r2m3" | this_mest.Name == "r3m3" | this_mest.Name == "r4m3" | this_mest.Name == "r5m3" | this_mest.Name == "r6m3" | this_mest.Name == "r7m3" | this_mest.Name == "r8m3" | this_mest.Name == "r9m3" | this_mest.Name == "r10m3")
                {
                    HelpM = 3;
                }
                else if (this_mest.Name == "r1m4" | this_mest.Name == "r2m4" | this_mest.Name == "r3m4" | this_mest.Name == "r4m4" | this_mest.Name == "r5m4" | this_mest.Name == "r6m4" | this_mest.Name == "r7m4" | this_mest.Name == "r8m4" | this_mest.Name == "r9m4" | this_mest.Name == "r10m4")
                {
                    HelpM = 4;
                }
                else if (this_mest.Name == "r1m5" | this_mest.Name == "r2m5" | this_mest.Name == "r3m5" | this_mest.Name == "r4m5" | this_mest.Name == "r5m5" | this_mest.Name == "r6m5" | this_mest.Name == "r7m5" | this_mest.Name == "r8m5" | this_mest.Name == "r9m5" | this_mest.Name == "r10m5")
                {
                    HelpM = 5;
                }
                else if (this_mest.Name == "r1m6" | this_mest.Name == "r2m6" | this_mest.Name == "r3m6" | this_mest.Name == "r4m6" | this_mest.Name == "r5m6" | this_mest.Name == "r6m6" | this_mest.Name == "r7m6" | this_mest.Name == "r8m6" | this_mest.Name == "r9m6" | this_mest.Name == "r10m6")
                {
                    HelpM = 6;
                }
                else if (this_mest.Name == "r1m7" | this_mest.Name == "r2m7" | this_mest.Name == "r3m7" | this_mest.Name == "r4m7" | this_mest.Name == "r5m7" | this_mest.Name == "r6m7" | this_mest.Name == "r7m7" | this_mest.Name == "r8m7" | this_mest.Name == "r9m7" | this_mest.Name == "r10m7")
                {
                    HelpM = 7;
                }
                else if (this_mest.Name == "r1m8" | this_mest.Name == "r2m8" | this_mest.Name == "r3m8" | this_mest.Name == "r4m8" | this_mest.Name == "r5m8" | this_mest.Name == "r6m8" | this_mest.Name == "r7m8" | this_mest.Name == "r8m8" | this_mest.Name == "r9m8" | this_mest.Name == "r10m8")
                {
                    HelpM = 8;
                }
                else if (this_mest.Name == "r1m9" | this_mest.Name == "r2m9" | this_mest.Name == "r3m9" | this_mest.Name == "r4m9" | this_mest.Name == "r5m9" | this_mest.Name == "r6m9" | this_mest.Name == "r7m9" | this_mest.Name == "r8m9" | this_mest.Name == "r9m9" | this_mest.Name == "r10m9")
                {
                    HelpM = 9;
                }
                else if (this_mest.Name == "r1m10" | this_mest.Name == "r2m10" | this_mest.Name == "r3m10" | this_mest.Name == "r4m10" | this_mest.Name == "r5m10" | this_mest.Name == "r6m10" | this_mest.Name == "r7m10" | this_mest.Name == "r8m10" | this_mest.Name == "r9m10" | this_mest.Name == "r10m10")
                {
                    HelpM = 10;
                }
                else if (this_mest.Name == "r1m11" | this_mest.Name == "r2m11" | this_mest.Name == "r3m11" | this_mest.Name == "r4m11" | this_mest.Name == "r5m11" | this_mest.Name == "r6m11" | this_mest.Name == "r7m11" | this_mest.Name == "r8m11" | this_mest.Name == "r9m11" | this_mest.Name == "r10m11")
                {
                    HelpM = 11;
                }
                else if (this_mest.Name == "r1m12" | this_mest.Name == "r2m12" | this_mest.Name == "r3m12" | this_mest.Name == "r4m12" | this_mest.Name == "r5m12" | this_mest.Name == "r6m12" | this_mest.Name == "r7m12" | this_mest.Name == "r8m12" | this_mest.Name == "r9m12" | this_mest.Name == "r10m12")
                {
                    HelpM = 12;
                }

                //сравнение Хелперов с сохр. значениями
                if (HelpR == ThisInfo.saveR1 & HelpM == ThisInfo.saveM1)
                {
                    ThisInfo.saveR1 = 0;
                    ThisInfo.saveM1 = 0;
                }
                else if (HelpR == ThisInfo.saveR2 & HelpM == ThisInfo.saveM2)
                {
                    ThisInfo.saveR2 = 0;
                    ThisInfo.saveM2 = 0;
                }
                else if (HelpR == ThisInfo.saveR3 & HelpM == ThisInfo.saveM3)
                {
                    ThisInfo.saveR3 = 0;
                    ThisInfo.saveM3 = 0;
                }
                else if (HelpR == ThisInfo.saveR4 & HelpM == ThisInfo.saveM4)
                {
                    ThisInfo.saveR4 = 0;
                    ThisInfo.saveM4 = 0;
                }
                else if (HelpR == ThisInfo.saveR5 & HelpM == ThisInfo.saveM5)
                {
                    ThisInfo.saveR5 = 0;
                    ThisInfo.saveM5 = 0;
                }


            }

            else if (ThisInfo.colmest == 5)
            {
                MessageBox.Show("Нельзя оформить более 5 билетов одновременно");
            }

        }
      

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var rd1 = Read1.Children.OfType<Button>().ToList();
            rd1.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd2 = Read2.Children.OfType<Button>().ToList();
            rd2.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd3 = Read3.Children.OfType<Button>().ToList();
            rd3.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd4 = Read4.Children.OfType<Button>().ToList();
            rd4.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd5 = Read5.Children.OfType<Button>().ToList();
            rd5.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd6 = Read6.Children.OfType<Button>().ToList();
            rd6.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd7 = Read7.Children.OfType<Button>().ToList();
            rd7.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd8 = Read8.Children.OfType<Button>().ToList();
            rd8.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd9 = Read9.Children.OfType<Button>().ToList();
            rd9.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });
            var rd10 = Read10.Children.OfType<Button>().ToList();
            rd10.ForEach(btn => {
                if (btn.Background == Brushes.Gold)
                    btn.Background = Brushes.Green;
            });

            ThisInfo.saveR1 = 0;
            ThisInfo.saveM1 = 0;
            ThisInfo.saveR2 = 0;
            ThisInfo.saveM2 = 0;
            ThisInfo.saveR3 = 0;
            ThisInfo.saveM3 = 0;
            ThisInfo.saveR4 = 0;
            ThisInfo.saveM4 = 0;
            ThisInfo.saveR5 = 0;
            ThisInfo.saveM5 = 0;

            ThisInfo.colmest = 0;
            LabelCol.Content = "Выбраных мест: " + ThisInfo.colmest;

        }

        private void Ofform(object sender, RoutedEventArgs e)
        {

           
            if (ThisInfo.colmest > 0 & ThisInfo.colmest < 6)
            {
                ThisInfo.MainFrame.Navigate(new Offormlenie());
            }
            else
            {
                MessageBox.Show("Пожалуйста выбирите места");
            }

        }
     

    }
}
