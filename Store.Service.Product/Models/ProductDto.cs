﻿namespace Store.Service.Product.Models
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}