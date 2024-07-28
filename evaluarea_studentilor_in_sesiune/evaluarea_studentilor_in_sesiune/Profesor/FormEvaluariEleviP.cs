using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using evaluarea_studentilor_in_sesiune.Properties;

namespace evaluarea_studentilor_in_sesiune
{

    public partial class FormEvaluariEleviP : Form
    {
        List<Student> listaStudent = ConexiuneBazaDeDate.ExtragereStudenti();
        List<IEREI> listaIerei = ConexiuneBazaDeDate.ExtrageIerei();
        List<Evaluare> listaEvaluare = ConexiuneBazaDeDate.ExtragereEvaluare();
        List<Grupa> listaGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        List<AsociereProfesorDisciplinaGrupa> listaApDg = ConexiuneBazaDeDate.ExtragereAsociereProfesorDisciplinaGrupa();
        List<Disciplina> listaDisciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
        List<RezultateEvaluare> listaRezultateEvalure = ConexiuneBazaDeDate.ExtrageRezultateEvaluare();
        List<Profesor> listaProfesor = ConexiuneBazaDeDate.ExtragereProfesor();
        List<Disciplina> listaDiciplineProfesor = new List<Disciplina>();
        List<Grupa> listaGrupaProfesor = new List<Grupa>();
        public FormEvaluariEleviP()
        {
            InitializeComponent();
          
            
            dateInComboBoxDisciplina();
            AdaugaGrupeInComboBox();
            
            dataGridInStudentIerei();
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
        void dataGridInStudentIerei()
        {
            var listaStudentIerei = from Student in listaStudent
                                    join RezultateEvaluare in listaRezultateEvalure on Student.NrMatricol equals RezultateEvaluare.NrMatricol
                                    join Evaluare in listaEvaluare on RezultateEvaluare.IdEvaluare equals Evaluare.IdEvaluare
                                    join Grupa in listaGrupa on Evaluare.IdGrupa equals Grupa.IdGrupa
                                    join AsociereProfesorDisciplinaGrupa in listaApDg on Grupa.IdGrupa equals AsociereProfesorDisciplinaGrupa.IdGrupa
                                    join Disciplina in listaDisciplina on Evaluare.IdDIsciplina equals Disciplina.IdDisciplina
                                    select new
                                    {
                                        NrMatricol = Student.NrMatricol,
                                        NumeStudent = Student.NumeStudent,
                                        PrenumeStudent= Student.PrenumeStudent,
                                        Grupa = Grupa.AnSud_AnUniv,
                                        Disciplina = Disciplina.Denumire,
                                        NumeEvaluare = Evaluare.DenumireEvaluare,
                                        NotaEvluare = RezultateEvaluare.NotaEvaluare,
                                        Cnp = AsociereProfesorDisciplinaGrupa.CNP
                                    };
            dataGridViewEvaluariElevi.DataSource = listaStudentIerei.Where(c => c.Cnp == aflareProfesor()).Where(n=>n.NotaEvluare!=-1).Distinct().ToList();
            dataGriP();

        }
        void dataGriP()
        {
            dataGridViewEvaluariElevi.Columns["NrMatricol"].HeaderText = "Numar matricol";
            dataGridViewEvaluariElevi.Columns["NumeStudent"].HeaderText = "Nume";
            if (dataGridViewEvaluariElevi.Columns["PrenumeStudent"] != null)
            {
                dataGridViewEvaluariElevi.Columns["PrenumeStudent"].HeaderText = "Prenume";
            }
            dataGridViewEvaluariElevi.Columns["Grupa"].HeaderText = "Grupa";
            dataGridViewEvaluariElevi.Columns["Disciplina"].HeaderText = "Disciplina";
            dataGridViewEvaluariElevi.Columns["NumeEvaluare"].HeaderText = "Evaluare";
            dataGridViewEvaluariElevi.Columns["NotaEvluare"].HeaderText = "Nota";
            dataGridViewEvaluariElevi.Columns["Cnp"].Visible = false;

            dataGridViewEvaluariElevi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEvaluariElevi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewEvaluariElevi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewEvaluariElevi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewEvaluariElevi.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dataGridViewEvaluariElevi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewEvaluariElevi.AutoResizeColumns();

            dataGridViewEvaluariElevi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 28);
            for (int i = 0; i < dataGridViewEvaluariElevi.ColumnCount; i++)
            {

                dataGridViewEvaluariElevi.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewEvaluariElevi.Columns[i].DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewEvaluariElevi.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 24, FontStyle.Regular);

            }
        }
        void dateInComboBoxDisciplina()
        {
            comboBoxDisciplina.DataSource = null;
            comboBoxDisciplina.Sorted = true;
            
            foreach (AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa in listaApDg)
            {

                foreach (Disciplina disciplina in listaDisciplina)
                {

                    if (asociereProfesorDisciplinaGrupa.CNP == aflareProfesor() && disciplina.IdDisciplina == asociereProfesorDisciplinaGrupa.IdDisciplina )
                    {

                          listaDiciplineProfesor.Add(disciplina);
 
                    }
                }

            }
            for (int i = 0; i < listaDiciplineProfesor.Count(); i++)
            {
                for (int j = i + 1; j < listaDiciplineProfesor.Count(); j++)
                {
                    if (listaDiciplineProfesor[i] == listaDiciplineProfesor[j])
                    {
                        listaDiciplineProfesor.Remove(listaDiciplineProfesor[i]);
                    }
                }
            }
            comboBoxDisciplina.DataSource = listaDiciplineProfesor.Distinct().ToList();
            comboBoxDisciplina.DisplayMember = "Denumire";


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
                        listaGrupaProfesor.Add(grupa);
                    }
                }
            }
            comboBoxGrupa.DataSource = listaGrupaProfesor.Distinct().ToList();
            comboBoxGrupa.DisplayMember = "AnSud_AnUniv";

        }

        private void comboBoxGrupa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grupa grupa = ((Grupa)comboBoxGrupa.SelectedItem);
            string grupaD = grupa.AnSud_AnUniv;
            
            var listaStudentIerei = from Student in listaStudent
                                    join RezultateEvaluare in listaRezultateEvalure on Student.NrMatricol equals RezultateEvaluare.NrMatricol
                                    join Evaluare in listaEvaluare on RezultateEvaluare.IdEvaluare equals Evaluare.IdEvaluare
                                    join Grupa in listaGrupa on Evaluare.IdGrupa equals Grupa.IdGrupa
                                    join AsociereProfesorDisciplinaGrupa in listaApDg on Grupa.IdGrupa equals AsociereProfesorDisciplinaGrupa.IdGrupa
                                    join Disciplina in listaDisciplina on Evaluare.IdDIsciplina equals Disciplina.IdDisciplina
                                    select new
                                    {
                                        NrMatricol = Student.NrMatricol,
                                        NumeStudent = Student.NumeStudent,
                                        PrenumeStudent=Student.PrenumeStudent,
                                        Grupa = Grupa.AnSud_AnUniv,
                                        Disciplina = Disciplina.Denumire,
                                        NumeEvaluare = Evaluare.DenumireEvaluare,
                                        NotaEvluare = RezultateEvaluare.NotaEvaluare,
                                        Cnp = AsociereProfesorDisciplinaGrupa.CNP
                                    };
            var listaStudentiFiltrata = listaStudentIerei.Where(g=>g.Grupa== grupaD).Where(n=>n.NotaEvluare!=-1).Distinct().ToList();
            dataGridViewEvaluariElevi.DataSource = listaStudentiFiltrata;
            dataGriP();


        }

        private void comboBoxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Disciplina disciplina = ((Disciplina)comboBoxDisciplina.SelectedItem);
            string denumireDisciplina = disciplina.Denumire;
            

            
            var listaStudentIerei = from Student in listaStudent
                                    join RezultateEvaluare in listaRezultateEvalure on Student.NrMatricol equals RezultateEvaluare.NrMatricol
                                    join Evaluare in listaEvaluare on RezultateEvaluare.IdEvaluare equals Evaluare.IdEvaluare
                                    join Grupa in listaGrupa on Evaluare.IdGrupa equals Grupa.IdGrupa
                                    join AsociereProfesorDisciplinaGrupa in listaApDg on Grupa.IdGrupa equals AsociereProfesorDisciplinaGrupa.IdGrupa
                                    join Disciplina in listaDisciplina on Evaluare.IdDIsciplina equals Disciplina.IdDisciplina
                                    select new
                                    {
                                        NrMatricol = Student.NrMatricol,
                                        NumeStudent = Student.NumeStudent,
                                        PrenumeStudent=Student.PrenumeStudent,
                                        Grupa = Grupa.AnSud_AnUniv,
                                        Disciplina = Disciplina.Denumire,
                                        NumeEvaluare = Evaluare.DenumireEvaluare,
                                        NotaEvluare = RezultateEvaluare.NotaEvaluare,
                                        Cnp = AsociereProfesorDisciplinaGrupa.CNP
                                   };
            var listaStudentiFiltrata = listaStudentIerei.Where(d => d.Disciplina == denumireDisciplina).Where(n=>n.NotaEvluare!=-1).Distinct().ToList();
            dataGridViewEvaluariElevi.DataSource = listaStudentiFiltrata;
            dataGriP();
        }

      

        private void textBoxEvaluare_TextChanged(object sender, EventArgs e)
        {
            var listaStudentIerei = from Student in listaStudent
                                    join RezultateEvaluare in listaRezultateEvalure on Student.NrMatricol equals RezultateEvaluare.NrMatricol
                                    join Evaluare in listaEvaluare on RezultateEvaluare.IdEvaluare equals Evaluare.IdEvaluare
                                    join Grupa in listaGrupa on Evaluare.IdGrupa equals Grupa.IdGrupa
                                    join AsociereProfesorDisciplinaGrupa in listaApDg on Grupa.IdGrupa equals AsociereProfesorDisciplinaGrupa.IdGrupa
                                    join Disciplina in listaDisciplina on Evaluare.IdDIsciplina equals Disciplina.IdDisciplina
                                    select new
                                    {
                                        NrMatricol = Student.NrMatricol,
                                        NumeStudent = Student.NumeStudent,
                                        PrenumeStudent = Student.PrenumeStudent,
                                        Grupa = Grupa.AnSud_AnUniv,
                                        Disciplina = Disciplina.Denumire,
                                        NumeEvaluare = Evaluare.DenumireEvaluare,
                                        NotaEvluare = RezultateEvaluare.NotaEvaluare,
                                        Cnp = AsociereProfesorDisciplinaGrupa.CNP
                                        
                                    };
            var listaDenumire = listaStudentIerei.Where(d => (d.NumeEvaluare).ToUpper().StartsWith(textBoxEvaluare.Text.ToUpper())).Where(n=>n.NotaEvluare!=-1).Distinct().ToList();
            dataGridViewEvaluariElevi.DataSource = listaDenumire;
            dataGriP();
        }

        private void checkBoxToate_CheckedChanged(object sender, EventArgs e)
        {
            dataGridInStudentIerei();
        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareP flp = new FormLogareP();
            this.Hide();
            flp.ShowDialog();
        }

        private void dataGridViewEvaluariElevi_DoubleClick(object sender, EventArgs e)
        {
            string denumireEV = "";
            string nrM = "";
            int rowE = dataGridViewEvaluariElevi.CurrentRow.Index;
            int columnE = 5;
            int idEv = 0;
            int columM = 0;
            int rowM= dataGridViewEvaluariElevi.CurrentRow.Index;

            
            object valoareCelulaM = dataGridViewEvaluariElevi.Rows[rowM].Cells[columM].Value;
            nrM = valoareCelulaM.ToString();
            object valoareCelulaE = dataGridViewEvaluariElevi.Rows[rowE].Cells[columnE].Value;
            denumireEV = valoareCelulaE.ToString();
            foreach(Evaluare evaluare in listaEvaluare)
            {
                if(denumireEV==evaluare.DenumireEvaluare)
                {
                    idEv = evaluare.IdEvaluare;
                }
            }
            List<IEREI> listaIntrebariRaspuns = listaIerei.Where(i => i.IdEvaluare == idEv).Where(M=>M.NrMatricol==nrM).ToList();
            FormEvaluari fe = new FormEvaluari(listaIntrebariRaspuns, idEv,nrM);
            this.Hide();
            fe.ShowDialog();
        }
    }
}
