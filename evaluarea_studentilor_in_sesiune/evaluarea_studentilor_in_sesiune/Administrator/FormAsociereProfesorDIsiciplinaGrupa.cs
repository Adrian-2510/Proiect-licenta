using evaluarea_studentilor_in_sesiune.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormAsociereProfesorDIsiciplinaGrupa : Form
    {
        List<Disciplina> listaDisciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<Profesor> listaProfesor = ConexiuneBazaDeDate.ExtragereProfesor();
        List<Grupa> listaGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        List<Cont> listaCont = ConexiuneBazaDeDate.ExtragereConturi();
        List<AsociereProfesorDisciplinaGrupa> listaAsociereProfesorDisciplinaGrupas = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<Profesor> listaProfesori = new List<Profesor>();

        public FormAsociereProfesorDIsiciplinaGrupa()
        {
            InitializeComponent();
            adaugaDisciplineInListBox();
            adaugaProfesorInListBox();
            adaugaGrupeInListBox();
            adaugaAnUniversitarInComboBox();
            NumericUpDownSem();
            AsociereProfesorInListBox();
        }
        void adaugaDisciplineInListBox()
        {
            listBoxDisiciplina.SelectionMode = SelectionMode.One;
            listBoxDisiciplina.DataSource = null;
            listBoxDisiciplina.Sorted = true;
            listBoxDisiciplina.DataSource = listaDisciplina;
            listBoxDisiciplina.DisplayMember = "Denumire";

        }
        void adaugaProfesorInListBox()
        {
            listBoxProfesor.SelectionMode = SelectionMode.One;
            listBoxProfesor.DataSource = null;
            listBoxProfesor.Sorted = true;


            foreach (Cont cont in listaCont)
            {
                foreach (Profesor profesor in listaProfesor)
                {
                    if (cont.UserName == profesor.UserName && cont.StatusCont == 0)
                    {

                        listaProfesori.Add(profesor);

                     
                    }
                }
            }
            listBoxProfesor.DataSource = listaProfesori.ToList();
            listBoxProfesor.DisplayMember = "Nume_Prenume_Profesor";
        }
        void AsociereProfesorInListBox()
        {
            listBoxAsocierepProfesorDisciplinaGrupa.DataSource = null;
            listBoxAsocierepProfesorDisciplinaGrupa.Sorted = true;
            listBoxAsocierepProfesorDisciplinaGrupa.DataSource = listaAsociereProfesorDisciplinaGrupas;
            listBoxAsocierepProfesorDisciplinaGrupa.DisplayMember = "AoscierProfesor";
        }
        string anulInCurs()
        {

            int anCurent = DateTime.Now.Year;
            int lunaCurenta = DateTime.Now.Month;
            string anulUniv = "";
            if (lunaCurenta >= 10 && lunaCurenta <= 12)
            {
                anCurent++;
            }
            else if (lunaCurenta >= 1 && lunaCurenta <= 9)
            {
                anCurent--;
            }
            anulUniv = $"{anCurent}-{anCurent+1}";
            return anulUniv;
            //anCurent}-{anCurent + 1}
        }
        


        void adaugaGrupeInListBox()
        {
            listBoxGrupe.SelectionMode = SelectionMode.One;
            listBoxGrupe.DataSource = null;
            listBoxGrupe.Sorted = true;
            listBoxGrupe.DataSource = listaGrupa.Where(a=>a.AnUniversitar==anulInCurs()).ToList();
            listBoxGrupe.DisplayMember = "AnSud_AnUniv";
        }

        void adaugaAnUniversitarInComboBox()
        {
            if (listBoxGrupe.SelectedIndex != -1)
            {
                string anUniv = ((Grupa)listBoxGrupe.SelectedItem).AnUniversitar;
                textBoxAnUniversitar.Text = anUniv;
            }

            

        }
        
        void NumericUpDownSem ()
        {
            numericUpDownSemestru.Minimum = 1;
            numericUpDownSemestru.Maximum = 2;
        }
        bool verificaDate()
        {
            if(listBoxDisiciplina.SelectedIndex==-1)
            {
                MessageBox.Show("Trebuie aleasa disciplina");
                return false;
            }
            if(listBoxProfesor.SelectedIndex==-1)
            {
                MessageBox.Show("Trebuie ales profesorul");
                return false;

            }
            if(listBoxGrupe.SelectedIndex==-1)
            {
                MessageBox.Show("Trebuie aleasa grupa");
                    return false;
            }
            if(textBoxAnUniversitar.Text=="")
            {
                MessageBox.Show("Trebuie ales anul universitar");
                return false;
            }
            if(numericUpDownSemestru.Value<1 || numericUpDownSemestru.Value>2)
            {
                MessageBox.Show("Trebuie ales semestrul 1 sau 2");
                return false;
            }
            return true;
        }

        private void buttonCreeazaAsocierea_Click(object sender, EventArgs e)
        {
            if(verificaDate())
            {
                string IdDisciplina = ((Disciplina)listBoxDisiciplina.SelectedItem).IdDisciplina;
                string CNP = ((Profesor)listBoxProfesor.SelectedItem).CNP.ToString();
                int IdGupa = ((Grupa)listBoxGrupe.SelectedItem).IdGrupa;
                string AnUniversitar = textBoxAnUniversitar.Text.ToString();
                if (listaAsociereProfesorDisciplinaGrupas.Count > 0)
                {
                    foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa1 in listaAsociereProfesorDisciplinaGrupas)
                    {
                        if (asociereProfesorDisciplinaGrupa1.IdDisciplina == IdDisciplina &&
                            asociereProfesorDisciplinaGrupa1.CNP == CNP && asociereProfesorDisciplinaGrupa1.IdGrupa == IdGupa &&
                            asociereProfesorDisciplinaGrupa1.AnUniversitar.Trim() == AnUniversitar.Trim() &&
                            asociereProfesorDisciplinaGrupa1.Semestrul == (int)numericUpDownSemestru.Value)
                        {
                            MessageBox.Show("Aceasta asociere este deja facuta");
                            return;
                        }
                    }
                }

                AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa = new AsociereProfesorDisciplinaGrupa()
                {
                    IdDisciplina = IdDisciplina,
                    CNP = CNP,
                    IdGrupa = IdGupa,
                    AnUniversitar = AnUniversitar,
                    Semestrul =(int)numericUpDownSemestru.Value
                };
                try
                {


                    ConexiuneBazaDeDate.InserareAsociereProfesorDsiciplinaGrupa(asociereProfesorDisciplinaGrupa);
                    MessageBox.Show("Asocierea a fost realizata cu succes");
                    listaAsociereProfesorDisciplinaGrupas.Add(asociereProfesorDisciplinaGrupa);
                    AsociereProfesorInListBox();
                }
                catch(Exception)
                {
                    MessageBox.Show("Asocierea nu a putut fi realizata");
                }
                
            }
        }

        private void textBoxAlegeDisiciplina_TextChanged(object sender, EventArgs e)
        {
            var output = listaDisciplina.Where(d => (d.Denumire).ToUpper().
            StartsWith(textBoxAlegeDisiciplina.Text.ToUpper())).ToList();
            listBoxDisiciplina.Sorted = true;
            listBoxDisiciplina.DataSource = null;
            listBoxDisiciplina.DataSource = output;
            listBoxDisiciplina.DisplayMember = "Denumire";
        }

        private void textBoxAlegeProfesor_TextChanged(object sender, EventArgs e)
        {
            var output = listaProfesori.Where(d => (d.Nume_Prenume_Profesor).ToUpper().
           StartsWith(textBoxAlegeProfesor.Text.ToUpper())).ToList();
            listBoxProfesor.Sorted = true;
            listBoxProfesor.DataSource = null;
            listBoxProfesor.DataSource = output;
            listBoxProfesor.DisplayMember = "Nume_Prenume_Profesor";
        }

        private void textBoxAlegeGrupa_TextChanged(object sender, EventArgs e)
        {
            var output = listaGrupa.Where(d => (d.AnSud_AnUniv).ToUpper().
           StartsWith(textBoxAlegeGrupa.Text.ToUpper())).ToList();
            listBoxGrupe.Sorted = true;
            listBoxGrupe.DataSource = null;
            listBoxGrupe.DataSource = output;
            listBoxGrupe.DisplayMember = "AnSud_AnUniv";
        }

        private void buttonStegereAsociere_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBoxAsocierepProfesorDisciplinaGrupa.SelectedIndex;

                if (selectedIndex != -1) // Verificăm dacă un element este selectat
                {
                    AsociereProfesorDisciplinaGrupa asociereSelectata = (AsociereProfesorDisciplinaGrupa)listBoxAsocierepProfesorDisciplinaGrupa.Items[selectedIndex];

                    ConexiuneBazaDeDate.StergeAsocierea(asociereSelectata);
                    listaAsociereProfesorDisciplinaGrupas.Remove(asociereSelectata);
                    AsociereProfesorInListBox();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Au aparut probleme la stergerea asocierii");
            }

        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareAdministrator fla = new FormLogareAdministrator();
            this.Hide();
            fla.ShowDialog();
        }

        private void listBoxGrupe_SelectedIndexChanged(object sender, EventArgs e)
        {

            adaugaAnUniversitarInComboBox();
        }
    }
}
