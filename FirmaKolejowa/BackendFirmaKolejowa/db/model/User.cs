﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendFirmaKolejowa.db.model
{
    [Table("User")]
    public class User
    {
        public int id { get; set; }
        [Column("nick")]
        public string nick { get; set; }
        [Column("password")]
        public string password { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("surname")]
        public string surname { get; set; }

    }

}
