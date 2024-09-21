using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Models;
using MVC1.Repository;

namespace MVC1.Controllers
{
    public class StudentController : Controller
    {
        //CRUD
        IStudentRepo StudentRepo ;
        IDepartmentRepo DepartmentRepo;
        public StudentController (IDepartmentRepo _departmentRepo , IStudentRepo _studentRepo)
        {
            StudentRepo = _studentRepo;
            DepartmentRepo = _departmentRepo;
        }
        //student/create?stdid=100&&stdname=ali&&stdage=20&&deptid=100
        public IActionResult Create()
        {
            ViewBag.Depts = DepartmentRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student Std)
        {
            if (ModelState.IsValid)
            {
                StudentRepo.Add(Std);
                return RedirectToAction("Lst");
            }
            else
            {
                ViewBag.Depts = DepartmentRepo.GetAll();
                return View(Std);
            }
        }
        //student/Delete?stdid=100
        public IActionResult Delete(int StdId)
        {
            Student Std = StudentRepo.GetById(StdId);
            if (Std == null)
            {
                return NotFound();
            }
            StudentRepo.DeleteById(StdId);
            return RedirectToAction("Lst");
        }
        //student/read?stdid=100
        public IActionResult Read(int StdId)
        {
            Student Std = StudentRepo.GetById(StdId);
            if (Std == null)
            {
                return NotFound();
            }
            return View(Std);
        }
        [HttpPost]
        public IActionResult Read(Student Std)
        {
            Student existingStudent = StudentRepo.GetById(Std.Std_Id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            return RedirectToAction("Lst");
        }
        //student/update?stdid=100&&stdname=mohamed&&stdage=18&&deptid=200
        public IActionResult Update(int? StdId)
        {
            if (StdId == null)
                return BadRequest();
            Student Std = StudentRepo.GetById(StdId.Value);
            if (Std == null)
            {
                return NotFound();
            }
            ViewBag.Depts = DepartmentRepo.GetAll();
            return View(Std);
        }
        [HttpPost]
        public IActionResult Update(Student Std)
        {
            if(ModelState.IsValid)
            {
                StudentRepo.Update(Std);
                return RedirectToAction("Lst");
            }
            else 
            {
                ViewBag.Depts = DepartmentRepo.GetAll();
                return View(Std);
            }
        }
        //student/lst
        public IActionResult Lst()
        {
            var Result = StudentRepo.GetAll();
            return View(Result);
        }
    }
}
