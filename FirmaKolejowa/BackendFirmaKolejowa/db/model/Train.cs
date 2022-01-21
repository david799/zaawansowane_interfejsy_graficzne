using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendFirmaKolejowa.db.model
{
    [Table("Train")]
    public class Train
    {
        public int id { get; set; }
        [Column("is_active")]
        public bool is_active { get; set; }
        [Column("capacity")]
        public int capacity { get; set; }

        public virtual List<Course> courses { get; set; }

    }

}
