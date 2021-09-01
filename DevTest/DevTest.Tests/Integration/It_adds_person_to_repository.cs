using DevTest.DAL.Repositories;
using DevTest.Domain;
using DevTest.Tests.Utilities;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DevTest.Tests.Integration
{
    public class It_adds_person_to_repository
    {
        [Fact]
        public void It_adds_person_with_all_data()
        {
            DatabaseTestHelper.RunWithContext(datacontext =>
            {
                var repository = new PersonRepository(datacontext);

                var person = new Person()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    SocialAccounts = new List<SocialAccount> {
                        new SocialAccount { Type = "LinkedIn", Address = "linkedin.com/johndoe"},
                        new SocialAccount { Type = "Twitter", Address = "@johndoe"},
                    },
                    SocialSkills = new List<SocialSkill>
                    {
                        new SocialSkill
                        {
                            Description = "social"
                        },
                        new SocialSkill
                        {
                            Description = "fun"
                        },
                        new SocialSkill
                        {
                            Description = "coach"
                        }
                    }
                };

                repository.Add(person);
                repository.Save();


                var contextPerson = datacontext.Set<Person>().Find(person.PersonId);
                var contextAccounts = datacontext.Set<SocialAccount>().Where(c => c.PersonId == person.PersonId);
                var contextSkills = datacontext.Set<SocialSkill>().Where(c => c.PersonId == person.PersonId);

                contextPerson.Should().NotBeNull();
                contextAccounts.Count().Should().Be(2);
                contextSkills.Count().Should().Be(3);
            });
        }
    }
}
