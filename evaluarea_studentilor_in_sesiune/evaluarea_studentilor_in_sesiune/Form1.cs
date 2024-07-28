using evaluarea_studentilor_in_sesiune.Properties;
using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;


namespace evaluarea_studentilor_in_sesiune
{
    public partial class Form1 : Form
    {

        List<Cont> listaConturi = ConexiuneBazaDeDate.ExtragereConturi();
        List<Student> listaStudenti = ConexiuneBazaDeDate.ExtragereStudenti();
        List<Profesor> listaProfesori = ConexiuneBazaDeDate.ExtragereProfesor();
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        Cont conturi = new Cont();
        private static string NumePrenume;
        public static string UserName1 { get; set; }
       private int activ = 2;


        public Form1()
        {
            InitializeComponent();
            
          
        }

       
        

        private void labelCraereCont_Click(object sender, EventArgs e)
        {
            FormCreareCont creareCont = new FormCreareCont(activ);
            this.Hide();
            creareCont.ShowDialog();
        }

        private void labelCraereCont_MouseHover(object sender, EventArgs e)
        {
            labelCraereCont.Cursor = Cursors.Hand;
        }


        //eXTRAGERE NUME PRENUME STUDENT DUPA ASOCIERE STUNDENT CONT GRUPA
        //void extragere()
        //{
        //    string nrM = "";
        //    foreach (Cont cont in listaConturi)
        //    {
        //        if (cont.TipCont == 2)
        //        {
        //            foreach(AsociereStudentContGrupa asociereStudentContGrupa in listaAsociereStudentContGrupa)
        //            {
        //                if(asociereStudentContGrupa.UserName==textBoxUserName.Text)
        //                {
        //                    nrM = asociereStudentContGrupa.NrMatricol;
        //                }
        //            }
        //            foreach(Student student in listaStudenti)
        //            {
        //                if(student.NrMatricol==nrM)
        //                {
        //                    NumePrenume = student.PrenumeStudent + " " + student.NumeStudent;
        //                }
        //            }
        //        }
        //    }
        //}
        string extragereNumePrenume()
        {
            foreach (Cont cont in listaConturi)
            {
                if (cont.TipCont == 2)
                {
                    foreach (Student studenti in listaStudenti)
                    {
                        if (studenti.UserName == textBoxUserName.Text)
                        {
                            NumePrenume = studenti.PrenumeStudent + " " + studenti.NumeStudent;
                        }
                    }
                }
                else if(cont.TipCont==1)
                {
                    foreach(Profesor profesor in listaProfesori)
                    {
                      if(  profesor.UserName==textBoxUserName.Text)
                      {
                            NumePrenume = profesor.PrenumeProfesor + " " + profesor.NumeProfesor;
                      }
                    }
                }
            }
            return NumePrenume;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserName1 = textBoxUserName.Text.ToUpper();
            foreach (Cont conturi in listaConturi)
            {
                if (conturi.UserName.ToUpper() == textBoxUserName.Text.ToUpper() &&( utility.Decriptare( textBoxParola.Text,conturi.Parola)||conturi.Parola==textBoxParola.Text))
                {
                    if (conturi.StatusCont == 0)
                    {
                        if (conturi.TipCont == 2)
                        {

                            FormLogareS_P logareS_P = new FormLogareS_P(extragereNumePrenume(),textBoxUserName.Text.ToUpper());
                            this.Hide();
                            logareS_P.ShowDialog();

                            
                            return; 
                        }
                        else if (conturi.TipCont == 1)
                        {
                          
                            FormLogareP logareP = new FormLogareP(extragereNumePrenume());
                            this.Hide();
                            logareP.ShowDialog();
                            return; 
                        }
                        else if (conturi.TipCont==0)
                        {
                            FormLogareAdministrator logareAdministrator = new FormLogareAdministrator();
                            this.Hide();
                            logareAdministrator.ShowDialog();
                            return;
                        }
                    }
                    else if (conturi.StatusCont == 2)
                    {
                        labelContDezactiva.Visible = true;
                        labelContDezactiva.Text = "Cont inactiv";
                        return; 
                    }
                    else if (conturi.StatusCont == 1)
                    {
                        labelContDezactiva.Visible = true;
                        labelContDezactiva.Text = "Cont dezactivat";
                        return; 
                    }
                }
            }

            // Dacă ajung aici, înseamnă că nu s-a găsit o potrivire validă
            labelContDezactiva.Visible = false;
            labelContDezactiva.Visible = false;
            MessageBox.Show("User name sau parola greșite");

        }

        private void pictureBoxParola_Click(object sender, EventArgs e)
        {
            if (textBoxParola.PasswordChar == '●')
            {
                textBoxParola.PasswordChar = '\0';
                pictureBoxParola.Image = Properties.Resources.pozac_lacat_deschis;
            }
           else if(textBoxParola.PasswordChar=='\0')
            {
                textBoxParola.PasswordChar = '●';
                pictureBoxParola.Image = Properties.Resources.pozaParola;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Doriți să închideți aplicația?", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                Form1 f1 = new Form1();
                f1.ShowDialog();
            }
           


        }

       
    }
}
