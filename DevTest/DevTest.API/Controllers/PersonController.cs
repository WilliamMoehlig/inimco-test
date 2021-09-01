using DevTest.API.Attributes;
using DevTest.BL.Interfaces;
using DevTest.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevTest.API.Controllers
{
    [ApiKey]
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _repository;
        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public IEnumerable<Person> Add(Person person)
        {
            _repository.Add(person);

            _repository.SaveChanges();

            return _repository.GetAll();
        }
    }
}
