using AutoMapper;
using DevTest.BL.Mapping;
using DevTest.BL.Persons.Models;
using DevTest.Domain;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DevTest.Tests.Unit.Mapper
{
    public class When_mapping_personrequest_to_person
    {
        private readonly IMapper _mapper;

        public When_mapping_personrequest_to_person()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(new PersonMappingProfile()));
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void It_should_map_as_expected()
        {
            var socialAccounts = new List<BL.Persons.Models.SocialAccount>
            {
                new BL.Persons.Models.SocialAccount
                {
                    Type = "LinkedIn",
                    Address = "linkedin.com/william-moehlig"
                },
                new BL.Persons.Models.SocialAccount
                {
                    Type = "Twitter",
                    Address = "@WilliamMoehlig"
                },
            };

            CreatePersonRequest createPersonRequest = new CreatePersonRequest
            {
                FirstName = "William",
                LastName = "Moehlig",
                SocialAccounts = socialAccounts.ToArray(),
                SocialSkills = new string[] {"loyal", "friendly", "teamwork"}
            };

            var person = Act(createPersonRequest);

            person.FirstName.Should().Be("William");
            person.LastName.Should().Be("Moehlig");

            person.SocialSkills.Count.Should().Be(3);
            person.SocialSkills.Should().Contain(c => c.Description == "loyal");
            person.SocialSkills.Should().Contain(c => c.Description == "friendly");
            person.SocialSkills.Should().Contain(c => c.Description == "teamwork");

            person.SocialAccounts.Count.Should().Be(2);
            var firstSocialAccount = person.SocialAccounts.First();
            firstSocialAccount.Type.Should().Be("LinkedIn");
            firstSocialAccount.Address.Should().Be("linkedin.com/william-moehlig");

            var secondSocialAccount = person.SocialAccounts.Last();
            secondSocialAccount.Type.Should().Be("Twitter");
            secondSocialAccount.Address.Should().Be("@WilliamMoehlig");
        }

        private Person Act(CreatePersonRequest personRequest)
        {
            return _mapper.Map<CreatePersonRequest, Person>(personRequest);
        }
    }
}
