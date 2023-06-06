using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Cinema_Desktop.Pages.ForAdmin
{
    /// <summary>
    /// Логика взаимодействия для SesCrudPage.xaml
    /// </summary>
    public partial class SesCrudPage : Page
    {
        CinemaEntities db;
        public SesCrudPage()
        {
            InitializeComponent();


            grid.ItemsSource = CinemaEntities.GetContext().Session.ToList();
        


        }
        //public List<Films> InitRead()
        //{
        //    using (var db = new CinemaEntities())
        //    {
        //        // Films films= new Films();
        //        //  CinemaEntities1 db;
        //        // db = new CinemaEntities1();
        //        db.Films.Load();
        //        var connect = db.Films.Local.ToList();
        //        // DataGrids.ItemsSource = db.Films.Local.ToBindingList();
        //        return connect;
        //    }


        //}


        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db = new CinemaEntities();
                CuSesWin cu = new CuSesWin();
              
                Session session= new Session();
                if (cu.ShowDialog() == true)
                {

                    session.film_id = cu.FilmVv.SelectedIndex;
                    session.price = Convert.ToInt32(cu.priceV.Text);

                    var cultureInfo = new CultureInfo("de-DE");
                   // string dateString = "12 Juni 2008";
                    //session.date_time = DateTime.Parse(cu.DateV.Text, cultureInfo,
                                          //          DateTimeStyles.NoCurrentDateDefault);
                    session.date_time = new DateTime(2023 , 4, 30, 20, 30, 00); // год - месяц - день - час - минута - секунда //cu.DateV.GetValue.Date;
                    session.number_zal = Convert.ToInt32(cu.zal.Text);
                }


                SaveCreate(session);

                db.Session.Load();
                grid.ItemsSource = db.Session.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr \n" + ex);
            }


        }
        public bool SaveCreate(Session session)
        {
            try
            {
                using (var db = new CinemaEntities())
                {
                    db.Session.Add(session);
                    db.SaveChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db = new CinemaEntities();
                int index = grid.SelectedIndex;
                var ci = new DataGridCellInfo(grid.Items[index], grid.Columns[0]);
                var content = (ci.Column.GetCellContent(ci.Item) as TextBlock).Text;

                //MessageBox.Show(content.Text);

                DeleteCreate(Convert.ToInt32(content));
                db.Films.Load();
                grid.ItemsSource = db.Films.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr \n" + ex);
            }
        }

        public void DeleteCreate(int id)
        {

            using (var db = new CinemaEntities())
            {
                Session session = db.Session.Find(id);
                db.Session.Remove(session);
                db.SaveChanges();


            }
        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                db = new CinemaEntities();
                CuSesWin cu = new CuSesWin();


                int index = grid.SelectedIndex;
                var ci = new DataGridCellInfo(grid.Items[index], grid.Columns[0]);
                var content = (ci.Column.GetCellContent(ci.Item) as TextBlock).Text;

                //MessageBox.Show(content.Text);
                Session session = db.Session.Find(Convert.ToInt32(content));

                cu.FilmVv.Text = session.film_id.ToString();
                cu.zal.Text = session.number_zal.ToString();
                cu.priceV.Text = session.price.ToString();
                cu.DateV.Text = session.date_time.ToString();

                if (cu.ShowDialog() == true)
                {

                    //films.name = cu.NameF.Text;
                    //films.description = cu.DicsF.Text;
                    //films.age_restriction = Convert.ToInt32(cu.AgeF.Text);
                    //films.image = cu.ImgF.Text;
                    SaveApdate(content, Convert.ToInt32(cu.FilmVv.SelectedIndex), Convert.ToInt32(cu.priceV.Text) , new DateTime(2023, 7, 20, 18, 30, 00), Convert.ToInt32(cu.zal.Text));
                }

                //db.SaveChanges();
                db.Films.Load();
                grid.ItemsSource = db.Films.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr \n" + ex);
            }
        }

        public bool SaveApdate(string content, int  film_id, int price, DateTime datetime,int  number_zal)
        {
            try
            {
                db = new CinemaEntities();
                Session ses1 = db.Session.Find(Convert.ToInt32(content));
                ses1.film_id = film_id;
                ses1.price = price;
                ses1.date_time = datetime;
                ses1.number_zal = number_zal;
                db.SaveChanges();
                db.Session.Load();
                return true;

            }
            catch
            {
                return false;
            }


        }
    }
}
