using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using MVC1.Data;
using MVC1.Models;
using MVC1.Repository;

namespace MVC1.Controllers
{
    public class DepartmentController : Controller
    {
        //CRUD
        //ITIContext DB = new ITIContext();
        IDepartmentRepo DepartmentRepo;
        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            DepartmentRepo = _departmentRepo;
        }

        //department/create?deptid=100&&deptname=cs&&deptcap=50
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department Dept)
        {
            if(ModelState.IsValid)
            {
                DepartmentRepo.Add(Dept);
                return RedirectToAction("Lst");
            }
            else
            {
                return View();
            }
        }      
        //[HttpPost][ActionName("Delete")]
        public IActionResult Delete(int DeptId) 
        {
            Department Dept = DepartmentRepo.GetById(DeptId);
            if (Dept == null)
            {
                return NotFound();
            }
            DepartmentRepo.DeleteById(DeptId);
            return RedirectToAction("Lst");
        }
        public IActionResult Read(int DeptId)
        {
            Department Dept = DepartmentRepo.GetById(DeptId);
            if (Dept == null)
            {
                return NotFound();
            }
            return View(Dept);
        }
        [HttpPost]
        public IActionResult Read(Department Dept)
        { 
            Department existingDept = DepartmentRepo.GetById(Dept.Dept_Id);
            if (existingDept == null)
            {
                return NotFound();
            }
            return RedirectToAction("Lst");
        }
        public IActionResult Update(int DeptId)
        {
            Department Dept = DepartmentRepo.GetById(DeptId);
            if (Dept == null)
            {
                return NotFound();
            }
            return View(Dept);
        }
        [HttpPost]
        public IActionResult Update(Department Dept)
        {
            if(ModelState.IsValid)
            {
                DepartmentRepo.Update(Dept);
                return RedirectToAction("Lst");
            }
            else
            {
                return View(Dept);
            }
        }
        public IActionResult Lst()
        {
            var Result = DepartmentRepo.GetAll();
            return View(Result);
        }
    }
}
