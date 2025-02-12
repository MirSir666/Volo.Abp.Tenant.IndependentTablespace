using IndependentTablespace.Samples.Authors;
using IndependentTablespace.Samples.Books;
using AutoMapper;

namespace IndependentTablespace.Samples.Web;

public class SamplesWebAutoMapperProfile : Profile
{
    public SamplesWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();
        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
        CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel, UpdateAuthorDto>();
        CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
        CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
        CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();
    }
}
