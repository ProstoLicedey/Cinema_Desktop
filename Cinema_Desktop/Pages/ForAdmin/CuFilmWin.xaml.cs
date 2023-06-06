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
    /// Логика взаимодействия для CuFilmWin.xaml
    /// </summary>
    public partial class CuFilmWin : Window
    {
        public CuFilmWin()
        {
            InitializeComponent();
        }
        private void TextChangedd(object sender, EventArgs e)
        {
            if (AgeF.Text.Length > 0)
            {
                AgeF.Text = AgeF.Text[0].ToString().ToUpper() + AgeF.Text.Substring(1, AgeF.Text.Length - 1);
                AgeF.SelectionStart = AgeF.Text.Length;
                AgeF.SelectionLength = 0;
            }
        }

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
