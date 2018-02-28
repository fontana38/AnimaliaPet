using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPAnimalia.Models
{
    public class VentaDiariaMesModel
    {
        public decimal? Dia { get; set; }
        public decimal? Mes { get; set; }
        public string DescripcionDia { get; set; }
        public string DescripcionMes { get; set; }
        public decimal? TotalDia { get; set; }
        public decimal? TotalMes { get; set; }
    }
}