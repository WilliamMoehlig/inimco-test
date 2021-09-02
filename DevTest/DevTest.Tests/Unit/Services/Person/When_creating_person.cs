using AutoMapper;
using DevTest.BL.Persons.Interfaces;
using DevTest.BL.Persons.Models;
using DevTest.BL.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace DevTest.Tests.Unit.Services.Person
{
    public class When_creating_person
    {
        private readonly IPersonRepository PersonRepository;
        private readonly PersonService PersonService;
        private readonly IMapper Mapper;

        public When_creating_person()
        {
            PersonRepository = Substitute.For<IPersonRepository>();
            
            Mapper = Substitute.For<IMapper>();

            var logger = Substitute.For<ILogger<PersonService>>();

            PersonService = new PersonService(PersonRepository, Mapper, logger);
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


        private async Task<CreatePersonResponse> Act()
        {
            return await PersonService.CreateAsync(new CreatePersonRequest());
        }
    }
}
