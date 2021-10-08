using System.Collections.Generic;
using GestionaleLibrary.Model;

namespace GestionaleAPI.Context
{
    public interface IClienteContext
    {
        Cliente GetCliente(int idCliente);
        IEnumerable<Cliente> GetAllCliente();
        IEnumerable<Cliente> GetCliente(string search);
        Cliente UpdateCliente(Cliente cliente);
        bool DeleteCliente(int idCliente);
        Cliente NewCliente(Cliente cliente);
    }
}