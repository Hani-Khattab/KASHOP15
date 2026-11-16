using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.DAL.DTO.Requests
{
    public class ProductRequest
    {
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public decimal Discount { set; get; }
        public IFormFile MainImage { set; get; }
        public int CategoryId { set; get; }
        public List<ProductTranslationRequest> Translations { set; get; } = new();
    }
}
