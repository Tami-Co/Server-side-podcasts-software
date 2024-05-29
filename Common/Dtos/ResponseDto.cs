using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class ResponseDto
    {
        public int? Id{ get; set; }
        public string? ContentOfResponse { get; set; }
        public int? LectureId { get; set; }
        public virtual UserDto? User { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
    }
}
