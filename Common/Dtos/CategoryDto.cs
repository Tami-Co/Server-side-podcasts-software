using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class CategoryDto
    {
        public int? Id { get; set; } 
        public string? NameOfCategory { get; set; }
        public IFormFile? FileImage { get; set; }
        public string? UrlImage { get; set; }
        public virtual ICollection<LectureDto>? Lectures { get; set; }
    }
}
