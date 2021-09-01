using DevTest.BL.Infrastructure;
using DevTest.BL.Persons.Create;
using DevTest.Domain;
using System.Linq;
using System.Text.Json;
using DevTest.BL.Extensions;

namespace DevTest.BL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public CreatePersonResponse Create(CreatePersonRequest personRequest)
        {
            // Introduce mapper

            System.Collections.Generic.List<SocialSkill> socialSkills = new System.Collections.Generic.List<SocialSkill>();

            foreach (var socialSkill in personRequest.SocialSkills)
            {
                socialSkills.Add(new SocialSkill { Description = socialSkill });
            }

            var person = new Person
            {
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                SocialSkills = socialSkills,
                SocialAccounts = personRequest.SocialAccounts.Select(c => new SocialAccount
                {
                    Type = c.Type,
                    Address = c.Address
                }).ToList()
            };

            _personRepository.Add(person);
            _personRepository.Save();

            var fullName = $"{personRequest.FirstName} {personRequest.LastName}";

            return new CreatePersonResponse {
                NumberOfVowels = fullName.CountVowels(),
                NumberOfConstenants = fullName.CountConsonants(),
                Name = fullName,
                ReverseName = fullName.Reverse(),
                JsonFormat = JsonSerializer.Serialize(personRequest)
            };
        }
    }
}
