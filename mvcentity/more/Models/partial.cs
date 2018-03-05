using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace more.Models
{
    
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {

    }
    public class PersonMetadata
    {
        [HiddenInput(DisplayValue = false)]
        
        public string PersonID { get; set; }
        [Display(Name ="Last Name")]
        [DisplayFormat(NullDisplayText = "Name does not exist")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        [DisplayFormat(NullDisplayText = "Name does not exist")]
        public string FirstName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy }",ApplyFormatInEditMode =true)]
        public Nullable<System.DateTime> date { get; set; }
    }
}