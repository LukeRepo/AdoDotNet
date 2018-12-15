using System;
using System.Collections.Generic;

namespace GestionalePartite
{
    class Program
    {
        static void Main(string[] args)
        {
            DBRepository repo = new DBRepository();

            Console.WriteLine("Buon giorno!!!");

            string scelta, tipo, tipoPartita, nome, cognome, nickName, orario;
            string risultato = null;
            int partitaId, numeroCampo, livello, giocatoreId;
            int anni;
            DateTime dataNascita, giorno;
            

            for (; ;)
            {
                Console.WriteLine("Scegli un'opzione: ");
                Console.WriteLine("I: Prenota partita");
                Console.WriteLine("E: lista partite per data");                
                Console.WriteLine("C: Cerca per età il livello:");
                Console.WriteLine("X: esci");                
                scelta = Console.ReadLine();

                if (scelta.Equals("i"))
                {


                    try
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Inserisci il numero ID della partita: ");
                                partitaId = Int32.Parse(Console.ReadLine());
                                break;
                            }
                            catch (Exception)
                            {

                                continue;
                            }
                        }
                        Console.WriteLine("Inserisci il Tipo di partita tennis/paddle: ");
                        tipo = Console.ReadLine();
                        if (tipo == "tennis")
                        {
                            Console.WriteLine("Vuoi fare un partita singolo o doppio?: ");
                            tipoPartita = Console.ReadLine();
                            if (tipoPartita == "singolo")
                            {
                                Console.WriteLine("Inserisci l'id di 2 giocatori: ");
                            }
                            if (tipoPartita == "doppio")
                            {
                                Console.WriteLine("Inserisci l'id di 4 giocatori: ");
                            }
                        }
                        if (tipo == "paddle")
                        {
                            Console.WriteLine("Inserisci l'id di 4 giocatori: ");
                        }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Inserisci la data della partita yyyy-mm-dd: ");
                                giorno = DateTime.Parse(Console.ReadLine());
                                break;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Inserisci l'orario della partita: ");
                                orario = Console.ReadLine();
                                break;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Inserisci il numero del campo: ");
                                numeroCampo = Int32.Parse(Console.ReadLine());
                                break;
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }

                        //List<Giocatore> giocatori = repo.PartecipantiSelezionati(Console.ReadLine());
                        //for (int i = 0; i < giocatori.Count; i++)
                        //{
                        //    Console.WriteLine(giocatori[i]);
                        //}
                        //Giocatore g = new Giocatore(giocatoreId, nome, cognome, dataNascita, nickName, livello);
                        Partita p = new Partita(partitaId, tipo, giorno, orario, risultato, numeroCampo);
                        repo.PrenotaPartita(p);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                   

                }

                if (scelta=="e")
                {
                    try
                    {
                        Console.WriteLine("Inserisci la data della partita yyyy-mm-dd:: ");
                        List<Partita> lista = repo.RicercaPartitaPerData(DateTime.Parse(Console.ReadLine()));
                        for (int i = 0; i < lista.Count; i++)
                        {
                            Console.WriteLine(lista[i]);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }


                }
                if (scelta.Equals("c"))
                {
                    Console.WriteLine("Inserisci gli anni del giocatore: ");
                    anni = Int32.Parse(Console.ReadLine());
                    decimal result = repo.RicercaLivelloPerEta(anni);
                    Console.WriteLine("La media è " + result);
                    //se da errore: 'System.DBNull' to type 'System.Decimal' vuol dire che non ci sono giocatori con quella data
                }

                if (scelta.Equals("x"))
                {
                    break;
                }


            }



        }
    }
}
