using evaluarea_studentilor_in_sesiune.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormAdaugaSpecializare : Form
    {
        List<Specializare> listaSpecializari = ConexiuneBazaDeDate.ExtrageSpecializari();
        List<Grupa> listagGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        public FormAdaugaSpecializare()
        {
            InitializeComponent();
            AdaugareSpecinListBox();
        }
      
        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareAdministrator formLogareAdministrator = new FormLogareAdministrator();
            this.Hide();
            formLogareAdministrator.ShowDialog();
        }
        string CreareCodSpec(string text)
        {
         

            string[] cuvinte = text.ToUpper().Split(" ");
            string cod = "";

            if (cuvinte.Length > 0)
            {
                foreach (string cuvint in cuvinte)
                {
                    if (string.IsNullOrEmpty(cuvint))
                    {
                       
                       
                        int spatiuGasit = cuvinte.Length;
                        if (spatiuGasit > 0)
                        {
                            Array.Resize(ref cuvinte, cuvinte.Length - 1);
                        }
                    }
                }
                
                foreach (string cuvant in cuvinte)
                {
                    if (cuvant.Length > 3)
                    {
                        cod += cuvant[0];
                    }

                }
            }

            if (listaSpecializari != null)
            {
                foreach (Specializare specializare in listaSpecializari)
                {
                    if (cod == specializare.CodSpecializare)
                    {
                        int lungimeFinala = cod.Length;
                        cod +=cod[lungimeFinala - 1];
                    }
                }
            }

            return cod;
        }
        void AdaugareSpecinListBox()
        {
            listBoxSpecializare.SelectionMode = SelectionMode.One;
            listBoxSpecializare.Sorted = true;
            listBoxSpecializare.DataSource = null;
            listBoxSpecializare.DataSource = listaSpecializari;
            listBoxSpecializare.DisplayMember = "Afisare";
        }


        private void buttonAdaugaaSpecializre_Click(object sender, EventArgs e)
        {
            if (!utility.verificaString(textBoxDenumireSpecializare.Text) || !string.IsNullOrEmpty(textBoxDenumireSpecializare.Text))
            {
                foreach(Specializare specializare1 in listaSpecializari)
                {
                   if( textBoxDenumireSpecializare.Text.ToUpper()==specializare1.NumeSpecializare.ToUpper())
                    {
                        MessageBox.Show("Aceasta specializare exista deja");
                        return;
                    }

                }
                Specializare specializare = new Specializare()
                {
                    CodSpecializare = CreareCodSpec(textBoxDenumireSpecializare.Text),
                    NumeSpecializare = textBoxDenumireSpecializare.Text.ToUpper(),
                    NumarAniDeStudiu = Convert.ToInt32(numericUpDownNumarAniSDeStudiu.Value)
                };
                DialogResult result = MessageBox.Show($"Verifica daca numele este corect '{textBoxDenumireSpecializare.Text}'", "avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    listaSpecializari.Add(specializare);
                    ConexiuneBazaDeDate.InserareSpecializare(specializare);
                    AdaugareSpecinListBox();
                    textBoxDenumireSpecializare.Clear();
                    
                }
            }
            else
            {
                MessageBox.Show("Campuri completate necorsepunzator sau goale");
            }

        }

        private void buttonActualizeazaSpecializarea_Click(object sender, EventArgs e)
        {

            if (!utility.verificaString(textBoxDenumireSpecializare.Text) || !string.IsNullOrEmpty(textBoxDenumireSpecializare.Text))
            {
                string cod = ((Specializare)listBoxSpecializare.SelectedItem).CodSpecializare;

                Specializare specializareSelectata = listaSpecializari[listBoxSpecializare.SelectedIndex];

                specializareSelectata.CodSpecializare = /*CreareCodSpec(textBoxDenumireSpecializare.Text)*/cod;
                specializareSelectata.NumeSpecializare = textBoxDenumireSpecializare.Text.ToUpper();
                specializareSelectata.NumarAniDeStudiu = Convert.ToInt32(numericUpDownNumarAniSDeStudiu.Value);
                ConexiuneBazaDeDate.UpdateSpecializare(specializareSelectata, cod);
                MessageBox.Show("Actualizare efectuata cu succes");
                //foreach (Specializare spec in listaSpecializari)
                //{
                //    if (spec.CodSpecializare == cod)
                //    {

                //        spec.CodSpecializare = CreareCodSpec(textBoxDenumireSpecializare.Text);
                //        spec.NumeSpecializare = textBoxDenumireSpecializare.Text.ToUpper();
                //        spec.NumarAniDeStudiu = Convert.ToInt32(numericUpDownNumarAniSDeStudiu.Value);

                //        break; 
                //    }
                //}

                AdaugareSpecinListBox();
            }
            else
            {
                MessageBox.Show("Campurile pentru actulizare sunt goale");
            }
        }

        private void buttonStergeSpeicializarea_Click(object sender, EventArgs e)
        {
            bool validare = false;
            string cod = ((Specializare)listBoxSpecializare.SelectedItem).CodSpecializare;
            foreach(Grupa grupa in listagGrupa)
            {
                if(grupa.CodSpecializare==cod)
                {
                    validare = true;
                }
            }

            if (validare == false)
            {
                Specializare specializareSelectata = ((Specializare)listBoxSpecializare.SelectedItem);
                ConexiuneBazaDeDate.StergeSpecializare(cod);
                listaSpecializari.Remove(specializareSelectata);
                AdaugareSpecinListBox();
            }
            else
            {
                MessageBox.Show("Ne pare rău dar ștergerea nu se poate efectua deoarece este asignată unei grupe");
            }
        }

        private void listBoxSpecializare_Click(object sender, EventArgs e)
        {
            string codSpec = ((Specializare)listBoxSpecializare.SelectedItem).CodSpecializare;
            foreach(Grupa grupa in listagGrupa)
            {
                if(grupa.CodSpecializare==codSpec)
                {
                    buttonActualizeazaSpecializarea.Enabled = false;
                    buttonStergeSpeicializarea.Enabled = false;
                    return;
                }
                else
                {
                    buttonActualizeazaSpecializarea.Enabled = true;
                    buttonStergeSpeicializarea.Enabled = true;
                    
                }
            }
        }
    }
}
