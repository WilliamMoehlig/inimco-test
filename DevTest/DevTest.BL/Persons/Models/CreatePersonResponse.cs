namespace DevTest.BL.Persons.Models
{
    public class CreatePersonResponse
    {
        public int NumberOfVowels { get; set; }
        public int NumberOfConstenants { get; set; }
        public string Name { get; set; }
        public string ReverseName { get; set; }
        public string JsonFormat { get; set; }
    }
}
