using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test5.laurapennetta.Entità;
using Test5.laurapennetta.Repository;

namespace Test5.laurapennetta
{
    public class RepositoryStudente : IRepositoryStudente
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
        Integrated Security = True; Initial Catalog = LibrettoUniversitario;";

        public bool Add(Studente item)
        {
            throw new NotImplementedException();
        }

        public IList<Studente> GetAll()
        {
            IList<Studente> studente = new List<Studente>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "SELECT * FROM Studente"
                    };
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Studente s = new Studente()
                        {
                            Matricola = reader["Matricola"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            Cognome = reader["Cognome"].ToString(),
                            DataNascita = DateTime.Parse(reader["DataNascita"].ToString()),
                        };
                        studente.Add(s);
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return studente;
        }
    }
}
