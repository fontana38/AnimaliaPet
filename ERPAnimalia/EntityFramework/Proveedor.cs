
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
    
public partial class Proveedor
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Proveedor()
    {

        this.IdProveedorProducto = new HashSet<IdProveedorProducto>();

        this.Comprobante = new HashSet<Comprobante>();

    }


    public System.Guid IdProveedor { get; set; }

    public string RazonSocial { get; set; }

    public string Direccion { get; set; }

    public string Telefono { get; set; }

    public string Mail { get; set; }

    public string Codigo { get; set; }

    public string Apellido { get; set; }

    public Nullable<System.DateTime> Fecha { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<IdProveedorProducto> IdProveedorProducto { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Comprobante> Comprobante { get; set; }

}

}
