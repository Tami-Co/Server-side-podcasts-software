using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{


    public class LectureDto
    {
        public int? Id { get; set; }
        public string NameLecture { get; set; }
        public string? Content { get; set; }

        //ההרצאה עצמה
        public IFormFile? LectureFile { get; set; }
        public string? UrlLectureFile { get; set; }

        public string? LengthOfLecture { get; set; }

        public bool? isVideo { get; set; }
        public DateTime? UploadingDate { get; set; }
        public int? CategoryId { get; set; } 
        public virtual LecturerDto? Lecturer { get; set; }

        public int? LecturerId { get; set; }
        public int? UserId { get; set; }
        public virtual ICollection<ResponseDto>? Responses { get; set; }
        public int? NumberViews { get; set; }

    }
}
