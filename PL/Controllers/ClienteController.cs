using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Clientes()
        {
            ENT.Cliente cliente = new ENT.Cliente();
            ENT.Result result = BLL.Cliente.GetAll();
            cliente.Clientes = new List<object>();
            if (result.Correct)
            {
                cliente.Clientes = result.Objects;
                return View(cliente);
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error fatal " + result.ErrorMessage;
                return PartialView("PView");
            }
        }
    }
}