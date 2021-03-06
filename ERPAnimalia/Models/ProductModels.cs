﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPAnimalia.Models
{
    public class ProductModels
    {
        public Guid IdProducto { get; set; }
        [Required(ErrorMessage = "Por favor Ingrese el Código")]
        [Display(Name = "Código")]
        public double Codigo { get; set; }

        [MaxLength(50)]

        [Required(ErrorMessage = "Por favor Ingrese la Marca")]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [MaxLength(50)]
        [Display(Name = "Presentacion")]
        public string Presentacion { get; set; }

        [Required(ErrorMessage = "Por favor Ingrese la Descripción1")]
        [MaxLength(50)]

        [Display(Name = "Descripción1")]
        public string Descripcion1 { get; set; }

        [MaxLength(50)]
        [Display(Name = "Código de Barra")]
        public string CodigoBarra { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Por favor Ingrese la Cantidad")]
        public decimal? Cantidad { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Ingrese Valor válido")]
        public decimal? RentabilidadPesos { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Ingrese Valor válido")]
        public decimal? Rentabilidad { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Ingrese Valor válido")]
        [Display(Name = "Precio Costo")]
        public decimal PrecioCosto { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Ingrese Valor válido")]
        [Display(Name = "Precio Venta")]
        public decimal PrecioVenta { get; set; }

        public decimal? TotalKg { get; set; }

        public decimal? CantidadAgregarSuelto { get; set; }

        public decimal? kg { get; set; }

        [Required(ErrorMessage = "Por favor Ingrese la Categoria")]

        public int IdCategory { get; set; }
       
        public int IdSubCategory { get; set; }

        public int IdTamanoMascota { get; set; }

        public List<CategoryModel> Category { get; set; }

        public List<TamanoMascotaModel> TamanoMascotaList { get; set; }

        public List<TipoAnimalModel> TipoAnimalList { get; set; }

        public SelectList CategorySelect { get; set; }

        [Display(Name = "Sub Categoria")]
        public List<SubCategoryModel> SubCategory { get; set; }

        [Display(Name = "Categoria")]
        public CategoryModel CategoryItem { get; set; }

        [Display(Name = "Sub Categoria")]
        public SubCategoryModel SubCategoryItem { get; set; }

        [Display(Name = "Tamaño")]
        public TamanoMascotaModel tamanoItem { get; set; }


        public string SubCategoryName { get; set; }

        public string tamanoName { get; set; }
        public string CategoryName { get; set; }

        public bool IsSelect { get; set; }
    }


}


    
