using System;

namespace e_commerce.Domain.Models
{
    public class ProductModel
    {
        public Guid id { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public Enumeration.ProductTypes type { get; set; }
        
        public bool voucherApplied { get; set; }

        public ProductModel()
        {
            
        }
    }
}