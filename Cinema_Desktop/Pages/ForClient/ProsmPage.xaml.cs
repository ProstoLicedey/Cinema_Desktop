using Cinema_Desktop.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для ProsmPage.xaml
    /// </summary>
    public partial class ProsmPage : Page
    {
        public ProsmPage()
        {
            InitializeComponent();
            SqlCommand cmd = new SqlCommand("SELECT Tickets.tickets_id, Films.name, Tickets.row_number, Tickets.seat_number, Session.number_zal FROM Tickets INNER JOIN Session ON Session.session_id = Tickets.session_id INNER JOIN Films ON Session.film_id = Films.film_id WHERE Tickets.user_id =" + ThisInfo.idUser + "", conn);
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataReader read = cmd.ExecuteReader();
            dt.Load(read);
            conn.Close();
            grid.ItemsSource = dt.DefaultView;


            //grid.ItemsSource = CinemaEntities.GetContext().Tickets.Where(U => U.user_id == ThisInfo.idUser).ToList();
        }
        SqlConnection conn = new SqlConnection(
          @"data source=LAPTOP-I1078BL5\MSSQLSERVER02;initial catalog=Cinema;integrated security=True"
      );

    }
}
