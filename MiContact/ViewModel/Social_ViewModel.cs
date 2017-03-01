using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiContact.ViewModel
{
    public class Social_ViewModel
    {
        public int? BasicInfoID { get; set; }
        public int? SocialID { get; set; }

        [Required]
        [Display(Name = "Link Name")]
        public string Link { get; set; }

        [Required]
        [Display(Name = "Link URL")]
        public string URL { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}