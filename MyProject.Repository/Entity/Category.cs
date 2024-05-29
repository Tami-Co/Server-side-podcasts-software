using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Entity
{
    public class Category         
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }

        public string UrlImage { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}