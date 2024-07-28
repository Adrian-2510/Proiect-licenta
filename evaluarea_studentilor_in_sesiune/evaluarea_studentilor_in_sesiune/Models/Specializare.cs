namespace evaluarea_studentilor_in_sesiune.Properties
{
    public class Specializare
    {
        public string CodSpecializare { get; set; }
        public string NumeSpecializare { get; set; }
        public int NumarAniDeStudiu { get; set; }


        public string Afisare
        {
          get { return $"{CodSpecializare}-->{NumeSpecializare}"; }
            
        }

    }

}
