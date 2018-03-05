using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anothermvc.Models
{
    public class addmodelviews
    {
        public IEnumerable<string> selectname { get; set; }
        public IEnumerable<SelectListItem> details { get; set; }
    }
}