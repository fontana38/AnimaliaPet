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
    
    public partial class UsuarioRoles
    {
        public System.Guid IdUsuarioRoles { get; set; }
        public Nullable<System.Guid> IdUsuario { get; set; }
        public Nullable<System.Guid> IdRol { get; set; }
    
        public virtual Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
