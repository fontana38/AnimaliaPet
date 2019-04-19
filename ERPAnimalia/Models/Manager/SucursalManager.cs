using ERPAnimalia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPAnimalia.Mapper;

namespace ERPAnimalia.Models.Manager
{
    public class SucursalManager
    {

        public static AnimaliaPetShopEntities db { get; set; }
        
        public List<Sucursal> SucursalMap;                  

        private static readonly Object obj = new Object();

        public SucursalManager()
        {

            db = Factory.Factory.CreateContextDataBase();

        }

        public List<SucursalModel> GetSucursal()
        {
            var sucursalModel = db.Sucursal.ToList();
            var map = SucursalMapeo.GetSucursalModel(sucursalModel);
            return map;
        }

    }
}