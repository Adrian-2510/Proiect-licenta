using evaluarea_studentilor_in_sesiune.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace evaluarea_studentilor_in_sesiune
{


    public partial class FormAdaugaIntrebari : Form
    {
        List<Disciplina> listaDisciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<Itemi> listaItemi = ConexiuneBazaDeDate.ExtragereItemi();
        List<ItemiEvaluare> listaItemiEvaluare = ConexiuneBazaDeDate.ExtragereItemiEvaluare();
        List<Disciplina> listaDiscipline2 = new List<Disciplina>();
        List<AsociereProfesorDisciplinaGrupa> listaAsociereProfesorDisciplinaGrupas = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<string> raspunsuriSelectate = new List<string>();

        List<Profesor> listaProfesor = ConexiuneBazaDeDate.ExtragereProfesor();

        string raspunsCorect1, EnuntPoza, raspunsCorect2, raspunsCorect3;
        string UserNameP;
        int activare = 0;
        int item,IdItem;
      
        public FormAdaugaIntrebari()
        {
            InitializeComponent();
            AdaugaDisciplineInComboBox();

           
            AdaugaEnuntInListbox();

            activare = 0;

        }
        public FormAdaugaIntrebari(int item)
        {
            InitializeComponent();
            AdaugaDisciplineInComboBox();

           
            AdaugaEnuntInListbox();
           
            this.item = item;
            activare = 1;
            scimbareDisciplinaDupaIntrebare();
            SimulareClick(buttonVizulizareIntegimeItem);

        }


        private void SimulareClick(Button button) => button.HandleCreated += (s, e) => button.PerformClick();
        
           


        void scimbareDisciplinaDupaIntrebare()
        {
            string numeDisc="";
            Itemi itemi1 = listaItemi.Where(i => i.IdItem == item).FirstOrDefault();
            string codDisc = itemi1.IdDisciplina;
            foreach(Disciplina disciplina in listaDisciplina)
            {
                if(disciplina.IdDisciplina==codDisc)
                {
                    numeDisc = disciplina.Denumire;
                    break;
                }
            }
            comboBoxDiscipline.Text = numeDisc;
        }
        private const  int MinTextBoxHeight = 25;


        private void textBoxEnuntItem_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            int neededHeight = CalculateNeededHeight(textBox);


            textBox.Height = Math.Max(neededHeight, MinTextBoxHeight);
        }

        private int CalculateNeededHeight(TextBox textBox)
        {
            // Calculează înălțimea necesară bazată pe numărul de linii și înălțimea liniei
            int lineCount = textBox.GetLineFromCharIndex(textBox.TextLength) + 2;
            int lineHeight = TextRenderer.MeasureText("A", textBox.Font).Height;  // Înălțimea aproximativă a unei linii
            int neededHeight = lineCount * lineHeight;

            return neededHeight;
        }


        private void textBoxRaspuns1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            int neededHeight = CalculateNeededHeight(textBox);


            textBox.Height = Math.Max(neededHeight, MinTextBoxHeight);
        }

        private void textBoxRaspun2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            int neededHeight = CalculateNeededHeight(textBox);

            textBox.Height = Math.Max(neededHeight, MinTextBoxHeight);
        }

        private void textBoxRaspuns3_TextChanged_1(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            int neededHeight = CalculateNeededHeight(textBox);


            textBox.Height = Math.Max(neededHeight, MinTextBoxHeight);
        }

        private void textBoxRaspuns4_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;


            int neededHeight = CalculateNeededHeight(textBox);


            textBox.Height = Math.Max(neededHeight, MinTextBoxHeight);
        }
        private void textBoxRaspuns5_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            int neededHeight = CalculateNeededHeight(textBox);

            textBox.Height = Math.Max(neededHeight, MinTextBoxHeight);

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
        List<string> alegeRaspunsCorect()
        {
            if (radioButtonUnSingurRaspunsCorect.Checked)
            {

                if (textBoxRaspuns1radioButton.Checked)
                {
                    raspunsCorect1 = textBoxRaspuns1.Text;
                }
                else if (textBoxRaspuns2radioButton.Checked)
                {
                    raspunsCorect1 = textBoxRaspuns2.Text;
                }
                else if (textBoxRaspuns3radioButton.Checked)
                {
                    raspunsCorect1 = textBoxRaspuns3.Text;
                }
                else if (textBoxRaspuns4radioButton.Checked)
                {
                    raspunsCorect1 = textBoxRaspuns4.Text;
                }
                else if (textBoxRaspuns5radioButton.Checked)
                {
                    raspunsCorect1 = textBoxRaspuns5.Text;
                }
                raspunsuriSelectate.Add(raspunsCorect1);

            }

            else if (radioButtonRaspunsMultiplu.Checked)
            {


                foreach (Control c in panelEcranAdaugaIntrebari.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox textBox = c as TextBox;
                        CheckBox checkBox = (CheckBox)panelEcranAdaugaIntrebari.Controls[textBox.Name + "CheckBox"];

                        if (checkBox != null && checkBox.Checked)
                        {
                            raspunsuriSelectate.Add(textBox.Text);
                        }
                    }
                }

                string raspuns1 = raspunsuriSelectate.Count > 0 ? raspunsuriSelectate[0] : null;
                string raspuns2 = raspunsuriSelectate.Count > 1 ? raspunsuriSelectate[1] : null;
                string raspuns3 = raspunsuriSelectate.Count > 2 ? raspunsuriSelectate[2] : null;


            }
            return raspunsuriSelectate;


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
            if (listBoxIntrebari.SelectedIndex != -1)
            {
                int IdItem = ((Itemi)listBoxIntrebari.SelectedItem).IdItem;
                foreach (ItemiEvaluare itemiEvaluare in listaItemiEvaluare)
                {
                    if (itemiEvaluare.IdItem == IdItem)
                    {
                        buttonActulizareItrebare.Enabled = false;
                        buttonStergeIntrebarea.Enabled = false;
                        pictureBoxIndomatie.Visible = true;
                        labelInfomatie.Visible = true;

                        return;
                    }
                    else
                    {
                        buttonActulizareItrebare.Enabled = true;
                        buttonStergeIntrebarea.Enabled = true;
                        pictureBoxIndomatie.Visible = false;
                        labelInfomatie.Visible = false;
                    }
                }
            }


           


        }

        bool ValidareCasete()
        {
            if (string.IsNullOrWhiteSpace(textBoxEnuntItem.Text) || string.IsNullOrEmpty(textBoxRaspuns1.Text) ||
                string.IsNullOrEmpty(textBoxRaspuns2.Text) || string.IsNullOrEmpty(textBoxRaspuns3.Text) /*||
                  string.IsNullOrEmpty(textBoxRaspuns4.Text) || string.IsNullOrEmpty(textBoxRaspuns5.Text)*/)
            {
                MessageBox.Show("Una dintre casete este goala\nToate casetele trebuie completate");
                return false;
            }
            if(radioButtonOintrebare.Checked)
            {
                if(string.IsNullOrEmpty(textBoxRaspuns4.Text))
                {
                    MessageBox.Show("Una dintre casete este goala\nToate casetele trebuie completate");
                    return false;
                }
            }
            if(radioButtonDouaIntrebari.Checked)
            {
                if(string.IsNullOrEmpty(textBoxRaspuns4.Text)|| string.IsNullOrEmpty(textBoxRaspuns5.Text))
                {
                    MessageBox.Show("Una dintre casete este goala\nToate casetele trebuie completate");
                    return false;
                }
            }
            if(radioButtonUnSingurRaspunsCorect.Checked)
            {
                int validareRb = 0;
                foreach(Control c in panelEcranAdaugaIntrebari.Controls)
                {
                    if(c is RadioButton)
                    {
                        RadioButton rb = c as RadioButton;
                        if(rb.Checked)
                        {
                            validareRb = 1;
                            break;
                        }

                    }
                }
                if(validareRb==0)
                {
                    MessageBox.Show("Trebuie selectat un raspuns corect");
                    return false;
                }
            }
            return true;
        }

        private void buttonAdaugaIntebarea_Click(object sender, EventArgs e)
        {
            alegeRaspunsCorect();
            int IdItem;
            DateTime dataCurenta = DateTime.Now;

            if (ValidareCasete())
            {
                if (listaItemi.Count == 0)
                {
                    IdItem = 1;
                }
                else
                {
                    IdItem = listaItemi.Max(id => id.IdItem) + 1;
                }
                string disciplinaSelectata = ((Disciplina)comboBoxDiscipline.SelectedItem).IdDisciplina;
                if (TipItem() == 0)
                {
                    if(raspunsuriSelectate.Count()<1)
                    {
                        MessageBox.Show("Trebuie selectat un raspuns");
                        return;
                    }
                    Itemi itemi = new Itemi()
                    {
                        IdItem = IdItem,
                        EnuntItem = textBoxEnuntItem.Text,
                        PozaItem = EnuntPoza,
                        Raspuns1 = textBoxRaspuns1.Text,
                        Raspuns2 = textBoxRaspuns2.Text,
                        Raspuns3 = textBoxRaspuns3.Text,
                        Raspuns4 = textBoxRaspuns4.Text,
                        Raspuns5 = textBoxRaspuns5.Text,
                        DataPublicareItem = dataCurenta,
                        RaspunsCorect1 = raspunsuriSelectate[0] != null ? raspunsuriSelectate[0] : null,

                        IdDisciplina = disciplinaSelectata
                    };

                    listaItemi.Add(itemi);
                    ConexiuneBazaDeDate.InserareIntrebare(itemi);
                    AdaugaEnuntInListbox();
                    MessageBox.Show("Itrebare introdusa cu succes!");
                   // raspunsuriSelectate.Clear();
                }
                else if (TipItem() == 1)
                {
                    if (raspunsuriSelectate.Count() < 2)
                    {
                        MessageBox.Show("La acest tip de item trebuie selectate cel putin 2 raspunsuri");
                        return;
                    }
                        Itemi itemi = new Itemi()
                        {
                            IdItem = IdItem,
                            EnuntItem = textBoxEnuntItem.Text,
                            TipItem = TipItem(),
                            PozaItem = EnuntPoza,
                            Raspuns1 = textBoxRaspuns1.Text,
                            Raspuns2 = textBoxRaspuns2.Text,
                            Raspuns3 = textBoxRaspuns3.Text,
                            Raspuns4 = textBoxRaspuns4.Text,
                            Raspuns5 = textBoxRaspuns5.Text,
                            DataPublicareItem = dataCurenta,
                            RaspunsCorect1 = raspunsuriSelectate[0],
                            RaspunsCorect2 = raspunsuriSelectate[1],
                            RaspunsCorect3 = null,

                            IdDisciplina = disciplinaSelectata
                        };
                    
                    if (raspunsuriSelectate.Count() > 2)
                    {
                        itemi.RaspunsCorect3 = raspunsuriSelectate[2];
                    }
                    listaItemi.Add(itemi);
                    ConexiuneBazaDeDate.InserareIntrebare(itemi);
                    AdaugaEnuntInListbox();
                    MessageBox.Show("Itrebare introdusa cu succes!");
                }
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox box)
                    {
                        box.Clear();
                    }
                }

                
            }
            raspunsuriSelectate.Clear();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand;

        }

        private void comboBoxDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdaugaEnuntInListbox();
        }

        private void buttonStergeIntrebarea_Click(object sender, EventArgs e)
        {
            if (listBoxIntrebari.SelectedIndex == -1)
            {
                MessageBox.Show("Nu ai ales nici o intrebare pentru a fi stearsa");
                return;
            }
            try
            {
                DialogResult result = MessageBox.Show("Stergerea este ireversibila.Esti sigur de aceasta actiune?", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    int IdIttem = ((Itemi)listBoxIntrebari.SelectedItem).IdItem;

                    Itemi ItemSelectat = ((Itemi)listBoxIntrebari.SelectedItem);
                    ConexiuneBazaDeDate.StergereIntrebare(IdIttem);
                    listaItemi.Remove(ItemSelectat);
                    AdaugaEnuntInListbox();
                    MessageBox.Show("Stergerea a fost efeectuata cu succes");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Nu e selectat nimic pentru stergere");
            }


        }

        private void buttonActulizareItrebare_Click(object sender, EventArgs e)
        {
            alegeRaspunsCorect();
            if (listBoxIntrebari.SelectedIndex == -1)
            {
                MessageBox.Show("Nu ai selectat nici un item pentru actulizare");
            }
            if (listBoxIntrebari.SelectedIndex >= 0)
            {

                string disciplinaSelectata = ((Disciplina)comboBoxDiscipline.SelectedItem).IdDisciplina;
                int IdItem = ((Itemi)listBoxIntrebari.SelectedItem).IdItem;
                Itemi itemS = ((Itemi)listBoxIntrebari.SelectedItem);
                Itemi itemi = new Itemi()
                {
                    IdItem = IdItem,
                    EnuntItem = textBoxEnuntItem.Text,
                    TipItem = TipItem(),
                    PozaItem = EnuntPoza,
                    Raspuns1 = textBoxRaspuns1.Text,
                    Raspuns2 = textBoxRaspuns2.Text,
                    Raspuns3 = textBoxRaspuns3.Text,
                    Raspuns4 = textBoxRaspuns4.Text,
                    Raspuns5 = textBoxRaspuns5.Text,
                    RaspunsCorect1 = raspunsuriSelectate[0],
                    
                   
                    IdDisciplina = disciplinaSelectata
                };
                if(raspunsuriSelectate.Count>1)
                {
                    itemi.RaspunsCorect2 = raspunsuriSelectate[1];
                }
                if(raspunsuriSelectate.Count>2)
                {
                    itemi.RaspunsCorect3 = raspunsuriSelectate[2];
                }
                listaItemi.Remove(itemS);
                try
                {


                    ConexiuneBazaDeDate.ActualizeazaIntrebare(itemi, IdItem);
                    MessageBox.Show("Item actulizat cu succes");

                    Itemi itemSelectat = listaItemi[listBoxIntrebari.SelectedIndex];
                    itemSelectat.IdItem = IdItem;
                    itemSelectat.EnuntItem = textBoxEnuntItem.Text;
                    itemSelectat.TipItem = TipItem();
                    itemSelectat.PozaItem = EnuntPoza;
                    itemSelectat.Raspuns1 = textBoxRaspuns1.Text;
                    itemSelectat.Raspuns2 = textBoxRaspuns2.Text;
                    itemSelectat.Raspuns3 = textBoxRaspuns3.Text;
                    itemSelectat.Raspuns4 = textBoxRaspuns4.Text;
                    itemSelectat.Raspuns5 = textBoxRaspuns5.Text;
                    itemSelectat.RaspunsCorect1 = raspunsuriSelectate[0];

                    itemSelectat.IdDisciplina = disciplinaSelectata;

                    if (raspunsuriSelectate.Count > 1)
                    {
                        itemSelectat.RaspunsCorect2 = raspunsuriSelectate[1];
                    }
                    if (raspunsuriSelectate.Count > 2)
                    {
                        itemSelectat.RaspunsCorect3 = raspunsuriSelectate[2];
                    }
                    AdaugaEnuntInListbox();

                }
                catch (Exception)
                {
                    MessageBox.Show("A aparut o eroare la actualizarea datelor");
                }
                raspunsuriSelectate.Clear();
            }

        }
        
            private void buttonVizulizareIntegimeItem_Click(object sender, EventArgs e)
            {
                if (listBoxIntrebari.SelectedIndex == -1)
                {
                    MessageBox.Show("Nu ai selecat nici o intrebare pentru a o vizuliza");
                }
                if (listBoxIntrebari.SelectedIndex >= 0)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is TextBox)
                        {
                            ((TextBox)c).Clear();
                        }
                    }
                    foreach (Control c1 in panelEcranAdaugaIntrebari.Controls)
                    {
                        if (c1 is CheckBox)
                        {
                            CheckBox ch = c1 as CheckBox;
                            if (ch.Checked)
                            {
                                ch.Checked = false;
                            }

                        }
                        if (c1 is RadioButton)
                        {
                            RadioButton rb = c1 as RadioButton;
                            if (rb.Checked)
                            {
                                rb.Checked = false;
                            }
                        }
                    }///////////////////////////////////////////////////////////////////
                    if (activare == 0)
                    {
                        IdItem = ((Itemi)listBoxIntrebari.SelectedItem).IdItem;
                    }
                    else if (activare == 1)
                    {
                        IdItem = item;
                    }
                activare = 0;

                    var intrebareSelecta = listaItemi.Where(i => i.IdItem == IdItem).ToList();
                    textBoxEnuntItem.Text = intrebareSelecta[0].EnuntItem;
                    textBoxRaspuns1.Text = intrebareSelecta[0].Raspuns1;
                    textBoxRaspuns2.Text = intrebareSelecta[0].Raspuns2;
                    textBoxRaspuns3.Text = intrebareSelecta[0].Raspuns3;
                    textBoxRaspuns4.Text = intrebareSelecta[0].Raspuns4;
                    textBoxRaspuns5.Text = intrebareSelecta[0].Raspuns5;
                    foreach (Itemi itemi1 in listaItemi)
                    {
                        if (itemi1.IdItem == IdItem)
                        {
                            if (itemi1.Raspuns4 != "" && itemi1.Raspuns5 == "")
                            {
                                radioButtonOintrebare.Checked = true;
                            }
                            else if (itemi1.Raspuns4 != "" && itemi1.Raspuns5 != "")
                            {
                                radioButtonDouaIntrebari.Checked = true;
                            }
                            else if (itemi1.Raspuns4 == "" && itemi1.Raspuns5 == "")
                            {
                                radioButtonZeroIntrebari.Checked = true;
                            }

                            if (itemi1.TipItem == 1)
                            {
                                radioButtonRaspunsMultiplu.Checked = true;


                                foreach (Control c in panelEcranAdaugaIntrebari.Controls)
                                {
                                    if (c is TextBox)
                                    {
                                        TextBox textBox = c as TextBox;
                                        CheckBox checkBox = (CheckBox)panelEcranAdaugaIntrebari.Controls[textBox.Name + "CheckBox"];
                                        foreach (Itemi itemi in listaItemi)
                                        {
                                            if (itemi.IdItem == IdItem)
                                            {
                                                if (c.Name.StartsWith("textBoxRaspuns"))
                                                {

                                                    if (c.Text == itemi.RaspunsCorect1 || c.Text == itemi.RaspunsCorect2 || c.Text == itemi.RaspunsCorect3)
                                                    {
                                                        checkBox.Checked = true;
                                                        // radioButtonRaspunsMultiplu.Checked = true;
                                                    }
                                                }
                                            }

                                        }
                                    }

                                }


                            }
                            if (itemi1.TipItem == 0)
                            {
                                radioButtonUnSingurRaspunsCorect.Checked = true;

                                foreach (Control c in panelEcranAdaugaIntrebari.Controls)
                                {
                                    if (c is TextBox)
                                    {
                                        TextBox textBox = c as TextBox;
                                        RadioButton radioButton = (RadioButton)panelEcranAdaugaIntrebari.Controls[textBox.Name + "RadioButton"];
                                        foreach (Itemi itemi in listaItemi)
                                        {
                                            if (itemi.IdItem == IdItem)
                                            {
                                                if (c.Name.StartsWith("textBoxRaspuns"))
                                                {
                                                    if (c.Text == itemi.RaspunsCorect1)
                                                    {
                                                        radioButton.Checked = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                        }


                    }

                }
            }
        

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareP flp = new FormLogareP();
            this.Hide();
            flp.ShowDialog();
        }

        private void buttonCurataCasete_Click(object sender, EventArgs e)
        {
            foreach (Control c in panelEcranAdaugaIntrebari.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c is CheckBox)
                {
                    CheckBox ch = c as CheckBox;
                    if (ch.Checked)
                    {
                        ch.Checked = false;
                    }
                }
                if (c is RadioButton)
                {
                    RadioButton rb = c as RadioButton;
                    if (rb.Checked)
                    {
                        rb.Checked = false;
                    }
                }
            }


        }



        private void listBoxIntrebari_Click(object sender, EventArgs e)
        {
            int IdItem = ((Itemi)listBoxIntrebari.SelectedItem).IdItem;
            foreach (ItemiEvaluare itemiEvaluare in listaItemiEvaluare)
            {
                if (itemiEvaluare.IdItem == IdItem)
                {
                    buttonActulizareItrebare.Enabled = false;
                    buttonStergeIntrebarea.Enabled = false;
                    pictureBoxIndomatie.Visible = true;
                    labelInfomatie.Visible = true;

                    return;
                }
                else
                {
                    buttonActulizareItrebare.Enabled = true;
                    buttonStergeIntrebarea.Enabled = true;
                    pictureBoxIndomatie.Visible = false;
                    labelInfomatie.Visible = false;
                }
            }
        }

        private void listBoxIntrebari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonOintrebare_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOintrebare.Checked)
            {
                labelRaspun4.Visible = true;
                textBoxRaspuns4.Visible = true;
                if (TipItem() == 0)
                {
                    textBoxRaspuns4radioButton.Visible = true;

                }
                else if (TipItem() == 1)
                {
                    textBoxRaspuns4CheckBox.Visible = true;

                }
                textBoxRaspuns5.Text = string.Empty;
            }
            else
            {
                labelRaspun4.Visible = false;
                textBoxRaspuns4.Visible = false;
                textBoxRaspuns4radioButton.Visible = false;
                textBoxRaspuns4CheckBox.Visible = false;
            }
        }

        private void radioButtonDouaIntrebari_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDouaIntrebari.Checked)
            {
                labelRaspun4.Visible = true;
                textBoxRaspuns4.Visible = true;
                labelRaspun5.Visible = true;
                textBoxRaspuns5.Visible = true;
                if (TipItem() == 0)
                {
                    textBoxRaspuns4radioButton.Visible = true;
                    textBoxRaspuns5radioButton.Visible = true;
                }
                else if (TipItem() == 1)
                {
                    textBoxRaspuns4CheckBox.Visible = true;
                    textBoxRaspuns5CheckBox.Visible = true;
                }

            }
            else
            {
                labelRaspun4.Visible = false;
                textBoxRaspuns4.Visible = false;
                labelRaspun5.Visible = false;
                textBoxRaspuns5.Visible = false;
                textBoxRaspuns4radioButton.Visible = false;
                textBoxRaspuns5radioButton.Visible = false;
                textBoxRaspuns4CheckBox.Visible = false;
                textBoxRaspuns5CheckBox.Visible = false;
            }
        }

        private void radioButtonUnSingurRaspunsCorect_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUnSingurRaspunsCorect.Checked)
            {
                textBoxRaspuns1radioButton.Visible = true;
                textBoxRaspuns2radioButton.Visible = true;
                textBoxRaspuns3radioButton.Visible = true;
                if (radioButtonOintrebare.Checked)
                {
                    textBoxRaspuns4radioButton.Visible = true;
                }
                if (radioButtonDouaIntrebari.Checked)
                {
                    textBoxRaspuns4radioButton.Visible = true;
                    textBoxRaspuns5radioButton.Visible = true;

                }
                textBoxRaspuns1CheckBox.Checked = false;
                textBoxRaspuns2CheckBox.Checked = false;
                textBoxRaspuns3CheckBox.Checked = false;
                textBoxRaspuns4CheckBox.Checked = false;
                textBoxRaspuns5CheckBox.Checked = false;
            }
            else
            {
                textBoxRaspuns1radioButton.Visible = false;
                textBoxRaspuns2radioButton.Visible = false;
                textBoxRaspuns3radioButton.Visible = false;
                textBoxRaspuns4radioButton.Visible = false;
                textBoxRaspuns5radioButton.Visible = false;

            }


        }

        private void radioButtonRaspunsMultiplu_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRaspunsMultiplu.Checked)
            {
                textBoxRaspuns1CheckBox.Visible = true;
                textBoxRaspuns2CheckBox.Visible = true;
                textBoxRaspuns3CheckBox.Visible = true;
                if (radioButtonOintrebare.Checked)
                {
                    textBoxRaspuns4CheckBox.Visible = true;
                }
                if (radioButtonDouaIntrebari.Checked)
                {
                    textBoxRaspuns4CheckBox.Visible = true;
                    textBoxRaspuns5CheckBox.Visible = true;
                }

                textBoxRaspuns1radioButton.Checked = false;
                textBoxRaspuns2radioButton.Checked = false;
                textBoxRaspuns3radioButton.Checked = false;
                textBoxRaspuns4radioButton.Checked = false;
                textBoxRaspuns5radioButton.Checked = false;
            }
            else
            {
                textBoxRaspuns1CheckBox.Visible = false;
                textBoxRaspuns2CheckBox.Visible = false;
                textBoxRaspuns3CheckBox.Visible = false;
                textBoxRaspuns4CheckBox.Visible = false;
                textBoxRaspuns5CheckBox.Visible = false;
            }
        }

        private void radioButtonZeroIntrebari_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonZeroIntrebari.Checked)
            {
                textBoxRaspuns4radioButton.Visible = false;
                textBoxRaspuns5radioButton.Visible = false;
                textBoxRaspuns4CheckBox.Visible = false;
                textBoxRaspuns5CheckBox.Visible = false;
                textBoxRaspuns4.Text = string.Empty;
                textBoxRaspuns5.Text = string.Empty;


            }
        }

       

        private void buttonPaginnaIntrebari_Click(object sender, EventArgs e)
        {
            FormVizualizareIntrebari fvi = new FormVizualizareIntrebari();
            this.Hide();
            fvi.ShowDialog();
        }

        int tipItem = 0;
        public int TipItem()
        {
            if (radioButtonUnSingurRaspunsCorect.Checked)
            {
                tipItem = 0;
            }
            else if (radioButtonRaspunsMultiplu.Checked)
            {
                tipItem = 1;
            }
            return tipItem;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vrei sa adaugi o poza pentru item?", "Avertizare", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Fișiere de imagine|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Alegeți o imagine";



                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string caleImagine = openFileDialog.FileName;


                        // pictureBox1.Image = Image.FromFile(caleImagine);

                        string numeImagine = Path.GetFileName(caleImagine);

                        string directorDestinatie = @"E:\facultate\anul 3\sem1\LICENTA\aplicatie evss\evaluarea_studentilor_in_sesiune\evaluarea_studentilor_in_sesiune\bin\Debug\POZA ITEMI";

                        string caleDestinatie = Path.Combine(directorDestinatie, numeImagine);
                        try
                        {
                            File.Copy(caleImagine, caleDestinatie);
                            label1PozaAdaugataCuSucces.Visible = true;
                            EnuntPoza = caleDestinatie;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Aceasta poza este deja atasata unei intrebari.\nEroare:{ex} ");
                        }



                    }
                }
            }
        }

    }
}











