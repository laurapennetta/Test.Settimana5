using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test5.laurapennetta.Entità;

namespace Test5.laurapennetta.Repository
{
    public class RepositoryEsame : IRepositoryEsame
    {
        const string connectionString = @"Server = .\SQLEXPRESS; Persist Security Info = False; 
        Integrated Security = True; Initial Catalog = LibrettoUniversitario;";

        public bool Add(Esame item)
        {
            bool esito;
            using (SqlConnection connection = new SqlConnection())
            {

                try
                {
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand()
                    {
                        Connection = connection,
                        CommandType = CommandType.Text,
                        CommandText = "INSERT INTO Esame VALUES (@ID, @Nome, @CFU, @DataEsame " +
                        "@Voto, @Passato)"
                    };

                    insertCommand.Parameters.AddWithValue("@Nome", item.Nome);
                    insertCommand.Parameters.AddWithValue("@CFU", item.CFU);
                    insertCommand.Parameters.AddWithValue("@DataEsame", item.DataEsame);
                    insertCommand.Parameters.AddWithValue("@Voto", item.Voto);
                    insertCommand.Parameters.AddWithValue("@Passato", item.Passato);

                    insertCommand.ExecuteNonQuery();
                    esito = true;
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                    esito = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    esito = false;
                }
            }
            return esito;
        }

        public IList<Esame> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
