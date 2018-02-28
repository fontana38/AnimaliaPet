using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPAnimalia.Models
{
    public class InvoiceDetailModel
    {
        public int Cantidad { get; set; }
        public Decimal Subtotal { get; set; }
        public Decimal PrecioVenta { get; set; }
        public string  Producto { get; set; }
        public string Descripcion1 { get; set; }
        public Guid idDetalleComprobante { get; set; }
    }
}