using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeesAndDepartmentsAPI.Models
{
    public class Employee
    {

        [Column("EmployeeId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee First Name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        [MaxLength(11, ErrorMessage = "Maximum length for mobile is 11 characters.")]
        public string Mobile { get; set; }
        public string Photo { get; set; }
        public ICollection<FamilyMember> FamilyMembers { get; set; }
        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
