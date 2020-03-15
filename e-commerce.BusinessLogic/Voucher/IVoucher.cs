using System.Collections.Generic;
using e_commerce.Domain.Models;

namespace e_commerce.BusinessLogic.Voucher
{
    public interface IVoucher
    {
        BasketModel CalculateTwoForOneTotal(IList<ProductModel> products, VoucherModel voucher, BasketModel basket);
    }
}