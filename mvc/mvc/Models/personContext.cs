using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class personContext : DbContext
    {
        public DbSet<person> entityperson { get; set; }
        public DbSet<Department> entitydepartment { get; set; }
    }
}