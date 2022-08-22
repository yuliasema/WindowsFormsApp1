using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public static class ClassSQL
    {
        public static SqlConnection conn;

        public static List<string> Select (string Text)
        {
            List<string> res = new List<string>();

            SqlCommand com = new SqlCommand(Text, conn);
            DbDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i<reader.FieldCount; i++)
                {

                     res.Add(reader.GetString(i));
                }

            }

            reader.Close();
            com.Dispose();
            return res;
        }

        public static decimal SelectId(string Text)
        {
            decimal res;

            SqlCommand com = new SqlCommand(Text, conn);
            DbDataReader reader = com.ExecuteReader();
            reader.Read();
            res = reader.GetDecimal(0);
            reader.Close();
            com.Dispose();
            return res;
        }

        public static void Insert(string Text)
        {

            SqlCommand com = new SqlCommand(Text, conn);
            DbDataReader reader = com.ExecuteReader();
            reader.Close();
            com.Dispose();
        }


    }
}
