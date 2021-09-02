using DevTest.Domain;
using System.Linq;
using System.Text.Json;
using DevTest.BL.Extensions;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using DevTest.BL.Persons.Models;
using DevTest.BL.Persons.Interfaces;

namespace DevTest.BL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public PersonService(IPersonRepository personRepository, IMapper mapper, ILogger<PersonService> logger)
        {
            _personRepository = personRepository;
            _mapper = mapper;

            _logger = logger;
        }

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest personRequest)
        {
            try
            {
                Person person = _mapper.Map<CreatePersonRequest, Person>(personRequest);
                _personRepository.Add(person);
                await _personRepository.Save();

                string fullName = $"{personRequest.FirstName} {personRequest.LastName}";

                return new CreatePersonResponse
                {
                    NumberOfVowels = fullName.CountVowels(),
                    NumberOfConsonants = fullName.CountConsonants(),
                    Name = fullName,
                    ReverseName = fullName.Reverse(),
                    JsonFormat = JsonSerializer.Serialize(personRequest)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
