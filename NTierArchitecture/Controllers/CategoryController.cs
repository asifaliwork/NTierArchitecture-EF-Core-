using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models;

namespace NTierArchitectureWeb.Controllers
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
            List<Category> obj = _db.Categories.ToList();   
            return View(obj);
        }

        public IActionResult Update(int? Id)
        {
            Category obj = new();
            if(Id==null ||Id == 0)
            {
                return View(obj);
            }

            obj = _db.Categories.FirstOrDefault(a => a.Category_Id == Id);
            if (obj == null) 
            {
                return NotFound();     
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Update(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Category_Id == 0)
                {
                    _db.Categories.Add(obj);

                }
                else
                {
                    _db.Categories.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");   
            }
            return View(obj);

        }


        public async Task<IActionResult> Delete(int? Id)
        {
            Category obj = new();

            obj = _db.Categories.FirstOrDefault(a => a.Category_Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> categories = new();
            for (int i = 1; i <= 2; i++)
            {
                categories.Add(new Category { GenreName=Guid.NewGuid().ToString() });
            }
            _db.Categories.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult CreateMultiple5()
        {
            List<Category> categories = new ();
            for (int i = 1; i <= 5; i++)
            {
                categories.Add(new Category { GenreName= Guid.NewGuid().ToString() });
            }
           _db.Categories.AddRange(categories);
            _db.SaveChanges ();
            return RedirectToAction("Index");
        }
        public IActionResult RemoveMultiple2()
        {
            List<Category> categories = _db.Categories.OrderByDescending(a=>a.Category_Id).Take(2).ToList();
           
               
         
            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult RemoveMultiple5()
        {
            List<Category> categories = _db.Categories.OrderByDescending(a => a.Category_Id).Take(5).ToList();
            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
