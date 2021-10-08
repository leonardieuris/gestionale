using System.Collections.Generic;
using Library.Model;

namespace Library.Repository
{
    public interface IProdotti
    {
        Prodotto GetProdotto(int idProdotto);
        IEnumerable<Prodotto> GetAllProdotto();
        IEnumerable<Prodotto> GetProdotto(string search);
        Prodotto UpdateProdotto(Prodotto prodotto);
        bool DeleteProdotto(int idProdotto);
        Prodotto NewProdotto(Prodotto prodotto);
    }
}