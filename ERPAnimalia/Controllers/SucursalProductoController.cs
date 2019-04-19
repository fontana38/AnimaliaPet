using ERPAnimalia.Models;
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

        
        public SucursalManager SucursalManager { get; set; }
        public ProductManager ProductManagers { get; set; }
        public SucursalProductoManager SucursalProductoManagers { get; set; }


        public SucursalProductoController()
        {
            SucursalManager = Factory.SucursalFactory.CreateSucursalManager();
            ProductManagers = Factory.Factory.CreateProducManager();
            
        }
        // GET: SucursalProducto
        public ActionResult Index(Guid? id)
        {
            SucursalProductoModel sucursalProductoModel = new SucursalProductoModel();
            //Load Sucursal
            var SucursalList = SucursalManager.GetSucursal();

            if (id != null)
            {
                sucursalProductoModel.Product = ProductManagers.GetProductById(id.Value);
            }

            //crear el modelo sucursal y 

            //var sucProductoModel= SucursalProductoManagers.GetSucursalProducto(id,)



            //sucursalProductoModel.ListSucModel = sucursal;

            return View("/views/ListProduct/SucursalProducto.cshtml");
        }

        public ActionResult Delete(Guid id)
        {
            ProductManagers.Delete(id);
            return RedirectToAction("Index", "ListProduct");
        }

    }
}