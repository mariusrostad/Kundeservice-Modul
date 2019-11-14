using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Models {
    public class Category {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}