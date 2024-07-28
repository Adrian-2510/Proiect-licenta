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
    public partial class FormPregatesteEvaluare : Form
    {
        TimeSpan timpEvaluare;

        List<DespreMineP> listaDespreMineP = ConexiuneBazaDeDate.ExtragereDespreMineP();
        List<Disciplina> listaDiscipline = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<Evaluare> listaEvaluare = ConexiuneBazaDeDate.ExtragereEvaluare();
        List<Grupa> listaGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        List<AsociereProfesorDisciplinaGrupa> listaAsociereProfesorDisciplinaGrupas = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<Profesor> listaProfesor = ConexiuneBazaDeDate.ExtragereProfesor();
        List<Grupa> listaGrupa2 = new List<Grupa>();
        List<Disciplina> listaDiscipline2 = new List<Disciplina>();
       static List<int> listaIdIntreabri = new List<int>();
        List<Itemi> listaItemi = ConexiuneBazaDeDate.ExtragereItemi();
        List<int> listaRandomId = new List<int>();
        List<RezultateEvaluare> listaRezultateEvaluare = ConexiuneBazaDeDate.ExtrageRezultateEvaluare();
        List<AsociereStudentContGrupa> listAAsociereStudentContGrupas = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<Specializare> listaSpecializare = ConexiuneBazaDeDate.ExtrageSpecializari();
        bool verificare = false;
       
        public FormPregatesteEvaluare()
        {
            InitializeComponent();
            dateTimePickerDataStartEvaluare.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataStartEvaluare.CustomFormat = " HH:mm dddd MMMM dd, yyyy";
            dateTimePickerOprireEvaluare.Format = DateTimePickerFormat.Custom;
            dateTimePickerOprireEvaluare.CustomFormat = "HH:mm dddd MMMM dd, yyyy";
            dateTimePickerDataProiectareEvaluare.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataProiectareEvaluare.CustomFormat = " HH:mm dddd MMMM dd, yyyy";
            
            AdaugaDenumireEvalaureInListBox();
AdaugaDisiciplineInComboBox();
            AdaugaGrupeInComboBox();
            comboBoxDisciplina.SelectedIndex = 0;
            dateTimePickerOprireEvaluare.Value = dateTimePickerDataStartEvaluare.Value.AddHours(1);
            numericUpDownNrItemi.Value = 18;
          
         
        }
        string UserNameP;
      
        public FormPregatesteEvaluare(string UserNameP)
        {
            InitializeComponent();
            dateTimePickerDataStartEvaluare.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataStartEvaluare.CustomFormat = " HH:mm dddd MMMM dd, yyyy";
            dateTimePickerOprireEvaluare.Format = DateTimePickerFormat.Custom;
            dateTimePickerOprireEvaluare.CustomFormat = "HH:mm dddd MMMM dd, yyyy";
            dateTimePickerDataProiectareEvaluare.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataProiectareEvaluare.CustomFormat = " HH:mm dddd MMMM dd, yyyy";
          //  timpEvaluare = dateTimePickerOprireEvaluare.Value - dateTimePickerDataStartEvaluare.Value;
            this.UserNameP = UserNameP;
            AdaugaDenumireEvalaureInListBox();
            AdaugaDisiciplineInComboBox();
            AdaugaGrupeInComboBox();
            
            dateTimePickerOprireEvaluare.Value = dateTimePickerDataStartEvaluare.Value.AddHours(1);
            numericUpDownNrItemi.Value = 18;
           
        }
       
        string ExtragereCNPdupaUser()
        {
            string CNPP = string.Empty;
            
            foreach (Profesor profesor in listaProfesor)
            {
                if(profesor.UserName==UserNameP)
                {
                    CNPP = profesor.CNP;
                }
            }
            return CNPP;
        }
        bool ValidareDate()
        {

            int idItemi = listaRandomId.Count() + 1;
            int nrItemi = (int)numericUpDownNrItemi.Value;
            string idDsiciplina = ((Disciplina)comboBoxDisciplina.SelectedItem).IdDisciplina.ToString();
            listaRandomId = listaItemi.Where(i => i.IdDisciplina == idDsiciplina).Select(id => id.IdItem).ToList();

            timpEvaluare = dateTimePickerOprireEvaluare.Value - dateTimePickerDataStartEvaluare.Value;
            if (string.IsNullOrEmpty(textBoxDenumireEvaluare.Text))
            {
                MessageBox.Show("Campul cu denumirea evluarrii este necompleta");
                return false;
            }
            if (dateTimePickerDataStartEvaluare.Value < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show($"Data este ma mica fata de cea curenta {Convert.ToString(dateTimePickerDataStartEvaluare.Value)}");
                
                return false;
            }
            if(dateTimePickerOprireEvaluare.Value > DateTime.Now.AddMonths(6))
            {
                MessageBox.Show("Nu poti proiecta o evaluare care sa aiba timpul de predare mai mare de 6 luni");
                return false;
            }
            if (numericUpDownTimpEvaluare.Value < 1)
            {
                MessageBox.Show("Trebuie ca timpul evaluarii nu trebuie sa fie mai mic de un minut");
                return false;
            }
            if (comboBoxDisciplina.SelectedItem==null)
            {
                MessageBox.Show("Trebuie aleasa disciplina testului");
                return false;
            }
            if(numericUpDownNrItemi.Value<1)
            {
                MessageBox.Show("Trebuie ca numarul de itemi sa fie mai mare de 0");
                return false;
            }

            if (nrItemi > listaRandomId.Count())
            {
                MessageBox.Show("Nu sunt suficiente intrebari pe aceasta disciplina");
                return false;
            }
            return true;
        }

        void AdaugaDisiciplineInComboBox()
        {
            
            comboBoxDisciplina.DataSource = null;
            comboBoxDisciplina.Sorted = true;
            foreach(AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaAsociereProfesorDisciplinaGrupas)
            {
                foreach(Disciplina disciplina in listaDiscipline)
                {
                    if(asociereProfesorDisciplinaGrupa.CNP == ExtragereCNPdupaUser() && asociereProfesorDisciplinaGrupa.IdDisciplina==disciplina.IdDisciplina)
                    {
                      
                        listaDiscipline2.Add(disciplina);          
                    }
                }    
            }

            for (int i = 0; i < listaDiscipline2.Count(); i++)
            {
                for (int j = i+1; j < listaDiscipline2.Count(); j++)
                {
                    if (listaDiscipline2[i] == listaDiscipline2[j])
                    {
                        listaDiscipline2.Remove(listaDiscipline2[i]);
                    }
                }
            }

            comboBoxDisciplina.DataSource = listaDiscipline2.Distinct().ToList();
            comboBoxDisciplina.DisplayMember = "Denumire";
            comboBoxDisciplina.SelectedIndex = 0;
        }
        void AdaugaGrupeInComboBox()
        {

            comboBoxGrupa.DataSource = null;
            comboBoxGrupa.Sorted = true;
            listaGrupa2.Clear();

            string IdDisciplina = "";
            if (comboBoxDisciplina.SelectedIndex != -1)
            {
                IdDisciplina = ((Disciplina)comboBoxDisciplina.SelectedItem).IdDisciplina;
            }
            
            foreach(AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaAsociereProfesorDisciplinaGrupas)
            {
                foreach(Grupa grupa in listaGrupa)
                {
                    if(asociereProfesorDisciplinaGrupa.CNP==ExtragereCNPdupaUser() && asociereProfesorDisciplinaGrupa.IdGrupa==grupa.IdGrupa && asociereProfesorDisciplinaGrupa.IdDisciplina==IdDisciplina )
                    {
                        listaGrupa2.Add(grupa);
                        
                        
                    }
                }
            }
            var listaGrupeD = listaGrupa2.Distinct().ToList();
            comboBoxGrupa.DataSource =listaGrupeD ;
            comboBoxGrupa.DisplayMember = "AnSud_AnUniv";
            

        }
        void AdaugaDenumireEvalaureInListBox()
        {

            int grupaP = 0;
                listBoxDenumireEvaluare.DataSource = null;
                listBoxDenumireEvaluare.Sorted = true;
            //foreach(AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaAsociereProfesorDisciplinaGrupas)
            //{

            //   if(asociereProfesorDisciplinaGrupa.CNP==ExtragereCNPdupaUser())

            //   {
            if (comboBoxGrupa.SelectedIndex > -1)
            {
                grupaP = ((Grupa)comboBoxGrupa.SelectedItem).IdGrupa;
            }
              // }

                var listaDenumireEvaluare = listaEvaluare.Where(d => d.IdDIsciplina == ExtragereCodDisciplina() )
                                  .Where(g => g.IdGrupa == grupaP).ToList();
                if (listaEvaluare.Count > 0)
                {
                    listBoxDenumireEvaluare.DataSource = listaDenumireEvaluare;
                    listBoxDenumireEvaluare.DisplayMember = "DenumireEvaluare";
                }

            //}
        }

        string ExtragereCodDisciplina()
        {
            string denumireDisciplina = string.Empty;
            if (comboBoxDisciplina.SelectedItem != null)
            {
                denumireDisciplina = ((Disciplina)comboBoxDisciplina.SelectedItem).Denumire;
            }

            string IdDisciplina = "";
            foreach(Disciplina disciplina in listaDiscipline)
            {
                if(disciplina.Denumire==denumireDisciplina)
                {
                    IdDisciplina = disciplina.IdDisciplina;
                } 
            }
            return IdDisciplina;
        }

        private void buttonProiecteazaEvaluare_Click(object sender, EventArgs e)
        {
            if (ValidareDate())
            {
                int grupaAleasa = ((Grupa)comboBoxGrupa.SelectedItem).IdGrupa;
                int numara = 0;
                foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaAsociereProfesorDisciplinaGrupas)
                {
                    foreach (Grupa grupa in listaGrupa)
                    {
                        if (asociereProfesorDisciplinaGrupa.CNP == ExtragereCNPdupaUser() && asociereProfesorDisciplinaGrupa.IdGrupa == grupa.IdGrupa)
                        {
                            foreach(Evaluare evaluare1 in listaEvaluare)
                            {
                              
                                if(evaluare1.DenumireEvaluare==textBoxDenumireEvaluare.Text)
                                {
                                    MessageBox.Show("Exista deja o evaluare cu numele asta");
                                    return;
                                }

                               if(evaluare1.IdGrupa==grupaAleasa && evaluare1.IdDIsciplina== ExtragereCodDisciplina()&& numara==0)
                                {
                                    numara++;
                                    DialogResult result = MessageBox.Show("Doriti sa mai adaugati un test la aceasta disciplina pentru grupa aleasa?", "Avertizare!!!", MessageBoxButtons.YesNo);
                                    if(result==DialogResult.No)
                                    {
                                        return;

                                    }
                                }
                            }
                        }
                    }
                }

                Evaluare evaluare = new Evaluare()
                {
                    IdEvaluare = default,
                    DenumireEvaluare = textBoxDenumireEvaluare.Text.ToString(),
                    DataStartEvaluare = dateTimePickerDataStartEvaluare.Value,
                    DataStopEvaluare = dateTimePickerOprireEvaluare.Value,
                    DataProiectareEvaluare = dateTimePickerDataProiectareEvaluare.Value,
                    TimpEvaluare = (int)numericUpDownTimpEvaluare.Value,
                    NrItemi = (int)numericUpDownNrItemi.Value,
                    IdDIsciplina = ExtragereCodDisciplina(),
                    IdGrupa = grupaAleasa
                    
                };

                try
                {
                    //adaugareIdIntrebariInLIsta();

                    if (verificare == false)
                    {
                        listaEvaluare.Add(evaluare);
                        ConexiuneBazaDeDate.InserareEvaluare(evaluare);
                        MessageBox.Show("Evaluare creata cu succes");
                        AdaugaDenumireEvalaureInListBox();
                    }
                    else if (verificare == true)
                    {
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Evaluarea nu a putut fi creata");
                }
            }
        }
        //void adaugareIdIntrebariInLIsta()
        //{
        //    int nrItemi = (int)numericUpDownNrItemi.Value;
        //    int idItemi;
        //    string idDsiciplina = ((Disciplina)comboBoxDisciplina.SelectedItem).IdDisciplina.ToString();
        //    listaRandomId = listaItemi.Where(i => i.IdDisciplina == idDsiciplina).Select(id => id.IdItem).ToList();
        //    Random random = new Random();
        //    idItemi = listaRandomId.Count()+1;
        //    if(nrItemi>listaRandomId.Count)
        //    {
        //        DialogResult result = MessageBox.Show($"Nu sunt suficiente intrbari\nYes pentru a adauga intrbari ,no pentru a ramane pe pagina\nExista {idItemi} intrebari pe aceasta disciplina ", "Avertizare!!!", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
        //        if(result==DialogResult.Yes)
        //        {
        //            FormAdaugaIntrebari fai = new FormAdaugaIntrebari();
        //            this.Hide();
        //            fai.ShowDialog();
        //        }
        //        else if(result==DialogResult.No)
        //        {
        //            verificare = true;
        //            return;
         
        //        }    
        //    }
           
        //    for (int i = 0; i < idItemi; i++)
        //    {
        //        int randomId;
        //        do
        //        {
        //            randomId = listaRandomId[random.Next(listaRandomId.Count)];
        //        } while (listaIdIntreabri.Contains(randomId));

        //        listaIdIntreabri.Add(randomId);
        //    }

        ////    FormEvaluari fe = new FormEvaluari(listaIdIntreabri);
        ////    this.Hide();
        ////    fe.ShowDialog();
        //}

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareP flp = new FormLogareP();
            this.Hide();
            flp.ShowDialog();
        }

        private void comboBoxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdaugaDenumireEvalaureInListBox();
            AdaugaGrupeInComboBox();
        }

        private void buttonStergeeVALUARE_Click(object sender, EventArgs e)
        {
            if (listBoxDenumireEvaluare.SelectedIndex >-1)
            {
              
                var selectedItems = listBoxDenumireEvaluare.SelectedItems.Cast<Evaluare>().ToList();
                listBoxDenumireEvaluare.SelectionMode = SelectionMode.MultiExtended;
                foreach (var selectedItem in selectedItems)
                {
                    int idEvaluare = selectedItem.IdEvaluare;

                    try
                    {
                        ConexiuneBazaDeDate.StergeEvaluare(idEvaluare);
                        listaEvaluare.RemoveAll(eval => eval.IdEvaluare == idEvaluare);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la ștergerea evaluării cu ID-ul {idEvaluare}: {ex.Message}");
                    }
                }
                AdaugaDenumireEvalaureInListBox();
            }
            else if(listBoxDenumireEvaluare.SelectedIndex==-1)
            {
                MessageBox.Show("Nu ai selectat mici un element pentru stergere");
            }
        }

        private void comboBoxGrupa_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdaugaDenumireEvalaureInListBox();

        }

        private void buttonVizualizareDateEvaluare_Click(object sender, EventArgs e)
        {
            Evaluare evaluare = ((Evaluare)listBoxDenumireEvaluare.SelectedItem);
            string denumireDisciplina = "";
            string numeGrupa = "";
            int idEv = evaluare.IdEvaluare;
            textBoxDenumireEvaluare.Text = evaluare.DenumireEvaluare;
            dateTimePickerDataStartEvaluare.Value = evaluare.DataStartEvaluare;
            dateTimePickerOprireEvaluare.Value = evaluare.DataStopEvaluare;
            dateTimePickerDataProiectareEvaluare.Value = evaluare.DataProiectareEvaluare;
            numericUpDownTimpEvaluare.Value = evaluare.TimpEvaluare;
            foreach(Disciplina disciplina in listaDiscipline)
            {
                if(disciplina.IdDisciplina==evaluare.IdDIsciplina)
                {
                    denumireDisciplina = disciplina.Denumire;
                }
            }
            comboBoxDisciplina.Text = denumireDisciplina;
            foreach(Grupa grupa in listaGrupa)
            {
                if(grupa.IdGrupa==evaluare.IdGrupa)
                {
                    numeGrupa = grupa.AnSud_AnUniv;
                }
            }
            comboBoxGrupa.Text = numeGrupa;
            numericUpDownNrItemi.Value = evaluare.NrItemi;
            textBoxDenumireEvaluare.ReadOnly = true;
            dateTimePickerDataStartEvaluare.Enabled = false;
            dateTimePickerOprireEvaluare.Enabled = false;
            numericUpDownTimpEvaluare.Enabled = false;
            comboBoxDisciplina.Enabled = false;
            comboBoxGrupa.Enabled = false;
            numericUpDownNrItemi.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxDenumireEvaluare.Clear();

            textBoxDenumireEvaluare.ReadOnly = false;
            dateTimePickerDataStartEvaluare.Enabled = true;
            dateTimePickerOprireEvaluare.Enabled = true;
            numericUpDownTimpEvaluare.Enabled = true;
            comboBoxDisciplina.Enabled = true;
            comboBoxGrupa.Enabled = true;
            numericUpDownNrItemi.Enabled = true;

            dateTimePickerDataStartEvaluare.Value = DateTime.Now;
            dateTimePickerOprireEvaluare.Value = dateTimePickerDataStartEvaluare.Value.AddHours(1);
            dateTimePickerDataProiectareEvaluare.Value = DateTime.Now;
            numericUpDownTimpEvaluare.Value = 30;

            AdaugaGrupeInComboBox();
            AdaugaDisiciplineInComboBox();
            dateTimePickerOprireEvaluare.Value = dateTimePickerDataStartEvaluare.Value.AddHours(1);
            numericUpDownNrItemi.Value = 18;
        }

        private void listBoxDenumireEvaluare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDenumireEvaluare.SelectedIndex !=-1)
            {
                int idEV = ((Evaluare)listBoxDenumireEvaluare.SelectedItem).IdEvaluare;
                foreach (RezultateEvaluare rezultateEvaluare in listaRezultateEvaluare)
                {
                    if (rezultateEvaluare.IdEvaluare == idEV)
                    {
                        buttonStergeeVALUARE.Enabled = false;
                        return;
                    }
                    else
                    {
                        buttonStergeeVALUARE.Enabled = true;
                    }
                }
            }
        }
        
    }
}
