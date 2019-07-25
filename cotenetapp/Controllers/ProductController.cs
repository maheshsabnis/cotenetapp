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
        private readonly IServiceRepository<Category, int> catRepository;

        public ProductController(
            IServiceRepository<Product, int> prdRepository, 
            IServiceRepository<Category, int> catRepository)
        {
            this.prdRepository = prdRepository;
            this.catRepository = catRepository;
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
            ViewBag.CategoryRowId = catRepository.GetAsync().Result.ToList();
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
            ViewBag.CategoryRowId = catRepository.GetAsync().Result.ToList();

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