using System.Collections.Generic;
using e_commerce.Domain.Models;

namespace e_commerce.BusinessLogic.Basket
{
    public interface IBasket
    {
        BasketModel CalculateBasketTotal(IList<ProductModel> products, VoucherModel voucher);
    }
}