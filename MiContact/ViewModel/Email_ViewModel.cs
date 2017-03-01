using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace MiContact.ViewModel
{
    public class Email_ViewModel
    {

        public int? BasicInfoID { get; set; }
        public int? EmailID { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]

        [Display(Name = "Email Type")]
        public string EmailType { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}