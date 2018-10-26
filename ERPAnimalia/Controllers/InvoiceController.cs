using ERPAnimalia.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPAnimalia.Models;

namespace ERPAnimalia.Controllers
{
    [RoutePrefix("Invoice")]
    public class InvoiceController : Controller
    {
        public InvoiceManager ManagerInvoice { get; set; }
        public List<TipoComprobantesModel> listInvoice { get; set; }

        public InvoiceController()
        {
            ManagerInvoice = Factory.Factory.CreateInvoiceManager();
            
        }
        // GET: Invoice
        [Route("ListaFactura")]
        public ActionResult ListInvoice()
        {
            InvoiceModel invoice = new InvoiceModel();
            listInvoice = ManagerInvoice.GetTypeInvoice();
            invoice.listTypeInvoice = listInvoice;
            return View("ListInvoice", invoice);
        }

        [HttpGet]
        public JsonResult GetInvoice(int? page, int? limit, string sortBy, string direction, string dateInvoiceFrom=null, string dateInvoiceTo=null, string idClient=null, string idTypeVoucher=null )
        {
            int total = 20;
            DateTime dateInvoice;
            DateTime dateInvoiceNew;
            List<InvoiceModel> records= new List<InvoiceModel>();

            if (!string.IsNullOrEmpty(dateInvoiceTo) && !string.IsNullOrEmpty(dateInvoiceFrom))
            {  
                dateInvoice =  DateTime.Parse(dateInvoiceTo).Date;
                dateInvoiceNew= DateTime.Parse(dateInvoiceFrom).Date;
                records = ManagerInvoice.GetInvoice(dateInvoiceNew, dateInvoice, idClient, idTypeVoucher);
            }
            else if (string.IsNullOrEmpty(dateInvoiceTo) && string.IsNullOrEmpty(dateInvoiceFrom))
            {
                dateInvoice = DateTime.Now.AddMonths(+1).Date;
                dateInvoiceNew = DateTime.Now.AddMonths(-1).Date;
                records = ManagerInvoice.GetInvoice(dateInvoiceNew, dateInvoice, idClient,idTypeVoucher);
            }


            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetDetailInvoice(Guid? IdComprobante, int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            int total = 20;


            var records = ManagerInvoice.GetDetailInvoice(IdComprobante);


            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }
       
    }
}