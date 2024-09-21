using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Models;
using MVC1.Repository;

namespace MVC1.Controllers
{
    public class CourseController : Controller
    {
        //CRUD
        //ITIContext DB = new ITIContext();
        ICourseRepo CourseRepo;
        IDepartmentRepo DepartmentRepo;
        public CourseController(ICourseRepo _courseRepo, IDepartmentRepo _departmentRepo)
        {
            CourseRepo = _courseRepo;
            DepartmentRepo = _departmentRepo;
        }
        public IActionResult Create()
        {
            ViewBag.Depts = DepartmentRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course Cru)
        {
            if (ModelState.IsValid)
            {
                CourseRepo.Add(Cru);
                return RedirectToAction("Lst");
            }
            else
            {
                ViewBag.Depts = DepartmentRepo.GetAll();
                return View(Cru);
            }
        }
        //[HttpPost][ActionName("Delete")]
        public IActionResult Delete(int CruId)
        {
            Course Cru = CourseRepo.GetById(CruId);
            if (Cru == null)
            {
                return NotFound();
            }
            CourseRepo.DeleteById(CruId);
            return RedirectToAction("Lst");
        }
        public IActionResult Read(int CruId)
        {
            Course Cru = CourseRepo.GetById(CruId);
            if (Cru == null)
            {
                return NotFound();
            }
            return View(Cru);
        }
        [HttpPost]
        public IActionResult Read(Course Cru)
        {
            Course existingCru = CourseRepo.GetById(Cru.Course_Id);
            if (existingCru == null)
            {
                return NotFound();
            }
            return RedirectToAction("Lst");
        }
        public IActionResult Update(int CruId)
        {
            Course Cru = CourseRepo.GetById(CruId);
            if (Cru == null)
            {
                return NotFound();
            }
            ViewBag.Depts = DepartmentRepo.GetAll();
            return View(Cru);
        }
        [HttpPost]
        public IActionResult Update(Course Cru)
        {
            if (ModelState.IsValid)
            {
                CourseRepo.Update(Cru);
                return RedirectToAction("Lst");
            }
            else
            {
                ViewBag.Depts = DepartmentRepo.GetAll();
                return View(Cru);
            }
        }
        public IActionResult Lst()
        {
            var Result = CourseRepo.GetAll();
            return View(Result);
        }

    }
}
