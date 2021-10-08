using System.Collections.Generic;
using System.Web.Configuration;
using GestionaleLibrary.Model;
using GestionaleLibrary.Repository;

namespace GestionaleAPI.Context
{
    public class OrdiniContext : IOrdiniContext
    {
        private readonly IOrdini _ordini;
        public OrdiniContext()
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
            _ordini = new Ordini(connectionString);
        }

        public Ordine GetOrdine(int idOrdine)
        {
            return _ordini.GetOrdine(idOrdine);
        }

        public IEnumerable<Ordine> GetAllOrdine()
        {
            return _ordini.GetAllOrdine();
        }

        public IEnumerable<Ordine> GetOrdineByIdCliente(int idCliente)
        {
            return _ordini.GetOrdineByIdCliente(idCliente);
        }

        public IEnumerable<Ordine> GetOrdineByIdProdotto(int idProdotto)
        {
            return _ordini.GetOrdineByIdProdotto(idProdotto);
        }

        public Ordine UpdateOrdine(Ordine Ordine)
        {
            return _ordini.UpdateOrdine(Ordine);
        }

        public bool DeleteOrdine(int idOrdine)
        {
            return _ordini.DeleteOrdine(idOrdine);
        }

        public Ordine NewOrdine(Ordine Ordine)
        {
            return _ordini.NewOrdine(Ordine);
        }
    }
}