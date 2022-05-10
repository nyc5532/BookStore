﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    [Table("Slides")]

    public class Slide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(256)]
        public string Description { set; get; }

        [MaxLength(500)]
        public string Image { set; get; }

        [MaxLength(256)]
        public string Url { set; get; }
        public int? DisplayOrder { set; get; }
        public bool Status { set; get; }

        public string Content { set; get; }
    }
}
