using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;
using QuickKartServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKartServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
    
        QuickKartRepository repository;

        public CategoryController()
        {
            repository = new QuickKartRepository();
        }
        public JsonResult GetAllCategories()
        {
            List<Categories> category = new List<Categories>();
            try
            {
                category = repository.GetAllCategories();
            }
            catch (Exception e)
            {
                category = null;
            }
            return Json(category);
        }

        [HttpPost]
        public JsonResult AddNewCategory(Category category)
        {
            string message;
            bool result = false;
            try 
            {
                result = repository.AddCategory(category.CategoryName);
                if (result)
                {
                    message = "Successfully Added Category";
                }
                else
                {
                    message = "Oops Something wrong";
                }
            }
            catch
            {
                message = "null";
            }
            return Json(message);
        }


        [HttpPut]
        public JsonResult UpdateCategory(Categories category)
        {
            string message;
            try
            {
                repository.UpdateCategory(category);
                message = "Updated";

            }
            catch(Exception e)
            {
                message = null;
            }
            return Json(message);
        }

        [HttpDelete]
        public JsonResult DeleteCategorybyId(byte categoryId)
        {
            string message;
            try
            {
                repository.DeleteCategory(categoryId);
                message = "Updated";

            }
            catch (Exception e)
            {
                message = null;
            }
            return Json(message);
        } 
       //add new method
    }
}
