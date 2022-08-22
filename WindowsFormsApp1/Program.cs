using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClassSQL.conn = new SqlConnection();
            ClassSQL.conn.ConnectionString = "Data Source = LAPTOP-10MGPV2V; Initial Catalog =test2; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;";
            ClassSQL.conn.Open();
            Application.Run(new Form1());
            ClassSQL.conn.Close();
        }
    }
}
