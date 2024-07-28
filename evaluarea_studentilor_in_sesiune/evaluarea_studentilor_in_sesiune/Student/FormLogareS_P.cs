using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using evaluarea_studentilor_in_sesiune.Properties;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using Image = iTextSharp.text.Image;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormLogareS_P : Form
    {

        List<Cont> listConturi = ConexiuneBazaDeDate.ExtragereConturi();
        List<DespreMineS> listaInfoS = ConexiuneBazaDeDate.ExtragereInfo();
        List<Student> listaStudenti = ConexiuneBazaDeDate.ExtragereStudenti();
        List<AsociereStudentContGrupa> listaasociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<object> listaCarnetNote = new List<object>();
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<Grupa> listaGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        List<Evaluare> listaEvaluare = ConexiuneBazaDeDate.ExtragereEvaluare();
        List<AsociereProfesorDisciplinaGrupa> listaApDg = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<RezultateEvaluare> listaRezultateEvaluare = ConexiuneBazaDeDate.ExtrageRezultateEvaluare();
        List<Disciplina> listaDicipline = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<DisciplinaNota> listaDisciplineNote = new List<DisciplinaNota>();
        List<NotaCuEvaluare> listaNoteCuEvluare = ConexiuneBazaDeDate.ExtragereNotaCuEvaluare();
        List<Catalog> listaCatalog = ConexiuneBazaDeDate.ExtragereCatalog();

        string NumePrenumeStud, UserName, NrMatricol, matr1;
        string numeComplet;
        int idGrupa;
        string format = "dd MM yyyy HH:mm";

        public FormLogareS_P(string NumePrenumeStud, string UserName)
        {
            this.NumePrenumeStud = NumePrenumeStud;
            this.UserName = UserName;

            InitializeComponent();
            numeS();


            adaugaNoteInCarnet();

            listaDisciplineNote = adaugaNoteInCarnet();
            anulCurent();
            PozaCont();


        }
        public FormLogareS_P()
        {
            InitializeComponent();

            UserName = Form1.UserName1;
            numeS();
            PozaCont();
            adaugaNoteInCarnet();


        }

        //List<object> listaCarnet()
        //{
        //    var listaCarnetNote = from RezultateEvaluare in listaRezultateEvaluare
        //                          join Evaluare in listaEvaluare on RezultateEvaluare.IdEvaluare equals Evaluare.IdEvaluare
        //                          join Grupa in listaGrupa on Evaluare.IdGrupa equals Grupa.IdGrupa
        //                          join AsociereStudentContGrupa in listaAsociereStudentContGrupa on RezultateEvaluare.NrMatricol equals AsociereStudentContGrupa.NrMatricol
        //                          join AsociereProfesorDisciplinaGrupa in listaApDg on Grupa.IdGrupa equals AsociereProfesorDisciplinaGrupa.IdGrupa
        //                          join Disciplina in listaDicipline on Evaluare.IdDIsciplina equals Disciplina.IdDisciplina
        //                          select new
        //                          {
        //                              Disciplina = Disciplina.Denumire,
        //                              nota = RezultateEvaluare.NotaEvaluare,
        //                              NrMatricol = RezultateEvaluare.NrMatricol,
        //                              idDisciplina = Disciplina.IdDisciplina,
        //                              idGrupa = Grupa.IdGrupa

        //                          };

        //    return listaCarnetNote.Cast<object>().ToList();

        //}

        List<DisciplinaNota> adaugaNoteInCarnet()
        {
            listaDisciplineNote = new List<DisciplinaNota>();
            foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplina in listaApDg)
            {
                foreach (Disciplina disciplina in listaDicipline)
                {
                    if (asociereProfesorDisciplina.IdGrupa == idGrupa && disciplina.IdDisciplina == asociereProfesorDisciplina.IdDisciplina)
                    {
                        DisciplinaNota disciplinaNota = new DisciplinaNota
                        {
                            Disciplina = disciplina.Denumire,
                            Nota = "-",
                            IdDisciplina = disciplina.IdDisciplina,
                            NrMatricol = matr1


                        };

                        foreach (Grupa grupa in listaGrupa)
                        {
                            if (grupa.IdGrupa == idGrupa)
                            {
                                disciplinaNota.IdGrupa = grupa.IdGrupa;
                                disciplinaNota.Anul = grupa.AnDeStudiu;


                            }
                        }

                        foreach (NotaCuEvaluare notaCuEvaluare in listaNoteCuEvluare)
                        {

                            if (notaCuEvaluare.IdDIsciplina == disciplina.IdDisciplina && notaCuEvaluare.NrMatricol == matr1)
                            {

                                foreach (Catalog catalog in listaCatalog)
                                {
                                    if (catalog.IdRezultat == notaCuEvaluare.IdRezultat)
                                    {
                                        
                                        
                                            disciplinaNota.Nota = catalog.NotaCatalog.ToString();
                                            disciplinaNota.DataFinalizareEvaluare = notaCuEvaluare.DataFinalizareEvaluare.ToString(format);
                                            if (disciplinaNota.Nota == Convert.ToString(-1))
                                            {
                                                disciplinaNota.Nota = "-";
                                            }
                                        
                                    }
                                }

                            }


                        }


                        listaDisciplineNote.Add(disciplinaNota);

                    }
                }
            }




            dataGridViewCarnetNote.DataSource = null;
            dataGridViewCarnetNote.DataSource = listaDisciplineNote.ToList();
            dataGridPCarnet();
            return listaDisciplineNote.ToList();
        }


        void numeS()
        {
            string matr = "";
            foreach (AsociereStudentContGrupa asociereStudentContGrupa in listaasociereStudentContGrupa)
            {
                if (asociereStudentContGrupa.UserName == UserName)
                {
                    matr = asociereStudentContGrupa.NrMatricol;
                    idGrupa = asociereStudentContGrupa.IdGrupa;
                    matr1 = asociereStudentContGrupa.NrMatricol;
                }
            }
            string specializare = listaInfoS.Where(n => n.NrMatricol == matr).Select(s => s.NumeSpecializare).First();
            labelNrMatricol.Text = "Numar mtricol:" + matr;
            labelSpecializare.Text = "Specializare:" + specializare;
            foreach (Student student in listaStudenti)
            {
                if (student.NrMatricol == matr)
                {
                    labelBunVenit.Text = "Bun venit domnul/doamna student " + student.NumeStudent + " " + student.PrenumeStudent;
                       
                    numeComplet = $"{student.NumeStudent} " + $"{student.PrenumeStudent}";
                 

                    labelBunVenit.Text = "Bun venit domnul/doamna student " +$"{utility.FormatString(numeComplet)}";

                    return;
                }
            }

        }
        void PozaCont()
        {
            foreach (Cont conturi in listConturi)
            {
                if (conturi.UserName == UserName)
                {
                    pictureBoxPozaStud.ImageLocation = conturi.Poza;
                    pictureBoxPozaStud.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        void DespreMineInDataGrid()
        {
            var listaDespreMine = listaInfoS.Where(d => d.UserName == UserName).ToList();

            dataGridViewDespreMine.DataSource = listaDespreMine;

            dataGridP();

        }



        private void pictureBoxPozaStud_MouseHover(object sender, EventArgs e)
        {
            pictureBoxPozaStud.Cursor = Cursors.Hand;
        }

        private void pictureBoxPozaStud_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ești sigur că vrei să schimbi poza?", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Fișiere de imagine|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Alegeți o imagine";



                    foreach (AsociereStudentContGrupa asociereStudentContGrupa in listaasociereStudentContGrupa)
                    {

                        if (asociereStudentContGrupa.UserName == UserName)
                        {
                            NrMatricol = asociereStudentContGrupa.NrMatricol;
                            NrMatricol += ".jpg";
                        }
                    }

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


                        pictureBoxPozaStud.Image = System.Drawing.Image.FromFile(caleImagine);


                        //  string numeImagine = Path.GetFileName(caleImagine);


                        string directorDestinatie = @"E:\facultate\anul 3\sem1\LICENTA\aplicatie evss\evaluarea_studentilor_in_sesiune\evaluarea_studentilor_in_sesiune\bin\Debug\IMAGINI UTILIZATOR";

                        string caleDestinatie = Path.Combine(directorDestinatie, Convert.ToString(stringNrm));

                        File.Copy(caleImagine, caleDestinatie, true);


                        ConexiuneBazaDeDate.UpdatePozaStud(caleDestinatie, UserName);
                    }
                }
            }
        }

        private void buttonDespreMine_Click(object sender, EventArgs e)
        {
            if (dataGridViewDespreMine.Visible == false)
            {

                DespreMineInDataGrid();
                dataGridViewDespreMine.Visible = true;
                buttonActualizeazaDespreMine.Visible = true;
            }
            else
            {
                DespreMineInDataGrid();
                dataGridViewDespreMine.Visible = false;
                buttonActualizeazaDespreMine.Visible = false;
            }

        }
        //void cdateIndataGrid()
        //{
        //    var listaCarnetNote = from RezultateEvaluare in listaRezultateEvaluare
        //                          join Evaluare in listaEvaluare on RezultateEvaluare.IdEvaluare equals Evaluare.IdEvaluare
        //                          join Grupa in listaGrupa on Evaluare.IdGrupa equals Grupa.IdGrupa
        //                          join AsociereStudentContGrupa in listaAsociereStudentContGrupa on RezultateEvaluare.NrMatricol equals AsociereStudentContGrupa.NrMatricol
        //                          join AsociereProfesorDisciplinaGrupa in listaApDg on Grupa.IdGrupa equals AsociereProfesorDisciplinaGrupa.IdGrupa
        //                          join Disciplina in listaDicipline on AsociereProfesorDisciplinaGrupa.IdDisciplina equals Disciplina.IdDisciplina
        //                          select new
        //                          {
        //                              Disciplina = Disciplina.Denumire,
        //                              nota = RezultateEvaluare.NotaEvaluare,
        //                              NrMatricol = RezultateEvaluare.NrMatricol,
        //                              idDisciplina = Disciplina.IdDisciplina,
        //                              idGrupa = Grupa.IdGrupa,
        //                              anul = Grupa.AnDeStudiu
        //                          };






        //    var listaUnica = listaCarnetNote.GroupBy(x => x.Disciplina)
        //                              .Select(g => g.First())
        //                              .ToList();

        //    dataGridViewCarnetNote.DataSource = listaUnica;



        //}

        //void dataGridP1()
        //{
        //    dataGridViewCarnetNote.Columns["Disciplina"].HeaderText="Diciplina"
        //}




        private void FormLogareS_P_FormClosed(object sender, FormClosedEventArgs e)
        {
            var da = MessageBox.Show("Confirmati inchiderea aplicatiei ?", "Atentie", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (da == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                FormLogareS_P fls = new FormLogareS_P();
                
                fls.ShowDialog();
                return;
            }
        }

        private void pictureBoxDelogare_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void buttonVizualizareEvaluari_Click(object sender, EventArgs e)
        {
            FormVizualizareEvaluari fve = new FormVizualizareEvaluari();
            this.Hide();
            fve.ShowDialog();
        }

        private void buttonCarnetNote_Click(object sender, EventArgs e)
        {
            int idGrupa = -1;

            if (panelCarnetNote.Visible == true)
            {
                panelCarnetNote.Visible = false;
            }
            else
            {
                panelCarnetNote.Visible = true;
            }
            foreach(AsociereStudentContGrupa asociereStudentContGrupa in listaasociereStudentContGrupa)
            {
                if(asociereStudentContGrupa.UserName.ToUpper()==Form1.UserName1.ToUpper())
                {
                    idGrupa = asociereStudentContGrupa.IdGrupa;
                    break;
                }
            }
            foreach (Grupa grupa in listaGrupa)
            {
                if(grupa.IdGrupa==idGrupa)
                {
                    numericUpDownAnStudiu.Value = grupa.AnDeStudiu;
                    break;
                }
            }
        }

        private void buttonDelogare_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void numericUpDownAnStudiu_ValueChanged(object sender, EventArgs e)
        {

            var listaNoteFiltrate = listaDisciplineNote.Where(a => a.Anul == numericUpDownAnStudiu.Value).ToList();

            dataGridViewCarnetNote.DataSource = listaNoteFiltrate;
            if (listaNoteFiltrate.Count == 0)
            {
                MessageBox.Show("Inca nu sunt date pentru acest an");
            }
            // dataGridP();
        }
        void anulCurent()
        {
            foreach (Grupa grupa in listaGrupa)
            {
                if (grupa.IdGrupa == idGrupa)
                {
                    numericUpDownAnStudiu.Value = grupa.AnDeStudiu;
                }
            }
        }

        private void pictureBoxPdfNote_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"Note {numeComplet}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    Document document = new Document();
                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, stream);
                    
                    document.Open();

                    // Adaugă un titlu centrat
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph($"Note student {numeComplet}");
                    title.Alignment = Element.ALIGN_CENTER;
                    title.Font.Size = 20f;
                    title.Font = FontFactory.GetFont(FontFactory.TIMES_BOLD, 20f);
                    document.Add(title);

                    // Adaugă spațiu vertical
                    document.Add(new iTextSharp.text.Paragraph("\n"));

                    // Adaugă datele din DataGridView

                    PdfPTable table = new PdfPTable(4); // Doar coloanele 0, 1 și 5

                    PdfPCell disciplinaHeaderCell = new PdfPCell(new Phrase("Disciplina"));
                    disciplinaHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(disciplinaHeaderCell);

                    PdfPCell notaHeaderCell = new PdfPCell(new Phrase("Nota"));
                    notaHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(notaHeaderCell);

                    PdfPCell anulHeaderCell = new PdfPCell(new Phrase("Anul"));
                    anulHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(anulHeaderCell);

                    PdfPCell dataHeaderCell = new PdfPCell(new Phrase("Data"));
                    dataHeaderCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(dataHeaderCell);
                    // Aliniere centrată pentru conținutul celulelor

                    for (int i = 0; i < dataGridViewCarnetNote.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridViewCarnetNote.ColumnCount; j++)
                        {
                            if (j == 0 || j == 1 || j == 5 ||j==6)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(dataGridViewCarnetNote[j, i].Value?.ToString() ?? "Valoare lipsă"));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER; // Aliniere centrată pentru conținutul celulelor
                                table.AddCell(cell);
                                
                            }
                        }
                    }
                  


                    table.WidthPercentage = 100; // Lățimea tabelului să fie 100% din pagina PDF
                    table.SpacingBefore = 40f; // Adaugă 40px spațiu înainte de tabel

                    document.Add(table);
                    table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    PdfContentByte cb = writer.DirectContent;
                    Image img = Image.GetInstance(@"E:\facultate\anul 3\sem1\LICENTA\aplicatie evss\imagini\logo dreapta.jpg");
                    float newWidth = 100f;
                    float aspectRatio = img.Width / img.Height;
                    float newHeight = newWidth / aspectRatio;
                    img.ScaleAbsolute(newWidth, newHeight);

                    // Setează poziția imaginii în colțul din dreapta sus
                    img.SetAbsolutePosition(document.PageSize.Width - img.ScaledWidth - 10, document.PageSize.Height - img.ScaledHeight - 10);
                    cb.AddImage(img);
                    Image watermark = Image.GetInstance(@"E:\facultate\anul 3\sem1\LICENTA\aplicatie evss\imagini\logo dreapta.jpg");

                    // Setează dimensiunea watermark-ului
                    float watermarkWidth = 500f;
                    float watermarkHeight = watermarkWidth / aspectRatio;
                    watermark.ScaleAbsolute(watermarkWidth, watermarkHeight);

                    // Setează poziția watermark-ului în centrul paginii
                    watermark.SetAbsolutePosition(
                        (document.PageSize.Width - watermark.ScaledWidth) / 2,
                        (document.PageSize.Height - watermark.ScaledHeight) / 2
                    );

                    // Setează transparența watermark-ului
                    PdfGState gState = new PdfGState();
                    gState.FillOpacity = 0.2f; // Setează opacitatea (0.0 = complet transparent, 1.0 = complet opac)
                    cb.SaveState();
                    cb.SetGState(gState);
                    cb.AddImage(watermark);
                    cb.RestoreState();

                    ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, new Phrase("One Academy"), document.PageSize.Width / 2, document.PageSize.GetBottom(60), 0);
                    ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, new Phrase($"Document generat in data de:{DateTime.Now}"), document.PageSize.Width / 2, document.PageSize.GetBottom(80), 0);
                    document.Close();
                }


                MessageBox.Show("PDF generat cu succes!");
            }
        }

        
        

        private void buttonActualizeazaDespreMine_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Esti sigur ca vrei sa modifici datele", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No)
            {
                List<DespreMineS> listaInfoS2 = ConexiuneBazaDeDate.ExtragereInfo();
                var listaDespreMine = listaInfoS2.Where(d => d.UserName == UserName).ToList();
                dataGridViewDespreMine.DataSource = listaDespreMine;
                return;
            }
            foreach (Student student in listaStudenti)
            {


                foreach (DataGridViewCell cell in dataGridViewDespreMine.SelectedCells)
                {
                    DespreMineS despreMine = (DespreMineS)dataGridViewDespreMine.Rows[cell.RowIndex].DataBoundItem;

                    if (despreMine.NrMatricol == student.NrMatricol)
                    {

                        student.Telefon = despreMine.Telefon;
                        student.Email = despreMine.Email;
                        ConexiuneBazaDeDate.UpdateStud(student);
                        MessageBox.Show("Date modificate cu succes");
                    }

                }
            }
        }

        void dataGridPCarnet()
        {
            dataGridViewCarnetNote.Columns["Disciplina"].HeaderText = "Disciplina";
            dataGridViewCarnetNote.Columns["Nota"].HeaderText = "Nota";
            dataGridViewCarnetNote.Columns["IdGrupa"].Visible = false;
            dataGridViewCarnetNote.Columns["NrMatricol"].Visible = false;
            dataGridViewCarnetNote.Columns["IdDisciplina"].Visible = false;
            dataGridViewCarnetNote.Columns["DataFinalizareEvaluare"].HeaderText = "Data nota";
            dataGridViewCarnetNote.Columns["Anul"].HeaderText = "Anul";

            dataGridViewCarnetNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCarnetNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCarnetNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCarnetNote.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCarnetNote.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridViewCarnetNote.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewDespreMine.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 16);
            foreach (DataGridViewRow row in dataGridViewCarnetNote.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null || cell.Value == DBNull.Value || String.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        cell.Value = "-";
                    }
                }
            }
            foreach (DataGridViewColumn column in dataGridViewCarnetNote.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < dataGridViewDespreMine.ColumnCount; i++)
            {

                dataGridViewDespreMine.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewDespreMine.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewDespreMine.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 16 , FontStyle.Regular);
            }
        }


        void dataGridP()
        {
            dataGridViewDespreMine.Columns[0].HeaderText = "Numar matricol";
            dataGridViewDespreMine.Columns[1].HeaderText = "Nume";
            dataGridViewDespreMine.Columns[2].HeaderText = "Prenume";
            dataGridViewDespreMine.Columns[3].HeaderText = "Telefon";
            dataGridViewDespreMine.Columns[4].HeaderText = "Email";
            dataGridViewDespreMine.Columns[5].HeaderText = "User name";
            dataGridViewDespreMine.Columns[6].HeaderText = "An de studiu";
            dataGridViewDespreMine.Columns[7].HeaderText = "An universitar";
            dataGridViewDespreMine.Columns[8].HeaderText = "Specializare";


            dataGridViewDespreMine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDespreMine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewDespreMine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewDespreMine.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewDespreMine.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
           


            dataGridViewDespreMine.Columns[0].ReadOnly = true;
            dataGridViewDespreMine.Columns[1].ReadOnly = true;
            dataGridViewDespreMine.Columns[2].ReadOnly = true;
            dataGridViewDespreMine.Columns[5].ReadOnly = true;
            dataGridViewDespreMine.Columns[6].ReadOnly = true;
            dataGridViewDespreMine.Columns[7].ReadOnly = true;
            dataGridViewDespreMine.Columns[8].ReadOnly = true;

            dataGridViewDespreMine.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 16);
            for (int i = 0; i < dataGridViewDespreMine.ColumnCount; i++)
            {

                dataGridViewDespreMine.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewDespreMine.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewDespreMine.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            }
            



        }
    }
}



