
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
    
public partial class IdProveedorProducto
{

    public System.Guid IdProveedorIdproducto { get; set; }

    public Nullable<System.Guid> IdProveedor { get; set; }

    public Nullable<System.Guid> IdProducto { get; set; }



    public virtual Proveedor Proveedor { get; set; }

    public virtual Product Product { get; set; }

}

}
