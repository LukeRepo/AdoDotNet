using System;
using System.Collections.Generic;
using System.Text;

namespace GestionalePartite
{
    class Iscrizione
    {
        private int GiocatoreId { get; set; }
        private int PartitaId { get; set; }

        public Iscrizione(int gId, int pId)
        {
            GiocatoreId = gId;
            PartitaId = pId;
            
        }
    }
}
