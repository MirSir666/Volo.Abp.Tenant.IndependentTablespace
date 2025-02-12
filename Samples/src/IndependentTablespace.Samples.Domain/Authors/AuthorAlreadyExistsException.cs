using Volo.Abp;

namespace IndependentTablespace.Samples.Authors;

public class AuthorAlreadyExistsException : BusinessException
{
    public AuthorAlreadyExistsException(string name)
        : base(SamplesDomainErrorCodes.AuthorAlreadyExists)
    {
        WithData("name", name);
    }
}
