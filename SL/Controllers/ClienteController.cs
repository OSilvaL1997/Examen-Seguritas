using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente/5
        [HttpGet]
        [Route("api/Cliente/{IdCliente}")]
        public IHttpActionResult GetById(int IdCliente)
        {
            ENT.Cliente cliente = new ENT.Cliente();
            cliente.IdCliente = IdCliente;
            ENT.Result result = BLL.Cliente.GetById(cliente);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }   
        }
        [HttpPost]
        [Route("api/Cliente")]
        // POST: api/Cliente
        public IHttpActionResult Post([FromBody]ENT.Cliente cliente)
        {
            ENT.Result result = BLL.Cliente.AddEF(cliente);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // PUT: api/Cliente/5
        [HttpPut]
        [Route("api/Cliente/{IdCliente}")]
        public IHttpActionResult Put(int IdCliente, [FromBody]ENT.Cliente cliente)
        {
            cliente.IdCliente = IdCliente;
            ENT.Result result = BLL.Cliente.AddEF(cliente);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE: api/Cliente/5
        [HttpDelete]
        [Route("api/Cliente/{IdCliente}")]
        public IHttpActionResult Delete(int IdCliente)
        {
            ENT.Cliente cliente = new ENT.Cliente();
            cliente.IdCliente = IdCliente;
            ENT.Result result = BLL.Cliente.AddEF(cliente);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
