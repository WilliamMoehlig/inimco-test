using AutoMapper;
using DevTest.BL.Persons.Interfaces;
using DevTest.BL.Persons.Models;
using DevTest.BL.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DevTest.Tests.Unit.Services.Person
{
    public class When_creating_person
    {
        private readonly IPersonRepository PersonRepository;
        private readonly PersonService PersonService;
        private readonly IMapper Mapper;
        private readonly CreatePersonRequest CreatePersonRequest;

        public When_creating_person()
        {
            PersonRepository = Substitute.For<IPersonRepository>();
            
            Mapper = Substitute.For<IMapper>();

            var logger = Substitute.For<ILogger<PersonService>>();

            PersonService = new PersonService(PersonRepository, Mapper, logger);

            var socialAccounts = new List<SocialAccount>
            {
                new SocialAccount
                {
                    Type = "LinkedIn",
                    Address = "linkedin.com/william-moehlig"
                },
                new SocialAccount
                {
                    Type = "Twitter",
                    Address = "@WilliamMoehlig"
                },
            };
            CreatePersonRequest = new CreatePersonRequest
            {
                FirstName = "William",
                LastName = "Moehlig",
                SocialAccounts = socialAccounts.ToArray(),
                SocialSkills = new string[] { "loyal", "friendly", "teamwork" }
            };
        }

        [Fact]
        public async Task It_should_call_mapper()
        {
            await Act();

            Mapper.Received().Map<CreatePersonRequest, Domain.Person>(Arg.Any<CreatePersonRequest>());
        }

        [Fact]
        public async Task It_should_call_repository()
        {
            await Act();

            PersonRepository.Received().Add(Arg.Any<Domain.Person>());
            await PersonRepository.Received().Save();
        }

        [Fact]
        public async Task It_should_return_correct_type()
        {
            var response = await Act();

            response.Should().BeOfType<CreatePersonResponse>();
        }


        [Fact]
        public async Task It_should_return_expected_information()
        {
            var response = await Act();

            response.NumberOfVowels.Should().Be(6);
            response.NumberOfConsonants.Should().Be(8);
            response.Name.Should().Be("William Moehlig");
            response.ReverseName.Should().Be("gilheoM mailliW");
            response.JsonFormat.Should().Be("{\"FirstName\":\"William\",\"LastName\":\"Moehlig\",\"SocialSkills\":[\"loyal\",\"friendly\",\"teamwork\"],\"SocialAccounts\":[{\"Type\":\"LinkedIn\",\"Address\":\"linkedin.com/william-moehlig\"},{\"Type\":\"Twitter\",\"Address\":\"@WilliamMoehlig\"}]}");
        }


        private async Task<CreatePersonResponse> Act()
        {
            return await PersonService.CreateAsync(CreatePersonRequest);
        }
    }
}
