using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPAnimalia.Models
{
    public class InvoiceModel
    {
        public string Cliente { get; set; }
        public Guid IdComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public string TipoComprobante { get; set; }
        public string FormaDePago { get; set; }
        public decimal Total { get; set; }
        public string Comentario { get; set; }
        public List<TipoComprobantesModel> listTypeInvoice { get; set; }

    }
}