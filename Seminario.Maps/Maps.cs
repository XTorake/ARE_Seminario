using System;
using AutoMapper;
using data = Seminario.DAL.EF;
using ent = Seminario.DO.Objects;

namespace Seminario.Maps
{
    public class Maps
    {
        [Obsolete]
        public static void CreateMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ent.Auditoria, data.Auditoria>();
           
                cfg.CreateMap<ent.CategoriaProducto, data.CategoriaProducto>();
            
              
                cfg.CreateMap<ent.DistritoEclesiastico, data.DistritoEclesiastico>();
                cfg.CreateMap<ent.EncabezadoFactura, data.EncabezadoFactura>();
                cfg.CreateMap<ent.Iglesia, data.Iglesia>();
                cfg.CreateMap<ent.LineaFactura, data.LineaFactura>();
                cfg.CreateMap<ent.MetodoPago, data.MetodoPago>();
                cfg.CreateMap<ent.Pais, data.Pai>();
                cfg.CreateMap<ent.Persona, data.Persona>();
                cfg.CreateMap<ent.Producto, data.Producto>();
             
                cfg.CreateMap<ent.TipoUsuario, data.TipoUsuario>();
                cfg.CreateMap<ent.Usuario, data.Usuario>();


                cfg.CreateMap<data.Auditoria, ent.Auditoria>();
             
                cfg.CreateMap<data.CategoriaProducto, ent.CategoriaProducto>();
                
              
                cfg.CreateMap<data.DistritoEclesiastico, ent.DistritoEclesiastico>();
                cfg.CreateMap<data.EncabezadoFactura, ent.EncabezadoFactura>();
                cfg.CreateMap<data.Iglesia, ent.Iglesia>();
                cfg.CreateMap<data.LineaFactura, ent.LineaFactura>();
                cfg.CreateMap<data.MetodoPago, ent.MetodoPago>();
                cfg.CreateMap<data.Pai, ent.Pais>();
                cfg.CreateMap<data.Persona, ent.Persona>();
                cfg.CreateMap<data.Producto, ent.Producto>();
               
                cfg.CreateMap<data.TipoUsuario, ent.TipoUsuario>();
                cfg.CreateMap<data.Usuario, ent.Usuario>();
            });

        }
    }
}
