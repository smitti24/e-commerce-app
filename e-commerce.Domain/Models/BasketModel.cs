using System;
using System.Collections.Generic;

namespace e_commerce.Domain.Models
{
    public class BasketModel
    {
        public Guid id { get; set; }
        public double totalPrice { get; set; }
        public IList<ProductModel> products { get; set; }
        public VoucherModel voucher { get; set; }
    }
}