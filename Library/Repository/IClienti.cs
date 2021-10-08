using System.Collections.Generic;
using Library.Model;

namespace Library.Repository
{
    public interface IClienti
    {
        Cliente GetCliente(int idCliente);
        IEnumerable<Cliente> GetAllCliente();
        IEnumerable<Cliente> GetCliente(string search);
        Cliente UpdateCliente(Cliente cliente);
        bool DeleteCliente(int idCliente);
        Cliente NewCliente(Cliente cliente);
    }
}
