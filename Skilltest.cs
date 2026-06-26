namespace Skilltest
{
    public class SkillTask
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public DateTime DeadLine { get; set; }
        public bool IsCompleted { get; set; }
    }
}
