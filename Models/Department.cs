using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC1.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dept_Id { get; set; }
        [StringLength(15)]
        [Required]
        public string ?Dept_Name { get; set; }
        [Range(10,100)]
        public int Dept_Capacity { get; set; }
        public List<Student> ?Students { get; set; }
        public List<Course> ?Courses { get; set; }
        public bool Status { get; set; } = true;

    }
}
