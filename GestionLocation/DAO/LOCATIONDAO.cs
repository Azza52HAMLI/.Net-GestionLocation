using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class LOCATIONDAO
    {
        public static DataSet DSLOC = new DataSet();
        /*- ChargerBusLocation : récupère les données de la table tbus et tlocation de la BDR dans 
        les DataTable respectives TLBus et TLLocation*/
        public static void chargerbuslocation()
        {

            SqlConnection cnx = Connexion.GetInstance();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("select * from bus", cnx);
                da.Fill(DSLOC, "TLBUS");//recepina les donnée f table TLBUS
                da.SelectCommand.CommandText = "select * from location";/
                da.Fill(DSLOC, "TLLOC");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
            }

        }
    }
}
