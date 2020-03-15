using System;

namespace e_commerce.Domain.Models
{
    public class VoucherModel
    {
        public Guid id { get; set; }
        public string desctription { get; set; }
        public Enumeration.VoucherTypes identifier { get; set; }

        public VoucherModel()
        {
            
        }
    }
}