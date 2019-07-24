using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cotenetapp.Models;
using cotenetapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace cotenetapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceRepository<Product, int> prdRepository;

        public ProductController(
            IServiceRepository<Product, int> prdRepository)
        {
            this.prdRepository = prdRepository;
        }
        /// <summary>
        /// Provides list of Model data
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var cats = prdRepository.GetAsync().Result;
            return View(cats);
        }

        
        public IActionResult Create()
        {
            var cat = new Product();
            return View(cat);
        }
         
        [HttpPost]
        public IActionResult Create(Product cat)
        {
            if (ModelState.IsValid)
            {
                var res = prdRepository.CreateAsync(cat).Result;
                // redirect to Index action  of the current controller
                return RedirectToAction("Index");
            }
            // else stay on the same view and show error messages
            return View(cat);
        }

        public IActionResult Edit(int id)
        {
            var res = prdRepository.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product cat)
        {
            if (ModelState.IsValid)
            {
                var res = prdRepository.UpdateAsync(id, cat).Result;
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        public IActionResult Delete(int id)
        {
            var res = prdRepository.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
    }
}