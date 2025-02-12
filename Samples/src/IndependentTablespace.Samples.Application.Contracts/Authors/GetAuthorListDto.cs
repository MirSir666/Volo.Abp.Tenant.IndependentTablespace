using Volo.Abp.Application.Dtos;

namespace IndependentTablespace.Samples.Authors;

public class GetAuthorListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
