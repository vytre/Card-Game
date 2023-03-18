﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
        public int Balance { get; set; }

        ICollection<Inventory>? Inventory { get; set; }
    }
}
