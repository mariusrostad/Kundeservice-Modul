using System.Collections.Generic;

namespace WebUi.Models 
{
    public class Question 
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Category Category { get; set; }
        public List<Answer> Answers { get; set; }
    }
}