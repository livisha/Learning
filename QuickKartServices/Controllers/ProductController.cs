using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;

namespace QuickKartServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        QuickKartRepository repository;
        public ProductController()
        {
            repository = new QuickKartRepository();

        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            List<Products> products = new List<Products>();
            try
            {
                products = repository.GetAllProducts();
            }
            catch(Exception e)
            {
                products = null;
            }
            return Json(products);
        }

        public JsonResult GetProductById(string productId)
        {
            Products product = null;
            try
            {
                product = repository.GetProductById(productId);
            }
            catch(Exception e)
            {
                product = null;
            }
            return Json(product);
        }

        [HttpPost]
        public JsonResult AddProductUsingParams(string productName, byte categoryId, decimal price, int quantityAvailable)
        {
            bool status = false;
            string productId = null;
            string message;
            try
            {               
                status=repository.AddProduct(productName, categoryId, price, quantityAvailable,out productId);
                if (status)
                {
                    message = "Successfully added product" + productId;
                }
                else
                {
                    message = "Oops Something wrong!!";
                }
            }
            catch (Exception e)
            {
                productId = null;
                status = false;
                message = "Some error Occured";
            }
            return Json(message);

        }

        [HttpPost]
        public JsonResult AddProductByModels(Products product)
        {
            bool status = false;
            string message;

            try
            {
                status = repository.AddProduct(product);
                if (status)
                {
                    message = "Successful addition operation, ProductId = " + product.ProductId;
                }
                else
                {
                    message = "Unsuccessful addition operation!";
                }
            }
            catch (Exception ex)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);
        }

       
        [HttpPut]
        public bool UpdateProductByAPIModels(Models.Products product)
        {
            bool status = false;
            try
            {

                Products prodObj = new Products();
                prodObj.ProductId = product.ProductId;
                prodObj.ProductName = product.ProductName;
                prodObj.CategoryId = product.CategoryId;
                prodObj.Price = product.Price;
                prodObj.QuantityAvailable = product.QuantityAvailable;
                status = repository.UpdateProduct(prodObj);
            }

            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }


    }
}
