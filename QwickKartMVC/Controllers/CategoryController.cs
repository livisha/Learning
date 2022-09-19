using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickKartDataAccessLayer.Models;
using QwickKartMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QwickKartMVC.Controllers
{
    public class CategoryController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Categories> list = new List<Categories>();
            client.BaseAddress = new Uri("https://localhost:44339/api/Category/GetAllCategories");
            var response = client.GetAsync("GetAllCategories");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Categories>>();
                display.Wait();
                list = display.Result;
               
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            string data = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("https://localhost:44339/api/Category/AddNewCategory", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Categories category)
        {
            string data = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("https://localhost:44339/api/Category/UpdateCategory", content).Result;
            if (response.IsSuccessStatusCode)
            { 
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Categories category)
        {
            return View(category);
        }
        [HttpPost] 
        public IActionResult Delete(byte categoryId)
        {
            client.BaseAddress = new Uri("https://localhost:44339/api/");
            var deleteTask = client.DeleteAsync($"Category/DeleteCategorybyId/?categoryid={categoryId}");
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}