namespace evaluarea_studentilor_in_sesiune
{
    public class Grupa
    {
        public int IdGrupa { get; set; }
        public int AnDeStudiu { get; set; }
        public string AnUniversitar { get; set; }
        public string CodSpecializare { get; set; }

     

          public string AnSud_AnUniv
          {
            get { return $"An Universitar {AnUniversitar}" + $"An Studiu{AnDeStudiu}" + $"/{CodSpecializare}"; }
           
          }
       

    }
}

