namespace DevTest.Domain
{
    public class SocialAccount
    {
        public int AccountId { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
