using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestionAffaire
{
    public partial class Form1 : Form
    {
        //public static SqlConnection con = new SqlConnection(@"Data Source=OMAR-PC\SQLEXPRESS; initial catalog=DB_Affaire;Integrated Security=True");
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_Affaire.mdf;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataAdapter da = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }


        // le menu
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxAff.Visible = true;
            BoxNoteAjouter.Visible = false;
            BoxMission.Visible = false;
            BoxPartiesInterecee.Visible = false;
        }
        private void affaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxNoteAjouter.Visible = true;
            BoxAff.Visible = false;
            BoxMission.Visible = false;
            BoxPartiesInterecee.Visible = false;
        }
        private void missionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }
        private void beneficaireToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void rechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxNoteAjouter.Visible = true;
            BoxAff.Visible = false;
            BoxMission.Visible = false;
            BoxPartiesInterecee.Visible = false;
        }
        private void beneficaireToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }
        private void noteDeFraisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }
        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxAff.Visible = true;
            BoxPartiesInterecee.Visible = false;
            BoxNoteAjouter.Visible = false;
            BoxMission.Visible = false;
        }
        private void missionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BoxMission.Visible = true;
            BoxPartiesInterecee.Visible = false;
            BoxAff.Visible = false;
            BoxNoteAjouter.Visible = false;
        }
        private void lesPartiesIntereceeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxMission.Visible = true;
            BoxPartiesInterecee.Visible = false;
            BoxAff.Visible = false;
            BoxNoteAjouter.Visible = false;
        }
        private void lesPartiesIntéresséesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoxPartiesInterecee.Visible = true;
            BoxMission.Visible = false;
            BoxAff.Visible = false;
            BoxNoteAjouter.Visible = false;
        }



        // les Methodes
        public void RemplirIdClient()
        {
            DataTable dt = new DataTable();

            cmbClientAff.Items.Clear();
            txtICEClient.Items.Clear();

            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select ICE from Client";
            da.SelectCommand = cmd;
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbClientAff.Items.Add(dt.Rows[i][0].ToString());
                txtICEClient.Items.Add(dt.Rows[i][0].ToString());
            }

            con.Close();
        }
        public void remplirListClient()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select ICE, raisonSociale as 'Raison Sociale' from Client";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListClient.DataSource = dt;
        }

        public void RemplirNomRespo()
        {
            DataTable dt = new DataTable();

            txtNomRespo.Items.Clear();
            cmbResponsableAff.Items.Clear();
            cmbRespoMission.Items.Clear();

            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select nom from Responsable";
            da.SelectCommand = cmd;
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtNomRespo.Items.Add(dt.Rows[i][0].ToString());
                cmbResponsableAff.Items.Add(dt.Rows[i][0].ToString());
                cmbRespoMission.Items.Add(dt.Rows[i][0].ToString());
            }

            con.Close();
        }
        public void remplirListRespo()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Nom, Prenom from Responsable";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListRespo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListRespo.DataSource = dt;
        }

        public void RemplirNumeroAffaire()
        {
            DataTable dt = new DataTable();

            cmbNumAffaireNote.Items.Clear();
            cmbNumAffMission.Items.Clear();
            cmbNumeroAff.Items.Clear();



            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select Numero from Affaires";
            da.SelectCommand = cmd;
            da.Fill(dt);

            cmbNumAffaireNote.Items.Add("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbNumAffaireNote.Items.Add(dt.Rows[i][0].ToString());
                cmbNumeroAff.Items.Add(dt.Rows[i][0].ToString());
                cmbNumAffMission.Items.Add(dt.Rows[i][0].ToString());
            }

            con.Close();
        }
        public void remplirListAffaire()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Numero,Client,Responsable as 'Chargé d''affaire' from Affaires";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListAff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListAff.DataSource = dt;
        }

        public void remplirNumeroNote()
        {
            DataTable dt = new DataTable();

            cmbNumeroNote.Items.Clear();

            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select Numero from NoteFrais";
            da.SelectCommand = cmd;
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbNumeroNote.Items.Add(dt.Rows[i][0].ToString());
            }

            con.Close();
        }
        public void remplirListNote()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Numero as 'Numero', Type as 'Type',PiecesComptables as 'Piece Comptable',date as 'Date',frais as 'Frais',affaire as 'Affaire' from NoteFrais";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            listNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listNote.DataSource = dt;
        }
        
        public void remplirNumeroMission()
        {
            DataTable dt = new DataTable();

            cmbNumeroMission.Items.Clear();

            if (dt != null)
            {
                dt.Rows.Clear();
            }


            con.Open();
            cmd.CommandText = "select numero from Mission";
            da.SelectCommand = cmd;
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbNumeroMission.Items.Add(dt.Rows[i][0].ToString());
            }

            con.Close();
        }
        public void remplirListMission()
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',affaire as 'Affaire' from Mission";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListMission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListMission.DataSource = dt;
        }
        
        public void remplirTypeNote()
        {
            cmbTypeNote.Items.Clear();

            cmbTypeNote.Items.Add("Gazoil");
            cmbTypeNote.Items.Add("Autoroute");
            cmbTypeNote.Items.Add("Gardiennage");
            cmbTypeNote.Items.Add("Restaurant");
            cmbTypeNote.Items.Add("Hotel");
            cmbTypeNote.Items.Add("Achat de Matiere ou Fourniture");
            cmbTypeNote.Items.Add("Produit et Frais des entretiens");
            cmbTypeNote.Items.Add("Frais Postaux");
            cmbTypeNote.Items.Add("Frais de Legalisation");
            cmbTypeNote.Items.Add("Frais de Manutention");
            cmbTypeNote.Items.Add("Indeminites de Deplacement");
            cmbTypeNote.Items.Add("Frais de Transport");
            cmbTypeNote.Items.Add("Frais de Deplacement Technicien(Controle de Gestion)");
            cmbTypeNote.Items.Add("Frais de Deplacement Ingenieur(Controle de Gestion)");
            cmbTypeNote.Items.Add("Frais de Kilometriques(Controle de Gestion)");
            cmbTypeNote.Items.Add("Divers");
            cmbTypeNote.Items.Add("...Définir");


        }
        public void remplirPCNote()
        {
            cmbPCNote.Items.Clear();

            cmbPCNote.Items.Add("Bon");
            cmbPCNote.Items.Add("Facture");
            cmbPCNote.Items.Add("Ticket");
            cmbPCNote.Items.Add("Sans");
        }

        public Boolean IsAffExists(string affaire)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false; 
            con.Open();
            cmd.CommandText = "select Numero from Affaires where Numero='"+ affaire +"'";
            da.SelectCommand = cmd;
            con.Close();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }
        public Boolean IsRespoExists(string nom)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select nom from Responsable where nom='" + nom + "'";
            da.SelectCommand = cmd;
            con.Close();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }
        public Boolean IsClientExists(string cin)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select ICE from Client where ICE='" + cin + "'";
            da.SelectCommand = cmd;
            con.Close();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }
        public Boolean IsNoteExists(int numero)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select Numero from NoteFrais where Numero='" + numero + "'";
            da.SelectCommand = cmd;
            con.Close();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }
        public Boolean IsMissionExists(int numero)
        {
            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            Boolean isThere = false;
            con.Open();
            cmd.CommandText = "select numero from Mission where numero='" + numero + "'";
            da.SelectCommand = cmd;
            con.Close();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                isThere = true;
            }
            return isThere;
        }






        private void Form1_Load(object sender, EventArgs e)
        {
            RemplirNumeroAffaire();
            remplirListAffaire();
            RemplirIdClient();
            remplirListClient();
            remplirNumeroMission();
            remplirListMission();
            remplirNumeroNote();
            remplirListNote();
            remplirTypeNote();
            remplirPCNote();
            RemplirNomRespo();
            remplirListRespo();
        }



        // les parties interecees
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton3.Checked = false;

                BoxRespoAjouter.Visible = true;
            }
            else
            {
                BoxRespoAjouter.Visible = false;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton2.Checked = false;

                BoxClientAjouter.Visible = true;
            }
            else
            {
                BoxClientAjouter.Visible = false;
            }
        }
        private void btnValiderClient_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton3.Checked == true)
            {
                if (txtICEClient.Text != "")
                {
                    if (IsClientExists(txtICEClient.Text) == true)
                    {
                        errorProvider1.SetError(txtICEClient, "Client est déjà Existant");
                    }
                    else
                    {
                        if (txtICEClient.Text != "" && txtRaisonSocialClient.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "insert into Client values('" + txtICEClient.Text + "','" + txtRaisonSocialClient.Text + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Client Ajouter Avec Succès");

                            txtICEClient.Text = txtRaisonSocialClient.Text = "";
                            remplirListClient();
                            RemplirIdClient();
                        }
                        else
                        {
                            errorProvider1.SetError(txtRaisonSocialClient, "cette information est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtICEClient, "cette information est Obligatoir");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtNomRespo.Text != "")
                {
                    if (IsRespoExists(txtNomRespo.Text) == true)
                    {
                        errorProvider1.SetError(txtNomRespo, "Chargé d'affaire est déjà Existant");
                    }
                    else
                    {
                        if (txtPrenomRespo.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "insert into Responsable values('" + txtNomRespo.Text + "','" + txtPrenomRespo.Text + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Chargé d'affaire Ajouter Avec Succès");

                            txtNomRespo.Text = txtPrenomRespo.Text = "";
                            RemplirNomRespo();
                            remplirListRespo();
                        }
                        else
                        {
                            errorProvider1.SetError(txtPrenomRespo, "les informations est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomRespo, "cette information est Obligatoir");
                }
            }
        }
        private void txtNomRespo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Nom, Prenom from Responsable where nom='"+ txtNomRespo.Text +"'";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListRespo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListRespo.DataSource = dt;

            txtPrenomRespo.Text = dt.Rows[0][1].ToString();
        }
        private void btnModifierCR_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton3.Checked == true)
            {
                if (txtICEClient.Text != "")
                {
                    if (IsClientExists(txtICEClient.Text) == false)
                    {
                        errorProvider1.SetError(txtICEClient, "Client n'est pas Existant");
                    }
                    else
                    {
                        if (txtRaisonSocialClient.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "update Client set raisonSociale='" + txtRaisonSocialClient.Text + "' where ICE='" + txtICEClient.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Modification Avec Succès");

                            txtICEClient.Text = txtRaisonSocialClient.Text = "";
                            remplirListClient();
                            RemplirIdClient();
                        }
                        else
                        {
                            errorProvider1.SetError(txtRaisonSocialClient, "cette information est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtICEClient, "cette information est Obligatoir");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtNomRespo.Text != "")
                {
                    if (IsRespoExists(txtNomRespo.Text) == false)
                    {
                        errorProvider1.SetError(txtNomRespo, "Chargé d'affaire n'est pas Existant");
                    }
                    else
                    {
                        if (txtPrenomRespo.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "update Responsable set prenom='" + txtPrenomRespo.Text + "' where nom='" + txtNomRespo.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Modification Avec Succès");

                            txtNomRespo.Text = txtPrenomRespo.Text = "";
                            RemplirNomRespo();
                            remplirListRespo();
                        }
                        else
                        {
                            errorProvider1.SetError(btnValiderClient, "les informations est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomRespo, "cette information est Obligatoir");
                }
            }
        }
        private void txtICEClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select * from Client where ICE='" + txtICEClient.Text + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListClient.DataSource = dt;

            txtRaisonSocialClient.Text = dt.Rows[0][1].ToString();
        }
        private void btnSupprimerCR_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (radioButton3.Checked == true)
            {
                if (txtICEClient.Text != "")
                {
                    if (IsClientExists(txtICEClient.Text) == false)
                    {
                        errorProvider1.SetError(txtICEClient, "Client n'est pas Existant");
                    }
                    else
                    {
                        if (txtRaisonSocialClient.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "delete Client where ICE='" + txtICEClient.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Suppression Avec Succès");

                            txtICEClient.Text = txtRaisonSocialClient.Text = "";
                            remplirListClient();
                            RemplirIdClient();
                        }
                        else
                        {
                            errorProvider1.SetError(txtRaisonSocialClient, "cette information est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtICEClient, "cette information est Obligatoir");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (txtNomRespo.Text != "")
                {
                    if (IsRespoExists(txtNomRespo.Text) == false)
                    {
                        errorProvider1.SetError(txtNomRespo, "Chargé d'affaire n'est pas Existant");
                    }
                    else
                    {
                        if (txtPrenomRespo.Text != "")
                        {
                            con.Open();
                            cmd.CommandText = "delete Responsable where nom='" + txtNomRespo.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            txtNomRespo.Text = txtPrenomRespo.Text = "";
                            RemplirNomRespo();
                            remplirListRespo();
                        }
                        else
                        {
                            errorProvider1.SetError(txtPrenomRespo, "les informations est Obligatoir");
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNomRespo, "cette information est Obligatoir");
                }
            }
        }


        // l'affaire
        private void cmbNumeroAff_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Numero,client as 'Client',responsable as 'Responsable' from Affaires where Numero='" + cmbNumeroAff.Text + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListAff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListAff.DataSource = dt;

            cmbClientAff.Text = dt.Rows[0][1].ToString();
            cmbResponsableAff.Text = dt.Rows[0][2].ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RemplirNumeroAffaire();
            remplirListAffaire();
            RemplirIdClient();
            RemplirNomRespo();

            cmbNumeroAff.Text = "";
        }
        private void btnValiderAff_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (cmbNumeroAff.Text != "")
            {
                if (IsAffExists(cmbNumeroAff.Text) == false)
                {
                    if (cmbClientAff.Text != "" && cmbResponsableAff.Text != "")
                    {
                        con.Open();
                        cmd.CommandText = "insert into Affaires values('" + cmbNumeroAff.Text + "','" + cmbClientAff.Text + "','" + cmbResponsableAff.Text + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        // afficher message d'inssertion
                        MessageBox.Show("Affaire Ajouter Avec Succès");

                        //vider la valeur de champ
                        cmbNumeroAff.Text = "";
                        RemplirIdClient();
                        RemplirNomRespo();

                        //faire le mis a jour
                        remplirListAffaire();
                        RemplirNumeroAffaire();
                    }
                    else
                    {
                        if (cmbClientAff.Text == "")
                            errorProvider1.SetError(cmbClientAff, "cette Information est Obligatoir");
                        if (cmbResponsableAff.Text == "")
                            errorProvider1.SetError(cmbResponsableAff, "cette Information est Obligatoir");
                    }
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroAff, "l'affaire est déjà Existant");
                }
            }
            else
            {
                errorProvider1.SetError(cmbNumeroAff,"cette Information est Obligatoir");
            }
        }
        private void btnModifierAffaire_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroAff.Text != "")
            {
                if (IsAffExists(cmbNumeroAff.Text) == true)
                {
                    if (cmbClientAff.Text != "" && cmbResponsableAff.Text != "")
                    {
                        con.Open();
                        cmd.CommandText = "update Affaires set Client='" + cmbClientAff.Text + "',Responsable='" + cmbResponsableAff.Text + "' where Numero='" + cmbNumeroAff.Text + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        // afficher message d'inssertion
                        MessageBox.Show("Modification Avec Succès");

                        //vider la valeur de champ
                        cmbNumeroAff.Text = "";
                        RemplirIdClient();
                        RemplirNomRespo();

                        //faire le mis a jour
                        remplirListAffaire();
                        RemplirNumeroAffaire();
                    }
                    else
                    {
                        if (cmbClientAff.Text == "")
                            errorProvider1.SetError(cmbClientAff, "cette Information est Obligatoir");
                        if (cmbResponsableAff.Text == "")
                            errorProvider1.SetError(cmbResponsableAff, "cette Information est Obligatoir");
                    }
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroAff, "l'affaire n'est pas Existant");
                }
            }
            else
                errorProvider1.SetError(cmbNumeroAff, "choisir une Affaire");
        }
        private void btnSupprimerAff_Click(object sender, EventArgs e)
        {
            if (cmbNumeroAff.Text != "")
            {
                if (IsAffExists(cmbNumeroAff.Text) == true)
                {
                    con.Open();
                    cmd.CommandText = "delete Affaires where Numero='" + cmbNumeroAff.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();


                    //afficher message Succès
                    MessageBox.Show("Suppression Avec Succès");

                    //faire mis a jour
                    RemplirNumeroAffaire();
                    remplirListAffaire();
                    RemplirNomRespo();
                    RemplirIdClient();

                    cmbNumeroAff.Text = "";

                    con.Close();
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroAff, "l'affaire n'est pas Existant");
                }
            }
            else
                errorProvider1.SetError(cmbNumeroAff, "choisir Numero d'affaire");
        }


        // note de frais
        private void cmbTypeNoteAjouter_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbTypeNote.Text == "...Définir")
            {
                cmbTypeNote.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTypeNote.Text = "";
            }
            else
            {
                cmbTypeNote.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private void cmbNumeroNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            DataTable dt = new DataTable();
            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select Numero,Type,PiecesComptables as 'Piece Comptable',Frais,Date as 'Date',Affaire from NoteFrais where Numero='" + cmbNumeroNote.Text + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();

            ListAff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListAff.DataSource = dt;

            cmbTypeNote.Text = dt.Rows[0][1].ToString();
            cmbPCNote.Text = dt.Rows[0][2].ToString();
            txtFraisNote.Text = dt.Rows[0][3].ToString();
            txtDateNote.Text = dt.Rows[0][4].ToString();
            cmbNumAffaireNote.Text = dt.Rows[0][5].ToString();

            Boolean isThere = false;
            for (int i = 0; i < cmbTypeNote.Items.Count; i++)
            {
                if (dt.Rows[0][1].ToString() == cmbTypeNote.Items[i].ToString())
                {
                    isThere = true;
                    break;
                }
            }

            if (!isThere)
            {
                cmbTypeNote.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTypeNote.Text = dt.Rows[0][1].ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (cmbNumeroNote.Text != "")
            {
                if (IsNoteExists(int.Parse(cmbNumeroNote.Text)) == false)
                {
                    if (cmbTypeNote.Text != "")
                    {
                        if (cmbPCNote.Text != "")
                        {
                            if (txtFraisNote.Enabled == true)
                            {
                                if (txtFraisNote.Text != "")
                                {
                                    con.Open();
                                    if (cmbNumAffaireNote.Text != "")
                                    {
                                        cmd.CommandText = "insert into NoteFrais(Type,PiecesComptables,affaire,frais,date) values('" +
                                                                                        cmbTypeNote.Text + "','" +
                                                                                        cmbPCNote.Text + "','" +
                                                                                        cmbNumAffaireNote.Text + "','" +
                                                                                        double.Parse(txtFraisNote.Text) + "','" +
                                                                                        Convert.ToDateTime(txtDateNote.Value) + "')";
                                    }
                                    else
                                    {
                                        cmd.CommandText = "insert into NoteFrais(Type,PiecesComptables,frais,date) values('" +
                                                                                        cmbTypeNote.Text + "','" +
                                                                                        cmbPCNote.Text + "','" +
                                                                                        double.Parse(txtFraisNote.Text) + "','" +
                                                                                        Convert.ToDateTime(txtDateNote.Value) + "')";
                                    }
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    remplirListNote();
                                    remplirNumeroNote();
                                    RemplirNumeroAffaire();
                                    remplirListAffaire();
                                    remplirTypeNote();
                                    remplirPCNote();


                                    MessageBox.Show("Ajouter Avec Succès");

                                    cmbNumeroNote.Text = cmbTypeNote.Text = cmbPCNote.Text = cmbNumAffaireNote.Text = "";
                                    txtFraisNote.Text = (0.00).ToString();

                                    errorProvider1.Dispose();
                                }
                                else
                                {
                                    errorProvider1.SetError(txtFraisNote, "Saisir Frais Valide");
                                }
                            }
                            else
                            {
                                con.Open();
                                if (cmbNumAffaireNote.Text != "")
                                {
                                    cmd.CommandText = "insert into NoteFrais(Type,PiecesComptables,affaire,frais) values('" + 
                                                                                    cmbTypeNote.Text + "','" +
                                                                                    cmbPCNote.Text + "','" +
                                                                                    cmbNumAffaireNote.Text + "','" +
                                                                                    double.Parse(txtFraisNote.Text) + "')";
                                }
                                else
                                {
                                    cmd.CommandText = "insert into NoteFrais(Type,PiecesComptables,frais) values('" + 
                                                                                    cmbTypeNote.Text + "','" +
                                                                                    cmbPCNote.Text + "','" +
                                                                                    double.Parse(txtFraisNote.Text) + "')";
                                }
                                cmd.ExecuteNonQuery();
                                con.Close();

                                remplirListNote();
                                remplirNumeroNote();
                                remplirTypeNote();
                                remplirPCNote();

                                MessageBox.Show("Ajouter Avec Succès");

                                cmbTypeNote.Text = cmbPCNote.Text = cmbNumAffaireNote.Text = txtFraisNote.Text = "";

                                errorProvider1.Dispose();
                            }
                        }
                        else
                            errorProvider1.SetError(cmbPCNote, "cette Information est Obligatoir");
                    }
                    else
                        errorProvider1.SetError(cmbTypeNote, "cette Information est Obligatoir");

                }
                else
                {
                    errorProvider1.SetError(cmbNumeroNote, "Note des Frais est déjà Existant");
                }
            }
            else
            {
                errorProvider1.SetError(cmbNumeroNote, "cette Information est Obligatoir");
            }
            cmbTypeNote.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btnModifierNoteFrais_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroNote.Text != "")
            {
                if (IsNoteExists(int.Parse(cmbNumeroNote.Text)) == true)
                {
                    if (cmbTypeNote.Text != "")
                    {
                        if (cmbPCNote.Text != "")
                        {
                            if (txtFraisNote.Enabled == true)
                            {
                                if (txtFraisNote.Text != "")
                                {
                                    con.Open();
                                    if (cmbNumAffaireNote.Text != "")
                                    {
                                        cmd.CommandText = "update NoteFrais set Type='" + cmbTypeNote.Text +
                                                                 "',PiecesComptables='" + cmbPCNote.Text +
                                                                 "',affaire = '" + cmbNumAffaireNote.Text +
                                                                 "',frais='" + double.Parse(txtFraisNote.Text) +
                                                                 "',date='" + Convert.ToDateTime(txtDateNote.Value) +
                                                                 "' where Numero='" + int.Parse(cmbNumeroNote.Text) + "'";
                                    }
                                    else
                                    {
                                        cmd.CommandText = "update NoteFrais set Type='" + cmbTypeNote.Text +
                                                                 "',PiecesComptables='" + cmbPCNote.Text +
                                                                 "',frais='" + double.Parse(txtFraisNote.Text) +
                                                                 "',date='" + Convert.ToDateTime(txtDateNote.Value) +
                                                                 "' where Numero='" + int.Parse(cmbNumeroNote.Text) + "')";
                                    }
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    remplirListNote();
                                    remplirNumeroNote();
                                    RemplirNumeroAffaire();
                                    remplirListAffaire();
                                    remplirTypeNote();
                                    remplirPCNote();


                                    MessageBox.Show("Modification Avec Succès");

                                    cmbNumeroNote.Text = cmbTypeNote.Text = cmbPCNote.Text = cmbNumAffaireNote.Text = "";
                                    txtFraisNote.Text = (0.00).ToString();

                                    errorProvider1.Dispose();
                                }
                                else
                                {
                                    errorProvider1.SetError(txtFraisNote, "Saisir Frais Valide");
                                }
                            }
                            else
                            {
                                con.Open();
                                if (cmbNumAffaireNote.Text != "")
                                {
                                    cmd.CommandText = "insert into NoteFrais(Type,PiecesComptables,affaire,frais) values('" + cmbTypeNote.Text + "','" +
                                                                                    cmbPCNote.Text + "','" +
                                                                                    cmbNumAffaireNote.Text + "','" +
                                                                                    double.Parse(txtFraisNote.Text) + "')";
                                }
                                else
                                {
                                    cmd.CommandText = "insert into NoteFrais(Type,PiecesComptables,frais) values('" + cmbTypeNote.Text + "','" +
                                                                                    cmbPCNote.Text + "','" +
                                                                                    double.Parse(txtFraisNote.Text) + "')";
                                }
                                cmd.ExecuteNonQuery();
                                con.Close();

                                remplirListNote();
                                remplirNumeroNote();
                                remplirTypeNote();
                                remplirPCNote();

                                MessageBox.Show("Modification Avec Succès");

                                cmbTypeNote.Text = cmbPCNote.Text = cmbNumAffaireNote.Text = txtFraisNote.Text = "";

                                errorProvider1.Dispose();
                            }
                        }
                        else
                            errorProvider1.SetError(cmbPCNote, "cette Information est Obligatoir");
                    }
                    else
                        errorProvider1.SetError(cmbTypeNote, "cette Information est Obligatoir");
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroNote, "Note des Frais n'est pas Existant");
                }
            }
            else
            {
                errorProvider1.SetError(cmbNumeroNote, "choisir Une Note");
            }
            cmbTypeNote.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btnSupprimerNoteFrais_Click(object sender, EventArgs e)
        {
            if (cmbNumeroNote.Text != "")
            {
                if (IsNoteExists(cmbNumeroNote.Text) == true)
                {
                    con.Open();
                    cmd.CommandText = "delete NoteFrais where Numero='" + cmbNumeroNote.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();


                    //afficher message Succès
                    MessageBox.Show("Suppression Avec Succès");

                    //faire mis a jour
                    remplirListNote();
                    remplirNumeroNote();
                    RemplirNomRespo();
                    RemplirNumeroAffaire();
                    remplirPCNote();
                    remplirTypeNote();

                    cmbNumeroNote.Text = cmbTypeNote.Text = cmbPCNote.Text = cmbNumAffaireNote.Text = txtFraisNote.Text = "";

                }
                else
                {
                    errorProvider1.SetError(cmbNumeroAff, "la Note n'est pas Existant");
                }
            }
            else
            {
                errorProvider1.SetError(cmbNumeroAff, "choisir Numero d'affaire");
            }
            cmbTypeNote.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        // ici report de note de Frais 
        private void btnImrimerPdfNote_Click(object sender, EventArgs e)
        {

        }


        // mission
        private void btnValiderMission_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroMission.Text != "")
            {
                if (IsMissionExists(cmbNumeroMission.Text) == false)
                {
                    if (cmbRespoMission.Text != "" && txtDateDebutMission.Text != "" && txtDateFinMission.Text != "" && txtLieuDepartMission.Text != "" && txtLieuArriveMission.Text != "" && cmbNumAffMission.Text != "")
                    {
                        con.Open();
                        cmd.CommandText = "insert into Mission(numero,dateDebut,dateFin,lieuDepart,lieuArriver,affaire,respo) values('"+ 
                                                    cmbNumeroMission.Text +"','"+ 
                                                    DateTime.Parse(txtDateDebutMission.Text) +"','"+
                                                    DateTime.Parse(txtDateFinMission.Text) +"','"+
                                                    txtLieuDepartMission.Text+"','"+
                                                    txtLieuArriveMission.Text+"','"+
                                                    cmbNumAffMission.Text+"','"+
                                                    cmbRespoMission.Text+"')";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Ajouter Avec Succès");

                        remplirNumeroMission();
                        remplirListMission();
                        remplirNumeroMission();
                        RemplirNumeroAffaire();
                        RemplirNomRespo();

                        cmbNumeroMission.Text = txtDateDebutMission.Text = txtDateFinMission.Text = txtLieuDepartMission.Text = txtLieuArriveMission.Text = "";
                    }
                    else
                    {
                        if (cmbRespoMission.Text == "")
                            errorProvider1.SetError(cmbRespoMission, "cette Information est Obligatoir");
                        if (txtDateDebutMission.Text == "")
                            errorProvider1.SetError(txtDateDebutMission, "cette Information est Obligatoir");
                        if (txtDateFinMission.Text == "")
                            errorProvider1.SetError(txtDateFinMission, "cette Information est Obligatoir");
                        if (txtLieuDepartMission.Text == "")
                            errorProvider1.SetError(txtLieuDepartMission, "cette Information est Obligatoir");
                        if (txtLieuArriveMission.Text == "")
                            errorProvider1.SetError(txtLieuArriveMission, "cette Information est Obligatoir");
                        if (cmbNumAffMission.Text == "")
                            errorProvider1.SetError(cmbNumAffMission, "cette Information est Obligatoir");
                    }
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroMission, "Ordre de Mission est déjà Existant");
                }
            }
            else
            {
                errorProvider1.SetError(cmbNumeroMission, "cette Information est Obligatoir");
            }
        }
        private void btnModifierMission_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (cmbNumeroMission.Text != "")
            {
                if (IsMissionExists(cmbNumeroMission.Text))
                {
                    if (cmbRespoMission.Text != "" && txtDateDebutMission.Text != "" && txtDateFinMission.Text != "" && txtLieuDepartMission.Text != "" && txtLieuArriveMission.Text != "" && cmbNumAffMission.Text != "")
                    {
                        con.Open();
                        cmd.CommandText = "update Mission set dateDebut='" + DateTime.Parse(txtDateDebutMission.Text) +
                                                            "',dateFin ='" + DateTime.Parse(txtDateFinMission.Text) +
                                                            "',lieuDepart='" + txtLieuDepartMission.Text +
                                                            "',lieuArriver='" + txtLieuArriveMission.Text +
                                                            "',affaire='" + cmbNumAffMission.Text +
                                                            "',respo='" + cmbRespoMission.Text +
                                                            "' where numero='" + cmbNumeroMission.Text + "'";
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = "update Mission set NbrJour = DATEDIFF(DAY, dateDebut, dateFin)  + 1 where numero='"+ cmbNumeroMission.Text +"'";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Modification Avec Succès");

                        remplirNumeroMission();
                        remplirListMission();
                        RemplirNumeroAffaire();
                        RemplirNomRespo();

                        cmbNumeroMission.Text = txtDateDebutMission.Text = txtDateFinMission.Text = txtLieuDepartMission.Text = txtLieuArriveMission.Text = "";
                    }
                    else
                    {
                        if (cmbRespoMission.Text == "")
                            errorProvider1.SetError(cmbRespoMission, "cette Information est Obligatoir");
                        if (txtDateDebutMission.Text == "")
                            errorProvider1.SetError(txtDateDebutMission, "cette Information est Obligatoir");
                        if (txtDateFinMission.Text == "")
                            errorProvider1.SetError(txtDateFinMission, "cette Information est Obligatoir");
                        if (txtLieuDepartMission.Text == "")
                            errorProvider1.SetError(txtLieuDepartMission, "cette Information est Obligatoir");
                        if (txtLieuArriveMission.Text == "")
                            errorProvider1.SetError(txtLieuArriveMission, "cette Information est Obligatoir");
                        if (cmbNumAffMission.Text == "")
                            errorProvider1.SetError(cmbNumAffMission, "cette Information est Obligatoir");
                    }

                }
                else
                {
                    errorProvider1.SetError(cmbNumeroMission, "Ordre de Mission n'est pas Existant");
                }
            }
            else
                errorProvider1.SetError(cmbNumeroMission, "choisir une mission");
        }
        private void cmbNumeroMissionRech_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            DataTable dt = new DataTable();

            if (dt != null)
            {
                dt.Rows.Clear();
            }

            con.Open();
            cmd.CommandText = "select numero as 'Numero', respo as 'Chargé d''affaire',dateDebut as 'Date Debut',dateFin as 'Date Fin',NbrJour as 'Nombre de Jours',lieuDepart as 'Lieu Départ',lieuArriver as 'Lieu Arrivé',affaire as 'Affaire' from Mission where numero='" + cmbNumeroMission.Text + "'";
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();

            cmbRespoMission.Text = dt.Rows[0][1].ToString();
            txtDateDebutMission.Text = dt.Rows[0][2].ToString();
            txtDateFinMission.Text = dt.Rows[0][3].ToString();
            txtLieuDepartMission.Text = dt.Rows[0][5].ToString();
            txtLieuArriveMission.Text = dt.Rows[0][6].ToString();
            cmbNumAffMission.Text = dt.Rows[0][7].ToString();



            ListMission.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListMission.DataSource = dt;
        }
        private void btnSupprimerMission_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (cmbNumeroMission.Text != "")
            {
                if (IsMissionExists(cmbNumeroMission.Text))
                {
                    con.Open();
                    cmd.CommandText = "delete Mission where numero='" + cmbNumeroMission.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Suppression Avec Succès");

                    remplirNumeroMission();
                    RemplirIdClient();
                    RemplirNumeroAffaire();
                    remplirListMission();

                    txtDateDebutMission.Text = txtDateFinMission.Text = txtLieuDepartMission.Text = "";
                }
                else
                {
                    errorProvider1.SetError(cmbNumeroMission,"Ordre de Mission n'est pas Existant");
                }
            }
            else
                errorProvider1.SetError(cmbNumeroMission, "choisir une Ordre de Mission");
        }
        private void btnLoadListMission_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            remplirNumeroMission();
            remplirListMission();
            RemplirNumeroAffaire();
            RemplirNomRespo();

            cmbNumeroMission.Text = txtDateDebutMission.Text = txtDateFinMission.Text = txtLieuDepartMission.Text = txtLieuArriveMission.Text = "";
        }















        private void button1_Click(object sender, EventArgs e)
        {
        }
        

        // beneficaire (client)
        private void cmbCinBeneRech_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void btnLoadListBene_Click(object sender, EventArgs e)
        {
        }
        private void btnValiderBene_Click(object sender, EventArgs e)
        {
            
        }
        private void btnModifierBene_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            
        }

        // note de frais
        private void cmbNumNoteRech_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btnModifierNote_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSupprimerNote_Click(object sender, EventArgs e)
        {
            
        }
        private void cmbPCNoteAjouter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPCNote.Text == "Sans")
            {
                txtFraisNote.Text = (0.00).ToString();
                txtFraisNote.Enabled = false;
            }
            else
            {
                txtFraisNote.Enabled = true;
                txtFraisNote.Text = (0.00).ToString();
            }
        }
        private void cmbPCNoteRech_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            remplirListNote();
            remplirNumeroNote();
            remplirTypeNote();
            remplirPCNote();

        }

       
        private void btnValiderMission_Click(object sender, EventArgs e)
        {
            
        }
        
        

        


        private void txtMontantAffAjouter_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void imprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void btnPdfAff_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (cmbNumeroAff.Text != "")
            {
                DataSet ds = new DataSet();
                ds.Tables.Clear();

                con.Open();
                cmd.CommandText = "select * from Affaires where Numero='"+ cmbNumeroAff.Text +"'";
                da.SelectCommand = cmd;
                da.Fill(ds, "Affaires");

                cmd.Parameters.Clear();

                cmd.CommandText = "select * from NoteFrais where affaire='" + cmbNumeroAff.Text + "'";
                da.SelectCommand = cmd;
                da.Fill(ds, "NoteFrais");

                cmd.Parameters.Clear();

                cmd.CommandText = "select * from Mission where affaire='" + cmbNumeroAff.Text + "'";
                da.SelectCommand = cmd;
                da.Fill(ds, "Mission");

                con.Close();


                
                CrystalReport1 cr = new CrystalReport1();
                cr.Database.Tables["Affaires"].SetDataSource(ds.Tables[0]);
                cr.Database.Tables["NoteFrais"].SetDataSource(ds.Tables[1]);
                cr.Database.Tables["Mission"].SetDataSource(ds.Tables[2]);

                Form2 f = new Form2();
                f.crystalReportViewer1.ReportSource = null;
                f.crystalReportViewer1.ReportSource = cr;
                f.crystalReportViewer1.Refresh();

                f.Show();
                this.Hide();
            }
            else
                errorProvider1.SetError(cmbNumeroAff, "chisir une Affaire");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            remplirTypeNote();
            remplirPCNote();
            RemplirNumeroAffaire();
            RemplirNomRespo();
            remplirNumeroNote();

            cmbNumeroNote.Text = "";
            txtDateNote.Text = "";
            txtFraisNote.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemplirIdClient();
            RemplirNumeroAffaire();
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            remplirNumeroNote();
            remplirTypeNote();
            remplirPCNote();
            RemplirNumeroAffaire();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
        }

        private void BoxClient_Enter(object sender, EventArgs e)
        {

        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            txtNomRespo.Text = txtPrenomRespo.Text = txtICEClient.Text = txtRaisonSocialClient.Text = "";

            remplirListClient();
            RemplirNomRespo();
            remplirListRespo();
        }

        

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
             
        }

        private void BoxClientAjouter_Enter(object sender, EventArgs e)
        {

        }

        private void noteDeFraisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void missionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
