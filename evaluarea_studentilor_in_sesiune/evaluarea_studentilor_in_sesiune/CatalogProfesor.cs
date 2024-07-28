
using System;

namespace evaluarea_studentilor_in_sesiune
{
    public class CatalogProfesor
    {
        public string NumeStudent { get; set; }
        public string PrenumeStudent { get; set; }
        public string disciplina { get; set; }
        public string notaStudent { get; set; }
        public int Blocat { get; set; }
        public int IdGrupa { get; set; }
        public int IdNotaCatalog { get; set; }
        public DateTime DataFinalNotaCatalog { get; set; }
    }
}
