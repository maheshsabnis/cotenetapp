using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cotenetapp.Models;
using cotenetapp.Services;
namespace cotenetapp.Controllers
{
    public class CatPrdController : Controller
    {
        IServiceRepository<Category, int> catRepo;
        IServiceRepository<Product, int> prdRepo;

        public CatPrdController(IServiceRepository<Category, int> catRepo, IServiceRepository<Product, int> prdRepo)
        {
            this.catRepo = catRepo;
            this.prdRepo = prdRepo;
        }
        public IActionResult Index()
        {
            var combine = new CategoryProduct()
            {
                Categories = catRepo.GetAsync().Result.ToList(),
                Products = prdRepo.GetAsync().Result.ToList()
            };
            return View(combine);
        }

        public IActionResult ShowDetails(int id)
        {
            var combine = new CategoryProduct()
            {
                Categories = catRepo.GetAsync().Result.ToList(),
                Products = prdRepo.GetAsync().Result.ToList().Where(c=>c.CategoryRowId==id).ToList()
            };
            return View("Index", combine);
        }
    }
}