namespace DevTest.Domain
{
    public class SocialSkill
    {
        public int SkillId { get; set; }
        public string Description  { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
