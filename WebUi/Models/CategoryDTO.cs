using System.Collections.Generic;

namespace WebUi.Models {
    public class CategoryDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}