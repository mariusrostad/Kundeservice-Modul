using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VyKundeservice.Models {
    public class Category {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}