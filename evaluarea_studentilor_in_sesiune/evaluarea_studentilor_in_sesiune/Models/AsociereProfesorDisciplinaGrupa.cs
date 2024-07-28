using evaluarea_studentilor_in_sesiune.Properties;
using System;
using System.Collections.Generic;
namespace evaluarea_studentilor_in_sesiune
{
    public class AsociereProfesorDisciplinaGrupa
        {
        public string IdDisciplina { get; set; }
        public string CNP { get; set; }
        public int IdGrupa { get; set; }
        public string AnUniversitar { get; set; }
        public int Semestrul { get; set; }
        string numeProf;
        string denumiregrupa;
        string numeDisciplina;

        string numeProfesor()
        {
            List<Profesor> listaProfesor = ConexiuneBazaDeDate.ExtragereProfesor();
            foreach(Profesor profesor in listaProfesor)
            {
                if(profesor.CNP==CNP)
                {
                    numeProf = profesor.NumeProfesor + " " + profesor.PrenumeProfesor;
                }
            }
            return numeProf.ToUpper();
        }
         string denumireGrupa()
        {
            List<Grupa> listaGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
            foreach(Grupa grupa in listaGrupa)
            {
                if(grupa.IdGrupa==IdGrupa)
                {
                    denumiregrupa = grupa.AnSud_AnUniv;
                }
            }
            return denumiregrupa;
        }
        string denumireDisciplina()
        {
            List<Disciplina> listaDisciplina = ConexiuneBazaDeDate.ExtragereDisciplina();
            foreach(Disciplina disciplina in listaDisciplina)
            {
                if(disciplina.IdDisciplina==IdDisciplina)
                {
                    numeDisciplina = disciplina.Denumire;
                }
            }
            return numeDisciplina;

        }

      

        public string AoscierProfesor
        {
            get { return $"{numeProfesor()}-"+$"{denumireDisciplina()} "+$"{denumireGrupa()}"; }
          
        }

    }
    
}
