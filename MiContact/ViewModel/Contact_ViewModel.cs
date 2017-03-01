using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace MiContact.ViewModel
{
    public class Contact_ViewModel
    {
        //public int Contact_ViewModel()
        //{
        //    return ContactID == null ? 0 : (int)ContactID;
        //}

        public int? BasicInfoID { get; set; }
        public int? ContactID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string Number { get; set; }


        [Required]
        [Display(Name = "Contact Type")]
        public string ContactType { get; set; }
    }
}