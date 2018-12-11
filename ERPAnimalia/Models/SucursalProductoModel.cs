using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPAnimalia.Models
{
    public class SucursalProductoModel
    {
        public Guid IdSucursaProducto { get; set; }
        public ProductModels Product { get; set; }
        public SucursalModel Sucursal { get; set; }
    }
}