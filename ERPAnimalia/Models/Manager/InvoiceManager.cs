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

        public List<InvoiceModel> GetInvoice(DateTime? dateFrom,DateTime? dateTo, string idClient)
        {
            if (dateFrom == null && dateTo == null && idClient == null)
            {
                dateFrom = DateTime.Now.Date;
                dateTo = DateTime.Now.Date.AddDays(7);
            }
               
            var invoice = db.GetInvoice(dateFrom, dateTo, idClient).ToList();
            var listInvoice = MapperObject.CreateListInvoiceModel(invoice);


            return listInvoice;
        }

    }
}