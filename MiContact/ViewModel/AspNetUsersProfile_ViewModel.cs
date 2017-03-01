using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MiContact.Models;

namespace MiContact.ViewModel
{
    public class AspNetUsersProfile_ViewModel
    {
        public int AspNetUsersProfileID { get; set; }

        public string ApplicationUserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Dob { get; set; }
        public IEnumerable<Gender> Genders { get; set; }

        [Required]
        public int GenderID { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string AboutMe { get; set; }
    }
}