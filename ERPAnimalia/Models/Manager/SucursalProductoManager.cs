using ERPAnimalia.EntityFramework;
using ERPAnimalia.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPAnimalia.Models.Manager
{
    public class SucursalProductoManager
    {
        public AnimaliaPetShopEntities db { get; set; }

        public  SucursalProductoManager()
        {
            db = Factory.Factory.CreateContextDataBase();

        }
        
        public SucursalProductoModel GetSucursalProducto(Guid idProducto, int IdSucursal)
        {
            var sucursalProducto = db.SucProducto.Where(x => x.IdSucursal == IdSucursal && x.IdProducto == idProducto).First();
            return SucursalProductoMapeo.GetSucursalProductoModel(sucursalProducto);
        }

        public List<SucursalProductoModel> GetProductoxSucursal(int IdSucursal)
        {
            var sucursalProducto = db.SucProducto.Where(x => x.IdSucursal == IdSucursal ).ToList();
            return SucursalProductoMapeo.GetSucursalProductoModelList(sucursalProducto);
        }


    }
}