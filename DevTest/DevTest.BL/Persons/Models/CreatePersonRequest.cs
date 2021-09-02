namespace DevTest.BL.Persons.Models
{
    public class SocialAccount
    {
        public string Type { get; set; }
        public string Address { get; set; }
    }

    public class CreatePersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] SocialSkills { get; set; }
        public SocialAccount[] SocialAccounts { get; set; }
    }
}
