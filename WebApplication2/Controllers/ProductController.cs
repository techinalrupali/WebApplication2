using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL context = new ProductDAL();
        private int res;

        public IActionResult List()
        {
            ViewBag.ProductList = context.GetAllProducts();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection form)
        {
            Product p = new Product();
            p.Name = form["name"];
            p.Price = Convert.ToDecimal(form["price"]);
            p.Company = form["company"];
            p.Description = form["description"];
            int res = context.Save(p);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = new Product();
            ViewBag.Name = prod.Name;
            ViewBag.Price = prod.Price;
            ViewBag.Company = prod.Company;
            ViewBag.Description = prod.Description;
            ViewBag.Id = prod.Id;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(IFormCollection form)
        {
            Product prod = new Product();
            prod.Name = form["name"];
            prod.Price = Convert.ToDecimal(form["price"]);
            prod.Company = form["company"];
            prod.Description = form["description"];
            prod.Id = Convert.ToInt32(form["id"]);
            int res = context.Update(prod);
            if (res == 1)
                return RedirectToAction("List");

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product prod = context.GetProductById(id);
            ViewBag.Name = prod.Name;
            ViewBag.Price = prod.Price;
            ViewBag.Company = prod.Company;
            ViewBag.Description = prod.Description;
            ViewBag.Id = prod.Id;
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            int res = context.Delete(id);
            if (res == 1)
                return RedirectToAction("List");
            return View();
        }
        
    }

}

