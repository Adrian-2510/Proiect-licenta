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
    public partial class FormAdaugaGrupele : Form
    {
        List<Specializare> listaSpecialiare = ConexiuneBazaDeDate.ExtrageSpecializari();
        List<Disciplina> listaDisiciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<Grupa> listaGrupe = ConexiuneBazaDeDate.ExtragereGrupa();
        List<AsociereProfesorDisciplinaGrupa> listaApDg = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<AsociereStudentContGrupa> listaAsCg = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<Evaluare> listaEvaluare = ConexiuneBazaDeDate.ExtragereEvaluare();
       
        public FormAdaugaGrupele()
        {
            InitializeComponent();
            adaugaAnUniversitarInComboBox();
            adaugaSpecializareInComboBox();
            adaugaGrupeInListBox();
           
        }

        void adaugaAnUniversitarInComboBox()
        {
            int anCurent = DateTime.Now.Year;
            int lunaCurenta = DateTime.Now.Month;

            if (lunaCurenta >= 10 && lunaCurenta <= 12)
            {
                anCurent++;
            }
            else if(lunaCurenta>=1 && lunaCurenta<=9)
            {
                anCurent--;
            }

            for (int i = 0; i < 1; i++)
            {
               
                comboBoxAnUniversitar.Items.Add($"{anCurent}-{anCurent + 1}");
                
                
                //anCurent++;
            }
           


        }
        void adaugaSpecializareInComboBox()
        {
            comboBoxSpecializare.DataSource = null;
            comboBoxSpecializare.Sorted = true;
            comboBoxSpecializare.DataSource = listaSpecialiare;
            comboBoxSpecializare.DisplayMember = "NumeSpecializare";
        }
        void adaugaGrupeInListBox()
        {
            listBoxGrupe.DataSource = null;
            listBoxGrupe.Sorted = true;
            listBoxGrupe.DataSource = listaGrupe;
            listBoxGrupe.DisplayMember = "AnSud_AnUniv";
        }
      
       
                 
        bool verificaDatele()
        {
            if(comboBoxAnUniversitar.SelectedIndex==-1)
            {
                MessageBox.Show("Trebuie selectat anul universitar");
                return false;
            }
            if(comboBoxAnStudiu.SelectedIndex==-1)
            {
                MessageBox.Show("Trebuie ales anul de studiu");
                return false;
            }
            if(comboBoxSpecializare.SelectedIndex==-1)
            {
                MessageBox.Show("Trebuie selectataSpecializarea");
                return false;
            }
            return true;
        }

        private void buttonCreeazaGrupa_Click(object sender, EventArgs e)
        {
            if(verificaDatele())
            {
                string anUniveristar = comboBoxAnUniversitar.SelectedItem.ToString();
                string anStudiu =comboBoxAnStudiu.SelectedItem.ToString();
                string codSpecializare = ((Specializare)comboBoxSpecializare.SelectedItem).CodSpecializare.ToString();
              
                int idGrupa;
                    if(listaGrupe.Count==0)
                {
                    idGrupa = 1;
                }
                else
                {
                    idGrupa = listaGrupe.Max(i => i.IdGrupa) + 1;
                }
                foreach(Grupa grupa in listaGrupe )
                {
                    if(grupa.AnUniversitar==anUniveristar && grupa.AnDeStudiu== Convert.ToInt32(anStudiu) && grupa.CodSpecializare==codSpecializare )
                    {
                        MessageBox.Show("Deja exista o grupa cu aceste atribute");
                        return;
                    }
                }
                Grupa grupa1 = new Grupa()
                {
                    IdGrupa= idGrupa,
                    AnUniversitar = anUniveristar,
                    AnDeStudiu =Convert.ToInt32( anStudiu),
                    CodSpecializare = codSpecializare
                };
                ConexiuneBazaDeDate.InserareGrupa(grupa1);
                MessageBox.Show("Grupa introdusa cu succes");
                listaGrupe.Add(grupa1);
                adaugaGrupeInListBox();
            }
        }

        private void buttonStergere_Click(object sender, EventArgs e)
        {
            int idGrupa = ((Grupa)listBoxGrupe.SelectedItem).IdGrupa;
            Grupa indexGrupa = listaGrupe[listBoxGrupe.SelectedIndex];
            ConexiuneBazaDeDate.StergereGrupa(idGrupa);
            MessageBox.Show("Grupa eliminata cu succes");
            listaGrupe.Remove(indexGrupa);
            adaugaGrupeInListBox();
        }

        private void buttonActualizare_Click(object sender, EventArgs e)
        {
            if(listBoxGrupe.SelectedIndex==-1)
            {
                MessageBox.Show("Pentru a face actulizarea trebuie selectata o grupa");
                return;
            }
            string anUniveristar = comboBoxAnUniversitar.SelectedItem.ToString();
            string anStudiu = comboBoxAnStudiu.SelectedItem.ToString();
            string codSpecializare = ((Specializare)comboBoxSpecializare.SelectedItem).CodSpecializare.ToString();
            int idGrupa = ((Grupa)listBoxGrupe.SelectedItem).IdGrupa;
            Grupa grupa1 = new Grupa()
            {
               
                AnUniversitar = anUniveristar,
                AnDeStudiu = Convert.ToInt32(anStudiu),
                CodSpecializare = codSpecializare
            };

            try
            {
                ConexiuneBazaDeDate.ActualizareGrupa(grupa1, idGrupa);
                MessageBox.Show("Grupa actulizata cu succes");
               foreach(Grupa grupa in listaGrupe)
                {
                    if(grupa.IdGrupa==idGrupa)
                    {
                        grupa.AnUniversitar = anUniveristar;
                        grupa.AnDeStudiu = Convert.ToInt32( anStudiu);
                        grupa.CodSpecializare = codSpecializare;
                    }
                }
                adaugaGrupeInListBox();
            }
            catch(Exception)
            {
                MessageBox.Show("Din pacate a aparut o eroare la nivelul actualizarii");
            }
            

        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareAdministrator fla = new FormLogareAdministrator();
            this.Hide();
            fla.ShowDialog();
        }

        private void listBoxGrupe_Click(object sender, EventArgs e)
        {
            int codGrupa = ((Grupa)listBoxGrupe.SelectedItem).IdGrupa;
            foreach(AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaApDg)
            {
                if(asociereProfesorDisciplinaGrupa.IdGrupa==codGrupa)
                {
                    buttonActualizare.Enabled = false;
                    buttonStergere.Enabled = false;
                    return;
                }
                else
                {
                    buttonActualizare.Enabled = true;
                    buttonStergere.Enabled = true;
                }
                         
            }
            foreach(AsociereStudentContGrupa asociereStudentContGrupa in listaAsCg)
            {
                if(asociereStudentContGrupa.IdGrupa==codGrupa)
                {
                    buttonActualizare.Enabled = false;
                    buttonStergere.Enabled = false;
                    return;
                }
                else
                {
                    buttonActualizare.Enabled = true;
                    buttonStergere.Enabled = true;
                }

            }
            foreach(Evaluare evaluare in listaEvaluare)
            {
                if(evaluare.IdGrupa==codGrupa)
                {
                    buttonActualizare.Enabled = false;
                    buttonStergere.Enabled = false;
                    return;
                }
                else
                {
                    buttonActualizare.Enabled = true;
                    buttonStergere.Enabled = true;
                }

            }
        }
    }
    
}
