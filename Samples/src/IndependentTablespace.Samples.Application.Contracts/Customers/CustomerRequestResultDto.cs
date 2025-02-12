using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace IndependentTablespace.Samples.Customers
{
    public class CustomerRequestResultDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
