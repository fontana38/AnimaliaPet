using ERPAnimalia.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPAnimalia.Controllers
{
    public class SucursalProductoController : Controller
    {

        public SucursalProductoManager sucursalProductoManagers { get; set; }
        // GET: SucursalProducto
        public ActionResult Index()
        {
           // var sucursal = sucursalProductoManagers.GetSucursal();
            return View();
        }
    }
}