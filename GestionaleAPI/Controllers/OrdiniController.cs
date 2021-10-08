using System.Collections.Generic;
using System.Web.Http;
using GestionaleAPI.Context;
using GestionaleLibrary.Model;

namespace GestionaleAPI.Controllers
{
    public class OrdiniController : ApiController
    {
        private readonly IOrdiniContext Ordini;

        public OrdiniController()
        {
            Ordini = new OrdiniContext();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("api/Ordine")]
        public IEnumerable<Ordine> Get()
        {
            return Ordini.GetAllOrdine();
        }


        [HttpGet]
        [Route("api/Clienti/OrdineByIdCliente/IdCliente")]
        public IEnumerable<Ordine> GetByIdCliente(int idCliente)
        {
            return Ordini.GetOrdineByIdCliente(idCliente);
        }

        [HttpGet]
        [Route("api/Clienti/OrdineByIdProdotto/IdProdotto")]
        public IEnumerable<Ordine> GetByIdProdotto(int idProdotto)
        {
            return Ordini.GetOrdineByIdProdotto(idProdotto);
        }


        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Ordine/id")]
        public Ordine Get(int id)
        {
            return Ordini.GetOrdine(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/Ordine")]
        public Ordine Post([FromBody]Ordine ordine)
        {
            return Ordini.NewOrdine(ordine);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Ordine/{id}")]
        public Ordine Put(int id, [FromBody]Ordine ordine)
        {
            return Ordini.UpdateOrdine(ordine);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/Ordine/{id}")]
        public bool Delete(int id)
        {
            return Ordini.DeleteOrdine(id);
        }



    }
}