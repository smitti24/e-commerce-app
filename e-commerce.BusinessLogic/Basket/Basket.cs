using System.Collections.Generic;
using System.Linq;
using e_commerce.BusinessLogic.Voucher;
using e_commerce.Domain;
using e_commerce.Domain.Models;

namespace e_commerce.BusinessLogic.Basket
{
    public class Basket: IBasket
    {
        IVoucher _voucher;

        public Basket(IVoucher voucher)
        {
            _voucher = voucher;
        }
        
        public BasketModel CalculateBasketTotal(IList<ProductModel> products, VoucherModel voucher)
        {
            var basket = new BasketModel();
            if (voucher?.identifier != null)
            {
                switch (voucher.identifier)
                {
                    case Enumeration.VoucherTypes.TwoForOne:
                        _voucher.CalculateTwoForOneTotal(products, voucher, basket);
                        break;
                }
            }
            
            var basketModel = CalculateBasketTotalWithoutDiscount(products, basket);
            return basketModel;

        }
        
        private BasketModel CalculateBasketTotalWithoutDiscount(IList<ProductModel> productList, BasketModel basket)
        {
            foreach (var product in productList.Where(x => x.voucherApplied == false))
            {
                basket.totalPrice += product.price;
            }

            basket.products = productList;
            
            return basket;
        }
    }
}
