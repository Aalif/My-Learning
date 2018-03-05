using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace mvcentity.Models
{
    [MetadataType(typeof(dmetadata))]
    public partial class Department
    {
    }
    public class dmetadata
    {
        [Display(Name = "DepartmentName")]
        public string Name { get; set; }
    }
    [MetadataType(typeof(emetdata))]
    public partial class Employee
    {

    }
    public class emetdata
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public Nullable<int> DepartmentId { get; set; }
      

    }
}