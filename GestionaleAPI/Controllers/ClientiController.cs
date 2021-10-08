using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Http;
using GestionaleAPI.Context;
using GestionaleLibrary.Model;
using GestionaleLibrary.Repository;


namespace GestionaleAPI.Controllers
{

    public class ClientiController : ApiController
    {
        private readonly IClienteContext Clienti;

        public ClientiController()
        {
            Clienti = new ClienteContext();
        }

        // GET: api/Clienti
        [HttpGet]
        [Route("api/Clienti")]
        public IEnumerable<Cliente> Get()
        {
            return Clienti.GetAllCliente();
        }

        
        [HttpGet]
        [Route("api/Clienti/{search}")]
        public IEnumerable<Cliente> Get(string search)
        {
            return Clienti.GetCliente(search);
        }



        // GET: api/Clienti/5
        [HttpGet]
        [Route("api/Clienti/id")]
        public Cliente Get(int id)
        {
            return Clienti.GetCliente(id);
        }

        [HttpPost]
        // POST: api/Clienti
        [Route("api/Clienti/")]
        public Cliente Post(Cliente cliente)
        {
            return Clienti.NewCliente(cliente);
        }

        // PUT: api/Clienti/5
        [HttpPut]
        [Route("api/Clienti/{id}")]
        public Cliente Put(int id, [FromBody]Cliente cliente)
        {
            if(id!=cliente.IdCliente)
                throw new ArgumentException();
            return Clienti.UpdateCliente(cliente);
        }

        // DELETE: api/Clienti/5
        [HttpDelete]
        [Route("api/Clienti/{id}")]
        public bool Delete(int id)
        {
            return Clienti.DeleteCliente(id);
        }
    }
}
