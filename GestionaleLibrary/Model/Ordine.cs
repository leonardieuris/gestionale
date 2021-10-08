using System;

namespace GestionaleLibrary.Model
{
    public class Ordine
    {
        public int IdOrdine { get; set; }
        public DateTime DataOrdine { get; set; }
        public int IdProdotto { get; set; }
        public int IdCliente { get; set; }
        public string IndirizzoSpedizione { get; set; }
        public bool Attivo { get; set; }
    }
}
