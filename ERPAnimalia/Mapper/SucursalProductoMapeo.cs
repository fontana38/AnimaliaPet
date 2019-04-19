using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPAnimalia.Mapper
{
    using ERPAnimalia.EntityFramework;
    using ERPAnimalia.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ERPAnimalia.Factory;
    using AutoMapper;
    using ERPAnimalia.Mapper;

    public class SucursalProductoMapeo
    {
        public static SucursalProductoModel GetSucursalProductoModel(SucProducto sucProducto)
        {
            try
            {
                SucursalProductoModel sucursalProductoModel;

                var mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();

                sucursalProductoModel = mapper.Map<SucursalProductoModel>(sucProducto);
                    
                return sucursalProductoModel;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }

        }

        public static List<SucursalProductoModel> GetSucursalProductoModelList(List<SucProducto> sucProducto)
        {
            try
            {
                
                List<SucursalProductoModel> sucProductoModel=new List<SucursalProductoModel>();

                var mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();

                foreach (var item in sucProducto)
                {
                    var suc = mapper.Map<SucursalProductoModel>(item);
                    sucProductoModel.Add(suc);
                }

                return sucProductoModel;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }

        }
    }
}