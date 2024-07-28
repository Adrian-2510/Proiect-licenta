using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace evaluarea_studentilor_in_sesiune.Properties
{
    public partial class FormCreareCont : Form
    {
        List<Specializare> listaSpecializari = ConexiuneBazaDeDate.ExtrageSpecializari();
        List<Student> listaStudenti = ConexiuneBazaDeDate.ExtragereStudenti();
        List<Grupa> listaGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();


        int activ=3;
        int TipCont = 2;
        string NrMatricol = "";
        public FormCreareCont(int activ)
        {
            this.activ = activ;
            InitializeComponent();

            addComboBoxSpec();
            addComboBoxGrupa();
            comboBoxGrupa.MaxDropDownItems = 2;
        }
        int anUniveristar()
        {
            int anCurent = DateTime.Now.Year;
            int lunaCurenta = DateTime.Now.Month;

            if (lunaCurenta >= 10 && lunaCurenta <= 12)
            {
                anCurent++;
                return anCurent;
            }
            else if (lunaCurenta >= 1 && lunaCurenta <= 9)
            {
                anCurent--;
                return anCurent;
            }
            return anCurent;
        }
    

        void addComboBoxSpec()
        {
            comboBoxSpecializari.DataSource = null;
            comboBoxSpecializari.Sorted = true;
            comboBoxSpecializari.DataSource = listaSpecializari;
            comboBoxSpecializari.DisplayMember = "NumeSpecializare";
        }
        void addComboBoxGrupa()
        {
         
            
            comboBoxGrupa.DataSource = null;
            comboBoxGrupa.Sorted = true;
            var listaGrupe = listaGrupa.Where(s => s.CodSpecializare == ((Specializare)comboBoxSpecializari.SelectedItem).CodSpecializare).ToList();
            comboBoxGrupa.DataSource = listaGrupe;
            comboBoxGrupa.DisplayMember= "AnSud_AnUniv";
           
        }
        int preluareIdGRupa()
        {
            int IdGrupa=((Grupa)comboBoxGrupa.SelectedItem).IdGrupa;
            return IdGrupa;

        }
        #region Tip cont
        private void radioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxP_S.Image = Properties.Resources.student_Cont;
            labelAlegeSpecializare.Visible = true;
            comboBoxSpecializari.Visible = true;
          
            TipCont = 2;
            labelTelefonG.Text = "Telefon";
            comboBoxGrad.Visible = false;
            pictureBoxValidareTelefonG.Visible = false;
            pictureBoxValidareTelefonG.Visible = false;
            labelNrMatricol.Visible = true;
            textBoxNrMatricol.Visible = true;
            comboBoxGrupa.Visible = true;
            labelGrupa.Visible = true;
            pictureBoxNrMatricol.Visible = true;
        }

       
        private void radioButtonProfesor_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxP_S.Image = Properties.Resources.profesor_cont;
            labelAlegeSpecializare.Visible = false;
            comboBoxSpecializari.Visible = false;
            TipCont = 1;
            labelTelefonG.Text = "Grad";
            comboBoxGrad.Visible = true;
            pictureBoxValidareTelefonG.Visible = false;
            labelNrMatricol.Visible = false;
            textBoxNrMatricol.Visible = false;
            comboBoxGrupa.Visible = false;
            labelGrupa.Visible = false;
            pictureBoxNrMatricol.Visible = false;
            textBoxCNP.TabIndex = 0;
            
        }
        #endregion
        bool verificareCNP(string CNP)
        {
            if(CNP.Length==13 )
            {
                return true;
            }
            return false;
        }
        
        #region CNP
        private void textBoxCNP_Enter(object sender, EventArgs e)
        {
            pictureBoxValidareCNP.Visible = true;
        }
        
        

        private void textBoxCNP_TextChanged(object sender, EventArgs e)
        {
            if(verificareCNP(textBoxCNP.Text))
            {
                pictureBoxValidareCNP.Image = Properties.Resources.bifaVerde;
            }
            else
            {
                pictureBoxValidareCNP.Image = Properties.Resources.dateNevalidate;
            }
            if(textBoxCNP.TextLength>13)
            {
                textBoxCNP.Text = textBoxCNP.Text.Substring(0, 13);
            }
            string text = textBoxCNP.Text;

            if (text.Length > 0)
            {
                char primaCifra = text[0];
                if (primaCifra != '1' && primaCifra != '2' && primaCifra != '5' && primaCifra != '6')
                {
                    pictureBoxValidareCNP.Image = Properties.Resources.dateNevalidate;
                }
                if (!verificareCNP(textBoxCNP.Text))
                {
                    pictureBoxValidareCNP.Image = Properties.Resources.dateNevalidate;
                }
            }
        }

        private void textBoxCNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
       
        }

        

        #endregion
        #region NumeS_P
        private void textBoxNumeS_P_Enter(object sender, EventArgs e)
        {
            pictureBoxValidareNume.Visible = true;
        }

        private void textBoxNumeS_P_TextChanged(object sender, EventArgs e)
        {


          
            if (utility.verificaString(textBoxNumeS_P.Text))
            {
                pictureBoxValidareNume.Image = Properties.Resources.bifaVerde;
            }
            else
            {
                pictureBoxValidareNume.Image = Properties.Resources.dateNevalidate; // Înlocuiți cu imaginea dvs. sau lăsați-o goală
            }
            if (textBoxNumeS_P.Text == "")
            {
               pictureBoxValidareNume.Image = Properties.Resources.dateNevalidate;
            }
            if (textBoxNumeS_P.Text.Length > 0 && textBoxNumeS_P.Text[0] == ' ')
            {
                textBoxNumeS_P.Text = "";
            }




        }

        private void textBoxNumeS_P_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        #endregion
        #region PrenumeS_P
        private void textBoxPrenumeS_P_Enter(object sender, EventArgs e)
        {
            pictureBoxvalidarePrenume.Visible = true;
        }
       

        private void textBoxPrenumeS_P_TextChanged(object sender, EventArgs e)
        {
            if(utility.verificaString(textBoxPrenumeS_P.Text))
            {
                pictureBoxvalidarePrenume.Image = Properties.Resources.bifaVerde;
            }
            else
            {
                pictureBoxvalidarePrenume.Image = Properties.Resources.dateNevalidate;
            }
            if(textBoxPrenumeS_P.Text=="")
            {
                pictureBoxvalidarePrenume.Image = Properties.Resources.dateNevalidate;
            }
            if (textBoxPrenumeS_P.Text.Length > 0 && textBoxPrenumeS_P.Text[0] == ' ')
            {
                textBoxPrenumeS_P.Text = "";
            }
          



        }
        private bool emailUnic()
        {
            foreach(Student student in listaStudenti)
            {
                if(student.Email.Trim().ToUpper()==textBoxEmailG.Text.ToUpper().Trim())
                {
                   
                    return true;
                }
            }
            return false;
        }
        private void textBoxPrenumeS_P_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                
            }
        }
        #endregion
        #region EmailG
        private void textBoxEmailG_Enter(object sender, EventArgs e)
        {
            pictureBoxValidareEmail.Visible = true;
        }
        private void textBoxEmailG_TextChanged(object sender, EventArgs e)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            string text = textBoxEmailG.Text.ToLower();

            if (!System.Text.RegularExpressions.Regex.IsMatch(text, emailPattern) || string.IsNullOrWhiteSpace(text))
            {

                pictureBoxValidareEmail.Image = Properties.Resources.dateNevalidate;
            }
            else
            {

                pictureBoxValidareEmail.Image = Properties.Resources.bifaVerde;
            }
            if(textBoxEmailG.Text=="")
            {
                pictureBoxValidareEmail.Image = Properties.Resources.dateNevalidate;
            }
            if (textBoxEmailG.Text.Length > 0 && textBoxEmailG.Text[0] == ' ')
            {
                textBoxEmailG.Text = "";
            }
            





        }

        bool validareEmail()
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            string text = textBoxEmailG.Text.ToLower();
            if (text.Length > 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(text, emailPattern))
                {
                   
                    return false;
                }        
            }
            return true;
        }

        #endregion

        #region TelefonG
        
        private void textBoxTelefonG_Enter(object sender, EventArgs e)
        {
            pictureBoxValidareTelefonG.Visible = true;
            pictureBoxValidareTelefonG.Image = Properties.Resources.dateNevalidate;
            
           
               
        }
        private void textBoxTelefonG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTelefonG_TextChanged(object sender, EventArgs e)
        {
            if(textBoxTelefonG.TextLength==10)
            {
                pictureBoxValidareTelefonG.Image = Properties.Resources.bifaVerde;
            }
            else
            {
                pictureBoxValidareTelefonG.Image = Properties.Resources.dateNevalidate;
            }
            if(textBoxTelefonG.TextLength>10)
            {
                textBoxTelefonG.Text = textBoxTelefonG.Text.Substring(0, 10);
            }
        }

        #endregion
     
        private void comboBoxGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxValidareTelefonG.Visible = true;
            pictureBoxValidareTelefonG.Image = Properties.Resources.bifaVerde;
           
           

        }
        bool verificareDate1()
        {
            if (TipCont == 2)
            {
                if (!verificareNrMatricol())
                {
                    MessageBox.Show("Numar matricol introdus necorespunzator \n sau este deja existent");
                    return false;
                }
            }
            if (!utility.VerifCNP(textBoxCNP.Text))
            {
                MessageBox.Show("CNP introdus incorect.\nIncepe cu cifrele 1,2,5,6 si este fromat din 13 caractere");
                return false;

            }
            if (!utility.verificaString(textBoxNumeS_P.Text) || string.IsNullOrEmpty(textBoxNumeS_P.Text))
            {
                MessageBox.Show("Nume introdus inccorect...");
                return false;

            }

            if (!utility.verificaString(textBoxPrenumeS_P.Text) || string.IsNullOrEmpty(textBoxPrenumeS_P.Text))
            {
                MessageBox.Show("Prenume introdus incorect...");
                return false;
            }
            if (validareEmail() )
            {
                MessageBox.Show("Adresa de email introdusa necorespunzator");
                return false;
            }
            if(emailUnic()==true)
            {
                MessageBox.Show("Aceasta adresa de email este deja folosita");
                return false;
            }
            if (TipCont == 2)
            {
                if (  textBoxTelefonG.TextLength < 10 || textBoxTelefonG.TextLength>10 || string.IsNullOrEmpty(textBoxTelefonG.Text) || !utility.verificaIntreg(textBoxTelefonG.Text))
                {
                    MessageBox.Show("Numar de telefon invalid");
                    return false;
                    
                }
                if(EvitareDuplicat()==false)
                {
                    MessageBox.Show("Acest CNP a mai fost inregistrat la aceasta specializare");
                    return false;
                }
            }
           else if(TipCont==1)
            {
                if(comboBoxGrad.Text=="")
                {
                    MessageBox.Show("Trebuie selectat gradul profesoral");
                    return false;
                }
               
                    
            }
            
            return true;



        }
        public string GenerareNrMatricol()
        {

                Specializare specializare = new Specializare();

                string numeSpec = ((Specializare)comboBoxSpecializari.SelectedItem).NumeSpecializare;
                string[] cuvinte = numeSpec.Split(" ");
                string cod = "";
                string NrMatricol = "";
                int matr = 0;


                foreach (string cuvant in cuvinte)
                {
                    if (cuvant.Length > 3)
                    {
                        cod += cuvant[0];
                    }
                }
                if (listaStudenti.Count == 0)
                {
                    matr = 1000;
                    NrMatricol = matr + "/" + cod;
                }
                else
                {
                    string numere = "";
                    Student student = listaStudenti[listaStudenti.Count - 1];

                    foreach (char nrMAT in student.NrMatricol)
                    {
                        if (char.IsDigit(nrMAT))
                        {
                            numere += nrMAT;

                        }
                    }

                    matr = int.Parse(numere) + 1;
                    NrMatricol = matr + "/" + cod;
                }
            

            return NrMatricol;

        }
        private void buttonCreareCont2_Click(object sender, EventArgs e)
        {
            if (verificareDate1())
            {

                //if(TipCont==2)
                //{
                //    NrMatricol = GenerareNrMatricol();
                //}
                string nrMatricol1 = "";
                int idGrupa;
                string codSpec = "";
                foreach(Student student in listaStudenti)
                {
                    if(student.CNP==textBoxCNP.Text)
                    {
                        nrMatricol1 = student.NrMatricol;
                        foreach(AsociereStudentContGrupa asociereStudentContGrupa in listaAsociereStudentContGrupa)
                        {
                            if(asociereStudentContGrupa.NrMatricol==nrMatricol1)
                            {
                                idGrupa = asociereStudentContGrupa.IdGrupa;
                                foreach(Grupa grupa in listaGrupa)
                                {
                                    if(grupa.IdGrupa==idGrupa)
                                    {
                                        codSpec = grupa.CodSpecializare;
                                        if(student.CNP==textBoxCNP.Text && codSpec==grupa.CodSpecializare)
                                        {
                                            MessageBox.Show("Acest student este deja sau a terminat deja acesta specializare");
                                            return;
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                }
                
                
                
                    FormCreareCont2cs creareCont2 = new FormCreareCont2cs(textBoxNrMatricol.Text.ToUpper(),textBoxCNP.Text, textBoxNumeS_P.Text, textBoxPrenumeS_P.Text,textBoxTelefonG.Text, comboBoxGrad.Text, textBoxEmailG.Text, TipCont,preluareIdGRupa(),activ);
                    this.Hide();
                    creareCont2.ShowDialog();
                
                
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
          
            if (activ != 0)
            {
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
            }
            else
            {
                FormLogareAdministrator fla = new FormLogareAdministrator();
                this.Hide();
                fla.ShowDialog();
            }
        }
        #region NrMatricol
        bool verificareNrMatricol()
        {
            int nrNumere = 0;
            bool exista = false;
            string text = textBoxNrMatricol.Text.ToUpper();
            string numeSpec = ((Specializare)comboBoxSpecializari.SelectedItem).NumeSpecializare;
           
            string cod = "";
            string codNou = "";
            string cifreMATR = "";
            string NrMatricol = "";
            bool corectitudineNrMatricol = false;
            bool existaInBazaDeDate = true;
            foreach (Specializare specializare in listaSpecializari)
            {
                if(specializare.NumeSpecializare==numeSpec)
                {
                    cod = specializare.CodSpecializare;
                }
                
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '/')
                {
                    exista = true;
                    codNou = '/' + cod;
                }

                if (char.IsDigit(text[i]))
                {
                    nrNumere += 1;
                    cifreMATR += text[i];
                }
            }
            NrMatricol = cifreMATR + codNou;

            if (text == NrMatricol)
            {
                corectitudineNrMatricol = true;
            }
            foreach (Student student in listaStudenti)
            {
                if (student.NrMatricol == text)
                {
                    existaInBazaDeDate = false;
                }
            }

            if (nrNumere == 4 && exista == true && corectitudineNrMatricol && existaInBazaDeDate)
            {
                pictureBoxNrMatricol.Image = Properties.Resources.bifaVerde;
                return true;

            }
            else
            {
                pictureBoxNrMatricol.Image = Properties.Resources.dateNevalidate;
                return false;
            }
        }
        private void textBoxNrMatricol_TextChanged(object sender, EventArgs e)
        {
            verificareNrMatricol();
        
        }
        private void textBoxNrMatricol_Enter(object sender, EventArgs e)
        {
            pictureBoxNrMatricol.Visible = true;
            if(activ==0)
            {
               
                textBoxNrMatricol.Text=GenerareNrMatricol();

                
            }
        }

        #endregion

        private void comboBoxSpecializari_SelectedIndexChanged(object sender, EventArgs e)
        {
            addComboBoxGrupa();
            if (activ == 0)
            {
                textBoxNrMatricol.Text = GenerareNrMatricol();
            }
            verificareNrMatricol();
        }
        // de testat//
        private bool  EvitareDuplicat()
        {
            string matr2="";
            int idGrupa=-1;
            string codSpec = "";
            foreach(Student student in listaStudenti)
            {
                if(student.CNP==textBoxCNP.Text)
                {
                    matr2 = student.NrMatricol;
                    break;
                }     
            }
            foreach(AsociereStudentContGrupa asociereStudentContGrupa in listaAsociereStudentContGrupa)
            {
                if(asociereStudentContGrupa.NrMatricol==matr2)
                {
                    idGrupa = asociereStudentContGrupa.IdGrupa;
                    break;
                }
            }
            foreach(Grupa grupa in listaGrupa)
            {
                if(grupa.IdGrupa==idGrupa)
                {
                    codSpec = grupa.CodSpecializare;
                    break;
                }
            }
            foreach(Student student1 in listaStudenti)
            {
                if(student1.CNP==textBoxCNP.Text && codSpec==((Specializare)comboBoxSpecializari.SelectedItem).CodSpecializare)
                {
                    return false;
                }

            }
            return true;
        }
    }

}

