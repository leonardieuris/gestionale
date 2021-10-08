using System.Collections.Generic;
using Library.Model;

namespace Library.Repository
{
    public interface IOrdini
    {
        Ordine GetOrdine(int idOrdine);
        IEnumerable<Ordine> GetAllOrdine();
        IEnumerable<Ordine> GetOrdineByIdCliente(int idCliente);
        IEnumerable<Ordine> GetOrdineByIdProdotto(int idProdotto);
        Ordine UpdateOrdine(Ordine Ordine);
        bool DeleteOrdine(int idOrdine);
        Ordine NewOrdine(Ordine Ordine);
    }
}