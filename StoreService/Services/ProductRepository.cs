using StoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreService.Services
{
    public class ProductRepository
    {
        private const string CacheKey = "ProductStore";

        public ProductRepository()
        {
            var ctx = HttpContext.Current;
            if(ctx != null)
            {
                if(ctx.Cache[CacheKey] == null)
                {
                    var products = new Product[]
                    {
                        new Product
                        {
                            category = "Sporting Goods",
                            price = "$49.99",
                            stocked = true,
                            name = "Football"
                        },
                        new Product
                        {
                            category = "Sporting Goods",
                            price = "$9.99",
                            stocked = true,
                            name = "Baseball"
                        },
                        new Product
                        {
                            category = "Sporting Goods",
                            price = "$29.99",
                            stocked = false,
                            name = "Basketball"
                        },
                        new Product
                        {
                            category = "Electronics",
                            price = "$99.99",
                            stocked = true,
                            name = "iPod Touch"
                        },
                        new Product
                        {
                            category = "Electronics",
                            price = "$399.99",
                            stocked = false,
                            name = "iPhone 5"
                        },
                        new Product
                        {
                            category = "Electronics",
                            price = "$199.99",
                            stocked = true,
                            name = "Nexus 7"
                        }
                    };
                    ctx.Cache[CacheKey] = products;
                }
            }
        }
        public Product[] GetAllProducts()
        {
            var ctx = HttpContext.Current;
            if(ctx != null)
            {
                return (Product[])ctx.Cache[CacheKey];
            }
            return null;
        }

        public bool SaveProduct(Product product)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                try
                {
                    var currentData = ((Product[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(product);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    return true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }
    }
}