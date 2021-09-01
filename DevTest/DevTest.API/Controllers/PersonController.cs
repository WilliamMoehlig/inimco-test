using DevTest.API.Attributes;
using DevTest.BL.Infrastructure;
using DevTest.BL.Persons.Create;
using Microsoft.AspNetCore.Mvc;

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
        public CreatePersonResponse Add(CreatePersonRequest command)
        {
            return _personService.Create(command);
        }
    }
}
