using Cinema_Desktop.Class;
using Cinema_Desktop.Pages.ForControler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для FilmCrudPage.xaml
    /// </summary>
       
    public partial class FilmCrudPage : Page
    {
        CinemaEntities db;
        public FilmCrudPage()
        {
            InitializeComponent();
            var conetent = InitRead();
            DataGrids.ItemsSource = conetent;


        }
        public List<Films> InitRead()
        {
            using (var db = new CinemaEntities())
            {
                // Films films= new Films();
                //  CinemaEntities1 db;
                // db = new CinemaEntities1();
                db.Films.Load();
                var connect = db.Films.Local.ToList();
                // DataGrids.ItemsSource = db.Films.Local.ToBindingList();
                return connect;
            }


        }
      

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db = new CinemaEntities();
                CuFilmWin cu = new CuFilmWin();
                Films films = new Films();
                if (cu.ShowDialog() == true)
                {

                    films.name = cu.NameF.Text;
                    films.description = cu.DicsF.Text;
                    films.age_restriction = Convert.ToInt32(cu.AgeF.Text);
                    films.image = cu.ImgF.Text;
                }


                SaveCreate(films);

                db.Films.Load();
                DataGrids.ItemsSource = db.Films.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr \n" + ex);
            }


        }
        public bool SaveCreate(Films films)
        {
            try
            {
                using (var db = new CinemaEntities())
                {
                    db.Films.Add(films);
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
                int index = DataGrids.SelectedIndex;
                var ci = new DataGridCellInfo(DataGrids.Items[index], DataGrids.Columns[0]);
                var content = (ci.Column.GetCellContent(ci.Item) as TextBlock).Text;

                //MessageBox.Show(content.Text);

                DeleteCreate(Convert.ToInt32(content));
                db.Films.Load();
                DataGrids.ItemsSource = db.Films.Local.ToBindingList();
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
                Films films = db.Films.Find(id);
                db.Films.Remove(films);
                db.SaveChanges();


            }
        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                db = new CinemaEntities();
                CuFilmWin cu = new CuFilmWin();


                int index = DataGrids.SelectedIndex;
                var ci = new DataGridCellInfo(DataGrids.Items[index], DataGrids.Columns[0]);
                var content = (ci.Column.GetCellContent(ci.Item) as TextBlock).Text;

                //MessageBox.Show(content.Text);
                Films films = db.Films.Find(Convert.ToInt32(content));

                cu.NameF.Text = films.name;
                cu.DicsF.Text = films.description;
                cu.AgeF.Text = films.age_restriction.ToString();
                cu.ImgF.Text = films.image;

                if (cu.ShowDialog() == true)
                {

                    //films.name = cu.NameF.Text;
                    //films.description = cu.DicsF.Text;
                    //films.age_restriction = Convert.ToInt32(cu.AgeF.Text);
                    //films.image = cu.ImgF.Text;
                    SaveApdate(content, cu.NameF.Text, cu.DicsF.Text, Convert.ToInt32(cu.AgeF.Text), cu.ImgF.Text);
                }

                //db.SaveChanges();
                db.Films.Load();
                DataGrids.ItemsSource = db.Films.Local.ToBindingList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr \n" + ex);
            }
        }

        public bool SaveApdate(string content, string name, string opis, int age, string img)
        {
            try
            {
                db = new CinemaEntities();
                Films films1 = db.Films.Find(Convert.ToInt32(content));
                films1.name = name;
                films1.description = opis;
                films1.age_restriction = age;
                films1.image = img;
                db.SaveChanges();
                db.Films.Load();
                return true;

            }
            catch
            {
                return false;
            }


        }

        private void Bron_Click(object sender, RoutedEventArgs e)
        {
            ThisInfo.MainFrame.Navigate(new SesCrudPage());
        }
    }
}
