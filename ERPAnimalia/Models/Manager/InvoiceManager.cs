using ERPAnimalia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPAnimalia.Models.Manager
{


    public class InvoiceManager
    {
        public static AnimaliaPetShopEntities db { get; set; }

        public InvoiceManager()
        {
            db = Factory.Factory.CreateContextDataBase();
        }

        public  List<InvoiceModel> GetInvoice(DateTime? dateFrom,DateTime? dateTo, string idClient)
        {

            if (dateFrom == null && dateTo == null && idClient == null)
            {
                dateFrom = DateTime.Now.AddDays(-7);
                dateTo = DateTime.Now.Date;
            }
               
            var invoice = db.GetInvoice3(dateFrom, dateTo, idClient).ToList();
            var listInvoice = MapperObject.CreateListInvoiceModel(invoice);


              return  listInvoice;
        }


        public List<InvoiceDetailModel> GetDetailInvoice(Guid? IdComprobante)
        {

            var invoiceDetalle = db.GetInvoiceDetail(IdComprobante).ToList();
            var listInvoice = MapperObject.CreateListDetailInvoiceModel(invoiceDetalle);


            return listInvoice;
        }
        

    }
}