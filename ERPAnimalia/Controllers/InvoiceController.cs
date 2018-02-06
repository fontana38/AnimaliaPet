using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPAnimalia.Controllers
{
    [RoutePrefix("Invoice")]
    public class InvoiceController : Controller
    {
        // GET: Invoice
        [Route("ListaFactura")]
        public ActionResult ListInvoice()
        {
            return View("ListInvoice");
        }

        [HttpGet]
        public JsonResult GetInvoice(int? page, int? limit, string sortBy, string direction, DateTime? dateInvoiceFrom, DateTime? dateInvoiceTo, string idClient=null )
        {
            int total = 20;
            var manager = Factory.Factory.CreateInvoiceManager();
            
            var records = manager.GetInvoice(dateInvoiceFrom, dateInvoiceTo, idClient);

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }
    }
}