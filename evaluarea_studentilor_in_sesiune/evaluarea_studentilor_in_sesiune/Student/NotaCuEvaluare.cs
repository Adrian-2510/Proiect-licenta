using System;
using System.Collections.Generic;
namespace evaluarea_studentilor_in_sesiune
{
    public class NotaCuEvaluare
    {

        public int IdEvaluare { get; set; }
        public string DenumireEvaluare { get; set; }
        public int NrItemi { get; set; }
        public string IdDIsciplina { get; set; }
        public int IdGrupa { get; set; }
        public int IdRezultat { get; set; }
      
        public string NrMatricol { get; set; }
        public float NotaEvaluare { get; set; }
        public DateTime DataFinalizareEvaluare { get; set; }

        private string denumireDisiciplina()
        {
            List<Disciplina> listaDisciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
            string denumireDisciplina = string.Empty;
            foreach(Disciplina disciplina in listaDisciplina)
            {
                if(disciplina.IdDisciplina==IdDIsciplina)
                {
                    denumireDisciplina = disciplina.Denumire;
                }
            }
            return denumireDisciplina;
        }

        public string DenumireNota
        {
            get { return $"{DenumireEvaluare}--disciplina:{denumireDisiciplina()} "+"---->"+$"{NotaEvaluare}"; }
           
        }

    }
}
