using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency
{
    public static MapperConfiguration Configure()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDTO>();
            cfg.CreateMap<CategoryDTO, Category>();
        });
        return config;
    }
}
