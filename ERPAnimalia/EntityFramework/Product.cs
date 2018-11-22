
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ERPAnimalia.EntityFramework
{

using System;
    using System.Collections.Generic;
    
public partial class Product
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Product()
    {

        this.IdClienteIdProducto = new HashSet<IdClienteIdProducto>();

        this.IdProveedorProducto = new HashSet<IdProveedorProducto>();

    }


    public Nullable<double> Codigo { get; set; }

    public string Marca { get; set; }

    public string Descripcion1 { get; set; }

    public Nullable<decimal> Cantidad { get; set; }

    public Nullable<decimal> Kg { get; set; }

    public System.Guid IdProducto { get; set; }

    public string CodigoBarra { get; set; }

    public Nullable<int> IdCategory { get; set; }

    public Nullable<int> IdSubCategory { get; set; }

    public string Descripcion2 { get; set; }

    public string Presentacion { get; set; }

    public Nullable<decimal> RentabilidadPesos { get; set; }

    public Nullable<decimal> Rentabilidad { get; set; }

    public Nullable<decimal> PrecioVenta { get; set; }

    public Nullable<decimal> PrecioCosto { get; set; }

    public Nullable<decimal> TotalKg { get; set; }

    public Nullable<int> IdTamanoMascota { get; set; }

    public Nullable<int> idTipoAnimal { get; set; }



    public virtual Category Category { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<IdClienteIdProducto> IdClienteIdProducto { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<IdProveedorProducto> IdProveedorProducto { get; set; }

    public virtual SubCategory SubCategory { get; set; }

}

}
