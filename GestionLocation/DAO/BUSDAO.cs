using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metiers;

namespace DAO
{
    public class BUSDAO
    {
        public static DataSet DSBUS = new DataSet();
/*ChargerBus : récupère les données de la table tbus de la BDR dans la DataTable TLBus*/
        public static void chargerBus()
        {
            SqlConnection cnx = Connexion.GetInstance();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("select * from bus", cnx);
                //Cela permet de remplir l'objet DSBUS avec les données de la table "bus" dans la base de données.
                da.Fill(DSBUS, "TVBUS");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }
        //ChercherParCapacite : retourne les bus de DataTable TLBus qui ont la capacité donné
        public static List<Bus> chercherparcapacite(int c)
        {
            List<Bus> buss = new List<Bus>();
            // Parcourir chaque DataRow de la DataTable TVBUS
            foreach (DataRow dr in DSBUS.Tables["TVBUS"].Rows )
            {    // Vérifier si la capacité du bus correspond à celle recherchée
                if (Convert.ToInt32(dr[3]) == c)//hetha khter el capacité hua el champs el thleth
                {// Créer un objet Bus correspondant avec les données de la DataRow
                    Bus b = new Bus(
                      dr[0].ToString(), dr[1].ToString()
                      , Convert.ToDateTime(dr[2]),
                      Convert.ToInt32(dr[3]),
                      Convert.ToDecimal(dr[4]),
                      Convert.ToDecimal(dr[5])
                        ) ;
                    // Ajouter le bus à la liste de bus correspondants
                    buss.Add(b);
                }

            }
            return buss;
        }
        //AjouterBus : ajoute les données d’un bus dans la DataTable TLBus
        public static void ajouterBus(Bus b)
        {// Créer une nouvelle DataRow pour la DataTable TVBUS
            DataRow dr = DSBUS.Tables["TVBUS"].NewRow();
            // Assigner les valeurs de l'objet Bus aux colonnes de la DataRow
            dr[0] = b.Immat;
            dr[1] = b.Marque;
            dr[2] = b.Dateachat;
            dr[3] = b.Capacite;
            dr[4] = b.Prixachat;
            dr[5] = b.Prixjour;
            // Ajouter la DataRow à la DataTable TVBUS
            DSBUS.Tables["TVBUS"].Rows.Add(dr);

        }

        //EnregistrerBus : sauvegarde les modifications dans la table tbus de la BDR
        public static void Enregistrer()

        {
            SqlConnection cnx = Connexion.GetInstance();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("select * from bus", cnx);
               //hetha n3mlha kan fel enregistrer fel mode D
               SqlCommandBuilder dcb = new SqlCommandBuilder(da);
                // permet d'effectuer les mises à jour dans la base de données en fonction
                // des modifications apportées aux données dans l'objet DSBUS.
                da.Update(DSBUS,"TVBUS");
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
    // gerer numéro 
    public static String genereeReference(int annee)
    {
        lesvoles = chercherparAnnee(annee);
        string chaine = "v" + annee + "-" + (lesvoles.count() + 1).ToSyring().PadLeft(3, '0');
        return chaine;
    }
}
