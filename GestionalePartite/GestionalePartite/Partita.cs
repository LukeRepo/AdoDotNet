using System;
using System.Collections.Generic;
using System.Text;

namespace GestionalePartite
{
    public class Partita
    {
        private int PartitaId { get; set; }
        private String Tipo { get; set; }
        private DateTime Giorno { get; set; }
        private String OrarioFine { get; set; }
        private String Risultato { get; set; }
        private int NumeroCampo { get; set; }

        private List<Giocatore> partecipanti;

        public void InserisciPartecipanti(Giocatore g)
        {
            partecipanti.Add(g);
        }

        public Partita(int id, string tipo, DateTime giorno, string orarioFine, string risultato, int numeroCampo)
        {
            PartitaId = id;
            Tipo = tipo;
            Giorno = giorno;
            OrarioFine = orarioFine;
            Risultato = risultato;
            NumeroCampo = numeroCampo;
            partecipanti = new List<Giocatore>();
        }

        public int getPartitaId()
        {
            return this.PartitaId;
        }        
        public String getTipo()
        {
            return Tipo;
        }
        public DateTime getGiorno()
        {
            return Giorno;
        }
        public String getOrario()
        {
            return OrarioFine;
        }
        public String getRisultato()
        {
            return Risultato;
        }
        public int getNumeroCampo()
        {
            return this.NumeroCampo;
        }



        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Partita ID: " + getPartitaId());
            builder.Append(Environment.NewLine);
            builder.Append("Data partita: " + getGiorno());
            builder.Append(Environment.NewLine);
            builder.Append("Orario partita: " + getOrario());
            builder.Append(Environment.NewLine);
            builder.Append("Risultato: " + getRisultato());
            builder.Append(Environment.NewLine);
            builder.Append("Numero campo: " + getNumeroCampo());
            builder.Append(Environment.NewLine);

            builder.Append("Partecipanti: " );
            builder.Append(Environment.NewLine);
            for (int i = 0; i < partecipanti.Count; i++)
            {
                builder.Append(partecipanti[i]);
                builder.Append(Environment.NewLine);
                
            }

            return builder.ToString();

        }

    }
}
