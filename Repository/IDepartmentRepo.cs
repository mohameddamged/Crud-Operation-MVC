using MVC1.Data;
using MVC1.Models;
namespace MVC1.Repository
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void DeleteById(int id);
        public void Add(Department Dept);
        public bool Update(Department Dept);
    }
    class DepartmentRepo : IDepartmentRepo
    {
        ITIContext DB ;
        public DepartmentRepo(ITIContext _DB)
        {
            DB = _DB;
        }
        public void Add(Department Dept)
        {
            DB.Add(Dept);
            DB.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var Dept = DB.Departments.SingleOrDefault(ID => ID.Dept_Id == id);
            Dept.Status = false;
            //DB.Departments.Remove(Dept);
            DB.SaveChanges ();
        }

        public List<Department> GetAll()
        {
            return DB.Departments.Where(D => D.Status == true).ToList();
        }

        public Department GetById(int id)
        {
            return DB.Departments.SingleOrDefault(ID => ID.Dept_Id == id);
        }

        public bool Update(Department Dept)
        {
            Department existingDept = DB.Departments.Find(Dept.Dept_Id);
            if (existingDept == null)
            {
                return false;
            }
            existingDept.Dept_Name = Dept.Dept_Name;
            existingDept.Dept_Capacity = Dept.Dept_Capacity;
            DB.SaveChanges();
            return true;
        }
    }
    class DepartmentRepo2 : IDepartmentRepo
    {
        static List<Department> Depts = new List<Department>();
        public void Add(Department Dept)
        {
            Depts.Add(Dept);
        }

        public void DeleteById(int id)
        {
            var Dept = Depts.SingleOrDefault(ID => ID.Dept_Id == id);
            Depts.Remove(Dept);
        }

        public List<Department> GetAll()
        {
            return Depts;
        }

        public Department GetById(int id)
        {
            return Depts.SingleOrDefault(ID => ID.Dept_Id == id);
        }

        public bool Update(Department Dept)
        {
            Department existingDept = Depts.Find(d => d.Dept_Id == Dept.Dept_Id);
            if (existingDept == null)
            {
                return false;
            }
            existingDept.Dept_Name = Dept.Dept_Name;
            existingDept.Dept_Capacity = Dept.Dept_Capacity;
            //DB.SaveChanges();
            return true;
        }
    }
}
