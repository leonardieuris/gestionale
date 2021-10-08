using System;
using System.Collections.Generic;
using GestionaleLibrary.Model;

namespace GestionaleAPI.Context
{
    public interface IOrdiniContext
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