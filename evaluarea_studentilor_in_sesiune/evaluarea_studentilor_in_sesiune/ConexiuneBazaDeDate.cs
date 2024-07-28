using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Windows.Forms;
using System;
using evaluarea_studentilor_in_sesiune.Properties;
using evaluarea_studentilor_in_sesiune.Resources;

namespace evaluarea_studentilor_in_sesiune
{
    public class ConexiuneBazaDeDate
    {
        const string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Evaluare_stud_Sesiune;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Cont> ExtragereConturi()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaConturi = con.Query<Cont>("SELECT* FROM CONT").ToList();
                return listaConturi;
                

            }
        }
        public static List<Profesor> ExtragereProfesor()
        {

            using (SqlConnection con = new SqlConnection(connString))
            {

                var listaProfesori = con.Query<Profesor>("SELECT* FROM Profesor").ToList();
                return listaProfesori;
            }
        }
        public static void InsertCont(Cont cont)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("INSERT INTO Cont values('" + cont.UserName + "','" + cont.Parola + "','" + cont.TipCont + "','" + cont.StatusCont + "','" + cont.Poza + "')");
            }
        }
        public static void InsertProfesor(Profesor profesor)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("Insert into Profesor values('" + profesor.CNP + "','" + profesor.NumeProfesor + "','" + profesor.PrenumeProfesor + "','" + profesor.Grad + "','" + profesor.Email + "','" + profesor.UserName + "')");
            }
        }
        public static List<Specializare> ExtrageSpecializari()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaSpecializari = con.Query<Specializare>("Select* from Specializare").ToList();
                return listaSpecializari;
            }
        }
        public static List<Student> ExtragereStudenti()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaStudenti = con.Query<Student>("SELECT * FROM Student").ToList();
                return listaStudenti;
            }
        }
        public static void InserareStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("Insert into Student values('" + student.NrMatricol + "','" + student.CNP + "','" + student.NumeStudent + "','" + student.PrenumeStudent + "','" + student.Telefon + "','" + student.Email + "','" + student.UserName + "')");
            }
        }
        public static List<Grupa> ExtragereGrupa()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaGrupa = con.Query<Grupa>("SELECT* FROM Grupa").ToList();
                return listaGrupa;
            }
        }
        public static void InsertAsociereStudentGrupa(AsociereStudentContGrupa asociereStudentGrupa)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("INSERT INTO AsociereStudentContGrupa values('" + asociereStudentGrupa.IdGrupa + "','" + asociereStudentGrupa.NrMatricol + "','" + asociereStudentGrupa.UserName + "')");
            }
        }
        public static void UpdatePozaStud(string calePoza, string user)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE CONT SET Poza=@CalePoza WHERE UserName=@User", new { CalePoza = calePoza, User = user });
            }
        }
        public static List<DespreMineS> ExtragereInfo()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaInfoS = con.Query<DespreMineS>("SELECT " +
            "Student.NrMatricol, " +
            "Student.NumeStudent, " +
            "Student.PrenumeStudent, " +
            "Student.Telefon, " +
            "Student.Email, " +
            "Cont.UserName, " +
            "Grupa.AnDeStudiu, " +
            "Grupa.AnUniversitar, " +
            "Specializare.NumeSpecializare " +
            "FROM " +
            "Student " +
            "INNER JOIN AsociereStudentContGrupa ON Student.NrMatricol = AsociereStudentContGrupa.NrMatricol " +
            "INNER JOIN Cont ON cont.UserName = AsociereStudentContGrupa.UserName " +
            "INNER JOIN Grupa ON AsociereStudentContGrupa.IdGrupa = Grupa.IdGrupa " +
            "INNER JOIN Specializare ON Grupa.CodSpecializare = Specializare.CodSpecializare").ToList();
                return listaInfoS;
            }

        }


        public static void UpdateStud(Student student)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE STUDENT SET NumeStudent=@nume, PrenumeStudent=@prenume, Telefon=@telefon, Email=@email WHERE NrMatricol=@nrMatricol",
              new { nume = student.NumeStudent, prenume = student.PrenumeStudent, telefon = student.Telefon, email = student.Email, nrMatricol = student.NrMatricol });



            }
        }
        public static List<AsociereStudentContGrupa> ExtragereasociereStudentContGrupa()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaAsociereStudentContGrupa = con.Query<AsociereStudentContGrupa>("select* from AsociereStudentContGrupa ").ToList();
                return listaAsociereStudentContGrupa;
            }
        }
        public static void InserareSpecializare(Specializare specializare)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Execute("Insert into Specializare values('" + specializare.CodSpecializare + "','" + specializare.NumeSpecializare + "','" + specializare.NumarAniDeStudiu + "')");
                }
                catch(Exception)
                {
                    MessageBox.Show("Va rog redeschideti pagina");
                }
            }
        }
        public static void UpdateSpecializare(Specializare specializare, string Cod)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE SPECIALIZARE SET CodSpecializare=@CodSpecializare,NumeSpecializare=@NumeSpecializare,NumarAniDeStudiu=@NumarAniDeStudiu where CodSpecializare='" + Cod + "'",
                    new { CodSpecializare = specializare.CodSpecializare, NumeSpecializare = specializare.NumeSpecializare, NumarAniDeStudiu = specializare.NumarAniDeStudiu });
            }
        }
        public static void StergeSpecializare(string cod)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("delete from Specializare Where CodSpecializare='" + cod + "'");
            }
        }

        public static List<DespreMineP> ExtragereDespreMineP()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                //         var listaDespreMineP = con.Query<DespreMineP>("SELECT  Cont.UserName, Profesor.NumeProfesor,Profesor.PrenumeProfesor, Profesor.Email, Profesor.Grad, Disciplina.Denumire,Profesor.CNP " +
                //"FROM Profesor " +
                //"INNER JOIN Cont ON Profesor.UserName = Cont.UserName " +
                //"INNER JOIN AsociereProfesorDisciplinaGrupa ON Profesor.CNP = AsociereProfesorDisciplinaGrupa.CNP " +
                //"INNER JOIN Disciplina ON AsociereProfesorDisciplinaGrupa.IdDisciplina = Disciplina.IdDisciplina").ToList();
                string query = @"
                SELECT 
                    Cont.UserName, 
                    Profesor.NumeProfesor,
                    Profesor.PrenumeProfesor, 
                    Profesor.Email, 
                    Profesor.Grad, 
                    Disciplina.Denumire, 
                    Profesor.CNP
                FROM 
                    Profesor
                INNER JOIN 
                    Cont ON Profesor.UserName = Cont.UserName
                LEFT JOIN 
                    AsociereProfesorDisciplinaGrupa ON Profesor.CNP = AsociereProfesorDisciplinaGrupa.CNP
                LEFT JOIN 
                    Disciplina ON AsociereProfesorDisciplinaGrupa.IdDisciplina = Disciplina.IdDisciplina";

                var listaDespreMineP = con.Query<DespreMineP>(query).ToList();

                return listaDespreMineP;
            }
        }

        public static void UpdateProfesor(Profesor profesor)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute(" update Profesor set CNP=@CNP,NumeProfesor=@NumeProfesor,PrenumeProfesor=@PrenumeProfesor,Grad=@Grad,Email=@Email,UserName=@UserName where UserName=@UserName ",
                    new
                    {
                        CNP = profesor.CNP,
                        NumeProfesor = profesor.NumeProfesor,
                        PrenumeProfesor = profesor.PrenumeProfesor,
                        Grad = profesor.Grad,
                        Email = profesor.Email,
                        UserName = profesor.UserName
                    });
            }
        }
        public static List<Disciplina> ExtragereDisciplina()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaDiscipline = con.Query<Disciplina>("SELECT* FROM DISCIPLINA").ToList();
                return listaDiscipline;
            }
        }

        public static void InserareIntrebare(Itemi itemi)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("INSERT INTO Itemi VALUES (@IdItem, @EnuntItem,@TipItem,@PozaItem, @Raspuns1, @Raspuns2, @Raspuns3, @Raspuns4,@Raspuns5, @RaspunsCorect1,@RaspunsCorect2,@RaspunsCorect3 ,@DataPublicareItem, @IdDisciplina)",
    new
    {
        IdItem = itemi.IdItem,
        EnuntItem = itemi.EnuntItem,
        TipItem=itemi.TipItem,
        PozaItem = itemi.PozaItem,
        Raspuns1 = itemi.Raspuns1,
        Raspuns2 = itemi.Raspuns2,
        Raspuns3 = itemi.Raspuns3,
        Raspuns4 = itemi.Raspuns4,
        Raspuns5 = itemi.Raspuns5,
        RaspunsCorect1 = itemi.RaspunsCorect1,
        RaspunsCorect2 = itemi.RaspunsCorect2,
        RaspunsCorect3 = itemi.RaspunsCorect3,
        DataPublicareItem = itemi.DataPublicareItem,
        IdDisciplina = itemi.IdDisciplina
    });

            }
        }
        public static List<Itemi> ExtragereItemi()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaItemi = con.Query<Itemi>("SELECT* FROM ITEMI").ToList();
                return listaItemi;
            }
        }
        public static void StergereIntrebare(int codItem)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("DELETE FROM ITEMI WHERE IdItem=@IdItem",
                    new
                    {
                        IdItem = codItem
                    });
            }
        }
        public static void ActualizeazaIntrebare(Itemi itemi, int cod)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE  ITEMI SET IdItem=@IdItem1, EnuntItem=@EnuntItem,TipItem=@TipItem,PozaItem=@PozaItem,Raspuns1=@Raspuns1,Raspuns2=@Raspuns2,Raspuns3=@Raspuns3" +
                    ",Raspuns4=@Raspuns4,Raspuns5=@Raspuns5,RaspunsCorect1=@RaspunsCorect1,RaspunsCorect2=@RaspunsCorect2,RaspunsCorect3=@RaspunsCorect3 where IdItem=@IdItem",
                    new
                    {
                        IdItem1=itemi.IdItem,
                        EnuntItem = itemi.EnuntItem,
                        TipItem=itemi.TipItem,
                        PozaItem = itemi.PozaItem,
                        Raspuns1 = itemi.Raspuns1,
                        Raspuns2 = itemi.Raspuns2,
                        Raspuns3 = itemi.Raspuns3,
                        Raspuns4 = itemi.Raspuns4,
                        Raspuns5 = itemi.Raspuns5,
                        RaspunsCorect1 = itemi.RaspunsCorect1,
                        RaspunsCorect2 = itemi.RaspunsCorect2,
                        RaspunsCorect3 = itemi.RaspunsCorect3,
                        IdDisciplina = itemi.IdDisciplina,
                        IdItem = cod

                    });
            }
        }
        public static void InserareDisciplina(Disciplina disciplina)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("Insert into Disciplina values (@IdDisciplina,@Denumire,@Descriere)",
                    new
                    {
                        IdDisciplina = disciplina.IdDisciplina,
                        Denumire = disciplina.Denumire,
                        Descriere = disciplina.Descriere

                    });
            }
        }

        public static void ActulizareDisciplina(Disciplina disciplina, string cod)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("Update disciplina set IdDisciplina=@IdDisciplina , Denumire=@Denumire,Descriere=@Descriere where IdDisciplina=@IdDisciplina1",
                    new
                    {
                        IdDisciplina = disciplina.IdDisciplina,
                        Denumire = disciplina.Denumire,
                        Descriere = disciplina.Descriere,
                        IdDisciplina1 = cod

                    });
            }
        }
        public static void StergereDisciplina(string cod)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("DELETE FROM DISCIPLINA WHERE IdDisciplina=@IdDisciplina",
                    new
                    {
                        IdDisciplina = cod
                    });
            }
        }
        public static void InserareEvaluare(Evaluare evaluare)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("INSERT INTO Evaluare (DenumireEvaluare, DataStartEvaluare, DataStopEvaluare, DataProiectareEvaluare, TimpEvaluare, NrItemi, IdDisciplina, IdGrupa) " +
              "VALUES (@DenumireEvaluare, @DataStartEvaluare, @DataStopEvaluare, @DataProiectareEvaluare, @TimpEvaluare, @NrItemi, @IdDisciplina, @IdGrupa)",
              new
              {
                  DenumireEvaluare = evaluare.DenumireEvaluare,
                  DataStartEvaluare = evaluare.DataStartEvaluare,
                  DataStopEvaluare = evaluare.DataStopEvaluare,
                  DataProiectareEvaluare = evaluare.DataProiectareEvaluare,
                  TimpEvaluare = evaluare.TimpEvaluare,
                  NrItemi = evaluare.NrItemi,
                  IdDisciplina = evaluare.IdDIsciplina,
                  IdGrupa = evaluare.IdGrupa
              });


            }
        }
        public static List<Evaluare> ExtragereEvaluare()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaEvaluare = con.Query<Evaluare>("SELECT IdEvaluare, DenumireEvaluare, DataStartEvaluare, DataStopEvaluare, DataProiectareEvaluare, TimpEvaluare, NrItemi, IdDisciplina, IdGrupa FROM Evaluare").ToList();
                return listaEvaluare;
            }

        }
        public static void InserareGrupa(Grupa grupa)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("INSERT INTO GRUPA (IdGrupa, AnDeStudiu, AnUniversitar, CodSpecializare) VALUES(@IdGrupa, @AnDeStudiu, @AnUniversitar, @CodSpecializare)",

                    new
                    {
                        IdGrupa = grupa.IdGrupa,
                        AnDeStudiu = grupa.AnDeStudiu,
                        AnUniversitar = grupa.AnUniversitar,
                        CodSpecializare = grupa.CodSpecializare

                    });
            }
        }
        public static void StergereGrupa(int idGrupa)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("DELETE FROM GRUPA WHERE IdGrupa=@IdGrupa",
                    new
                    {
                        IdGrupa = idGrupa
                    });
            }
        }
        public static void ActualizareGrupa(Grupa grupa, int idGrupa)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE GRUPA SET AnDeStudiu=@AnDeStudiu,AnUniversitar=@AnUniversitar,CodSpecializare=@CodSpecializare where " +
                    "IdGrupa=@IdGrupa",
                    new
                    {
                        AnDeStudiu = grupa.AnDeStudiu,
                        AnUniversitar = grupa.AnUniversitar,
                        CodSpecializare = grupa.CodSpecializare,
                        IdGrupa = idGrupa
                    });
            }
        }

        public static void ActulizareCont(Cont cont)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE CONT SET UserName=@UserName,Parola=@Parola,TipCont=@TipCont,StatusCont=@StatusCont where UserName=@user",
                    new
                    {
                        UserName = cont.UserName,
                        Parola = cont.Parola,
                        TipCont = cont.TipCont,
                        StatusCont = cont.StatusCont,
                        user = cont.UserName
                    });
            }
        }


        public static void InserareAsociereProfesorDsiciplinaGrupa(AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("INSERT INTO AsociereProfesorDisciplinaGrupa VALUES(@IdDisciplina,@CNP,@IdGrupa,@AnUniversitar,@Semestrul)",
                    new
                    {
                        IdDisciplina = asociereProfesorDisciplinaGrupa.IdDisciplina,
                        CNP = asociereProfesorDisciplinaGrupa.CNP,
                        IdGrupa = asociereProfesorDisciplinaGrupa.IdGrupa,
                        AnUniversitar = asociereProfesorDisciplinaGrupa.AnUniversitar,
                        Semestrul = asociereProfesorDisciplinaGrupa.Semestrul
                    });
            }
        }
        public static List<AsociereProfesorDisciplinaGrupa> ExtragereAsociereProfesorDisciplinaGrupa()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                var listaAsociereProfesorDisciplinaGrupa = con.Query<AsociereProfesorDisciplinaGrupa>("SELECT * FROM AsociereProfesorDisciplinaGrupa").ToList();
                return listaAsociereProfesorDisciplinaGrupa;
            }
        }
        public static void StergeAsocierea(AsociereProfesorDisciplinaGrupa asociereProfesorDisciplinaGrupa)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("DELETE FROM AsociereProfesorDisciplinaGrupa WHERE IdDisciplina=@IdDisciplina AND CNP=@CNP AND IdGrupa=@IdGrupa",
     new
     {
         IdDisciplina = asociereProfesorDisciplinaGrupa.IdDisciplina,
         CNP = asociereProfesorDisciplinaGrupa.CNP,
         IdGrupa = asociereProfesorDisciplinaGrupa.IdGrupa
     });


            }
        }
        public static void StergeEvaluare(int codE)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("Delete from Evaluare where IdEvaluare=@IdEvaluare",
                    new
                    {
                        IdEvaluare = codE
                    }); ;

            }
        }
        public static void ActualizeazaAsociereStudentContGrupa(AsociereStudentContGrupa asociereStudentContGrupa)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE AsociereStudentContGrupa SET IdGrupa = @IdGrupa, NrMatricol = @NrMatricol, UserName=@UserName WHERE UserName=@UserName and NrMatricol=@NrMatricol  ",
                    new
                    {
                        IdGrupa = asociereStudentContGrupa.IdGrupa,
                        NrMatricol = asociereStudentContGrupa.NrMatricol,
                        UserName = asociereStudentContGrupa.UserName

                    }); 
            }
        }
        public static List<RezultateEvaluare> ExtrageRezultateEvaluare()
        {
            using(SqlConnection con =new SqlConnection(connString))
            {
                var listaRezultateEvaluare = con.Query<RezultateEvaluare>("Select * from RezultateEvaluare").ToList();
                return listaRezultateEvaluare;
            }
        }
        public static void InsereazaRezultateEvaluare(RezultateEvaluare rezultateEvaluare)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute(@"INSERT INTO RezultateEvaluare (IdRezultat,IdEvaluare, NrMatricol, NotaEvaluare)
                      VALUES (@IdRezultat,@IdEvaluare, @NrMatricol, @NotaEvaluare)",
                    new
                    {
                        IdRezultat=rezultateEvaluare.IdRezultat,
                        IdEvaluare = rezultateEvaluare.IdEvaluare,
                        NrMatricol = rezultateEvaluare.NrMatricol,
                        NotaEvaluare = rezultateEvaluare.NotaEvaluare
                    });
            }
        }
        public static void UpdateNota(float nota,int idEvalure)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE RezultateEvaluare SET NotaEvaluare = @nota,DataFinalizareEvaluare=@DataCurenta where IdEvaluare=@idEvalure",
                    new
                    {
                        nota = nota,
                        idEvalure = idEvalure,
                        DataCurenta=DateTime.Now
                        
                    }); ;
            }
        }
        public static void InserareItemEvluare(ItemiEvaluare itemiEvaluare)
        { 
            using(SqlConnection con =new SqlConnection(connString))
            {
                con.Execute("Insert into ItemiEvaluare values(@IdRezultat,@IdItem,@RaspunsAles1,@RaspunsAles2,@RaspunsAles3)",
                    new
                    {
                        IdRezultat = itemiEvaluare.IdRezultat,
                        IdItem = itemiEvaluare.IdItem,
                        RaspunsAles1 = itemiEvaluare.RaspunsAles1,
                        RaspunsAles2 = itemiEvaluare.RaspunsAles2,
                        RaspunsAles3 = itemiEvaluare.RaspunsAles3
                    });
            }
        }
        public static List<NotaCuEvaluare>ExtragereNotaCuEvaluare()
        {
            using(SqlConnection con =new SqlConnection(connString))
            {
                var listaExtragereNotaCuEvaluare = con.Query<NotaCuEvaluare>("SELECT r.IdEvaluare, e.DenumireEvaluare, e.NrItemi, e.IdDIsciplina, e.IdGrupa, r.IdRezultat, r.NrMatricol, r.NotaEvaluare, r.DataFinalizareEvaluare " +
                    "FROM Evaluare e INNER JOIN RezultateEvaluare r ON e.IdEvaluare = r.IdEvaluare").ToList();
                return listaExtragereNotaCuEvaluare;
            }
        }


        public static List<IEREI>ExtrageIerei()
        {
            using(SqlConnection con =new SqlConnection(connString))
            {
                var listIerei = con.Query<IEREI>("SELECT ie.IdRezultat, ie.IdItem, ie.RaspunsAles1,ie.RaspunsAles2,ie.RaspunsAles3, re.IdEvaluare, re.NrMatricol, re.NotaEvaluare, i.EnuntItem,i.TipItem, i.PozaItem, i.Raspuns1, i.Raspuns2, i.Raspuns3, i.Raspuns4,i.Raspuns5, i.RaspunsCorect1, i.RaspunsCorect2,i.RaspunsCorect3 " +
                    "FROM itemiEvaluare ie  left JOIN RezultateEvaluare re ON ie.IdRezultat = re.IdRezultat left JOIN itemi" +
                    " i ON ie.IdItem = i.IdItem").ToList();
                return listIerei;
                    
            }
        }
        public static List<ItemiEvaluare>ExtragereItemiEvaluare()
        {
            using(SqlConnection con =new SqlConnection(connString))
            {
                var listaItemiEvaluare = con.Query<ItemiEvaluare>("Select * from ItemiEvaluare").ToList();
                return listaItemiEvaluare;
            }
        }
        public static void InserareNotaCatalog (Catalog catalog)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("Insert into Catalog Values(@IdNotaCatalog,@IdRezultat,@Blocat,@NotaCatalog)",
                    new
                    {
                        IdNotaCatalog=catalog.IdNotaCatalog,
                        IdRezultat = catalog.IdRezultat,
                        Blocat = catalog.Blocat,
                        NotaCatalog = catalog.NotaCatalog

                    });
            }
        }

        public static List<Catalog> ExtragereCatalog()
        {
            using (SqlConnection con = new SqlConnection(connString))
            {

                var listaCatalog = con.Query<Catalog>("SELECT * FROM CATALOG").ToList();
                if (listaCatalog == null)
                {
                    return null;
                }
                return listaCatalog;
            }
        }
        public static void DeblocheazaBlocheazaStudent(Catalog catalog)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Execute("UPDATE CATALOG SET blocat=@blocat where IdNotaCatalog=@IdNotaCatalog",
                    new
                    {
                        blocat = catalog.Blocat,
                        IdNotaCatalog = catalog.IdNotaCatalog
                    });
            }
        }
      

        //public static List<DisciplinaNota> ExtrageDisciplinaNota()
        //{
        //    using (SqlConnection con = new SqlConnection(connString))
        //    {
        //        var listaDisciplinaNote = con.Query<DisciplinaNota>("SELECT Disciplina.Denumire AS Disciplina, RezultateEvaluare.NotaEvaluare AS Nota,RezultateEvaluare.NrMatricol AS NrMatricol,  Disciplina.IdDisciplina AS IdDisciplina, Grupa.IdGrupa AS IdGrupa, Grupa.AnDeStudiu AS Anul FROM RezultateEvaluare JOIN Evaluare ON RezultateEvaluare.IdEvaluare = Evaluare.IdEvaluare JOIN Grupa ON Evaluare.IdGrupa = Grupa.IdGrupa JOIN AsociereStudentContGrupa ON RezultateEvaluare.NrMatricol = AsociereStudentContGrupa.NrMatricol JOIN AsociereProfesorDisciplinaGrupa ON Grupa.IdGrupa = AsociereProfesorDisciplinaGrupa.IdGrupa JOIN Disciplina ON AsociereProfesorDisciplinaGrupa.IdDisciplina = Disciplina.IdDisciplina GROUP BY Disciplina.Denumire,RezultateEvaluare.NotaEvaluare,  RezultateEvaluare.NrMatricol,Disciplina.IdDisciplina,Grupa.IdGrupa, Grupa.AnDeStudiu; ");
        //        return listaDisciplinaNote.ToList();
        //    }
        //}

    }
}
