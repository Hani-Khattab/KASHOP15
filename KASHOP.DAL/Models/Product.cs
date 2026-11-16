using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.DAL.Models
{
    public class Product
    {
        public int Id { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public decimal Discount { set; get; }
        public double Rate { set; get; }
        public string MainImage { set; get; }
        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public List<ProductTranslation> Translations { set; get; } = new();
    }
}
