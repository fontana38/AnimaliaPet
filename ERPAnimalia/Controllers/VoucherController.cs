﻿using ERPAnimalia.Interfaces;
using ERPAnimalia.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPAnimalia.Controllers
{

    [RoutePrefix("Factura")]
    public class VoucherController : Controller
    {
        public IVoucherHeadManager HeadVoucherManager { get; set; }
        public IVoucherDetailManager VoucherDetailManager { get; set; }
        public VoucherDetailModel voucherDetailModel;
        public List<DetailGrid> Listproduct;
        private List<Guid> idProducts = new List<Guid>();

        public VoucherController()
        {
            HeadVoucherManager = Factory.VoucherFactory.CreateVoucherHeadManager();
            VoucherDetailManager = Factory.VoucherFactory.CreateVoucherDetailManager();         
        }
    // GET: Voucher
    public ActionResult Index()
        {
            return View();
        }

        // GET: Voucher
        [Route("CrearFactura")]
        [HttpGet]
        public ActionResult HeadVoucher(string ids)
        {
            string method =Request.HttpMethod;
           
           if (!String.IsNullOrEmpty(ids))
            {
              string[] productList = ids.Split(',');

                for (int i = 0; i < productList.Count(); i++)
                {
                    var id = new Guid(productList[i]);
                    idProducts.Add(id);
                }
                
            }
           
           var voucherModel =Factory.VoucherFactory.CreateVoucherHeadModel();
           voucherDetailModel = Factory.VoucherFactory.CreateVoucherDetailModel();

            TempData["idProducts"] = idProducts;

            ViewData["listTipoComprobante"] = VoucherDetailManager.GetTipoComprobante();
            ViewData["listFormaPAgo"] = VoucherDetailManager.GetFormaDePago();


            return View("~/Views/Voucher/Voucher.cshtml");
        }

        // GET: Voucher
        [HttpPost]
        public JsonResult GetClient(string term)
        {
            
            var voucherModel = Factory.VoucherFactory.CreateVoucherHeadModel();
            var listClient = HeadVoucherManager.GetClient();
            voucherModel.ClientModel = listClient;

            var clientName = (from N in listClient
                              where  (N.Nombre !=null && N.Nombre.ToUpper().StartsWith(term.ToUpper()) ||N.Nombre!=null && N.Nombre.ToUpper().EndsWith(term.ToUpper()) )|| ( N.Apellido != null && N.Apellido.ToUpper().StartsWith(term.ToUpper()) || N.Apellido!=null && N.Apellido.ToUpper().EndsWith(term.ToUpper()))
                              select new {N.NombreCompleto,N.Direccion,N.Telefono }).ToList();

            return Json(clientName, JsonRequestBehavior.AllowGet);

           
        }

        // GET: Voucher
        [HttpPost]
        public JsonResult GetClientSelect(string term)
        {

            var voucherModel = Factory.VoucherFactory.CreateVoucherHeadModel();
            var listClient = HeadVoucherManager.GetClient();
            voucherModel.ClientModel = listClient;


            var clientName = (from N in listClient
                              where ((N.Apellido.ToLower().StartsWith(term.ToUpper()) || N.Apellido.ToLower().EndsWith(term.ToUpper()))||(N.Nombre.ToLower().StartsWith(term.ToUpper()) || N.Nombre.ToLower().EndsWith(term.ToUpper())))
                              select new { N.NombreCompleto, N.Direccion, N.Telefono }).ToList();
           
            return Json(clientName, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult GetProduct(string term)
        {

            voucherDetailModel = Factory.VoucherFactory.CreateVoucherDetailModel();
            var listProduct = VoucherDetailManager.GetProduct(term);
                 
             var Descripcion1 = (from N in listProduct
                              select new { N.Codigo,N.Descripcion1,N.Marca, N.kg, N.SubCategoryName,N.IdProducto }).ToList();
  
            return Json(Descripcion1, JsonRequestBehavior.AllowGet);


        }

       

        [HttpGet]
        public JsonResult GetProductDetail(int? page, int? limit, string term, Guid? idProducto, decimal cantidad = 0, decimal descuento = 0)
        {

            var detailGridTemp = TempData["DetailGrid"] as List<DetailGrid>;
            var detailGridList = new List<DetailGrid>();
            int total;
            var isDelete = TempData["isDelete"] as string;
            
            if (String.IsNullOrEmpty(term) || isDelete=="true")
            {
                term = string.Empty;
                TempData["isDelete"] = "false";
            }

                voucherDetailModel = Factory.VoucherFactory.CreateVoucherDetailModel();
                var listProduct = VoucherDetailManager.GetProduct();
                voucherDetailModel.ProductModel = listProduct;

            if ( TempData["idProducts"] !=null)
            {
                idProducts = TempData["idProducts"] as List<Guid>;

                foreach (var itemProduct in idProducts)
                {
                    detailGridTemp = AgregarProductosGrilla(detailGridTemp, detailGridList, listProduct, term, itemProduct, cantidad, descuento);
                }

                TempData["idProducts"] = null;
            }

            else
            {
                if (!String.IsNullOrEmpty(term))
                {
                    detailGridTemp = AgregarProductosGrilla(detailGridTemp, detailGridList, listProduct, term, idProducto, cantidad, descuento);
                }
            }

            TempData["DetailGrid"] = (detailGridTemp != null) ?  detailGridTemp : detailGridList;

            var records= (detailGridTemp!=null) ? detailGridTemp: detailGridList;
           
            total = (detailGridTemp != null) ? detailGridTemp.Count() : detailGridList.Count();


            return Json(new { records, total }, JsonRequestBehavior.AllowGet);

        }

        private List<DetailGrid> AgregarProductosGrilla(List<DetailGrid> detailGridTemp, List<DetailGrid> detailGridList, List<ProductModels> listProduct, string term, Guid? idProducto, decimal cantidad = 0, decimal descuento = 0)
        {
            var Descripcion1 = (from N in listProduct
                                where (N.IdProducto == idProducto)
                                select new { N }).ToList();

            var detailGrid = new DetailGrid();

            if (listProduct.Count != 0 && term != string.Empty || idProducto != null)
            {
                if (Descripcion1.Count > 0)
                {
                    detailGrid.IdProduct = Descripcion1[0].N.IdProducto;
                    detailGrid.Codigo = Descripcion1[0].N.Codigo;
                    detailGrid.Descripcion1 = Descripcion1[0].N.Descripcion1;
                    detailGrid.PrecioVenta = Descripcion1[0].N.PrecioVenta;
                    detailGrid.PrecioCosto = Descripcion1[0].N.PrecioCosto;
                    detailGrid.CategoryItem = Descripcion1[0].N.CategoryItem.IdCategory;
                    detailGrid.SubCategoryItem = Descripcion1[0].N.SubCategoryItem.IdSubCategory;
                    detailGrid.Category = Descripcion1[0].N.CategoryItem.Name;
                    detailGrid.SubCategory = Descripcion1[0].N.SubCategoryItem.Name;
                    detailGrid.Marca = Descripcion1[0].N.Marca;
                    detailGrid.kg = Descripcion1[0].N.kg;
                }


                detailGrid = VoucherDetailManager.SetValuesNewRowTable(detailGrid, cantidad, descuento);
            }

            if (detailGridTemp != null)
            {
                var newRowExist = detailGridTemp.Find(x => x.IdProduct == detailGrid.IdProduct);

                if (newRowExist == null)
                {
                    detailGridTemp.Add(detailGrid);

                }
            }
            else if (!String.IsNullOrEmpty(term)|| listProduct.Count > 0)
            {
                detailGridTemp = new List<DetailGrid>();
                detailGridTemp.Add(detailGrid);
            }

            if (detailGridTemp != null)
            {
                TempData["DetailGrid"] = detailGridTemp;
            }

            if (detailGridTemp != null)
            {
                detailGridTemp.Last().Total = 0;
                var totalRow = new decimal();
                foreach (var item in detailGridTemp)
                {
                    totalRow += Convert.ToDecimal(item.Subtotal);
                }

                detailGridTemp.Last().Total = Decimal.Round(totalRow, 2);
            }
            return detailGridTemp;


        }


    
    [HttpGet]
        public JsonResult GetSubtotal(Guid? idProduct, decimal cantidad = 0, decimal descuento = 0)
        {
            var detailGridTemp = TempData["DetailGrid"] as List<DetailGrid>;
            var records = new List<DetailGrid>();
            decimal total = 0;
            if (detailGridTemp != null)
            {
                DetailGrid product = detailGridTemp.Find(x => x.IdProduct == idProduct);
                product.Cantidad = cantidad;
                product.Descuento = descuento;
                if(product.SubCategoryItem ==1)
                {
                    if( cantidad < 1)
                    {
                        cantidad = cantidad * 1000;
                        product.Subtotal = ((product.PrecioVenta * ( cantidad/1000)) - descuento).ToString("F");
                    }
                    else
                    {
                        product.Subtotal = ((product.PrecioVenta * cantidad) - descuento).ToString("F");
                    }
                }
                else
                {
                    product.Subtotal = ((product.PrecioVenta * cantidad) - descuento).ToString("F");
                }
               
                product.Total = CalculateTotal(detailGridTemp);
                product.Porcentage = VoucherDetailManager.CalculateDiscountPorcentage(product, descuento);
                product.Porcentage = Math.Round(product.Porcentage, 2);
                TempData["DetailGrid"] = detailGridTemp;
                records = detailGridTemp;
                total = detailGridTemp.Count;
            }

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        private decimal CalculateTotal(List<DetailGrid> detailGridTemp)
        {
            foreach (var item in detailGridTemp)
            {
                item.Total += Convert.ToDecimal(item.Subtotal);
               
            }
            return detailGridTemp.Last().Total;

        }
            
          
           

        [HttpPost]
        public JsonResult Save(string cliente,string date, int comprobante,int formaDePago, string notes)
        {
            var detailGridTemp = TempData["DetailGrid"] as List<DetailGrid>;

            var listClient = HeadVoucherManager.GetClient();

            var idClient = listClient.Find(x => x.NombreCompleto == cliente).IdCliente;
            var voucherHeadModel =Factory.VoucherFactory.CreateVoucherHeadModel();
            voucherHeadModel.IdformaDePago = formaDePago;
            voucherHeadModel.IdtipoComprobante = comprobante;
            voucherHeadModel.Fecha = DateTime.Parse(date).Date;
            voucherHeadModel.IdCliente = idClient;
            voucherHeadModel.comentario = notes;

            var IsSave =VoucherDetailManager.SaveVoucher(detailGridTemp,voucherHeadModel);
            var message = string.Empty;
            if (IsSave)
            {
                TempData["DetailGrid"] = null;
                message = "El comprobante fue guardado";
            }
            else
            {
                message = "El stock es insuficiente";
                message =string.Concat(message,VoucherDetailManager.errorStock);
                TempData["DetailGrid"] = detailGridTemp;
            }
            
            return Json(message);
        }

        [HttpPost]
        public JsonResult Delete(Guid idProduct)
        {
            string count = string.Empty; 
            TempData["isDelete"] = "true";
            var detailGridTemp = TempData["DetailGrid"] as List<DetailGrid>;

            if(detailGridTemp !=null)
            {
                var product = detailGridTemp.Find(x => x.IdProduct == idProduct);
                detailGridTemp.Remove(product);
                TempData["DetailGrid"] = detailGridTemp;
               count= detailGridTemp.Count().ToString();
            }
           
            return Json(count);
        }


        [HttpPost]
        public JsonResult RemoveData()
        {
            try
            {
                TempData["DetailGrid"] =null;
                return Json(true);
            }
            catch (Exception)
            {

                return Json(false);
            }
        }



        }
}