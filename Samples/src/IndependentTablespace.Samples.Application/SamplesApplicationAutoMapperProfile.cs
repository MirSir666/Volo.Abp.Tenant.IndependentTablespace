using IndependentTablespace.Samples.Authors;
using IndependentTablespace.Samples.Books;
using AutoMapper;

namespace IndependentTablespace.Samples;

public class SamplesApplicationAutoMapperProfile : Profile
{
    public SamplesApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
    }
}
