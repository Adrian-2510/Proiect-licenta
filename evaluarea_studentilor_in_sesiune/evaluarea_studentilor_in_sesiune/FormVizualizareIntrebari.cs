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
    public partial class FormVizualizareIntrebari : Form
    {
        List<Disciplina> listaDisciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<Itemi> listaItemi = ConexiuneBazaDeDate.ExtragereItemi();
        List<Disciplina> listaDiscipline2 = new List<Disciplina>();
        List<AsociereProfesorDisciplinaGrupa> listaAsociereProfesorDisciplinaGrupas = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<Profesor> listaProfesor = ConexiuneBazaDeDate.ExtragereProfesor();
        string UserNameP;


        public FormVizualizareIntrebari()
        {
            InitializeComponent();
            AdaugaEnuntInListbox();
            AdaugaDisciplineInComboBox();
            listBoxIntrebari.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxIntrebari.MeasureItem += new MeasureItemEventHandler(listBoxIntrebari_MeasureItem);
            listBoxIntrebari.DrawItem += new DrawItemEventHandler(listBoxIntrebari_DrawItem);
            AdaugaEnuntInListbox();

        }

        private void listBoxIntrebari_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            Itemi item = listBoxIntrebari.Items[e.Index] as Itemi;
            SizeF size = e.Graphics.MeasureString(item.EnuntItem, listBoxIntrebari.Font, listBoxIntrebari.Width);
            e.ItemHeight = (int)size.Height;
        }

        private void listBoxIntrebari_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            
            e.DrawBackground();
            e.DrawFocusRectangle();

            Itemi item = listBoxIntrebari.Items[e.Index] as Itemi;
            Rectangle bounds = e.Bounds;

            // Folosim StringFormat pentru a permite înfășurarea textului
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Near;
            format.Trimming = StringTrimming.Word;

            e.Graphics.DrawString(item.EnuntItem, listBoxIntrebari.Font, Brushes.Black, bounds, format);
        }
        string ExtragereCNPdupaUser()
        {
            string CNPP = string.Empty;
            UserNameP = Form1.UserName1;
            foreach (Profesor profesor in listaProfesor)
            {
                if (profesor.UserName == UserNameP)
                {
                    CNPP = profesor.CNP;
                }
            }
            return CNPP;
        }
        void AdaugaDisciplineInComboBox()
        {
            comboBoxDiscipline.DataSource = null;
            comboBoxDiscipline.Sorted = true;
            foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaAsociereProfesorDisciplinaGrupas)
            {
                foreach (Disciplina disciplina in listaDisciplina)
                {
                    if (asociereProfesorDisciplinaGrupa.CNP == ExtragereCNPdupaUser() && asociereProfesorDisciplinaGrupa.IdDisciplina == disciplina.IdDisciplina)
                    {

                        listaDiscipline2.Add(disciplina);
                    }
                }
            }

            for (int i = 0; i < listaDiscipline2.Count(); i++)
            {
                for (int j = i + 1; j < listaDiscipline2.Count(); j++)
                {
                    if (listaDiscipline2[i] == listaDiscipline2[j])
                    {
                        listaDiscipline2.Remove(listaDiscipline2[i]);
                    }
                }
            }

            comboBoxDiscipline.DataSource = listaDiscipline2.Distinct().ToList();
            comboBoxDiscipline.DisplayMember = "Denumire";

        }
        void AdaugaEnuntInListbox()
        {

            listBoxIntrebari.DataSource = null;
            listBoxIntrebari.Sorted = true;
            if (comboBoxDiscipline.SelectedIndex != -1)
            {
                var listaItemiPeDisc = listaItemi.Where(i => i.IdDisciplina == ((Disciplina)comboBoxDiscipline.SelectedItem).IdDisciplina).ToList();
                listBoxIntrebari.DataSource = listaItemiPeDisc;
                listBoxIntrebari.SelectionMode = SelectionMode.One;
                listBoxIntrebari.DisplayMember = "EnuntItem";
            }

        }

        private void comboBoxDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdaugaEnuntInListbox();
        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormAdaugaIntrebari fai = new FormAdaugaIntrebari();
            this.Hide();
            fai.ShowDialog();
        }

        private void listBoxIntrebari_DoubleClick(object sender, EventArgs e)
        {
            int item = ((Itemi)listBoxIntrebari.SelectedItem).IdItem;
            FormAdaugaIntrebari fai = new FormAdaugaIntrebari(item);
            this.Hide();
            fai.ShowDialog();
        }
    }

}

