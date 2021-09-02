using DevTest.API.Attributes;
using DevTest.BL.Persons.Interfaces;
using DevTest.BL.Persons.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevTest.API.Controllers
{
    [ApiKey]
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<CreatePersonResponse> Add(CreatePersonRequest command)
        {
            return await _personService.CreateAsync(command);
        }
    }
}
