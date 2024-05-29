using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    //מרצה!!!!!!
    public class LecturerDto
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? NumberViews { get; set; }

        //public IFormFile? FileImage { get; set; }
        //public string? UrlImage { get; set; }

    }
}
