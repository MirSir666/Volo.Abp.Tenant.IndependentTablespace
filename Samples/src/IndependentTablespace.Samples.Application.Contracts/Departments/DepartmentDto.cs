using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace IndependentTablespace.Samples.Departments
{
    public class DepartmentDto:EntityDto<Guid>
    {
        public string Name{ get; set; }
    }
}
