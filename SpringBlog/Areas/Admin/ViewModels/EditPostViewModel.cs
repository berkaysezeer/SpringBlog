using SpringBlog.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Areas.Admin.ViewModels
{
    public class EditPostViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        [Display(Name = "Created")]
        public DateTime CreationTime { get; set; }
        [Display(Name = "Last Modified")]
        public DateTime ModificationTime { get; set; }

        public string CurrentFeaturedImage { get; set; }

        [PostedImage]
        public HttpPostedFileBase FeaturedImage { get; set; }

        [Display(Name = "Short Url")]
        [Required]
        [StringLength(200)]
        public string Slug { get; set; }

    }
}