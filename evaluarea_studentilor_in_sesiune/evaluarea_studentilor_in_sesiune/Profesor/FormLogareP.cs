using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using evaluarea_studentilor_in_sesiune.Properties;
using System.IO;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormLogareP : Form
    {
        List<DespreMineP> listaInfoP = ConexiuneBazaDeDate.ExtragereDespreMineP();
        List<Profesor> listProfesori = ConexiuneBazaDeDate.ExtragereProfesor();
        List<Cont> listConturi = ConexiuneBazaDeDate.ExtragereConturi();
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        string NumePrenumeProfesor, UserName;

        public FormLogareP(string NumePrenumeProfesor)
        {
            InitializeComponent();
            this.NumePrenumeProfesor = NumePrenumeProfesor;
            // this.UserName = UserName;
            UserName = Form1.UserName1;
            numeP();
             addDataGrid();
            PozaCont();
        }
        public FormLogareP()
        {
            InitializeComponent();

            UserName = Form1.UserName1;
            numeP();
           addDataGrid();
            PozaCont();

        }
       
        void addDataGrid()
        {
            listaInfoP = ConexiuneBazaDeDate.ExtragereDespreMineP();
            dataGridViewDespreMineP.DataSource = null;
            var listDespreMineP = listaInfoP.Where(p => p.UserName == UserName ).GroupBy(g=>g.Denumire).Select(s=>s.First()).ToList();
            dataGridViewDespreMineP.DataSource = listDespreMineP;
            DataGridP();
        }

        void numeP()
        {
           foreach(Profesor profesor in listProfesori)
            {
                if (profesor.UserName == UserName)
                {
                    string numeCopmplet = $"{profesor.NumeProfesor}" + " " + $"{profesor.PrenumeProfesor}";


                    labelBunVenit.Text = $"Bun venit domnule/doamna Profesor {utility.FormatString(numeCopmplet)} " ;
                }
            }
                

        }

        private void buttonDespreMine_Click(object sender, EventArgs e)
        {
            if (dataGridViewDespreMineP.Visible == true)
            {
                dataGridViewDespreMineP.Visible = false;
                buttonActualizeazaDespreMine.Visible = false;  
            }
            else
            {
                dataGridViewDespreMineP.Visible = true;
                buttonActualizeazaDespreMine.Visible = true;
                
               
                addDataGrid();
            }



        }
        void PozaCont()
        {
            foreach (Cont conturi in listConturi)
            {
                if (conturi.UserName == UserName)
                {
                    pictureBoxProfesor.ImageLocation = conturi.Poza;
                    pictureBoxProfesor.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        private void buttonActualizeazaDespreMine_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Profesor profesor in listProfesori)
                {
                    foreach (DataGridViewCell cell in dataGridViewDespreMineP.SelectedCells)
                    {
                        DespreMineP despreMineP = (DespreMineP)dataGridViewDespreMineP.Rows[cell.RowIndex].DataBoundItem;
                        if (despreMineP.UserName == profesor.UserName)
                        {
                            profesor.Email = despreMineP.Email;
                            ConexiuneBazaDeDate.UpdateProfesor(profesor);
                            MessageBox.Show("Actulizare reusita.");
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Nu s-a putut realiza actualizarea");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdaugaIntrebari formAdaugaIntrebari = new FormAdaugaIntrebari();
            this.Hide();
            formAdaugaIntrebari.ShowDialog();
        }

        private void buttonPregatesteEvaluare_Click(object sender, EventArgs e)
        {
            FormPregatesteEvaluare fpe = new FormPregatesteEvaluare(UserName);
            this.Hide();
            fpe.ShowDialog();
        }

        private void pictureBoxProfesor_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ești sigur că vrei să schimbi poza?", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {

                    openFileDialog.Filter = "Fișiere de imagine|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Alegeți o imagine";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string caleImagine = openFileDialog.FileName;

                        pictureBoxProfesor.Image = Image.FromFile(caleImagine);

                        //  string numeImagine = Path.GetFileName(caleImagine);

                        string directorDestinatie = @"E:\facultate\anul 3\sem1\LICENTA\aplicatie evss\evaluarea_studentilor_in_sesiune\evaluarea_studentilor_in_sesiune\bin\Debug\IMAGINI UTILIZATOR";

                        string caleDestinatie = Path.Combine(directorDestinatie, Convert.ToString(UserName));

                        File.Copy(caleImagine, caleDestinatie, true);


                        ConexiuneBazaDeDate.UpdatePozaStud(caleDestinatie, UserName);
                    }
                }
            }
        }

        private void FormLogareP_FormClosed(object sender, FormClosedEventArgs e)
        {

            var da = MessageBox.Show("Confirmati inchiderea aplicatiei ?", "Atentie", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (da == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                FormLogareP logareP = new FormLogareP();
                this.Hide();
                logareP.ShowDialog();
                return;
            }

        }

        private void pictureBoxDelogare_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Dispose();
            f1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Dispose();
            f1.ShowDialog();
        }

        private void buttonEvaluareElevi_Click(object sender, EventArgs e)
        {
            FormEvaluariEleviP fep = new FormEvaluariEleviP();
            this.Hide();
            fep.ShowDialog();
        }

        private void buttonCatalog_Click(object sender, EventArgs e)
        {
            FormCatalogProfesor fcp = new FormCatalogProfesor();
            this.Hide();
            fcp.ShowDialog();
        }

        

        void DataGridP()
        {

            dataGridViewDespreMineP.Columns[0].HeaderText = "UserName";

            dataGridViewDespreMineP.Columns[1].HeaderText = "Nume Profesor";
            dataGridViewDespreMineP.Columns[2].HeaderText = "Prenume Profesor";
            dataGridViewDespreMineP.Columns[3].HeaderText = "Eamil";
            dataGridViewDespreMineP.Columns[4].HeaderText = "Grad";
            dataGridViewDespreMineP.Columns[5].HeaderText = "Discipline predate";

            dataGridViewDespreMineP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDespreMineP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewDespreMineP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewDespreMineP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewDespreMineP.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridViewDespreMineP.Columns[0].ReadOnly = true;
            dataGridViewDespreMineP.Columns[1].ReadOnly = true;
            dataGridViewDespreMineP.Columns[2].ReadOnly = true;
            dataGridViewDespreMineP.Columns[4].ReadOnly = true;
            dataGridViewDespreMineP.Columns[5].ReadOnly = true;

            dataGridViewDespreMineP.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 16);

            for (int i = 0; i < dataGridViewDespreMineP.ColumnCount; i++)
            {
                dataGridViewDespreMineP.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewDespreMineP.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewDespreMineP.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 16, FontStyle.Regular);
            }

            if (dataGridViewDespreMineP.Visible == false)
            {
                for (int i = 1; i < dataGridViewDespreMineP.RowCount; i++)
                {
                    for (int j = 0; j < dataGridViewDespreMineP.ColumnCount; j++)
                    {
                        if (j == 5)
                        {
                            continue;

                        }
                        else
                        {
                            dataGridViewDespreMineP.Rows[i].Cells[j].Value = "";

                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i < dataGridViewDespreMineP.RowCount; i++)
                {
                    for (int j = 0; j < dataGridViewDespreMineP.ColumnCount; j++)
                    {
                        if (j == 5)
                        {
                            continue;

                        }
                        else
                        {
                            dataGridViewDespreMineP.Rows[i].Cells[j].Value = "";

                        }
                    }
                }
            }
        }
    }
}






