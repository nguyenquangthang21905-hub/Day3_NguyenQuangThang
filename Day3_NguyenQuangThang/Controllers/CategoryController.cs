using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_NguyenQuangThang.Data;
using Day3_NguyenQuangThang.Models;

namespace Day3_NguyenQuangThang.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            var _categories = SeedData.categories;
            return View(_categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details([FromRoute] int id)
        {
            // lay ra category co id truyen vao tu SeedData
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            // neu category == null, tra ve trang loi
            if (category == null)
            {
                return NotFound();
            }
            // neu category != null, tra ve view va truyen category vao view
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Models.Category category)
        {
            if(ModelState.IsValid)
            {
                // lay ra id lon nhat trong danh sach SeedData.categories
                int maxId = SeedData.categories.Max(c => c.Id);
                // set id cho category
                category.Id = maxId + 1;
                // them category vao danh sach SeedData.categories
                SeedData.categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Models.Category category)
        {
            var existingCategory = SeedData.categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfig(int id)
        {
            var category = SeedData.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            SeedData.categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
