using System.Collections.Generic;
using System.Web.Http;
using GestionaleAPI.Context;
using GestionaleLibrary.Model;

namespace GestionaleAPI.Controllers
{
    public class ProdottoController : ApiController
    {
        private readonly IProdottiContext Prodotti;

        public ProdottoController()
        {
            Prodotti = new ProdottiContext();
        }

        /// <summary>
        /// Get All Prodotti
        /// </summary>
        /// <returns>Restituisce tutti i prodotti</returns>
        // GET api/<controller>
        [HttpGet]
        [Route("api/Prodotto")]
        public IEnumerable<Prodotto> Get()
        {
            return Prodotti.GetAllProdotto();
        }

        /// <summary>
        /// Get prodotto by id
        /// </summary>
        /// <param name="id">id del prodotto</param>
        /// <returns>restituisce il prodotto cercato</returns>
        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Prodotto/id")]
        public Prodotto Get(int id)
        {
            return Prodotti.GetProdotto(id);
        }

        /// <summary>
        /// inserisce un nuovo prodotto
        /// </summary>
        /// <param name="prodotto">prodotto</param>
        /// <returns>restituisce il prodotto appena inserito</returns>
        // POST api/<controller>
        [HttpPost]
        [Route("api/Prodotto")]
        public Prodotto Post([FromBody]Prodotto prodotto)
        {
            return Prodotti.NewProdotto(prodotto);
        }

        /// <summary>
        /// aggiorna un prodotto
        /// </summary>
        /// <param name="id">id del prodotto</param>
        /// <param name="prodotto">prodotto da aggiornare</param>
        /// <returns>restituisce il prodotto appena aggiornato</returns>
        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Prodotto/{id}")]
        public Prodotto Put(int id, [FromBody]Prodotto prodotto)
        {
            return Prodotti.UpdateProdotto(prodotto);
        }


        /// <summary>
        /// Cancella il prodotto con l'id indicato
        /// </summary>
        /// <param name="id">id del prodotto da cancellare</param>
        /// <returns>restituisce un booleano per indicare se l'operazione è andata a buon fine</returns>
        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/Prodotto/{id}")]
        public bool Delete(int id)
        {
            return Prodotti.DeleteProdotto(id);
        }



    }
}