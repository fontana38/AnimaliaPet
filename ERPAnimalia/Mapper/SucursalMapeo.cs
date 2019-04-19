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

    public class SucursalMapeo
    {

        public static List<SucursalModel> GetSucursalModel (List<Sucursal> sucursal)
        {
            try
            {
                List<SucursalModel> sucursalModelList = new List<SucursalModel>();
                var mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();

                foreach (var item in sucursal)
                {
                    var sucursalModel = mapper.Map<SucursalModel>(item);
                    sucursalModelList.Add(sucursalModel);
                }
             
                return sucursalModelList;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }

        }
    }
}