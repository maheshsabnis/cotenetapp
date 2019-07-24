using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cotenetapp.Models;
using cotenetapp.Services;

namespace cotenetapp.Controllers
{ 
    /// <summary>
    /// Must have following
    /// 1. Must be Secured is needed
    /// 2. Must be constructor Injected using repositories
    /// 3. Optionally can be applied with Action Filters
    /// </summary>
    public class CategoryController : Controller
    {
        private readonly IServiceRepository<Category, int> catRepository;

        public CategoryController(
            IServiceRepository<Category, int> catRepository)
        {
            this.catRepository = catRepository;
        }
        /// <summary>
        /// Provides list of Model data
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var cats = catRepository.GetAsync().Result;
            return View(cats);
        }

        /// <summary>
        /// HttpGet method that will return 
        /// a view with EMpty Category Object
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var cat = new Category();
            return View(cat);
        }
        /// <summary>
        /// The HttpPost method that will accept
        /// the Posted Category Object from View
        /// The method must validate the posted object
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Category cat)
        {
            // check if the category is valid as per
            // data annotation rules
            if (ModelState.IsValid)
            {
                var res  = catRepository.CreateAsync(cat).Result;
                // redirect to Index action  of the current controller
                return RedirectToAction("Index");
            }
            // else stay on the same view and show error messages
            return View(cat);
        }
        
        public IActionResult Edit(int id)
        {
            var res = catRepository.GetAsync(id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(int id,Category cat) 
        {
            if (ModelState.IsValid)
            {
                var res = catRepository.UpdateAsync(id, cat).Result;
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        public IActionResult Delete(int id)
        {
            var res = catRepository.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
    }
}