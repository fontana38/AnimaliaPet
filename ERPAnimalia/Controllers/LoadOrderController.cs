﻿using ERPAnimalia.Helper;
using ERPAnimalia.Models;
using ERPAnimalia.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPAnimalia.Controllers
{
    [RoutePrefix("Pedido")]
    public class LoadOrderController : Controller
    {
        public LoadOrderManager _LoadOrderManager { get; set; }
        public ProductManager ProductManagers { get; set; }

        public LoadOrderController()
        {
            _LoadOrderManager = Factory.LoadOrderFacory.CreateOrderManager();
            ProductManagers = Factory.Factory.CreateProducManager();
        }
        // GET: LoadOrder
        public ActionResult Index()
        {
            
            var LoadOrderModel = Factory.LoadOrderFacory.CreateVoucherHeadLoadOrder();
            

            ViewData["TipoComprobante"] = "Nota Pedido";
            ViewData["listFormaPago"] = Common.GetFormaPagoLoadOrder();

            return View();
        }
   
        [HttpPost]
        public JsonResult GetProveedor(string term)
        {
            var listProveedor = _LoadOrderManager.GetProveedor();
            var LoadOrderModel = Factory.LoadOrderFacory.CreateVoucherHeadLoadOrder();
            LoadOrderModel.ProveedorModel = listProveedor;


         
            var proveedorName = (from N in listProveedor
                                 where (N.RazonSocial.ToUpper().StartsWith(term.ToUpper()) || N.RazonSocial.ToUpper().EndsWith(term.ToUpper()))
                                 select new { N.RazonSocial }).ToList();

            return Json(proveedorName, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProduct(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            int total;


            var records = ProductManagers.GetProductList(page, limit, sortBy, direction, searchString, out total);
            records = ProductManagers.GetProducBugtList(records);
            foreach (var item in records)
            {
                item.PrecioCosto= Math.Round(item.PrecioCosto, 2);
                item.PrecioVenta=Math.Round(item.PrecioVenta, 2);
            }

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(string proveedor, string date, string fechaPago,int formaPago, Guid[] idProducto, string[]precioCosto,int[]cantidad, string[] precioVenta)
        {
            _LoadOrderManager.Save(proveedor, date, fechaPago, formaPago, precioCosto, cantidad, idProducto, precioVenta);
            return Json(true);
        }

    }
}