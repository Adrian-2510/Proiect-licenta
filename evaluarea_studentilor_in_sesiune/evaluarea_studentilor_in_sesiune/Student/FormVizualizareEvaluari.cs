using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using evaluarea_studentilor_in_sesiune.Properties;
using evaluarea_studentilor_in_sesiune.Resources;

namespace evaluarea_studentilor_in_sesiune
{


    public partial class FormVizualizareEvaluari : Form
    {
        List<Evaluare> listaEvaluare = ConexiuneBazaDeDate.ExtragereEvaluare();
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<Cont> listaCont = ConexiuneBazaDeDate.ExtragereConturi();
        List<Student> listaStudent = ConexiuneBazaDeDate.ExtragereStudenti();
        List<Itemi> listaItemi = ConexiuneBazaDeDate.ExtragereItemi();
        List<int> listaRandomId = new List<int>();
        List<int> listaIdIntreabri = new List<int>();
        List<RezultateEvaluare> listaRezultateEvaluare = ConexiuneBazaDeDate.ExtrageRezultateEvaluare();
        List<int> listaIdE = new List<int>();
        List<NotaCuEvaluare> listaNotaCuEvaluare = ConexiuneBazaDeDate.ExtragereNotaCuEvaluare();
        List<IEREI> listaIerei = ConexiuneBazaDeDate.ExtrageIerei();
        List<Evaluare> listaEvaluariNefinalizate = new List<Evaluare>();
        List<ItemiEvaluare> listaItemiEvaluare = ConexiuneBazaDeDate.ExtragereItemiEvaluare();
        List<Catalog> listaCatalog = ConexiuneBazaDeDate.ExtragereCatalog();
        List<string> listaDisciplineCuNota = new List<string>();
        string UserName;
        string matr1 = "";
        //validare este termenul care determina daca studentul are nota sau nu si daca ma ipote da evluari
        int validare;
        public FormVizualizareEvaluari()
        {
            InitializeComponent();
            UserName = Form1.UserName1;
            EvalauriListBox();
        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            FormLogareS_P flsp = new FormLogareS_P();
            this.Hide();
            flsp.ShowDialog();
        }

        void EvalauriListBox()
        {
            // status evaluare 1-evaluarea incheiata,0=evaluare activa;
            int StatusEvaluare = 0;
            int idE = 0;
            float nota = 0f;
            string matr = "";
            listBoxEvaluariActive.DataSource = null;
            listBoxEvaluariActive.Sorted = true;
            int idGrupa = 0;
            listBoxEvaluariFinalizate.SelectionMode = SelectionMode.One;
            foreach (AsociereStudentContGrupa asociereStudentContGrupa in listaAsociereStudentContGrupa)
            {
                if (asociereStudentContGrupa.UserName == UserName)
                {

                    idGrupa = asociereStudentContGrupa.IdGrupa;
                    matr = asociereStudentContGrupa.NrMatricol;
                    matr1 = matr;
                    break;

                }
            }
            foreach (RezultateEvaluare rezultateEvaluare in listaRezultateEvaluare)
            {
                if (matr == rezultateEvaluare.NrMatricol)
                {
                    StatusEvaluare = 1;
                    idE = rezultateEvaluare.IdEvaluare;
                    listaIdE.Add(idE);
                    nota = rezultateEvaluare.NotaEvaluare;
                }




            }
            string matr2 = "";
            foreach (AsociereStudentContGrupa asociereStudentContGrupa1 in listaAsociereStudentContGrupa)
            {
                if (asociereStudentContGrupa1.UserName == UserName)
                {
                    matr2 = asociereStudentContGrupa1.NrMatricol;
                    foreach (RezultateEvaluare rezultateEvaluare in listaRezultateEvaluare)
                    {
                        if (matr2 == rezultateEvaluare.NrMatricol)
                        {
                            int idRezultat = rezultateEvaluare.IdRezultat;
                            foreach (Catalog catalog in listaCatalog)
                            {
                                if (catalog.IdRezultat == idRezultat)
                                {

                                    if (catalog.Blocat == 1)
                                    {
                                        validare = 1;
                                        int IdEv1 = rezultateEvaluare.IdEvaluare;
                                        foreach (Evaluare evaluare in listaEvaluare)
                                        {
                                            if (IdEv1 == evaluare.IdEvaluare)
                                            {
                                                listaDisciplineCuNota.Add(evaluare.IdDIsciplina);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var listaEvaluari = listaEvaluare.Where(g => g.IdGrupa == idGrupa).Where(i => !listaIdE.Contains(i.IdEvaluare)).Where(d => !listaDisciplineCuNota.Contains(d.IdDIsciplina)).Where(t => t.DataStartEvaluare <= DateTime.Now && t.DataStopEvaluare >= DateTime.Now).ToList();
            listBoxEvaluariActive.DataSource = listaEvaluari;
            listBoxEvaluariActive.DisplayMember = "DennumireEvaluareTimp";


            var listaEvaluariFinalizate = listaNotaCuEvaluare.Where(i => listaIdE.Contains(i.IdEvaluare)).Where(g => g.IdGrupa == idGrupa).Where(m => m.NrMatricol == matr).Where(n => n.NotaEvaluare != -1).ToList();
            listBoxEvaluariFinalizate.DataSource = listaEvaluariFinalizate;
            listBoxEvaluariFinalizate.DisplayMember = "DenumireNota";

            foreach (Evaluare evaluare in listaEvaluare)
            {


                if (evaluare.DataStartEvaluare <= DateTime.Now && evaluare.DataStopEvaluare <= DateTime.Now && evaluare.IdGrupa == idGrupa && !listaIdE.Contains(evaluare.IdEvaluare))
                {
                    int idRezultat = 0;
                    if (listaRezultateEvaluare.Count == 0)
                    {
                        idRezultat = 1;
                    }
                    else
                    {
                        idRezultat = listaRezultateEvaluare.Max(i => i.IdRezultat) + 1;
                    }

                    RezultateEvaluare rezultateEvaluare = new RezultateEvaluare()
                    {
                        IdRezultat = idRezultat,
                        IdEvaluare = evaluare.IdEvaluare,
                        NrMatricol = matr1,
                        NotaEvaluare = -1

                    };
                    ConexiuneBazaDeDate.InsereazaRezultateEvaluare(rezultateEvaluare);
                    listaRezultateEvaluare.Add(rezultateEvaluare);

                }


            }

            listBoxEvaluariNepredate.DataSource = listaNotaCuEvaluare.Where(n => n.NotaEvaluare == -1 && n.NrMatricol == matr1).Where(d => !listaDisciplineCuNota.Contains(d.IdDIsciplina)).ToList();
            listBoxEvaluariNepredate.DisplayMember = "DenumireEvaluare";

        }

        void extragereItemi()
        {
            Evaluare evaluare = ((Evaluare)listBoxEvaluariActive.SelectedItem);
            int IdEvaluare = evaluare.IdEvaluare;
            string CodDisciplina = evaluare.IdDIsciplina;
            int nrItemi = evaluare.NrItemi;
            listaRandomId = listaItemi.Where(i => i.IdDisciplina == CodDisciplina).Select(id => id.IdItem).ToList();
            Random random = new Random();
            int idItemi = listaRandomId.Count();
            for (int i = 0; i < nrItemi; i++)
            {
                int randomId;
                do
                {
                    randomId = listaRandomId[random.Next(listaRandomId.Count)];
                } while (listaIdIntreabri.Contains(randomId));

                listaIdIntreabri.Add(randomId);
            }

        }

        private void buttonIncepeEvaluarea_Click(object sender, EventArgs e)
        {
            //Evaluare evaluare = ((Evaluare)listBoxEvaluariActive.SelectedItem);
            //int IdEvaluare = evaluare.IdEvaluare;
            //string CodDisciplina = evaluare.IdDIsciplina;
            //int nrItemi = evaluare.NrItemi;
            // extragereItemi();
            if (listBoxEvaluariActive.SelectedIndex != -1)
            {
                int idEvaluare = ((Evaluare)listBoxEvaluariActive.SelectedItem).IdEvaluare;
                extragereItemi();
                FormEvaluari fe = new FormEvaluari(listaIdIntreabri, idEvaluare);
                this.Hide();
                fe.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nu a fost nici o evaluare selectata pentru a incepe");
            }

        }

        private void listBoxEvaluariFinalizate_DoubleClick(object sender, EventArgs e)
        {
            listBoxEvaluariFinalizate.SelectionMode = SelectionMode.One;
            NotaCuEvaluare notaCuEvaluare = (NotaCuEvaluare)listBoxEvaluariFinalizate.SelectedItem;
            int idEvaluare = notaCuEvaluare.IdEvaluare;
            string nrM = notaCuEvaluare.NrMatricol;
            List<IEREI> listaIntrebariRaspuns = listaIerei.Where(i => i.IdEvaluare == idEvaluare).Where(m => m.NrMatricol == matr1).ToList();
            FormEvaluari fe = new FormEvaluari(listaIntrebariRaspuns, idEvaluare, nrM);
            this.Hide();
            fe.ShowDialog();
        }

        private void FormVizualizareEvaluari_FormClosed(object sender, FormClosedEventArgs e)
        {
            var da = MessageBox.Show("Confirmati inchiderea aplicatiei ?", "Atentie", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (da == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                FormVizualizareEvaluari fve = new FormVizualizareEvaluari();
                this.Hide();
                fve.ShowDialog();
                return;
            }

        }
    }
}
