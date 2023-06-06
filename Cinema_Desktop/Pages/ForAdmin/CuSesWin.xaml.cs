using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cinema_Desktop.Pages.ForAdmin
{
    /// <summary>
    /// Логика взаимодействия для CuSesWin.xaml
    /// </summary>
    public partial class CuSesWin : Window
    {
        public CuSesWin()
        {
            InitializeComponent();
            FilmVv.ItemsSource = CinemaEntities.GetContext().Films.ToList();
        }
        //private void TextChangedd(object sender, EventArgs e)
        //{
        //    if (zal.Text.Length > 0)
        //    {
        //        zal.Text = zal.Text[0].ToString().ToUpper() + zal.Text.Substring(1, zal.Text.Length - 1);
        //        zal.SelectionStart = zal.Text.Length;
        //        zal.SelectionLength = 0;
        //    }
        //}

        private void Create_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

