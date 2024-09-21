using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1.Models
{
    public class Course
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Course_Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string? Course_Name { get; set; }
        [Range(30,60)]
        public int Course_duration { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public bool Status { get; set; } = true;
        //public List<Student>? Students { get; set; }
        public virtual Department? Department { get; set; }
    }
}
