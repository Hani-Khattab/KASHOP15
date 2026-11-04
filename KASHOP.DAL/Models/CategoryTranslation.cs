using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace KASHOP.DAL.Models
{
    [Table("CategoriesTranslations")]
    public class CategoryTranslation
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Language { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
