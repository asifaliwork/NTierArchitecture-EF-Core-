﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        [Required ]
        [Column("Name")]
        public string GenreName { get; set; }
       // public int DisplayOrder { get; set; }
    }
}
