
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
    
public partial class FormaDePago
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public FormaDePago()
    {

        this.Comprobante = new HashSet<Comprobante>();

    }


    public string Descripcion { get; set; }

    public int IdFormaDePago { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Comprobante> Comprobante { get; set; }

}

}
