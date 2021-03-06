using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Web.Models
{
    public class CategoryViewModel
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }


        public string Description { set; get; }
        public int? ParentId { set; get; }
        [Required]
        public int? DisplayOrder { set; get; }


        public string Image { set; get; }
        public bool? HomeFlag { set; get; }

        public virtual IEnumerable<PostViewModel> Posts { set; get; }

        public DateTime? CreatedDate { set; get; }


        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }


        public string UpdatedBy { set; get; }


        public string MetaKeyword { set; get; }


        public string MetaDescription { set; get; }

        [Required]
        public bool Status { set; get; }
    }
}