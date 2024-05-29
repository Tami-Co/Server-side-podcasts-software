using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Entity
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? NumberViews { get; set; }

        //public string UrlImage { get; set; }
        //public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
