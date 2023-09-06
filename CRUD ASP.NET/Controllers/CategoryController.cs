using CRUD_ASP.NET.Data;
using CRUD_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ASP.NET.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;  
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create() 
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayError cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            //var firstCategory = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var singleCategory = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (category == null) {
                return NotFound();
            }

            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayError cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            //var firstCategory = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var singleCategory = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj); 
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");   
        }

        //GET
        public IActionResult Read(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            //var firstCategory = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var singleCategory = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
