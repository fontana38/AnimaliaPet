﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class AnimaliaPetShopEntities : DbContext
{
    public AnimaliaPetShopEntities()
        : base("name=AnimaliaPetShopEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<FormaDePago> FormaDePago { get; set; }

    public virtual DbSet<TipoComprobante> TipoComprobante { get; set; }

    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    public virtual DbSet<IdClienteIdProducto> IdClienteIdProducto { get; set; }

    public virtual DbSet<SubCategory> SubCategory { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetalleComprobante> DetalleComprobante { get; set; }

    public virtual DbSet<IdProveedorProducto> IdProveedorProducto { get; set; }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<Proveedor> Proveedor { get; set; }

    public virtual DbSet<Comprobante> Comprobante { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<UsuarioRoles> UsuarioRoles { get; set; }

    public virtual DbSet<TipoAnimal> TipoAnimal { get; set; }

    public virtual DbSet<TamanoMascota> TamanoMascota { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<SucProducto> SucProducto { get; set; }


    public virtual ObjectResult<GetInvoiceDetail_Result> GetInvoiceDetail(Nullable<System.Guid> idComprobante)
    {

        var idComprobanteParameter = idComprobante.HasValue ?
            new ObjectParameter("idComprobante", idComprobante) :
            new ObjectParameter("idComprobante", typeof(System.Guid));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetInvoiceDetail_Result>("GetInvoiceDetail", idComprobanteParameter);
    }


    public virtual ObjectResult<VentaDiariaMes_Result1> VentaDiariaMes()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VentaDiariaMes_Result1>("VentaDiariaMes");
    }


    public virtual ObjectResult<VentaMes_Result2> VentaMes()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VentaMes_Result2>("VentaMes");
    }


    public virtual ObjectResult<GetInvoice_Result2> GetInvoice(Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo, Nullable<int> idTypeVoucher)
    {

        var dateFromParameter = dateFrom.HasValue ?
            new ObjectParameter("DateFrom", dateFrom) :
            new ObjectParameter("DateFrom", typeof(System.DateTime));


        var dateToParameter = dateTo.HasValue ?
            new ObjectParameter("DateTo", dateTo) :
            new ObjectParameter("DateTo", typeof(System.DateTime));


        var idTypeVoucherParameter = idTypeVoucher.HasValue ?
            new ObjectParameter("IdTypeVoucher", idTypeVoucher) :
            new ObjectParameter("IdTypeVoucher", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetInvoice_Result2>("GetInvoice", dateFromParameter, dateToParameter, idTypeVoucherParameter);
    }

}

}

