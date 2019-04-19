using ERPAnimalia.Models;
using ERPAnimalia.Models.Manager;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPAnimalia.Controllers
{
    [RoutePrefix("Producto")]
    public class ProductController : Controller
    {
        public ProductManager ProductManagers { get; set; }
        public SucursalManager SucursalManager { get; set; }


        public ProductController()
        {
            ProductManagers = Factory.Factory.CreateProducManager();
            SucursalManager = Factory.SucursalFactory.CreateSucursalManager();        
        }


      
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Product/Create
        public ActionResult Create(ProductModels product)
        {
            try
            {
                product.Category = ProductManagers.GetCategory();
                product.SubCategory = ProductManagers.GetSubCategory();
                product.TamanoMascotaList = ProductManagers.GetTamañoMascota();
                

                ModelState.Remove("RentabilidadPesos");
                ModelState.Remove("Rentabilidad");
                ModelState.Remove("Codigo");
                ModelState.Remove("Descripcion1");
                ModelState.Remove("Cantidad");
                ModelState.Remove("IdCategory");
                ModelState.Remove("IdTamanoMascota");
                ModelState.Remove("marca");
                ModelState.Remove("precioCosto");
                ModelState.Remove("precioVenta");

                return View("Add", product);
            }
            catch (Exception)
            {
                return View();
            }
               
            
        }


        public ActionResult SaveProduct(ProductModels product)
        {
            ModelState.Remove("RentabilidadPesos");
            ModelState.Remove("IdSubCategory");
            if (product.IdCategory == 0 || product.IdSubCategory == 0 || product.IdTamanoMascota ==0)
            {
                ModelState.AddModelError(string.Empty, "La categoria ,subcategoria  y tamaño deben ser seleccionadas");
            }
            if (ModelState.IsValid)
            {               
                ProductManagers.SaveProduct(product);
                product.Category = ProductManagers.GetCategory();
                product.SubCategory = ProductManagers.GetSubCategory();
                product.TamanoMascotaList = ProductManagers.GetTamañoMascota();
                return RedirectToAction("Index", "ListProduct");

            }
            product.Category = ProductManagers.GetCategory();
            product.SubCategory = ProductManagers.GetSubCategory();
            product.TamanoMascotaList = ProductManagers.GetTamañoMascota();

            return View("Add", product);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit( Guid ids)
        {
           
           var productEdit = ProductManagers.GetProductById(ids);
            productEdit.Category = ProductManagers.GetCategory();
            productEdit.SubCategory = ProductManagers.GetSubCategory();
            productEdit.TamanoMascotaList = ProductManagers.GetTamañoMascota();
            return View(productEdit);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid? id, ProductModels product)
        {
            try
            {
                ModelState.Remove("IdCategory");
                ModelState.Remove("Rentabilidad");
               

                if (product.IdCategory == 0 || product.IdSubCategory == 0 || product.IdTamanoMascota == 0)
                {
                    ModelState.AddModelError(string.Empty, "La categoria , subcategoria y tamaño deben ser seleccionadas");
                    product.Category = ProductManagers.GetCategory();
                    product.SubCategory = ProductManagers.GetSubCategory();
                    product.TamanoMascotaList = ProductManagers.GetTamañoMascota();

                    return View(product);
                }

                if (ModelState.IsValid)
                {
                    ProductManagers.EditProduct(product);
                    product.Category = ProductManagers.GetCategory();
                    product.SubCategory = ProductManagers.GetSubCategory();
                    product.TamanoMascotaList = ProductManagers.GetTamañoMascota();


                    return RedirectToAction("Index", "ListProduct");
                }
                product.Category = ProductManagers.GetCategory();
                product.SubCategory = ProductManagers.GetSubCategory();

                return View(product);

            }
            catch
            {
                return View(product);
            }
        }



        // GET: Product/Delete/5
        public ActionResult Delete(Guid id)
        {
            ProductManagers.Delete(id);
            return RedirectToAction("Index", "ListProduct");
        }

      
        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
