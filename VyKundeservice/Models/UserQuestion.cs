namespace VyKundeservice.Models 
{
    public class UserQuestion
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Question { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}