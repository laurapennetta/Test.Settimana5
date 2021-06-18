using System;
using Test5.laurapennetta.Repository;

namespace Test5.laurapennetta
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositoryStudente studente = new RepositoryStudente();
            foreach (var s in studente.GetAll())
            {
                Console.WriteLine("Matricola: {0}\nNome: {1}\nCognome: {2}\nData di Nascita: {3}\n",
                    s.Matricola, s.Nome, s.Cognome, s.DataNascita);
            }
            AggiungiPrenotazione();
        }
        public static void AggiungiPrenotazione()
        {

        }
    }
}
