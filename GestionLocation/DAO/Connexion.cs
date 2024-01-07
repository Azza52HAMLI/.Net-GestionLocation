using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class Connexion
    {
        static String chaineCnx = "Server=.;Database=BDagence3;" +
         "Trusted_Connection=True; ";
        static SqlConnection cnx = new SqlConnection(chaineCnx);
        public static SqlConnection GetInstance()
        {
            try
            {
                if (cnx.State != System.Data.ConnectionState.Open)
                    cnx.Open();
            }
            catch (Exception ex)
            { MessageBox.Show("Vente: Pb de connexion\n " + ex.Message); }
            return cnx;
        }
    }
}
