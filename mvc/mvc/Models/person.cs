using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    [Table("tblEmployee")]
    public class person
    {
        [System.ComponentModel.DataAnnotations.Key]
        
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int DepartmentId { get; set; }
    }
    [Table("tblDepartment")]
    public class Department
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string Name { get; set; }
        //public List<Employee> Employees { get; set; }
    }
}