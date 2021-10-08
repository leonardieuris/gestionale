using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using GestionaleLibrary.Model;
using GestionaleLibrary.Repository;

namespace GestionaleAPI.Context
{
    public class ClienteContext : IClienteContext
    {
        private IClienti _clienti;

        public ClienteContext()
        {
            var ConnectionString = WebConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
            _clienti = new Clienti(ConnectionString);
        }

        public Cliente GetCliente(int idCliente)
        {
           return _clienti.GetCliente(idCliente);
        }

        public IEnumerable<Cliente> GetAllCliente()
        {
            return _clienti.GetAllCliente();
        }

        public IEnumerable<Cliente> GetCliente(string search)
        {
            return _clienti.GetCliente(search);
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            return _clienti.UpdateCliente(cliente);
        }

        public bool DeleteCliente(int idCliente)
        {
            return _clienti.DeleteCliente(idCliente);
        }

        public Cliente NewCliente(Cliente cliente)
        {
            return _clienti.NewCliente(cliente);
        }
    }
}