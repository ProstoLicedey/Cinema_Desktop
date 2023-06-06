using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using static System.Collections.Specialized.BitVector32;
using Cinema_Desktop.Class;
using Cinema_Desktop.Pages.ForClient;
using Cinema_Desktop.Pages.AuthReg;

namespace Cinema_Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Seans.xaml
    /// </summary>
    public partial class Seans : Page
    {
        public Seans()
        {
            InitializeComponent();
            try
            {

                //if (ThisInfo.AdminCheck == true)//если админ
                //{
                //    ControlMenu.Visibility = Visibility.Visible;//это ваше программирование просто пака

                //}

                ThisInfo.saveR1 = 0; ThisInfo.saveR2 = 0; ThisInfo.saveR3 = 0; ThisInfo.saveR4 = 0; ThisInfo.saveR5 = 0;
                ThisInfo.saveM1 = 0; ThisInfo.saveM2 = 0; ThisInfo.saveM3 = 0; ThisInfo.saveM4 = 0; ThisInfo.saveM5 = 0;
                ThisInfo.idSesion = 0;
                ThisInfo.colmest = 0;

                using (var db = new CinemaEntities())
                {
                    foreach (Films film in db.Films)
                    {

                        Image image = new Image();
                        try
                        {
                            if (film.image != null)
                                image.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/image/" + film.image));
                        }
                        catch
                        {
                            image.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/image/nophoto1.png"));
                        }
                        image.Width = 230;
                        image.HorizontalAlignment = HorizontalAlignment.Left;
                        image.Margin = new Thickness(50, 20, 0, 20);

                        TextBlock Nametext = new TextBlock();
                        Nametext.Name = "NameFilm" + film.film_id;
                        Nametext.TextWrapping = TextWrapping.Wrap;
                        Nametext.Foreground = Brushes.Pink;
                        Nametext.FontWeight = FontWeights.Bold;
                        Nametext.FontSize = 50;
                        Nametext.Width = 658;
                        Nametext.Text = film.name;

                        TextBlock Agetext = new TextBlock();
                        Agetext.Name = "Age" + film.film_id;
                        Agetext.Text = Convert.ToString(film.age_restriction) + "+";
                        Agetext.Foreground = Brushes.White;
                        Agetext.FontWeight = FontWeights.Bold;
                        Agetext.FontSize = 30;
                        Agetext.HorizontalAlignment = HorizontalAlignment.Left;
                        Agetext.VerticalAlignment = VerticalAlignment.Center;
                        Agetext.Margin = new Thickness(20, 0, 0, 0);

                        StackPanel stackPaneltext = new StackPanel();
                        stackPaneltext.Orientation = Orientation.Horizontal;
                        stackPaneltext.Children.Add(Nametext);
                        stackPaneltext.Children.Add(Agetext);

                        TextBlock textBlockAbout = new TextBlock();
                        textBlockAbout.Name = "About" + film.film_id;
                        textBlockAbout.Text = film.description;
                        textBlockAbout.TextWrapping = TextWrapping.Wrap;
                        textBlockAbout.Margin = new Thickness(20, 0, 20, 0);
                        textBlockAbout.Foreground = Brushes.White;
                        textBlockAbout.FontSize = 16;

                        ComboBox comboBox = new ComboBox();
                        comboBox.Name = "combobox" + film.film_id;
                        comboBox.SelectedIndex = 0;
                        comboBox.FontWeight = FontWeights.Bold;
                        comboBox.FontSize = 18;
                        comboBox.Width = 330;
                        comboBox.Height = 45;
                        comboBox.Margin = new Thickness(0, 20, 0, 0);
                        comboBox.HorizontalAlignment = HorizontalAlignment.Right;
                        comboBox.Items.Add("Выберите сеанс");
                        foreach (Session ses in db.Session)
                        {
                            if (film.film_id == ses.film_id)
                                comboBox.Items.Add(ses.date_time.ToString("dd MMMM yyyy HH:mm"));
                        }
                        comboBox.SelectionChanged += films_SelectionChanged;


                        Button btn = new Button();
                        btn.Name = "button" + film.film_id;
                        btn.Content = "Выбрать место";
                        btn.Opacity = 0.7;
                        btn.Height = 57;
                        btn.Width = 234;
                        btn.FontSize = 24;
                        btn.FontWeight = FontWeights.Bold;
                        btn.Visibility = Visibility.Collapsed;
                        btn.HorizontalAlignment = HorizontalAlignment.Right;
                        btn.Click += zall_Click;
                        //btn.Style = {StaticResource btn};

                        TextBlock timetext = new TextBlock();
                        timetext.Name = "time" + film.film_id;
                        timetext.Foreground = Brushes.White;
                        timetext.Margin = new Thickness(0, 0, 10, 0);
                        timetext.FontSize = 36;
                        timetext.Visibility = Visibility.Collapsed;


                        TextBlock datetext = new TextBlock();
                        datetext.Name = "date" + film.film_id;
                        datetext.Foreground = Brushes.White;
                        datetext.Margin = new Thickness(0, 0, 10, 0);
                        datetext.FontSize = 36;
                        datetext.Visibility = Visibility.Collapsed;

                        TextBlock prisetext = new TextBlock();
                        prisetext.Name = "prise" + film.film_id;
                        prisetext.Foreground = Brushes.White;
                        prisetext.Margin = new Thickness(0, 0, 10, 0);
                        prisetext.FontSize = 36;
                        prisetext.Visibility = Visibility.Collapsed;

                        TextBlock zaltext = new TextBlock();
                        zaltext.Name = "zal" + film.film_id;
                        zaltext.Foreground = Brushes.White;
                        zaltext.Margin = new Thickness(0, 0, 10, 0);
                        zaltext.FontSize = 36;
                        zaltext.Visibility = Visibility.Collapsed;

                        StackPanel stackPanel = new StackPanel();
                        stackPanel.Margin = new Thickness(20, 0, 0, 0);

                        stackPanel.Children.Add(stackPaneltext);
                        stackPanel.Children.Add(textBlockAbout);
                        stackPanel.Children.Add(comboBox);
                        stackPanel.Children.Add(timetext);
                        stackPanel.Children.Add(datetext);
                        stackPanel.Children.Add(prisetext);
                        stackPanel.Children.Add(zaltext);
                        stackPanel.Children.Add(btn);

                        DockPanel dock = new DockPanel();

                        dock.Children.Add(image);
                        dock.Children.Add(stackPanel);

                        Border border = new Border();
                        border.Child = dock;
                        border.Margin = new Thickness(30, 30, 30, 30);
                        border.BorderBrush = Brushes.White;
                        border.BorderThickness = new Thickness(3, 3, 3, 3);
                        border.Name = "b" + film.film_id;

                        FilmsContent.Children.Add(border);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки, пожалйста перезагрузите приложение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void zall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var this_btn = e.OriginalSource as Button; //нажатая кнопка
                var this_stack = VisualTreeHelper.GetParent(this_btn) as StackPanel;// стек фильма
                var this_stack_name = this_stack.Children.OfType<StackPanel>().ToList();//стек с названием фильма
                var this_name = this_stack_name[0].Children.OfType<TextBlock>().ToList();// имя фильма
                var this_Combo = this_stack.Children.OfType<ComboBox>().ToList();//комбобокс

                if (this_Combo[0].SelectedIndex != 0)
                {
                    using (var db = new CinemaEntities())
                    {
                        foreach (Films film in db.Films)
                        {
                            if (this_name[0].Text == film.name)
                                foreach (Session ses in db.Session)
                                {
                                    ;
                                    if (film.film_id == ses.film_id)
                                        if (ses.date_time == DateTime.Parse(Convert.ToString(this_Combo[0].SelectedValue)))
                                        {
                                            ThisInfo.idSesion = ses.session_id;
                                        }

                                }
                        }
                    }
                    if (ThisInfo.idUser != 0)
                    {
                        ThisInfo.MainFrame.Navigate(new Zal());
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, перед выбором места, войдите в аккаунт");
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите сеанс!");
                }

            }
            catch
            {
                MessageBox.Show("Ошибка загрузки, пожалйста перезагрузите приложение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void films_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var thisCombo = e.OriginalSource as ComboBox;
                var thisstack = VisualTreeHelper.GetParent(thisCombo) as StackPanel;
                var this_text = thisstack.Children.OfType<TextBlock>().ToList();
                var this_btn = thisstack.Children.OfType<Button>().ToList();


                using (var db = new CinemaEntities())
                {
                    foreach (Session ses in db.Session)
                    {
                        foreach (Films film in db.Films)
                        {

                            if (thisCombo.SelectedIndex != 0)
                            {
                                if (ses.date_time == DateTime.Parse(Convert.ToString(thisCombo.SelectedValue)))
                                {

                                    this_btn[0].Visibility = Visibility.Visible;
                                    this_text[1].Visibility = Visibility.Visible;
                                    this_text[2].Visibility = Visibility.Visible;
                                    this_text[3].Visibility = Visibility.Visible;


                                    this_text[1].Text = "Время: " + ses.date_time.ToString("HH:mm");
                                    this_text[2].Text = "Дата: " + ses.date_time.ToString("dd.MM.yyyy");
                                    this_text[3].Text = "Цена: " + ses.price.ToString("#") + "₽";
                                    this_text[4].Text = "Зал: " + ses.number_zal;

                                }
                            }
                            else
                            {
                                this_btn[0].Visibility = Visibility.Collapsed;
                                this_text[1].Visibility = Visibility.Collapsed;
                                this_text[2].Visibility = Visibility.Collapsed;
                                this_text[3].Visibility = Visibility.Collapsed;

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
    }
}