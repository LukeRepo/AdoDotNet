using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GestionalePartite
{

    static class ConnectionData
    {
        public const string CONN_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GestionalePartite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        

    }
    public class DBRepository
    {       
        
                const string INSERT_PARTITA = @"
                insert into Partite
                (                   
                   PartitaId,
                   Giorno,
                   OrarioFine,
                   NumeroCampo,                   
                   Tipo              
                )
                values(@PartitaId, @Giorno, @OrarioFine, @NumeroCampo, @Tipo )
                ";

                const string INSERT_ISCRIPTION = @"                
                insert into Iscrizioni
                (
                   partitaId,
                   giocatoreId                   
                )
                values((SELECT partitaId from Partite WHERE partitaId=@partitaId),(SELECT giocatoreId FROM Giocatori WHERE giocatoreId=@giocatoreId))
                ";

                const string INSERT_PLAYER = @"
                SELECT *
                FROM Giocatori 
                WHERE dataInizio LIKE 
                ";                

                const string RESEARCH = @"
                SELECT *
                FROM Partite 
                WHERE Giorno = @data
                ";

                const string RESEARCH_LEVEL_AVG = @"
                SELECT AVG(CONVERT(DECIMAL(4,2), livello))
                FROM Giocatori
                WHERE DATEDIFF(year, DataNascita, GETDATE())<@anni
                ";


        public void PrenotaPartita(Partita p)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionData.CONN_STRING))
                {
                    
                    using (SqlCommand cmd = new SqlCommand(INSERT_PARTITA, conn))
                    {
                        Console.WriteLine("query" + cmd.CommandText);
                        cmd.Parameters.AddWithValue("@PartitaId", p.getPartitaId());
                        cmd.Parameters.AddWithValue("@Giorno", p.getGiorno());
                        cmd.Parameters.AddWithValue("@OrarioFine", p.getOrario());
                        cmd.Parameters.AddWithValue("@numeroCampo", p.getNumeroCampo());                        
                        cmd.Parameters.AddWithValue("@Tipo", p.getTipo());

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);                            
                        }                        
                                               
                    }
                    //using (SqlCommand cmd = new SqlCommand(INSERT_PARTITA, conn))
                    //{
                    //    cmd.Parameters.AddWithValue("@partitaId", p.getPartitaId());
                    //    //cmd.Parameters.AddWithValue("@giocaotreId", g.getGiocatoreId());
                    //    cmd.ExecuteNonQuery();
                    //}


                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }

        public List<Giocatore> PartecipantiSelezionati(string title)
        {
            try
            {
                List<Giocatore> lista = new List<Giocatore>();
                using (SqlConnection conn = new SqlConnection(ConnectionData.CONN_STRING))
                {
                    conn.Open();

                    title = title.Replace("'", "\'");
                    using (SqlCommand cmd = new SqlCommand(INSERT_PLAYER + "'%" + title + "%'", conn))
                    {
                        
                        Console.WriteLine("query" + cmd.CommandText);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Giocatore((Int32)reader["giocatoreId"], reader["nome"].ToString(), reader["cognome"].ToString(), (DateTime)reader["dataNascita"], reader["nickName"].ToString(), (Int32)reader["livello"]));
                            }
                            return lista;
                        }

                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Partita> RicercaPartitaPerData(DateTime data)
        {
            try
            {
                Console.WriteLine("ricerca per data");
                List<Partita> lista = new List<Partita>();
                using (SqlConnection conn = new SqlConnection(ConnectionData.CONN_STRING))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(RESEARCH, conn))
                    //using (SqlCommand cmd = new SqlCommand(RESEARCH + id, conn))
                    {
                        cmd.Parameters.AddWithValue("@data", data);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("ricerca per data2");

                            while (reader.Read())
                            {
                                Console.WriteLine("ricerca per dataaaaaa");

                                //for (int i = 0;i<reader.FieldCount;i++)
                                //{
                                //    Console.Write("campo " + i + " " + reader[i]+ reader.GetName(i)+" ");


                                //}
                                //Console.WriteLine();
                                //Console.WriteLine(reader["partitaid"]);

                                lista.Add(new Partita((Int32)reader["PartitaId"], reader["Tipo"].ToString(), (DateTime)reader["Giorno"], reader["OrarioFine"].ToString(), reader["Risultato"].ToString(), (Int32)reader["NumeroCampo"]));
                            
                            }
                            return lista;
                        }

                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public decimal RicercaLivelloPerEta(int anni)
        {
            try
            {
                
                using (SqlConnection conn = new SqlConnection(ConnectionData.CONN_STRING))
                {
                    SqlCommand cmd = new SqlCommand(RESEARCH_LEVEL_AVG, conn);
                    cmd.Parameters.AddWithValue("@anni", anni);

                    try
                    {
                        conn.Open();
                        decimal result = (decimal)cmd.ExecuteScalar();
                        cmd.Dispose();
                        return result;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return 0;
                    }                    

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        //public override string ToString()
        //{
        //    StringBuilder builder = new StringBuilder();
        //    List<Partita> elenco = RicercaPartitaPerData();
        //    for (int i = 0; i < elenco.Count; i++)
        //    {
        //        builder.Append(elenco[i]).Append(Environment.NewLine);

        //    }
        //    return builder.ToString();

        //}

    }
}
