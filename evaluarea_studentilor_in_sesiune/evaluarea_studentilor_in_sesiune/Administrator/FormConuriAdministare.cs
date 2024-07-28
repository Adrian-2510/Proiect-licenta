using evaluarea_studentilor_in_sesiune.Properties;
using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormConuriAdministare : Form
    {
        List<Cont> listConturi = ConexiuneBazaDeDate.ExtragereConturi();
        List<Profesor> listaProfesori = ConexiuneBazaDeDate.ExtragereProfesor();
        List<AsociereStudentContGrupa> ListaasociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<DespreMineP> listaDepreMineP = ConexiuneBazaDeDate.ExtragereDespreMineP();
        List<DespreMineS> listDespreMineS = ConexiuneBazaDeDate.ExtragereInfo();
        List<Student> listaStudenti = ConexiuneBazaDeDate.ExtragereStudenti();
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<Grupa> listaGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        List<Specializare> listaSpecialziare = ConexiuneBazaDeDate.ExtrageSpecializari();
        List<RadioButton> listaRadioButton = new List<RadioButton>();
        string UserName;
        public FormConuriAdministare()
        {
            InitializeComponent();
            adaugaDateInDataGrid();
            adaugareRbTipCont();
            adaugaRbStatusCont();

        }

        private void dataGridViewConturiT_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificăm dacă suntem în coloana corespunzătoare și în rândul corespunzător
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridViewConturiT.Columns["TipCont"].Index ||
                                   e.ColumnIndex == dataGridViewConturiT.Columns["StatusCont"].Index))
            {
                // Obținem valoarea celulei corespunzătoare
                var cellValue = dataGridViewConturiT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (e.ColumnIndex == dataGridViewConturiT.Columns["TipCont"].Index)
                {
                    // Setăm culoarea și textul în funcție de valoarea din coloana "TipCont"
                    if (cellValue != null && cellValue.ToString() == "0")
                    {
                        e.CellStyle.BackColor = Color.Yellow;
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
                else if (e.ColumnIndex == dataGridViewConturiT.Columns["StatusCont"].Index)
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
                    else if (cellValue != null && cellValue.ToString() == "0")
                    {
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.Black;
                        e.Value = "Activ";
                    }
                }
            }
        }
        void adaugareRbTipCont()
        {
            foreach (Control control in groupBoxTipCont.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += RadioButton_CheckedChanged; ;
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewContInfo.DataSource = null;
            RadioButton rbt = (RadioButton)sender;
            if (rbt.Checked)
            {
                if (rbt.Text == "Profesor")
                {

                    var listaContruiVizulizat = listConturi
                    /* .Where(s => s.StatusCont == StatusCont())*/.Where(t => t.TipCont == 1).ToList();
                    dataGridViewConturiT.SelectionMode = (DataGridViewSelectionMode)SelectionMode.One;

                    dataGridViewConturiT.DataSource = listaContruiVizulizat.ToList();
                    dataGridP();

                }
                else if (rbt.Text == "Student")
                {

                    var listaContruiVizulizat = listConturi
                    /*.Where(s => s.StatusCont == StatusCont())*/.Where(t => t.TipCont == 2).ToList();
                    dataGridViewConturiT.SelectionMode = (DataGridViewSelectionMode)SelectionMode.One;

                    dataGridViewConturiT.DataSource = listaContruiVizulizat.Where(t=>t.TipCont!=0).ToList();
                    dataGridP();
                }
                else if (rbt.Text == "Toate")
                {
                    
                        var listaContruiVizulizat = listConturi.ToList();
                        

                        dataGridViewConturiT.SelectionMode = (DataGridViewSelectionMode)SelectionMode.One;

                        dataGridViewConturiT.DataSource = listaContruiVizulizat.ToList();
                        dataGridP();
                    
                }
            }
        }
        int StatusCont()
        {
            int statusCont = 4;
            if (radioButtonActiv.Checked)
            {
                statusCont = 0;
            }
            else if (radioButtonInactiv.Checked)
            {
                statusCont = 2;

            }
            return statusCont;
        }
        int TipCont()
        {
            int tipCont = 3; // Implicit, nu s-a selectat nicio opțiune

            if (radioButtonProfesor.Checked)
            {
                tipCont = 1;
            }
            else if (radioButtonStudent.Checked)
            {
                tipCont = 2;
            }

            return tipCont;
        }

        void adaugaRbStatusCont()
        {
            foreach (Control control in groupBoxStatusCont.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += RadioButton_CheckedChanged1;
                }
            }
        }
        private void RadioButton_CheckedChanged1(object sender, EventArgs e)
        {
            RadioButton rbs = (RadioButton)sender;

            if (rbs.Checked)
            {
                if (rbs.Text == "Activ")
                {
                    var listaContruiVizulizat = listConturi
                    .Where(s => s.StatusCont == 0)/*.Where(t => t.TipCont == TipCont())*/.ToList();
                    dataGridViewConturiT.SelectionMode = (DataGridViewSelectionMode)SelectionMode.One;

                    dataGridViewConturiT.DataSource = listaContruiVizulizat.ToList();
                    dataGridP();
                }
                else if (rbs.Text == "Inactiv/Dezactivat")
                {
                    var listaContruiVizulizat = listConturi
                       .Where(s => s.StatusCont == 1 || s.StatusCont == 2)/*.Where(t => t.TipCont == TipCont())*/.ToList();
                    dataGridViewConturiT.SelectionMode = (DataGridViewSelectionMode)SelectionMode.One;

                    dataGridViewConturiT.DataSource = listaContruiVizulizat.ToList();
                    dataGridP();
                }
                else if (rbs.Text == "Toate")
                {
                    var listaContruiVizulizat = listConturi
                    .Where(s => s.StatusCont == 1 || s.StatusCont == 2 || s.StatusCont == 0)/*.Where(t => t.TipCont == TipCont())*/.ToList();
                    dataGridViewConturiT.SelectionMode = (DataGridViewSelectionMode)SelectionMode.One;

                    dataGridViewConturiT.DataSource = listaContruiVizulizat.ToList();
                    dataGridP();
                }
            }
        }

        void adaugaDateInDataGrid()
        {
            var listaContruiVizulizat = listConturi
                     .Where(s => s.StatusCont == 1 || s.StatusCont == 2 || s.StatusCont == 0).Where(t=>t.TipCont!=0).ToList();
            dataGridViewConturiT.SelectionMode = (DataGridViewSelectionMode)SelectionMode.One;

            dataGridViewConturiT.DataSource = listaContruiVizulizat.ToList();
            dataGridP();

        }
        void dataGridP()
        {
            dataGridViewConturiT.Columns[0].HeaderText = "User name";
            dataGridViewConturiT.Columns[1].Visible = false;
            dataGridViewConturiT.Columns[2].HeaderText = "Tip cont";
            dataGridViewConturiT.Columns[3].HeaderText = "Status cont";
            dataGridViewConturiT.Columns[4].Visible = false;

            dataGridViewConturiT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewConturiT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewConturiT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewConturiT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewConturiT.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridViewConturiT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewConturiT.AutoResizeColumns();

            dataGridViewConturiT.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 18);
            for (int i = 0; i < dataGridViewConturiT.ColumnCount; i++)
            {
                dataGridViewConturiT.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewConturiT.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewConturiT.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 16, FontStyle.Regular);
            }
        }

        void adaugaDateInDataGridInfoSuplimentar()
        {
            string userC = "";
            int tipCont = 0;

            foreach (DataGridViewCell cell in dataGridViewConturiT.SelectedCells)
            {
                Cont conturi = (Cont)dataGridViewConturiT.Rows[cell.RowIndex].DataBoundItem;

                userC = conturi.UserName;
                tipCont = conturi.TipCont;
            }
            if (tipCont == 1)
            {
                listaDepreMineP = ConexiuneBazaDeDate.ExtragereDespreMineP();
                var listaInfoSuplInDataGrid = listaDepreMineP.Where(u => u.UserName == userC).GroupBy(x => x.Denumire).Select(g => g.First()).ToList();
                dataGridViewContInfo.DataSource = listaInfoSuplInDataGrid;

                dataGridpP();
                if (listaInfoSuplInDataGrid.Count < 1)
                {
                    MessageBox.Show("Nu sunt date despre acest ptofesor");
                }
            }
            else if (tipCont == 2)
            {
                var listaInfoSuplInDataGrid = listDespreMineS.Where(u => u.UserName == userC).ToList();
                dataGridViewContInfo.DataSource = listaInfoSuplInDataGrid;
                dataGridpS();
                if (listaInfoSuplInDataGrid.Count < 1)
                {
                    MessageBox.Show("Nu sunt date despre acest student");
                }
            }
        }
        void dataGridpS()
        {

            dataGridViewContInfo.Columns[0].HeaderText = "Numar matricol";
            dataGridViewContInfo.Columns[1].HeaderText = "Nume student";
            dataGridViewContInfo.Columns[2].HeaderText = "Prenume student";
            dataGridViewContInfo.Columns[3].HeaderText = "Telefon";
            dataGridViewContInfo.Columns[4].HeaderText = "Email";
            dataGridViewContInfo.Columns[5].HeaderText = "User name";
            dataGridViewContInfo.Columns[6].HeaderText = "An de studiu";
            dataGridViewContInfo.Columns[7].HeaderText = "An univeristar";
            dataGridViewContInfo.Columns[8].HeaderText = "Nume specializare";

            dataGridViewContInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewContInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewContInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewContInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewContInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridViewContInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 16);

            for (int i = 0; i < dataGridViewContInfo.ColumnCount; i++)
            {
                dataGridViewContInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewContInfo.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewContInfo.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Regular);
            }
        }

        void dataGridpP()
        {

            dataGridViewContInfo.Columns[0].HeaderText = "User name";
            dataGridViewContInfo.Columns[1].HeaderText = "Nume profesor";
            dataGridViewContInfo.Columns[2].HeaderText = "Prenume profesor";
            dataGridViewContInfo.Columns[3].HeaderText = "Email";
            dataGridViewContInfo.Columns[4].HeaderText = "Grad";
            dataGridViewContInfo.Columns[5].HeaderText = "Discipline predate";

            dataGridViewContInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewContInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewContInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewContInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewContInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            for (int i = 0; i < dataGridViewContInfo.ColumnCount; i++)
            {
                dataGridViewContInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewContInfo.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewContInfo.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 16, FontStyle.Regular);
            }
            for (int i = 1; i < dataGridViewContInfo.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewContInfo.ColumnCount; j++)
                {
                    if (j == 5)
                    {
                        continue;
                    }
                    else
                    {
                        dataGridViewContInfo.Rows[i].Cells[j].Value = "";
                    }
                }
            }
        }
        private void dataGridViewConturiT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridViewConturiT.SelectedCells)
            {
                Cont conturi = (Cont)dataGridViewConturiT.Rows[cell.RowIndex].DataBoundItem;
            }
            adaugaDateInDataGridInfoSuplimentar();
        }
        private void buttonActivareCont_Click(object sender, EventArgs e)
        {
            if (dataGridViewConturiT.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dataGridViewConturiT.SelectedCells)
                {

                    Cont conturi = (Cont)dataGridViewConturiT.Rows[cell.RowIndex].DataBoundItem;
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

        private void buttonDezactivareCont_Click(object sender, EventArgs e)
        {
            if (dataGridViewConturiT.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dataGridViewConturiT.SelectedCells)
                {
                    Cont conturi = (Cont)dataGridViewConturiT.Rows[cell.RowIndex].DataBoundItem;
                    int tipCont = conturi.TipCont;
                    string userC = conturi.UserName;
                    int stareCont = conturi.StatusCont;
                    if (tipCont != 0)
                    {
                        if (stareCont == 0 || stareCont == 2)
                        {

                            conturi.StatusCont = 1;
                            ConexiuneBazaDeDate.ActulizareCont(conturi);
                            MessageBox.Show("Contul a fost dezactivat");
                            adaugaDateInDataGrid();
                            return;
                        }
                    }
                }
            }
        }

        private void buttonModificaDate_Click(object sender, EventArgs e)
        {
            Cont conturi;
            string UserName = "";
            int tipCont = -1;
            int IdGrupa = -1;
            int IdGrupaVer = -1;
            string codSpec = "";
            int contor = 0;
            //int verificareGrupa = 0;
            foreach (DataGridViewCell cell in dataGridViewConturiT.SelectedCells)
            {
                conturi = (Cont)dataGridViewConturiT.Rows[cell.RowIndex].DataBoundItem;
                UserName = conturi.UserName;
                tipCont = conturi.TipCont;
            }
            if (tipCont == 2)
            {
                DialogResult result = MessageBox.Show("Esti sigur ca vrei sa modifici datele", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No)
                {
                    List<DespreMineS> listaInfoS2 = ConexiuneBazaDeDate.ExtragereInfo();
                    var listaDespreMine = listaInfoS2.Where(d => d.UserName == UserName).ToList();
                    dataGridViewContInfo.DataSource = listaDespreMine;
                    return;
                }


                foreach (DataGridViewCell cell in dataGridViewContInfo.SelectedCells)
                {
                    foreach (Student student in listaStudenti)
                    {
                        DespreMineS despreMine = (DespreMineS)dataGridViewContInfo.Rows[cell.RowIndex].DataBoundItem;
                        if (despreMine.NrMatricol == student.NrMatricol)
                        {
                            student.Telefon = despreMine.Telefon;
                            student.Email = despreMine.Email;
                            student.NumeStudent = despreMine.NumeStudent;
                            student.PrenumeStudent = despreMine.PrenumeStudent;
                            foreach (Cont cont in listConturi)
                            {
                                if (cont.UserName == UserName)
                                {
                                    cont.UserName = despreMine.UserName;
                                    ConexiuneBazaDeDate.ActulizareCont(cont);

                                }
                            }
                            foreach (AsociereStudentContGrupa asociereStudentContGrupa in listaAsociereStudentContGrupa)
                            {
                                if (asociereStudentContGrupa.UserName == despreMine.UserName)
                                {
                                    IdGrupaVer = asociereStudentContGrupa.IdGrupa;
                                    foreach (Specializare specializare in listaSpecialziare)
                                    {
                                        if (specializare.NumeSpecializare == despreMine.NumeSpecializare)
                                        {
                                            codSpec = specializare.CodSpecializare;
                                        }
                                    }
                                }

                                foreach (Grupa grupa in listaGrupa)
                                {
                                    int aparitie = 0;
                                    if (codSpec == grupa.CodSpecializare && grupa.AnDeStudiu == despreMine.AnDeStudiu
                                        && grupa.AnUniversitar == despreMine.AnUniversitar && grupa.IdGrupa == IdGrupaVer)
                                    {
                                        contor+=1;
                                        IdGrupa = grupa.IdGrupa;
                                        asociereStudentContGrupa.IdGrupa = IdGrupa;
                                        ConexiuneBazaDeDate.ActualizeazaAsociereStudentContGrupa(asociereStudentContGrupa);

                                    }
                                   
                                }


                            }
                            if(contor==0)
                            {
                                MessageBox.Show("Nu exista anul de studiu si anul universitar pentru aceasta specializare");
                                
                            }
                            ConexiuneBazaDeDate.UpdateStud(student);
                            MessageBox.Show("Date modificate cu succes");
                        }
                    }
                }
            }
            else if (tipCont == 1)
            {
                DialogResult result = MessageBox.Show("Esti sigur ca vrei sa modifici datele", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No)
                {
                    List<DespreMineS> listaInfoS2 = ConexiuneBazaDeDate.ExtragereInfo();
                    var listaDespreMine = listaInfoS2.Where(d => d.UserName == UserName).ToList();
                    dataGridViewContInfo.DataSource = listaDespreMine;
                    return;
                }

                foreach (Profesor profesor in listaProfesori)
                {
                    foreach (DataGridViewCell cell in dataGridViewContInfo.SelectedCells)
                    {
                        DespreMineP despreMine = (DespreMineP)dataGridViewContInfo.Rows[cell.RowIndex].DataBoundItem;

                        if (despreMine.UserName == profesor.UserName)
                        {

                            profesor.NumeProfesor = despreMine.NumeProfesor;
                            profesor.PrenumeProfesor = despreMine.PrenumeProfesor;
                            profesor.Email = despreMine.Email;
                            profesor.UserName = despreMine.UserName;
                            ConexiuneBazaDeDate.UpdateProfesor(profesor);
                            MessageBox.Show("Date modificate cu succes");
                        }
                    }
                }
            }
        }
       
        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareAdministrator fla = new FormLogareAdministrator();
            this.Hide();
            fla.ShowDialog();
        }
        private void checkBoxSchimbaParola_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxParola.Visible = true;
            if (checkBoxSchimbaParola.Checked)
            {
                textBoxSchimbaParola.Visible = true;
                pictureBoxSchimbaParola.Visible = true;
                pictureBoxParola.Visible = true;
            }
            else
            {
                textBoxSchimbaParola.Visible = false;
                pictureBoxSchimbaParola.Visible = false;
                pictureBoxParola.Visible = false;
            }
        }
        void SendEmail(string email,string nouaParola)
        {

            try
            {
                SmtpClient sc = new SmtpClient();
                sc.EnableSsl = true;
                sc.Port = 587;
                sc.Host = "smtp.mail.yahoo.com";
                sc.EnableSsl = true;
                sc.Timeout = 10000;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential("nicolescumarian10@yahoo.com", "fjhh tzhi aznz euky");
                string msg_subject = "Schimbare parola pentru contul de pe 'One Academy' ";
                string msg_body = "Noua prola pentru contul dumneavoastra pentru 'One Academy' este: "+nouaParola;
                MailMessage mm = new MailMessage("nicolescumarian10@yahoo.com", email, msg_subject, msg_body);
                //System.Net.Mail.Attachment attachment;
                // attachment = new System.Net.Mail.Attachment(path);
                // mm.Attachments.Add(attachment);
                sc.Send(mm);
                MessageBox.Show("Mesajul a fost trimis cu succes");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema intampinata este " + ex);
            }
        }
        private async void pictureBoxSchimbaParola_Click(object sender, EventArgs e)
        {
            int contor = 0;
            string email = "";
            string matr = "";
            try
            {
                foreach (DataGridViewCell cell in dataGridViewConturiT.SelectedCells)
                {
                    Cont conturi = (Cont)dataGridViewConturiT.Rows[cell.RowIndex].DataBoundItem;
                    
                    if (!utility.VerificareParola(textBoxSchimbaParola.Text) || string.IsNullOrEmpty(textBoxSchimbaParola.Text))
                    {
                        MessageBox.Show("Parola invalida...");
                        return;
                    }
                    else
                    {
                        conturi.Parola = utility.CripteazaParola(textBoxSchimbaParola.Text);
                    }
                    if (contor == 0)
                    {
                        contor = 1;
                        ConexiuneBazaDeDate.ActulizareCont(conturi);
                        MessageBox.Show($"Pentru contul cu user:{conturi.UserName} s-a schimbat parola\nParola este:{textBoxSchimbaParola.Text}");
                        checkBoxSchimbaParola.Checked = false;
                        textBoxSchimbaParola.Visible = false;
                        pictureBoxSchimbaParola.Visible = false;
                    }
                    if(conturi.TipCont==1)
                    {
                        foreach(Profesor profesor in listaProfesori)
                        {
                            if(profesor.UserName==conturi.UserName)
                            {
                                email = profesor.Email;
                                SendEmail(email,textBoxSchimbaParola.Text);
                                pictureBoxSendEmail.Visible = true;
                                await Task.Delay(2000);
                                this.Invoke((MethodInvoker)delegate
                                {
                                    pictureBoxSendEmail.Visible = false;
                                });
                                return;
                            }
                        }
                    }
                    else if(conturi.TipCont==2)
                    {
                        foreach(AsociereStudentContGrupa asociereStudentContGrupa in listaAsociereStudentContGrupa)
                        {
                            if(conturi.UserName==asociereStudentContGrupa.UserName)
                            {
                                matr = asociereStudentContGrupa.NrMatricol;
                                foreach(Student student in listaStudenti )
                                {
                                    if(student.NrMatricol==matr)
                                    {
                                        email = student.Email;
                                        SendEmail(email, textBoxSchimbaParola.Text);
                                        
                                        pictureBoxSendEmail.Visible = true;
                                        await Task.Delay(2000);
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            pictureBoxSendEmail.Visible = false;
                                        });
                                        return;
                                    }
                                }
                            }   
                            
                        }
                    }

                }
               
               
            }
            catch (Exception)
            {
                MessageBox.Show("Parola nu a potut fi schimbata, va rugam incercati mai tarziu");
            }
        }
        

        

        private void pictureBoxParola_Click_1(object sender, EventArgs e)
        {
            if (textBoxSchimbaParola.PasswordChar == '●')
            {
                textBoxSchimbaParola.PasswordChar = '\0';
                pictureBoxParola.Image = Properties.Resources.pozac_lacat_deschis;
            }
            else if (textBoxSchimbaParola.PasswordChar == '\0')
            {
                textBoxSchimbaParola.PasswordChar = '●';
                pictureBoxParola.Image = Properties.Resources.pozaParola;
            }
        }

       
    }
}
