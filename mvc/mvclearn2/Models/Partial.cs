using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace mvclearn2.Models
{
    [MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {
    }
    public class PersonMetadata
    {
        [StringLength(10,ErrorMessage ="Enter at least 5 alphabet", MinimumLength =3)]
        [Required(ErrorMessage ="Enter name")]
        
        public string LastName { get; set; }
    }
}