using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionaleLibrary.Model;

namespace GestionaleAPI.Context
{
    public interface IProdottiContext
    {
        Prodotto GetProdotto(int idProdotto);
        IEnumerable<Prodotto> GetAllProdotto();
        IEnumerable<Prodotto> GetProdotto(string search);
        Prodotto UpdateProdotto(Prodotto prodotto);
        bool DeleteProdotto(int idProdotto);
        Prodotto NewProdotto(Prodotto prodotto);
    }
}