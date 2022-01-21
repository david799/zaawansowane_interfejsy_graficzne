

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendFirmaKolejowa.db.model
{
    [Table("Ticket")]
    public class Ticket
    {
        public int id { get; set; }
        [Column("course_id")]
        public int course_id { get; set; }
        [Column("user_id")]
        public int user_id { get; set; }
        [Column("status")]
        public int status { get; set; }

    }

}
