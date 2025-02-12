using IndependentTablespace.Samples.Departments;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentTablespace.Samples.MapperProfiles
{
    public class DepartmentMapperProfile : Profile
    {
        public DepartmentMapperProfile()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}
