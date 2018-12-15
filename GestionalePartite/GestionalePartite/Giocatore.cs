using System;
using System.Collections.Generic;
using System.Text;

namespace GestionalePartite
{
    public class Giocatore
    {
        private int GiocatoreId { get; set;  }
        private String Nome { get; set; }
        private String Cognome { get; set; }
        private DateTime DataNascita { get; set; }
        private String NickName { get; set; }
        private int Livello { get; set; }

        public Giocatore(int id, string nome, string cognome, DateTime dataNascita, string nickName, int livello)
        {
            GiocatoreId = id;
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            NickName = nickName;
            Livello = livello;
        }

        public int getGiocatoreId()
        {
            return GiocatoreId;
        }
        public string getNome()
        {
            return Nome;
        }

        public string getCognome()
        {
            return Cognome;
        }
        public DateTime getDataNascita()
        {
            return DataNascita;
        }
        public string getNickName()
        {
            return NickName;
        }
        public int getLivello()
        {
            return Livello;
        }

    }
}
