using evaluarea_studentilor_in_sesiune.Properties;
using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormCatalogProfesor : Form
    {
        List<Student> listaStudent = ConexiuneBazaDeDate.ExtragereStudenti();
        List<IEREI> listaIerei = ConexiuneBazaDeDate.ExtrageIerei();
        List<Evaluare> listaEvaluare = ConexiuneBazaDeDate.ExtragereEvaluare();
        List<Grupa> listaGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        List<AsociereProfesorDisciplinaGrupa> listaApDg = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<Disciplina> listaDisciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<RezultateEvaluare> listaRezultateEvalure = ConexiuneBazaDeDate.ExtrageRezultateEvaluare();
        List<Profesor> listaProfesor = ConexiuneBazaDeDate.ExtragereProfesor();
        List<NotaCuEvaluare> listaNoteCuEvluare = ConexiuneBazaDeDate.ExtragereNotaCuEvaluare();
        List<Catalog> listaCatalog = ConexiuneBazaDeDate.ExtragereCatalog();
        List<Grupa> listaGrupa2 = new List<Grupa>();
        List<Disciplina> listaDiscipline2 = new List<Disciplina>();
        List<Cont> listaCont = ConexiuneBazaDeDate.ExtragereConturi();


        List<CatalogProfesor> listaCatalogProfesor = new List<CatalogProfesor>();
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        public FormCatalogProfesor()
        {
            InitializeComponent();
            CatalogProfesor();
            AdaugaGrupeInComboBox();
            AdaugaDisiciplineInComboBox();

        }
        string aflareProfesor()
        {
            string userName = Form1.UserName1;
            string cnp = "";
            foreach (Profesor profesor in listaProfesor)
            {
                if (userName == profesor.UserName)
                {
                    cnp = profesor.CNP;
                }
            }
            return cnp;
        }

        void AdaugaGrupeInComboBox()
        {
            comboBoxGrupa.DataSource = null;
            comboBoxGrupa.Sorted = true;
            foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaApDg)
            {
                foreach (Grupa grupa in listaGrupa)
                {
                    if (asociereProfesorDisciplinaGrupa.CNP == aflareProfesor() && asociereProfesorDisciplinaGrupa.IdGrupa == grupa.IdGrupa)
                    {
                        listaGrupa2.Add(grupa);
                    }
                }
            }
            var listaGrupeD = listaGrupa2.Distinct().ToList();
            comboBoxGrupa.DataSource = listaGrupeD;
            comboBoxGrupa.DisplayMember = "AnSud_AnUniv";

        }
        void AdaugaDisiciplineInComboBox()
        {

            comboBoxDisciplina.DataSource = null;
            comboBoxDisciplina.Sorted = true;
            foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaApDg)
            {
                foreach (Disciplina disciplina in listaDisciplina)
                {
                    if (asociereProfesorDisciplinaGrupa.CNP == aflareProfesor() && asociereProfesorDisciplinaGrupa.IdDisciplina == disciplina.IdDisciplina)
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

            comboBoxDisciplina.DataSource = listaDiscipline2.Distinct().ToList();
            comboBoxDisciplina.DisplayMember = "Denumire";

        }

        void CatalogProfesor()
        {
            string matrS = "";
            foreach (Student student in listaStudent)
            {
                foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaApDg)
                {
                    if (asociereProfesorDisciplinaGrupa.CNP == aflareProfesor())
                    {
                        foreach (AsociereStudentContGrupa asociereStudentContGrupa in listaAsociereStudentContGrupa)
                        {
                            if (asociereStudentContGrupa.IdGrupa == asociereProfesorDisciplinaGrupa.IdGrupa)
                            {
                                matrS = asociereStudentContGrupa.NrMatricol;
                                foreach (Disciplina disciplina in listaDisciplina)
                                {
                                    if (disciplina.IdDisciplina == asociereProfesorDisciplinaGrupa.IdDisciplina)
                                    {
                                        if (student.NrMatricol == matrS)
                                        {

                                            CatalogProfesor catalogProfesor = new CatalogProfesor()
                                            {
                                                NumeStudent = student.NumeStudent.ToUpper(),
                                                PrenumeStudent = student.PrenumeStudent.ToUpper(),
                                                disciplina = disciplina.Denumire,
                                                notaStudent = "-",
                                                Blocat = -1,
                                                IdGrupa = asociereProfesorDisciplinaGrupa.IdGrupa,
                                                IdNotaCatalog = -1

                                            };
                                            foreach (NotaCuEvaluare notaCuEvaluare in listaNoteCuEvluare)
                                            {
                                                if (notaCuEvaluare.IdGrupa == asociereProfesorDisciplinaGrupa.IdGrupa && disciplina.IdDisciplina == notaCuEvaluare.IdDIsciplina && notaCuEvaluare.NrMatricol == matrS)
                                                {
                                                    foreach (Catalog catalog in listaCatalog)
                                                    {
                                                        if (catalog.IdRezultat == notaCuEvaluare.IdRezultat)
                                                        {
                                                            catalogProfesor.IdNotaCatalog = catalog.IdNotaCatalog;
                                                            catalogProfesor.notaStudent = catalog.NotaCatalog.ToString();

                                                            catalogProfesor.Blocat = catalog.Blocat;
                                                            catalogProfesor.DataFinalNotaCatalog = notaCuEvaluare.DataFinalizareEvaluare;

                                                        }
                                                    }
                                                }
                                            }
                                            listaCatalogProfesor.Add(catalogProfesor);



                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            dataGridViewCatalogProfesor.DataSource = null;
            dataGridViewCatalogProfesor.DataSource = listaCatalogProfesor;
            dataGridP();
        }

        private void buttonDeblocheaza_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridViewCatalogProfesor.SelectedCells)
            {
                CatalogProfesor catalogProfesor = (CatalogProfesor)dataGridViewCatalogProfesor.Rows[cell.RowIndex].DataBoundItem;
                int idNotaCatalog = catalogProfesor.IdNotaCatalog;
                foreach (Catalog catalog in listaCatalog)
                {

                    if (idNotaCatalog == catalog.IdNotaCatalog)
                    {
                        if (catalogProfesor.Blocat == 1)
                        {

                            catalog.Blocat = 0;
                            catalog.IdNotaCatalog = idNotaCatalog;
                            catalogProfesor.Blocat = 0;
                            try
                            {
                                ConexiuneBazaDeDate.DeblocheazaBlocheazaStudent(catalog);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ceva nu a functionat");
                            }
                            MessageBox.Show("Acest student este deblocat");


                            return;
                        }
                        else if (catalogProfesor.Blocat == 0)
                        {
                            DialogResult result = MessageBox.Show("Acest student este deja deblocat.\nDoreiti sa il blocati?", "Atentie", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (result == DialogResult.Yes)
                            {

                                catalog.Blocat = 1;
                                catalog.IdNotaCatalog = idNotaCatalog;
                                catalogProfesor.Blocat = 1;


                                ConexiuneBazaDeDate.DeblocheazaBlocheazaStudent(catalog);
                                MessageBox.Show("Acest student este blocat");


                                return;


                            }
                        }
                    }
                    else if (idNotaCatalog == -1)
                    {
                        MessageBox.Show("Acest student trbuie sa aiba nota pentru a putea fi blocat/deblocat pentru evluari viitoare");
                        return;
                    }
                }


            }

        }

        void dataGridP()
        {
            dataGridViewCatalogProfesor.Columns["NumeStudent"].HeaderText = "Nume student";
            dataGridViewCatalogProfesor.Columns["PrenumeStudent"].HeaderText = "Prenume student";
            dataGridViewCatalogProfesor.Columns["Disciplina"].HeaderText = "Disciplina";
            dataGridViewCatalogProfesor.Columns["notaStudent"].HeaderText = "Nota";
            dataGridViewCatalogProfesor.Columns["Blocat"].HeaderText = "Observatii";
            dataGridViewCatalogProfesor.Columns["IdGrupa"].Visible = false;
            dataGridViewCatalogProfesor.Columns["IdNotaCatalog"].Visible = false;
            dataGridViewCatalogProfesor.Columns["DataFinalNotaCatalog"].HeaderText = "Data nota";

            dataGridViewCatalogProfesor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCatalogProfesor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCatalogProfesor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCatalogProfesor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCatalogProfesor.DefaultCellStyle.WrapMode = DataGridViewTriState.False;





            dataGridViewCatalogProfesor.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 22);

            foreach (DataGridViewColumn column in dataGridViewCatalogProfesor.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            for (int i = 0; i < dataGridViewCatalogProfesor.ColumnCount; i++)
            {

                dataGridViewCatalogProfesor.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewCatalogProfesor.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewCatalogProfesor.Columns[i].DefaultCellStyle.Font = new Font("Times New Roman", 18, FontStyle.Regular);
            }
        }

        private void dataGridViewCatalogProfesor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewCatalogProfesor.DataSource != null)
            {
                if (e.ColumnIndex == dataGridViewCatalogProfesor.Columns["Blocat"].Index && e.Value != null && e.Value.ToString() == "-1")
                {
                    e.Value = "Nu are notă în catalog";
                    e.FormattingApplied = true;
                }
                if (e.ColumnIndex == dataGridViewCatalogProfesor.Columns["Blocat"].Index && e.Value != null && e.Value.ToString() == "1")
                {
                    e.Value = "Nota trecuta in catalog";
                    e.FormattingApplied = true;
                }
                if (e.ColumnIndex == dataGridViewCatalogProfesor.Columns["Blocat"].Index && e.Value != null && e.Value.ToString() == "0")
                {
                    e.Value = "Nota nu e trecuta inca in catalog";
                    e.FormattingApplied = true;

                }
            }
        }

        private void comboBoxGrupa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDisciplina.SelectedIndex != -1)
            {
                int idGrupa = ((Grupa)comboBoxGrupa.SelectedItem).IdGrupa;
                var StudentiGrupa = listaCatalogProfesor.Where(i => i.IdGrupa == idGrupa);
                dataGridViewCatalogProfesor.DataSource = null;
                dataGridViewCatalogProfesor.DataSource = StudentiGrupa.ToList();
                dataGridP();
            }
        }

        private void comboBoxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDisciplina.SelectedIndex != -1)
            {
                string denumireDisciplina = ((Disciplina)comboBoxDisciplina.SelectedItem).Denumire;
                var StudentiDisicplina = listaCatalogProfesor.Where(d => d.disciplina.ToUpper().Trim() == denumireDisciplina.ToUpper().Trim()).ToList();
                dataGridViewCatalogProfesor.DataSource = null;
                dataGridViewCatalogProfesor.DataSource = StudentiDisicplina.ToList();
                dataGridP();
            }
        }

        private void textBoxNumeStudent_TextChanged(object sender, EventArgs e)
        {


            var NumeStudentCatalog = listaCatalogProfesor.Where(d => (d.NumeStudent).ToUpper().
              StartsWith(textBoxNumeStudent.Text.ToUpper())).ToList();
            dataGridViewCatalogProfesor.DataSource = null;
            dataGridViewCatalogProfesor.DataSource = NumeStudentCatalog.ToList();
            dataGridP();

        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareP flp = new FormLogareP();
            this.Hide();
            flp.ShowDialog();
        }

        private void checkBoxTotCatlogul_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTotCatlogul.Checked)
            {
                dataGridViewCatalogProfesor.DataSource = null;
                dataGridViewCatalogProfesor.DataSource = listaCatalogProfesor.ToList();
                dataGridP();
            }
        }
    }
}
