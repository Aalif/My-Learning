using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace mvclearnn.Models
{

    //for myemployee
    [MetadataType(typeof(MyemployeeData))]
    public partial class Myemployee
    {

    }
    public class MyemployeeData
    {
        [Display(Name ="Employee Name")]
        [Required]
        public string Name { get; set; }
    }
    //for department
    [MetadataType(typeof(tblDepartmentMetadata))]
    public partial class tblDepartment
    {

    }
    public class tblDepartmentMetadata
    {
        [Display(Name = "Department Name")]
        public string Name { get; set; }

    }
    [MetadataType(typeof(tblEmployeeMetadata))]
    public partial class tblEmployee
    {
    }
    public class tblEmployeeMetadata
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name="Deparment")]
        public Nullable<int> DepartmentId { get; set; }
    }

}