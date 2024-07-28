using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Windows.Forms;
using System;

namespace evaluarea_studentilor_in_sesiune
{
	public class ConexiuneBazaDeDate
	{
		const connString= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Evaluare_stud_Sesiune;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public static List<Cont> ExtragereConturi()
		{
			using (SqlConnection con = new SqlConnection(connString))
			{
				var listConturi = con.Query<Cont>
	
			}

		}


	}
}
