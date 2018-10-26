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

        public  List<InvoiceModel> GetInvoice(DateTime? dateFrom,DateTime? dateTo, string idClient, string idTypeVoucher)
        {

            if (dateFrom == null && dateTo == null && idClient == null)
            {
                dateFrom = DateTime.Now.AddDays(-7);
                dateTo = DateTime.Now.Date;
            }

            var typeVocher = Convert.ToInt16(idTypeVoucher);
               
            var invoice = db.GetInvoice(dateFrom, dateTo,  typeVocher).ToList();
            var listInvoice = MapperObject.CreateListInvoiceModel(invoice);
 
              return  listInvoice;
        }


        public List<InvoiceDetailModel> GetDetailInvoice(Guid? IdComprobante)
        {

            var invoiceDetalle = db.GetInvoiceDetail(IdComprobante).ToList();
            var listInvoice = MapperObject.CreateListDetailInvoiceModel(invoiceDetalle);


            return listInvoice;
        }


        public List<TipoComprobantesModel> GetTypeInvoice()
        {

            var tipoComprobante = db.TipoComprobante.ToList();
            var listInvoice = MapperObject.tipoComprobante(tipoComprobante);

            return listInvoice;
        }


    }
}