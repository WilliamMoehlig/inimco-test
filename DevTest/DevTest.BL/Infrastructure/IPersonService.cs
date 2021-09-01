using DevTest.BL.Persons.Create;

namespace DevTest.BL.Infrastructure
{
    public interface IPersonService
    {
        CreatePersonResponse Create(CreatePersonRequest personRequest);
    }
}
