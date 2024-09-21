using MVC1.Data;
using MVC1.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC1.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void DeleteById(int id);
        public void Add(Student std);
        public bool Update(Student Std);
    }
    class StudentRepo : IStudentRepo
    {
        ITIContext DB ;
        public StudentRepo(ITIContext _DB)
        {
            DB = _DB;
        }
        public void Add(Student Std)
        {
            DB.Add(Std);
            DB.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var Std = DB.Students.SingleOrDefault(ID => ID.Std_Id == id);
            Std.Status = false;
            DB.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return DB.Students.Include(S => S.Department).Where(A => A.Status == true).ToList();
        }

        public Student GetById(int id)
        {
            return DB.Students.SingleOrDefault(ID => ID.Std_Id == id);
        }

        public bool Update(Student Std)
        {
            Student existingStd = DB.Students.Find(Std.Std_Id);
            if (existingStd == null)
            {
                return false;
            }
            existingStd.Std_Name = Std.Std_Name;
            existingStd.Age = Std.Age;
            existingStd.Std_Email = Std.Std_Email;
            existingStd.Dept_Id = Std.Dept_Id;
            DB.SaveChanges();
            return true;
        }
    }
    class StudentRepo2 : IStudentRepo
    {
        static List<Student> Studs = new List<Student>();
        static List<Department> Depts = new List<Department>();
        public void Add(Student Std)
        {
            Studs.Add(Std);
        }

        public void DeleteById(int id)
        {
            var Std = Studs.SingleOrDefault(ID => ID.Std_Id == id);
            Studs.Remove(Std);
        }

        public List<Student> GetAll()
        {
            foreach (var student in Studs)
            {
                student.Department = Depts.SingleOrDefault(d => d.Dept_Id == student.Dept_Id);
            }
                return Studs;
        }
        public Student GetById(int id)
        {
            return  Studs.SingleOrDefault(ID => ID.Std_Id == id);
        }

        public bool Update(Student Std)
        {
            Student existingStd = Studs.Find(d => d.Std_Id == Std.Std_Id);
            if (existingStd == null)
            {
                return false;
            }
            existingStd.Std_Name = Std.Std_Name;
            existingStd.Age = Std.Age;
            existingStd.Std_Email = Std.Std_Email;
            existingStd.Dept_Id = Std.Dept_Id;
            return true;
        }
    }
}
