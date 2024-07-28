using evaluarea_studentilor_in_sesiune.Properties;
using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormLogareAdministrator : Form
    {
        List<Cont> listConturi = ConexiuneBazaDeDate.ExtragereConturi();
        List<Profesor> listaProfesori = ConexiuneBazaDeDate.ExtragereProfesor();
        List<AsociereStudentContGrupa> ListaasociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<DespreMineP> listaDepreMineP = ConexiuneBazaDeDate.ExtragereDespreMineP();
        List<DespreMineS> listDespreMineS = ConexiuneBazaDeDate.ExtragereInfo();

        List<Student> listaStudenti = ConexiuneBazaDeDate.ExtragereStudenti();
        bool asteptare=true;
        int statusCont = 0;

        public FormLogareAdministrator()
        {
            InitializeComponent();
            timerAnimareMeniu.Interval = 10;
            adaugaDateInDataGrid();

        }

        private void timerAnimareMeniu_Tick(object sender, EventArgs e)
        {
           

            if (asteptare)
            {

                panelMeniu.Height -= 80;
                if (panelMeniu.Height == panelMeniu.MinimumSize.Height)
                {
                    asteptare = false;
                    timerAnimareMeniu.Stop();
                }
            }
            else
            {
                panelMeniu.Height += 30;
                if (panelMeniu.Height == panelMeniu.MaximumSize.Height)
                {
                    asteptare = true;
                    timerAnimareMeniu.Stop();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timerAnimareMeniu.Start();
            pictureBoxMeniu.Image = RotesteImagine(pictureBoxMeniu.Image,90);
        }
        private Image RotesteImagine(Image imagine, float unghi)
        {
            // Crează o matrice de transformare pentru rotație
            Matrix matrix = new Matrix();
            matrix.RotateAt(unghi, new Point(imagine.Width / 2, imagine.Height / 2));

            // Creează o imagine nouă pe baza matricei de transformare
            Bitmap imagineRotita = new Bitmap(imagine.Width, imagine.Height);
            using (Graphics g = Graphics.FromImage(imagineRotita))
            {
                g.Transform = matrix;
                g.DrawImage(imagine, new Point(0, 0));
            }

            return imagineRotita;
        }

        private void buttonAdaugaSpecializarw_Click(object sender, EventArgs e)
        {
            FormAdaugaSpecializare formAdaugaSpecializare = new FormAdaugaSpecializare();
            this.Hide();
            formAdaugaSpecializare.ShowDialog();
        }

        private void buttonAdaugaDisciplina_Click(object sender, EventArgs e)
        {
            FormAdaugaDisciplina formAdaugaDisciplina = new FormAdaugaDisciplina();
            this.Hide();
            formAdaugaDisciplina.ShowDialog();
        }
        void adaugaDateInDataGrid()
        {
            var listaContruiVizulizat = listConturi
     .Where(s => s.StatusCont == 1 || s.StatusCont == 2).ToList();
            dataGridViewConturiInactiveDezecativate.SelectionMode = (DataGridViewSelectionMode)SelectionMode.One;


            dataGridViewConturiInactiveDezecativate.DataSource = listaContruiVizulizat.ToList();
            dataGridP();

        }

        void dataGridP()
        {
            dataGridViewConturiInactiveDezecativate.Columns[0].HeaderText = "User name";
            dataGridViewConturiInactiveDezecativate.Columns[1].Visible = false;
            dataGridViewConturiInactiveDezecativate.Columns[2].HeaderText = "Tip cont";
            dataGridViewConturiInactiveDezecativate.Columns[3].HeaderText = "Status cont";
            dataGridViewConturiInactiveDezecativate.Columns[4].Visible = false;

            dataGridViewConturiInactiveDezecativate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewConturiInactiveDezecativate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewConturiInactiveDezecativate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewConturiInactiveDezecativate.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewConturiInactiveDezecativate.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridViewConturiInactiveDezecativate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewConturiInactiveDezecativate.AutoResizeColumns();

            dataGridViewConturiInactiveDezecativate.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 18);
            for (int i = 0; i < dataGridViewConturiInactiveDezecativate.ColumnCount; i++)
            {

                dataGridViewConturiInactiveDezecativate.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewConturiInactiveDezecativate.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewConturiInactiveDezecativate.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 16, FontStyle.Regular);

            }
        }

        private void buttonConturiInactiveSauDezacrivate_Click(object sender, EventArgs e)
        {
            if (dataGridViewConturiInactiveDezecativate.Visible == false)
            {
                if (dataGridViewConturiInactiveDezecativate.RowCount>0)
                {

                    dataGridViewConturiInactiveDezecativate.Visible = true;
                }
                else
                {
                    dataGridViewConturiInactiveDezecativate.Visible = false;
                    MessageBox.Show("Momentan nu exista conturi dezactivate sau inactive");
                }

            }
            else
            {
                dataGridViewConturiInactiveDezecativate.Visible = false;
                dataGridViewInfomatiiSuplimentareCont.Visible = false;
                buttonActivareCont.Visible = false;
            }
        }
        

        private void dataGridViewConturiInactiveDezecativate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ////// Verificăm dacă suntem în coloana corespunzătoare și în rândul corespunzător
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridViewConturiInactiveDezecativate.Columns["TipCont"].Index ||
                                   e.ColumnIndex == dataGridViewConturiInactiveDezecativate.Columns["StatusCont"].Index))
            {
                // Obținem valoarea celulei corespunzătoare
                var cellValue = dataGridViewConturiInactiveDezecativate.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (e.ColumnIndex == dataGridViewConturiInactiveDezecativate.Columns["TipCont"].Index)
                {
                    // Setăm culoarea și textul în funcție de valoarea din coloana "TipCont"
                    if (cellValue != null && cellValue.ToString() == "0")
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                        e.Value = "Admin";
                    }
                    else if (cellValue != null && cellValue.ToString() == "1")
                    {
                        e.CellStyle.BackColor = Color.Blue;
                        e.CellStyle.ForeColor = Color.Black;
                        e.Value = "Profesor";
                    }
                    else if (cellValue != null && cellValue.ToString() == "2")
                    {
                        e.CellStyle.BackColor = Color.DeepSkyBlue;
                        e.CellStyle.ForeColor = Color.Black;
                        e.Value = "Student";
                    }
                }
                else if (e.ColumnIndex == dataGridViewConturiInactiveDezecativate.Columns["StatusCont"].Index)
                {
                    // Setăm culoarea și textul în funcție de valoarea din coloana "StatusCont"
                    if (cellValue != null && cellValue.ToString() == "1")
                    {
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.ForeColor = Color.Black;
                        e.Value = "Dezactivat";
                    }
                    else if (cellValue != null && cellValue.ToString() == "2")
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.Black;
                        e.Value = "Inactiv";
                    }
                }
            }
        }

        private void dataGridViewConturiInactiveDezecativate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridViewInfomatiiSuplimentareCont.Visible = true;
            buttonActivareCont.Visible = true;
            adaugaDateInDataGridInfoSuplimentar();

        }

        void adaugaDateInDataGridInfoSuplimentar()
        {
            string userC = "";
            int tipCont = 0;

            foreach (DataGridViewCell cell in dataGridViewConturiInactiveDezecativate.SelectedCells)
            {
                Cont conturi = (Cont)dataGridViewConturiInactiveDezecativate.Rows[cell.RowIndex].DataBoundItem;

                userC = conturi.UserName;
                tipCont = conturi.TipCont;

            }
            if (tipCont == 1)
            {
                var listaInfoSuplInDataGrid = listaDepreMineP.Where(u => u.UserName == userC).ToList();
                dataGridViewInfomatiiSuplimentareCont.DataSource = listaInfoSuplInDataGrid;

                dataGridpP();
                if (listaInfoSuplInDataGrid.Count < 1)
                {
                    dataGridViewInfomatiiSuplimentareCont.Visible = false;
                    MessageBox.Show("Nu sunt date despre acest ptofesor");
                    return;
                }
            }
            else if (tipCont == 2)
            {

                var listaInfoSuplInDataGrid = listDespreMineS.Where(u => u.UserName == userC).ToList();
                dataGridViewInfomatiiSuplimentareCont.DataSource = listaInfoSuplInDataGrid;
                dataGridpS();
                if (listaInfoSuplInDataGrid.Count == 0)
                {
                    dataGridViewInfomatiiSuplimentareCont.Visible = false;
                    MessageBox.Show("Nu sunt date despre acest student");
                    return;
                    
                }
            }
        }

        void dataGridpS()
        {
            dataGridViewInfomatiiSuplimentareCont.Columns[0].HeaderText = "Numar matricol";
            dataGridViewInfomatiiSuplimentareCont.Columns[1].HeaderText = "Nume student";
            dataGridViewInfomatiiSuplimentareCont.Columns[2].HeaderText = "Prenume student";
            dataGridViewInfomatiiSuplimentareCont.Columns[3].HeaderText = "Telefon";
            dataGridViewInfomatiiSuplimentareCont.Columns[4].HeaderText = "Email";
            dataGridViewInfomatiiSuplimentareCont.Columns[5].HeaderText = "User name";
            dataGridViewInfomatiiSuplimentareCont.Columns[6].HeaderText = "An de studiu";
            dataGridViewInfomatiiSuplimentareCont.Columns[7].HeaderText = "An univeristar";
            dataGridViewInfomatiiSuplimentareCont.Columns[8].HeaderText = "Nume specializare";

            dataGridViewInfomatiiSuplimentareCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInfomatiiSuplimentareCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewInfomatiiSuplimentareCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewInfomatiiSuplimentareCont.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewInfomatiiSuplimentareCont.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridViewInfomatiiSuplimentareCont.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 16);


            for (int i = 0; i < dataGridViewInfomatiiSuplimentareCont.ColumnCount; i++)
            {
                dataGridViewInfomatiiSuplimentareCont.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewInfomatiiSuplimentareCont.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewInfomatiiSuplimentareCont.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Regular);
            }

        }
        void dataGridpP()
        {
            dataGridViewInfomatiiSuplimentareCont.Columns[0].HeaderText = "User name";
            dataGridViewInfomatiiSuplimentareCont.Columns[1].HeaderText = "Nume profesor";
            dataGridViewInfomatiiSuplimentareCont.Columns[2].HeaderText = "Prenume profesor";
            dataGridViewInfomatiiSuplimentareCont.Columns[3].HeaderText = "Email";
            dataGridViewInfomatiiSuplimentareCont.Columns[4].HeaderText = "Grad";
            dataGridViewInfomatiiSuplimentareCont.Columns[5].HeaderText = "Discipline predate";

            dataGridViewInfomatiiSuplimentareCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInfomatiiSuplimentareCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewInfomatiiSuplimentareCont.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewInfomatiiSuplimentareCont.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewInfomatiiSuplimentareCont.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridViewInfomatiiSuplimentareCont.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 16);
            for (int i = 0; i < dataGridViewInfomatiiSuplimentareCont.ColumnCount; i++)
            {
                dataGridViewInfomatiiSuplimentareCont.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewInfomatiiSuplimentareCont.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewInfomatiiSuplimentareCont.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Regular);
            }
            for (int i = 1; i < dataGridViewInfomatiiSuplimentareCont.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewInfomatiiSuplimentareCont.ColumnCount; j++)
                {
                    if (j == 5)
                    {
                        continue;
                    }
                    else
                    {
                        dataGridViewInfomatiiSuplimentareCont.Rows[i].Cells[j].Value = "";
                    }
                }
            }
        }

        private void buttonAdaugaGrupele_Click(object sender, EventArgs e)
        {
            FormAdaugaGrupele fag = new FormAdaugaGrupele();
            this.Hide();
            fag.ShowDialog();
        }

        private void buttonActivareCont_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esti sigur ca vrei sa activezi acest utilizator?", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {

                if (dataGridViewConturiInactiveDezecativate.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell cell in dataGridViewConturiInactiveDezecativate.SelectedCells)
                    {

                        Cont conturi = (Cont)dataGridViewConturiInactiveDezecativate.Rows[cell.RowIndex].DataBoundItem;
                        int tipCont = conturi.TipCont;
                        string userC = conturi.UserName;
                        int stareCont = conturi.StatusCont;
                        if (tipCont != 0)
                        {
                            if (stareCont == 2 || stareCont == 1)
                            {

                                conturi.StatusCont = 0;
                                ConexiuneBazaDeDate.ActulizareCont(conturi);
                                MessageBox.Show("Contul a fost activat");
                                adaugaDateInDataGrid();
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void pictureBoxDelogare_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void buttonConturiInAdministrare_Click(object sender, EventArgs e)
        {
            FormConuriAdministare fca = new FormConuriAdministare();
            this.Hide();
            fca.ShowDialog();
        }

        private void FormLogareAdministrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            var da = MessageBox.Show("Confirmati inchiderea aplicatiei ?", "Atentie", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (da == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                FormLogareAdministrator fla = new FormLogareAdministrator();
                this.Hide();
                fla.ShowDialog();
                return;
            }
        }

        private void buttonAdaugaStudentProfesor_Click(object sender, EventArgs e)
        {
            FormCreareCont fcc = new FormCreareCont(statusCont);
            this.Hide();
            fcc.ShowDialog();
        }

        private void buttonAsociereprofesorDisciplinaGrupa_Click(object sender, EventArgs e)
        {
            FormAsociereProfesorDIsiciplinaGrupa fapdg = new FormAsociereProfesorDIsiciplinaGrupa();
            this.Hide();
            fapdg.ShowDialog();
;
        }
    }
}
