using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Entity
{
    public class Lecture
    {
        public int Id { get; set; }
        public string? NameLecture { get; set; }
        public string? Content { get; set; } 
        //ההרצאה עצמה
        public string? UrlLectureFile { get; set; }
        public string? LengthOfLecture { get; set; }

        public bool isVideo { get; set; }
        public DateTime UploadingDate { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int LecturerId { get; set; }
        [ForeignKey("LecturerId")]
        public virtual Lecturer Lecturer { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? NumberViews { get; set; }

    }
}
