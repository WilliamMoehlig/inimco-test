namespace DevTest.BL.Persons.Create
{
    public class SocialAccounts
    {
        public string Type { get; set; }
        public string Address { get; set; }
    }

    public class CreatePersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] SocialSkills { get; set; }
        public SocialAccounts[] SocialAccounts { get; set; }
    }
}
