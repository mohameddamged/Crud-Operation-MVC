using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Models;

namespace MVC1.Repository
{
        public interface ICourseRepo
        {
            public List<Course> GetAll();
            public Course GetById(int id);
            public void DeleteById(int id);
            public void Add(Course Cru);
            public bool Update(Course Cru);
        }
        class CourseRepo : ICourseRepo
        {
            ITIContext DB;
            public CourseRepo(ITIContext _DB)
            {
                DB = _DB;
            }
            public void Add(Course Cru)
            {
                DB.Add(Cru);
                DB.SaveChanges();
            }

            public void DeleteById(int id)
            {
                var Cru = DB.Courses.SingleOrDefault(ID => ID.Course_Id == id);
                Cru.Status = false;
                DB.SaveChanges();
            }

            public List<Course> GetAll()
            {
                return DB.Courses.Include(C => C.Department).Where(A => A.Status == true).ToList();
            }

            public Course GetById(int id)
            {
                return DB.Courses.SingleOrDefault(ID => ID.Course_Id == id);
            }

            public bool Update(Course Cru)
            {
                Course existingCru = DB.Courses.Find(Cru.Course_Id);
                if (existingCru == null)
                {
                    return false;
                }
                existingCru.Course_Name = Cru.Course_Name;
                existingCru.Course_duration = Cru.Course_duration;
                existingCru.Dept_Id = Cru.Dept_Id;
                DB.SaveChanges();
                return true;
            }
        }
       class CourseRepo2 : ICourseRepo
    {
        static List<Course> Courses = new List<Course>();
        public void Add(Course Cru)
        {
            Courses.Add(Cru);
        }

        public void DeleteById(int id)
        {
            var Cru = Courses.SingleOrDefault(ID => ID.Course_Id == id);
            Courses.Remove(Cru);
        }

        public List<Course> GetAll()
        {
            return Courses;
        }

        public Course GetById(int id)
        {
            return Courses.SingleOrDefault(ID => ID.Course_Id == id);
        }

        public bool Update(Course Cru)
        {
            Course existingCru = Courses.Find(d => d.Course_Id == Cru.Course_Id);
            if (existingCru == null)
            {
                return false;
            }
            existingCru.Course_Name = Cru.Course_Name;
            existingCru.Course_duration = Cru.Course_duration;
            //DB.SaveChanges();
            return true;
        }
    }
}

