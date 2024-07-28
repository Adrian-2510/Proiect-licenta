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

    public class Evaluare 
    {
        List<AsociereStudentContGrupa> listaAsociereStudentContGrupas = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<RezultateEvaluare> listaRezultateEvaluare = ConexiuneBazaDeDate.ExtrageRezultateEvaluare();
        public int IdEvaluare { get; set; }
        public string DenumireEvaluare { get; set; }
        public DateTime DataStartEvaluare { get; set; }
        public DateTime DataStopEvaluare { get; set; }
        public DateTime DataProiectareEvaluare { get; set; }
        public int TimpEvaluare { get; set; }
        public int NrItemi { get; set; }
        public string IdDIsciplina { get; set; }
        public int IdGrupa { get; set; }


        private string denumireDisiciplina()
        {
            List<Disciplina> listaDisciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
            string denumireDisciplina = string.Empty;
            foreach (Disciplina disciplina in listaDisciplina)
            {
                if (disciplina.IdDisciplina == IdDIsciplina)
                {
                    denumireDisciplina = disciplina.Denumire;
                }
            }
            return denumireDisciplina;
        }

        public string DennumireEvaluareTimp
        {
            get { return $"{DenumireEvaluare}-timp limita:{DataStopEvaluare}-disciplina:{denumireDisiciplina()}"; }
            
        }



















    }
}
