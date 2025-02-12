using IndependentTablespace.Samples.Customers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentTablespace.Samples.MapperProfiles
{
    public class CustomerMapperProfile:Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
