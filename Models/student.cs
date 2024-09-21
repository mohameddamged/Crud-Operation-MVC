using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1.Models
{
    public class Student
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Std_Id { get; set; }
        [Required]
        [StringLength(15,MinimumLength =3)]
        public string ?Std_Name { get; set; }
        [Range(15,25)]
        public int Age { get; set; }
        //[EmailAddress]
        [Required]
        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        public string? Std_Email { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public bool Status { get; set; } = true;
        //public List<Course>? Courses { get; set; }
        public virtual Department ?Department { get; set; }
    }
}
