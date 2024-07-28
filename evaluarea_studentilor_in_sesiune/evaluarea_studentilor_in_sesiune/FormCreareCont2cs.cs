using evaluarea_studentilor_in_sesiune.Properties;
using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace evaluarea_studentilor_in_sesiune
{

    public partial class FormCreareCont2cs : Form
    {
        string NrMatricol, CNP, NumeS_P, PrenumeS_P, Email, Grad, Telefon, calePoza, NrPozaP;
        int TipCont, IdGrupa, activ;

        List<Profesor> listaProfesori = ConexiuneBazaDeDate.ExtragereProfesor();
        List<Cont> listaConturi = ConexiuneBazaDeDate.ExtragereConturi();
        List<Student> listaStudenti = ConexiuneBazaDeDate.ExtragereStudenti();
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        public FormCreareCont2cs(string NrMatricol, string CNP, string NumeS_P, string PrenumeS_P, string Telefon, string Grad, string Email, int TipCont, int IdGrupa, int activ)
        {
            this.NrMatricol = NrMatricol;
            this.CNP = CNP;
            this.NumeS_P = NumeS_P;
            this.PrenumeS_P = PrenumeS_P;
            this.Email = Email;
            this.Telefon = Telefon;
            this.Grad = Grad;
            this.TipCont = TipCont;
            this.IdGrupa = IdGrupa;
            this.activ = activ;
            InitializeComponent();
        }

        public FormCreareCont2cs()
        {
            InitializeComponent();
        }

        #region UserName
        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            string textWithoutSpaces = textBoxUserName.Text.Replace(" ", "");
            for (int i = 0; i < textBoxUserName.TextLength; i++)
            {
                if (char.IsWhiteSpace(textBoxUserName.Text[i]))
                {
                    if (textBoxUserName.Text != textWithoutSpaces)
                    {
                        // int cursorPosition = textBoxUserName.SelectionStart;
                        textBoxUserName.Text = textWithoutSpaces;

                        MessageBox.Show("User name-ul nu poate avea spatii");


                    }
                }
            }
            if (textBoxUserName.TextLength >= 4)
            {
                pictureBoxUserName.Image = Properties.Resources.bifaVerde;
                labelUsename4.Visible = false;
            }
            else
            {
                pictureBoxUserName.Image = Properties.Resources.dateNevalidate;

            }
            if (pictureBoxUserName.Image == Properties.Resources.bifaVerde)
            {
                labelUsename4.Visible = false;
            }


        }


        private void pictureBoxParola1_Click(object sender, EventArgs e)
        {
            if (textBoxParola.PasswordChar == '\0')
            {
                textBoxParola.PasswordChar = '●';
                pictureBoxParola1.Image = Properties.Resources.pozaParola;

            }
            else
            {
                textBoxParola.PasswordChar = '\0';
                pictureBoxParola1.Image = Properties.Resources.lacat_deschis;
            }
        }

        private void PictureBoxConfrimaParola_Click(object sender, EventArgs e)
        {
            if (textBoxConfirmaParola.PasswordChar == '\0')
            {
                textBoxConfirmaParola.PasswordChar = '●';
                pictureBoxConfirmaaParola.Image = Properties.Resources.pozaParola;

            }
            else
            {
                textBoxConfirmaParola.PasswordChar = '\0';
                pictureBoxConfirmaaParola.Image = Properties.Resources.lacat_deschis;

            }
        }
        #region Poza profil
        private void pictureBoxPozaProfil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vrei sa iti pui poza de profil?", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Fișiere de imagine|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Alegeți o imagine";


                    if (TipCont == 2)
                    {


                        NrPozaP = NrMatricol;
                        NrPozaP += ".jpg";


                        StringBuilder stringNrm = new StringBuilder(NrMatricol);
                        int indexCaracter = 0;
                        foreach (Char caracter in NrMatricol)
                        {


                            if (caracter == '/')
                            {
                                stringNrm.Remove(indexCaracter, 1);
                                break;
                            }
                            indexCaracter += 1;
                        }
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string caleImagine = openFileDialog.FileName;


                            pictureBoxPozaProfil.Image = Image.FromFile(caleImagine);


                            //  string numeImagine = Path.GetFileName(caleImagine);


                            string directorDestinatie = @"E:\facultate\anul 3\sem1\LICENTA\aplicatie evss\evaluarea_studentilor_in_sesiune\evaluarea_studentilor_in_sesiune\bin\Debug\IMAGINI UTILIZATOR";

                            string caleDestinatie = Path.Combine(directorDestinatie, Convert.ToString(stringNrm));

                            File.Copy(caleImagine, caleDestinatie, true);
                            calePoza = caleDestinatie;

                        }

                    }
                    else
                    {

                        {


                            NrPozaP = "Profesor " + NumeS_P + ".jpg";

                        }
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string caleImagine = openFileDialog.FileName;


                            pictureBoxPozaProfil.Image = Image.FromFile(caleImagine);


                            //  string numeImagine = Path.GetFileName(caleImagine);


                            string directorDestinatie = @"E:\facultate\anul 3\sem1\LICENTA\aplicatie evss\evaluarea_studentilor_in_sesiune\evaluarea_studentilor_in_sesiune\bin\Debug\IMAGINI UTILIZATOR";

                            string caleDestinatie = Path.Combine(directorDestinatie, NrPozaP);


                            calePoza = caleDestinatie;

                        }
                    }
                }
            }
        }
        #endregion
        private void textBoxUserName_Enter(object sender, EventArgs e)
        {
            pictureBoxUserName.Visible = true;
            if (textBoxUserName.TextLength >= 4)
            {
                labelUsename4.Visible = false;
            }
            else
            {
                labelUsename4.Visible = true;
            }
        }

        #endregion
        #region Parola
        private void textBoxParola_Enter(object sender, EventArgs e)
        {
            pictureBoxParola.Visible = true;
            if (textBoxParola.TextLength >= 6)
            {
                labelNumar.Visible = false;
            }
            else
            {
                labelNumar.Visible = true;
            }
        }

        private void textBoxParola_TextChanged(object sender, EventArgs e)
        {

            bool contineCifra = false;
            string parola = textBoxParola.Text;

            foreach (char caracter in parola)
            {
                if (char.IsDigit(caracter))
                {
                    contineCifra = true;
                    break;
                }
            }

            if (parola.Length >= 6)
            {
                if (contineCifra)
                {
                    labelNumar.Visible = false;
                    pictureBoxParola.Image = Properties.Resources.bifaVerde;
                }
                else
                {
                    labelNumar.Visible = true;
                    pictureBoxParola.Image = Properties.Resources.dateNevalidate;
                }
            }
            else
            {
                labelNumar.Visible = true;
                pictureBoxParola.Image = Properties.Resources.dateNevalidate;
            }


        }
        #endregion
        #region ConfrimaParola
        private void textBoxConfirmaParola_Enter(object sender, EventArgs e)
        {
            pictureBoxConfirmaParola.Visible = true;
        }

        private void textBoxConfirmaParola_TextChanged(object sender, EventArgs e)
        {

            bool contineCifra = false;
            string parola = textBoxConfirmaParola.Text;

            foreach (char caracter in parola)
            {
                if (char.IsDigit(caracter))
                {
                    contineCifra = true;
                    break;
                }
            }
            if (parola.Length >= 6)
            {
                if (contineCifra)
                {


                    pictureBoxConfirmaParola.Image = Properties.Resources.bifaVerde;

                }

                else
                {
                    pictureBoxConfirmaParola.Image = Properties.Resources.dateNevalidate;
                }
            }
            else
            {
                pictureBoxConfirmaParola.Image = Properties.Resources.dateNevalidate;
            }
            if (textBoxConfirmaParola.Text == textBoxParola.Text)
            {
                pictureBoxConfirmaParola.Image = Properties.Resources.bifaVerde;
            }
            else
            {
                pictureBoxConfirmaParola.Image = Properties.Resources.dateNevalidate;
            }
        }
        #endregion
        bool validareDate()
        {
            if (string.IsNullOrEmpty(textBoxUserName.Text) || string.IsNullOrWhiteSpace(textBoxUserName.Text) || textBoxUserName.TextLength < 4)
            {
                MessageBox.Show("User name-ul contine spatii libere\n sau este invalid");
                return false;
            }
            if (!utility.VerificareParola(textBoxParola.Text) || string.IsNullOrEmpty(textBoxParola.Text))
            {
                labelParola.Visible = true;
                MessageBox.Show("Parola invalida...");
                return false;
                ;
            }
            if (textBoxParola.Text != textBoxConfirmaParola.Text)
            {
                MessageBox.Show("Parola din caseta confirma parola\n nu coincide cu cea din caseta parola");
                return false;
            }
            foreach(Cont cont in listaConturi)
            {
                if(cont.UserName.ToUpper()==textBoxUserName.Text.ToUpper().Trim())
                {
                    MessageBox.Show("Exista deja acest username");
                    return false;
                }
            }
            return true;
        }

        //public static string CapitalizeFirstLetter(string input)
        //{
        //    if (string.IsNullOrEmpty(input))
        //    {
        //        return input;
        //    }

        //    return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        //}

        #region Creare Cont
        private void buttonCreareCont_Click(object sender, EventArgs e)
        {

            if (validareDate())
            {
                foreach (Cont conturi in listaConturi)
                {
                    if (textBoxUserName.Text == conturi.UserName)
                    {
                        MessageBox.Show("Un utilizator cu acest user name deja exista");
                        return;
                    }
                }
                Cont cont = new Cont( )
                {
                    UserName = textBoxUserName.Text.ToUpper(),
                    Parola = utility.CripteazaParola(textBoxParola.Text),
                    TipCont = TipCont,
                    StatusCont = activ,
                    Poza = calePoza

                };
                listaConturi.Add(cont);
                ConexiuneBazaDeDate.InsertCont(cont);
                MessageBox.Show($"Cont creat cu succes.\nUser {Convert.ToString(textBoxUserName.Text)} ");

                if (TipCont == 1)
                {
                    Profesor profesor = new Profesor()
                    {
                        CNP = CNP,
                        NumeProfesor = NumeS_P.ToUpper(),
                        PrenumeProfesor = PrenumeS_P.ToUpper(),
                        Grad = Grad,
                        Email = Email.ToLower(),
                        UserName = textBoxUserName.Text.ToUpper()

                    };
                    listaProfesori.Add(profesor);
                    ConexiuneBazaDeDate.InsertProfesor(profesor);
                    MessageBox.Show("Profesor adaugat cu succes");
                    if (activ != 0)
                    {

                        Form1 logare = new Form1();
                        this.Dispose();
                        logare.ShowDialog();
                    }
                    if (activ == 0)
                    {
                        FormLogareAdministrator fla = new FormLogareAdministrator();
                        this.Hide();
                        fla.ShowDialog();
                    }

                }
                else if (TipCont == 2)
                {
                    Student student = new Student()
                    {
                        NrMatricol = NrMatricol.ToUpper(),
                        CNP = CNP,
                        NumeStudent = NumeS_P.ToUpper(),
                        PrenumeStudent = PrenumeS_P.ToUpper(),
                        Telefon = Telefon,
                        Email = Email.ToLower(),
                        UserName = textBoxUserName.Text.ToUpper()

                    };
                    listaStudenti.Add(student);
                    ConexiuneBazaDeDate.InserareStudent(student);
                    MessageBox.Show("Student adaugat cu succes");

                    AsociereStudentContGrupa asociereStudentGrupa = new AsociereStudentContGrupa()
                    {
                        IdGrupa = IdGrupa,
                        NrMatricol = NrMatricol.ToUpper(),
                        UserName = textBoxUserName.Text.ToUpper()

                    };
                    ConexiuneBazaDeDate.InsertAsociereStudentGrupa(asociereStudentGrupa);
                    MessageBox.Show("Asociere facuta cu succes");

                    if (activ != 0)
                    {

                        Form1 logare = new Form1();
                        this.Dispose();
                        logare.ShowDialog();
                    }
                    if (activ == 0)
                    {
                        FormLogareAdministrator fla = new FormLogareAdministrator();
                        this.Hide();
                        fla.ShowDialog();
                    }
                }
            }
           

        }
        #endregion

    }
}
