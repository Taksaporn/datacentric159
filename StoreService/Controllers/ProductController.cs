using StoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StoreService.Services;

namespace StoreService.Controllers
{
    public class ProductController : ApiController
    {
        private ProductRepository productRepository;

        public ProductController()
        {
            this.productRepository = new ProductRepository();
        }
        public Product[] Get()
        {
            return this.productRepository.GetAllProducts();
        }

        public HttpResponseMessage Post(Product product)
        {
            if (this.productRepository.SaveProduct(product))
            {
                return Request.CreateResponse<Product>(System.Net.HttpStatusCode.Created, product);
            }
            return Request.CreateResponse<Product>(System.Net.HttpStatusCode.InternalServerError, product);
        }
    }
}
