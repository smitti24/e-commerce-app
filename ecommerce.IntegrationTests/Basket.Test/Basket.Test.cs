using System;
using System.Collections.Generic;
using e_commerce.BusinessLogic.Basket;
using e_commerce.BusinessLogic.Voucher;
using e_commerce.Domain;
using e_commerce.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void CalculateBasketTotal()
        {
            //setUp
            VoucherModel _voucher = new VoucherModel();
            List<ProductModel> _productList = new List<ProductModel>();
            
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Orange",
                price = 2,
                type = Enumeration.ProductTypes.Oranges
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Orange",
                price = 2,
                type = Enumeration.ProductTypes.Oranges
            });
            
            
            _voucher.id = Guid.NewGuid();
            _voucher.desctription = "This is a two for the price of one voucher";
            _voucher.identifier = Enumeration.VoucherTypes.TwoForOne;
            
            using (var container = BuildIOCContainer())
            {
                
                var basket = container.GetService<IBasket>();

                //Action
                var basketModel = basket.CalculateBasketTotal(_productList, _voucher);

                
                //asserts
                Assert.AreEqual(8, basketModel.totalPrice, "Totals do not match!");
            }
        }
        
        [Test]
        public void CalculateBasketTotal2()
        {
            //setUp
            VoucherModel _voucher = new VoucherModel();
            List<ProductModel> _productList = new List<ProductModel>();
            
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Orange",
                price = 2,
                type = Enumeration.ProductTypes.Oranges
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Orange",
                price = 2,
                type = Enumeration.ProductTypes.Oranges
            });
            
            
            _voucher.id = Guid.NewGuid();
            _voucher.desctription = "This is a two for the price of one voucher";
            _voucher.identifier = Enumeration.VoucherTypes.TwoForOne;
            
            using (var container = BuildIOCContainer())
            {
                
                var basket = container.GetService<IBasket>();

                //Action
                var basketModel = basket.CalculateBasketTotal(_productList, _voucher);

                
                //asserts
                Assert.AreEqual(12, basketModel.totalPrice, "Totals do not match!");
            }
        }
        
        [Test]
        public void CalculateBasketTotalWithoutVoucher()
        {
            //setUp
            VoucherModel _voucher = new VoucherModel();
            List<ProductModel> _productList = new List<ProductModel>();
            
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Green Apple",
                price = 2,
                type = Enumeration.ProductTypes.Apples
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Orange",
                price = 2,
                type = Enumeration.ProductTypes.Oranges
            });
            _productList.Add(new ProductModel()
            {
                id = Guid.NewGuid(),
                description = "Orange",
                price = 2,
                type = Enumeration.ProductTypes.Oranges
            });

            using (var container = BuildIOCContainer())
            {
                var basket = container.GetService<IBasket>();
                //Action
                var basketModel = basket.CalculateBasketTotal(_productList, null);
                //asserts
                Assert.AreEqual(10, basketModel.totalPrice, "Totals do not match!");
            }
        }
        
        private ServiceProvider BuildIOCContainer()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IVoucher, Voucher>();
            services.AddSingleton<IBasket, Basket>();

            return services.BuildServiceProvider();
        }
        
    }
}