using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Seminario.DAL.EF;
using ent = Seminario.DO.Objects;

namespace Seminario.Maps
{
    public class Maps
    {
        public static void CreateMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ent.Pais, data.Pai>();


                cfg.CreateMap<data.Pai, ent.Pais>();
            });

        }
    }
}
