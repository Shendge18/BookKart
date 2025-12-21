using BookKart.DataAccess.Data;
using BookKart.DataAccess.Repository.IRepository;
using BookKart.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookKartWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<CategoryDALModel> categoryList = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();

                TempData["successMsg"] = "Category created sucessfully.";

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

            CategoryDALModel? categoryFromDb = _unitOfWork.Category.Get(x=>x.Id == id);
            //othet ways to retrieve
            //CategoryDALModel? categoryFromDb2 = _db.Categories.Find(id); --- works only with primary keys
            //CategoryDALModel? categoryFromDb3 = _db.Categories.Where(x => x.Id == id).FirstOrDefault();

            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["successMsg"] = "Category updated sucessfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CategoryDALModel? categoryFromDb = _unitOfWork.Category.Get(x => x.Id == id);
            //othet ways to retrieve
            //CategoryDALModel? categoryFromDb2 = _db.Categories.Find(id); --- works only with primary keys
            //CategoryDALModel? categoryFromDb3 = _db.Categories.Where(x => x.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int?id)
        {
            CategoryDALModel? obj = _unitOfWork.Category.Get(x => x.Id == id);
            if (obj == null) 
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["successMsg"] = "Category deleted sucessfully.";

            return RedirectToAction("Index");
        }

    }
}
