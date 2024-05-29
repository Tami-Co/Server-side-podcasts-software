using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Entity
{
    public class Response
    {
        public int Id { get; set; }
        public string ContentOfResponse { get; set; }
        public int LectureId { get; set; }
        //[ForeignKey("LectureId")]
        //public virtual Lecture Lecture { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        //לדאוג למחוק את כל הקשרים!!!!!!!!!!!
        public virtual User User { get; set; }
        public DateTime? Date { get; set; }

    }
}

