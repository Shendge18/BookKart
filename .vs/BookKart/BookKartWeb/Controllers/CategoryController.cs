using BookKartWeb.Data;
using BookKartWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookKartWeb.Controllers
{
    public class CategoryController : Controller
    {
        protected readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<CategoryDALModel> categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryDALModel obj)
        {
            //Custom Validation
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            //}

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0) 
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(CategoryDALModel obj)
        {
            //Custom Validation
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            //}

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
