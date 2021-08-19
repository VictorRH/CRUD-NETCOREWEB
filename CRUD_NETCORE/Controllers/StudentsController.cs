using CRUD_NETCORE.Data;
using CRUD_NETCORE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_NETCORE.Controllers
{
    public class StudentsController : Controller
    {
        private readonly CrudDbContext context;

        public StudentsController(CrudDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Students> listStudents = context.Students;

            return View(listStudents);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Students students)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(students);
                context.SaveChanges();
                TempData["message"] = "Successfully created student";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var validation = await context.Students.FindAsync(id);
            if (validation == null)
            {
                return NotFound();
            }
            return View(validation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Students students)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(students);
                context.SaveChanges();
                TempData["message"] = "Successfully update student";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var validation = await context.Students.FindAsync(id);
            if (validation == null)
            {
                return NotFound();
            }
            return View(validation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudents(int? id)
        {
            var validation = await context.Students.FindAsync(id);
            if (validation == null)
            {
                return NotFound();
            }

            context.Students.Remove(validation);
            context.SaveChanges();
            TempData["message"] = "Successfully delete student";
            return RedirectToAction("Index");

        }

    }
}
