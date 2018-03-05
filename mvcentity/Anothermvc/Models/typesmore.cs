using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anothermvc.Models
{
    public class typesmore
    {
        public bool checking { get; set; }
        public string getdetails { get; set; }
        public List<PersonDetail> persondetail
        {
            get
            {
                learnEntities db = new learnEntities();
                return db.PersonDetails.ToList();
            }
        }
    }
}