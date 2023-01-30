using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMap
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //领域模型和视图模型结构不匹配，可进行手动配置
            //view -> domain
            CreateMap<StudentViewModel, Student>()
              .ForPath(d => d.Address.Province, o => o.MapFrom(s => s.Province))
              .ForPath(d => d.Address.City, o => o.MapFrom(s => s.City))
              .ForPath(d => d.Address.County, o => o.MapFrom(s => s.County))
              .ForPath(d => d.Address.Street, o => o.MapFrom(s => s.Street)); 
        }
    }
}
