namespace evaluarea_studentilor_in_sesiune.Properties
{
    public class Profesor
    {
        public string CNP { get; set; }
        public string NumeProfesor { get; set; }
        public string PrenumeProfesor { get; set; }
        public string Email { get; set; }
        public string Grad { get; set; }
        public string UserName { get; set; }



        public string Nume_Prenume_Profesor
        {

            get { return $"{NumeProfesor.ToUpper()} {PrenumeProfesor.ToUpper()}"; }
        }

    }
}

   

