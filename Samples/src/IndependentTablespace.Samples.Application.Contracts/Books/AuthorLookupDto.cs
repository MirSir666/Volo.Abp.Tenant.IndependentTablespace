using System;
using Volo.Abp.Application.Dtos;

namespace IndependentTablespace.Samples.Books;

public class AuthorLookupDto : EntityDto<Guid>
{
    public string Name { get; set; }
}
