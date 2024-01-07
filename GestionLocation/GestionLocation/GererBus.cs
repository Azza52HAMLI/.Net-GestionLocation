using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using metiers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace GestionLocation
{
    public partial class GererBus : Form
    {
        public GererBus()
        {
            InitializeComponent();
        }

        private void GererBus_Load(object sender, EventArgs e)
        {/*Vérifier si le DataTable "TVBUS" de la classe BUSDAO contient déjà des données. Si ce n'est pas le cas,
         appeler la méthode chargerBus() pour charger les données de la table "tbus" de la base de données dans le DataTable.*/
            if (BUSDAO.DSBUS.Tables["TVBUS"] == null)
                BUSDAO.chargerBus();
         //Définir la source de données du DataGridView "dgvBus" en utilisant le DataTable "TVBUS" de la classe BUSDAO.
            dgvBus.DataSource = BUSDAO.DSBUS.Tables["TVBUS"];
        }
        private void viderchamp()
        {
            txtImmat.Text = txtCapacite.Text = txtMarque.Text =
                txtMarque.Text = txtPrixJour.Text = "";
            dtpachat.Value = DateTime.Now;
        }
        
        private void btnAjouter_Click(object sender, EventArgs e)
        { // Vérifier si le champ d'immatriculation est renseigné
            if (txtImmat.Text!="")
            {// Parcourir toutes les lignes du tableau pour vérifier si une ligne contient la même immatriculation
                bool trouve = false;
                // Parcourir chaque DataRow de la DataTable TVBUS
                    foreach (DataRow dr in BUSDAO.DSBUS.Tables["TVBUS"].Rows)
                {
                    if(dr[0].ToString().Equals(txtImmat.Text))
                    {
                        trouve = true;
                        MessageBox.Show("Existe");
                        break;
                    }

                }// Si aucune ligne avec la même immatriculation n'est trouvée, ajouter le bus
                if (!trouve)
                { // Créer un nouvel objet Bus à partir des valeurs des champs
                    Bus b = new Bus(txtImmat.Text,
                        txtMarque.Text, dtpachat.Value,
                        Convert.ToInt32(txtCapacite.Text)
                        , Convert.ToDecimal(txtPrixAchat.Text)
                        , Convert.ToDecimal(txtPrixJour.Text));
                    // Ajouter le nouveau bus au tableau DSBUS
                    BUSDAO.ajouterBus(b);
                    viderchamp();
                    MessageBox.Show("Ajouté avec success");
                    // Mettre à jour l'affichage de la liste des bus
                    GererBus_Load(sender, e);
                }


            }

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            BUSDAO.Enregistrer();
        }

        private void btnChercher_Click(object sender, EventArgs e)
        {
            if(txtCapacite.Text!="")
            {

                dgvBus.DataSource = BUSDAO.chercherparcapacite(//3mltu appl el methode ely DAO w zdtu fel data gride 
                   Convert.ToInt32(txtCapacite.Text)
                    );
            }
        }
        
    }
}
