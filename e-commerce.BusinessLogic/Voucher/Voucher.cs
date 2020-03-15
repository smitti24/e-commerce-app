using System;
using System.Collections.Generic;
using System.Linq;
using e_commerce.Domain;
using e_commerce.Domain.Models;

namespace e_commerce.BusinessLogic.Voucher
{
    public class Voucher: IVoucher
    {

        public BasketModel CalculateTwoForOneTotal(IList<ProductModel> products, VoucherModel voucher, BasketModel basket)
        {
            var isVoucherApplied = false;
            var productTypes = Enum.GetValues(typeof(Enumeration.ProductTypes)).Cast<Enumeration.ProductTypes>();

            foreach (var productType in productTypes)
            {
                var productList = products.Where(x => x.type == productType).ToList();

                if (isVoucherApplied == false && productList.Count() > 1)
                {
                    isVoucherApplied = true;
                    basket = applyVoucher(productList, voucher, basket);

                }
            }
            
            return basket;
        }
        

        private BasketModel applyVoucher(List<ProductModel> productList, VoucherModel voucher, BasketModel basket)
        {
            int skip = 0;
            var products = new List<ProductModel>();

            products = productList.Take(2).Skip(skip).ToList();
            
            while (products.Count() == 2)
            {
                foreach (var item in products)
                {
                    item.voucherApplied = true;
                }

                basket.totalPrice += products[0].price;
                skip += 2;
                products = productList.Take(2).Skip(skip).ToList();
            }

            basket.products = productList;
            basket.voucher = voucher;
            
            return basket;
        }

    }
}