using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormAdaugaDisciplina : Form
    {
        List<Disciplina> listaDiscipline = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<AsociereProfesorDisciplinaGrupa> listaApDg = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<Evaluare> listaEvaluare = ConexiuneBazaDeDate.ExtragereEvaluare();

        public FormAdaugaDisciplina()
        {
            InitializeComponent();
            AdaugaDisciplineInListBox();
        }

        void AdaugaDisciplineInListBox()
        {
         //   listBoxDiscipline.Sorted = true;
            listBoxDiscipline.DataSource = null;
            listBoxDiscipline.DataSource = listaDiscipline;
            listBoxDiscipline.DisplayMember = "Denumire";

        }

        private void textBoxDescriereDisciplina_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;

            utility.CalculateNeededHeight(text);
        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareAdministrator formLogareA = new FormLogareAdministrator();
            this.Hide();
            formLogareA.ShowDialog();
        }

        bool verificareCasete()
        {
            if (string.IsNullOrEmpty(textBoxDenumireDisciplina.Text))
            {
                MessageBox.Show("Caseta cu denumire este goala ori nu este introdus nimic in ea");
                return false;
            }

            return true;

        }
        //string codificareCodDisc(string cod)
        //{
        //    int indiceMaxim = 0;
        //    string prefix = string.Empty;

        //    // Verificați dacă codul există deja în listă
        //    if (listaDiscipline.Any(disciplina => disciplina.IdDisciplina.StartsWith(cod)))
        //    {
        //        // Găsiți cel mai mare indice utilizat și adăugați 1
        //        indiceMaxim = listaDiscipline
        //            .Where(disciplina => disciplina.IdDisciplina.StartsWith(cod))
        //            .Select(disciplina => int.Parse(disciplina.IdDisciplina.Substring(cod.Length)))
        //            .DefaultIfEmpty(0)
        //            .Max();

        //        indiceMaxim++;
        //    }

        //    // Construiți noul cod utilizând prefixul și indicele
        //    string codNou = $"{cod}{indiceMaxim}";

        //    return codNou;
        //}


        //string codificareCodDisc(string cod)
        //{
        //    int max = 0;
        //    int dNrCod = 0;
        //    int[] vNrCod = new int[dNrCod];
        //    string text = cod;
        //    string[] text2 = text.Split(' ');
        //    string codD = string.Empty;

        //    // Verificăm dacă există mai multe cuvinte în șir
        //    if (text2.Length > 1)
        //    {
        //        foreach (string cuvant in text2)
        //        {
        //            // Dacă cuvântul are mai mult de 2 caractere, adăugăm prima literă la codD
        //            if (cuvant.Length > 2)
        //            {
        //                codD += cuvant[0];
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // Dacă avem doar un cuvânt, luăm prima literă a acestuia
        //        codD = text.Substring(0, 1);
        //    }

        //    foreach (Disciplina disciplina in listaDiscipline)
        //    {
        //        // Verificăm dacă codD este deja prezent în listă
        //        if (codD == disciplina.IdDisciplina)
        //        {
        //            foreach (Disciplina disciplina1 in listaDiscipline)
        //            {
        //                // Extragem toate literele din IdDisciplina
        //                string nrCod = new string(disciplina1.IdDisciplina.Where(char.IsLetter).ToArray());

        //                // Dacă codurile coincid, continuăm
        //                if (codD == nrCod)
        //                {
        //                    // Extragem toate cifrele din IdDisciplina
        //                    string nrV = new string(disciplina1.IdDisciplina.Where(char.IsDigit).ToArray());

        //                    // Convertim la int și adăugăm în vectorul vNrCod
        //                    Array.Resize(ref vNrCod, dNrCod += 1);
        //                    vNrCod[dNrCod - 1] = Convert.ToInt32(nrV);
        //                }
        //            }

        //            // Aflăm valoarea maximă din vectorul vNrCod
        //            max = (dNrCod > 0) ? vNrCod.Max() : 0;
        //            max += 1;
        //            codD += max;
        //        }
        //    }

        //    return codD;
        //}


        string codificareCodDisc(string cod)
        {
            int max = 0;
            string nrCod = string.Empty;
            string nrV = string.Empty;

            int dNrCod = 0;
            int[] vNrCod = new int[dNrCod];
            string text = cod;
            string[] text2 = text.Split(' ');
            string codD = string.Empty;

            if (text2.Length > 1)
            {
                foreach (string cuvinte in text2)
                {
                    if (cuvinte.Length > 2)
                    {

                        codD += cuvinte[0];
                    }
                }
            }
            else
            {
                codD = text.Substring(0, 1);
            }
            foreach (Disciplina disciplina in listaDiscipline)
            {

                if (codD == disciplina.IdDisciplina)
                {
                    foreach (Disciplina disciplina1 in listaDiscipline)
                    {
                        nrCod = string.Empty;
                        nrV = string.Empty;

                        foreach (char c in disciplina1.IdDisciplina)
                        {


                            if (char.IsLetter(c))
                            {
                                nrCod += c;
                            }

                            if (codD == nrCod)
                            {
                                {
                                    if (char.IsDigit(c))
                                    {
                                        nrV += c;
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(nrV))
                        {
                            Array.Resize(ref vNrCod, dNrCod += 1);
                            vNrCod[dNrCod - 1] = Convert.ToInt32(nrV);
                            max = vNrCod.Max();
                        }
                    }
                    max += 1;
                    codD += max;
                }
            }
            return codD;
        }

        private async void buttonAdaugaDisciplina_Click(object sender, EventArgs e)
        {
            if (verificareCasete())
            {
                foreach (Disciplina disciplina1 in listaDiscipline)
                {
                    if (textBoxDenumireDisciplina.Text.ToUpper() == disciplina1.Denumire.ToUpper())
                    {
                        MessageBox.Show("Exista aceasta disciplina deja");
                        return;
                    }
                }
                Disciplina disciplina = new Disciplina()
                {
                    IdDisciplina = codificareCodDisc(textBoxDenumireDisciplina.Text.ToUpper()).ToUpper(),
                    Denumire = textBoxDenumireDisciplina.Text.ToUpper(),
                    Descriere = textBoxDescriereDisciplina.Text
                };
                listaDiscipline.Add(disciplina);
                ConexiuneBazaDeDate.InserareDisciplina(disciplina);
                MessageBox.Show($"Disciplina '{disciplina.Denumire}' a fost adaugata cu succes!");
                buttonAdaugaDisciplina.BackColor = Color.Green;
                await Task.Delay(2000);
                this.Invoke((MethodInvoker)delegate
                {
                    buttonAdaugaDisciplina.BackColor = SystemColors.Control;
                });

                AdaugaDisciplineInListBox();
                textBoxDenumireDisciplina.Clear();
                textBoxDescriereDisciplina.Clear();

            }
        }

        private void textBoxCautareDisciplina_TextChanged(object sender, EventArgs e)
        {
            var listaDisciplineCautate = listaDiscipline.Where(d => (d.Denumire).ToUpper().
              StartsWith(textBoxCautareDisciplina.Text.ToUpper())).ToList();
            listBoxDiscipline.DataSource = null;
            listBoxDiscipline.Sorted = true;
            listBoxDiscipline.DataSource = listaDisciplineCautate;
            listBoxDiscipline.DisplayMember = "Denumire";

        }

        private void buttonActulizeazaDisciplina_Click(object sender, EventArgs e)
        {
            string cod = ((Disciplina)listBoxDiscipline.SelectedItem).IdDisciplina;

            Disciplina disciplinaSelectata = listaDiscipline[listBoxDiscipline.SelectedIndex];

            disciplinaSelectata.IdDisciplina = cod.ToUpper();
            disciplinaSelectata.Denumire = textBoxDenumireDisciplina.Text.ToUpper();
            disciplinaSelectata.Descriere = textBoxDescriereDisciplina.Text;

            try
            {
                ConexiuneBazaDeDate.ActulizareDisciplina(disciplinaSelectata, cod);
                MessageBox.Show("Actualizarea datelor a fost realizata cu succes");
               AdaugaDisciplineInListBox();
                
                
            }
            catch (Exception)
            {
                MessageBox.Show("Din pacate a fost o eroare la actualizarea datelor");
            }



        }

        private void buttonStergereDisciplina_Click(object sender, EventArgs e)
        {
            string cod = ((Disciplina)listBoxDiscipline.SelectedItem).IdDisciplina;
            Disciplina disciplinaSelectata = listaDiscipline[listBoxDiscipline.SelectedIndex];


            try
            {
                ConexiuneBazaDeDate.StergereDisciplina(cod);
                listaDiscipline.Remove(disciplinaSelectata);

                AdaugaDisciplineInListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Eroare la stergerea disciplinei in baza de date");
            }




        }

        private void listBoxDiscipline_Click(object sender, EventArgs e)
        {
            string codDisc = ((Disciplina)listBoxDiscipline.SelectedItem).IdDisciplina;
            foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaApDg)
            {
                if (asociereProfesorDisciplinaGrupa.IdDisciplina == codDisc)
                {
                    buttonStergereDisciplina.Enabled = false;
                    return;
                }
                else
                {
                    buttonStergereDisciplina.Enabled = true;
                }
            }
            foreach (Evaluare evaluare in listaEvaluare)
            {
                if (evaluare.IdDIsciplina == codDisc)
                {
                    buttonStergereDisciplina.Enabled = false;
                    return;
                }
                else
                {
                    buttonStergereDisciplina.Enabled = true;
                }

            }

        }
    }
}
