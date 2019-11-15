using System.Collections.Generic;

namespace VyKundeservice.Models {
    public class CategoryDTO {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}