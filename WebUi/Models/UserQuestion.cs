namespace WebUi.Models 
{
    public class UserQuestion
    {
        public int UserQuestionId { get; set; }
        public string Question { get; set; }
        public Category Category { get; set; }
    }
}