using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_Desktop.Class
{
    public class ThisInfo
    {
        public static Frame MainFrame { get; set; }//открытое окно
        public static int saveR1, saveR2, saveR3, saveR4, saveR5;//ряды
        public static int saveM1, saveM2, saveM3, saveM4, saveM5;//места

        public static int idUser = 0;// код пользователя
        public static int AdminCheck;// проверка на админа

        public static int idSesion ;// код сеанса
        public static int colmest;// код сеанса

        //private string slovo;
        //{get; set}
        public ThisInfo()
        {
        }

    }

}
