using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMap
{
    public class AutoMapperConfig
    {
        public static MapperConfigurationExpression RegisterMappings() 
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfile(new DomainToViewModelMappingProfile());
            cfg.AddProfile(new ViewModelToDomainMappingProfile());

            return cfg;
        }
    }
}
