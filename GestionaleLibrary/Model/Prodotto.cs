namespace GestionaleLibrary.Model
{
    public class Prodotto
    {
        public int IdProdotto { get; set; }
        public string NomeProdotto { get; set; }
        public string Codice8 { get; set; }
        public string Categoria { get; set; }
        public int Qta { get; set; }
        public bool Attivo { get; set; }
    }
}
