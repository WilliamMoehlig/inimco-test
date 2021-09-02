using DevTest.BL.Persons.Models;
using System.Threading.Tasks;

namespace DevTest.BL.Persons.Interfaces
{
    public interface IPersonService
    {
        Task<CreatePersonResponse> CreateAsync(CreatePersonRequest personRequest);
    }
}
