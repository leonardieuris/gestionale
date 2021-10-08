using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using GestionaleLibrary.Model;
using GestionaleLibrary.Repository;

namespace GestionaleAPI.Context
{
    public class ProdottiContext : IProdottiContext
    {
        private IProdotti _prodotti;

        public ProdottiContext()
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
            _prodotti = new Prodotti(connectionString);
        }

        public Prodotto GetProdotto(int idProdotto)
        {
            return _prodotti.GetProdotto(idProdotto);
        }

        public IEnumerable<Prodotto> GetAllProdotto()
        {
            return _prodotti.GetAllProdotto();
        }

        public IEnumerable<Prodotto> GetProdotto(string search)
        {
            return _prodotti.GetProdotto(search);
        }

        public Prodotto UpdateProdotto(Prodotto prodotto)
        {
            return _prodotti.UpdateProdotto(prodotto);
        }

        public bool DeleteProdotto(int idProdotto)
        {
            return _prodotti.DeleteProdotto(idProdotto);
        }

        public Prodotto NewProdotto(Prodotto prodotto)
        {
            return _prodotti.NewProdotto(prodotto);
        }
    }
}