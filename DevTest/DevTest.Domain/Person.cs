using System.Collections.Generic;

namespace DevTest.Domain
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SocialSkill> SocialSkills { get; set; }
        public List<SocialAccount> SocialAccounts { get; set; }
    }
}
