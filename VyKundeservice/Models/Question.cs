using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Models 
{
    public class Question 
    {
        [Key]
        public int QuestionId { get; set; }
        public string Message { get; set; }
        public string Answer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}