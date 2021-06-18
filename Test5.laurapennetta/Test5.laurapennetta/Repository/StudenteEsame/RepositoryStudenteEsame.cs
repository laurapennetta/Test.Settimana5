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
    public class RepositoryStudenteEsame : IRepositoryStudenteEsame
    {
        public bool Add(StudenteEsame item)
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
                        CommandText = "INSERT INTO StudenteEsame VALUES (@StudenteID, @EsameID)" +
                        "INSERT INTO Esame VALUES (@ID, @Nome, @CFU, @DataEsame " +
                        "@Voto, @Passato)"
                    };

                    insertCommand.Parameters.AddWithValue("@StudenteID", item.Studente.Matricola);
                    insertCommand.Parameters.AddWithValue("@EsameID", item.Esame.Nome);

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

        public IList<StudenteEsame> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
