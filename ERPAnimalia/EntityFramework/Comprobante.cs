
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
    
public partial class Comprobante
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Comprobante()
    {

        this.DetalleComprobante = new HashSet<DetalleComprobante>();

    }


    public Nullable<System.DateTime> Fecha { get; set; }

    public System.Guid IdComprobante { get; set; }

    public string Numero { get; set; }

    public Nullable<int> IdFormaDePago { get; set; }

    public Nullable<int> IdTipoComprobante { get; set; }

    public Nullable<decimal> Total { get; set; }

    public byte[] Cobrada { get; set; }

    public Nullable<System.Guid> IdCliente { get; set; }

    public Nullable<System.Guid> IdProveedor { get; set; }

    public Nullable<System.DateTime> FechaPago { get; set; }

    public string Comentario { get; set; }



    public virtual Cliente Cliente { get; set; }

    public virtual Comprobante Comprobante1 { get; set; }

    public virtual Comprobante Comprobante2 { get; set; }

    public virtual FormaDePago FormaDePago { get; set; }

    public virtual Proveedor Proveedor { get; set; }

    public virtual TipoComprobante TipoComprobante { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DetalleComprobante> DetalleComprobante { get; set; }

}

}
