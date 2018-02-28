using ERPAnimalia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ERPAnimalia.Models.Manager
{
    public class HomeManager
    {
        public static AnimaliaPetShopEntities db { get; set; }

        public HomeManager()
        {
           
        }

        public async Task<List<VentaDiariaMesModel>>  GetVentasDiaria()
        {
            try
            {
                db = Factory.Factory.CreateContextDataBase();

                await Task.Delay(1000);

                var dia =  db.VentaDiariaMes().ToList();

                var vtaModel = Factory.ReportFactory.CreateListventaDiariaModel();

                foreach (var item in dia)
                {
                    var venta = Factory.ReportFactory.CreateventaDiariaModel();
                    venta.Dia = (item.dia != null) ? item.dia : 0;
                    venta.DescripcionDia = (item.Descripcion != null) ? item.Descripcion : string.Empty;

                    vtaModel.Add(venta);
                }

                int cant = dia.Count();

                if (cant > 0)
                {
                    vtaModel[cant - 1].TotalDia = 0;
                    foreach (var item in dia)
                    {
                        vtaModel[cant - 1].TotalDia += item.dia;
                    }
                }


                return vtaModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            // using Object Context (EF4.0)            
        
        }

        public async Task<List<VentaDiariaMesModel>> GetVentasMes()
        {
            try
            {
                db = Factory.Factory.CreateContextDataBase();
                var mes = db.VentaMes().ToList();

                var vtaModel = Factory.ReportFactory.CreateListventaDiariaModel();


                foreach (var item in mes)
                {
                    var venta = Factory.ReportFactory.CreateventaDiariaModel();
                    venta.Mes = (item.Mes != null) ? item.Mes : 0;
                    venta.DescripcionMes = (item.Descripcion != null) ? item.Descripcion : string.Empty;
                    vtaModel.Add(venta);
                }

                int cant = mes.Count();

                if (cant > 0)
                {
                    vtaModel[cant - 1].TotalMes = 0;
                    foreach (var item in mes)
                    {
                        vtaModel[cant - 1].TotalMes += item.Mes;
                    }
                }

                return vtaModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}