using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiContact.Models
{
    public class AspNetUsersProfile
    {
        public AspNetUsersProfile()
        {
            CreatedOn = DateTime.Now;
            Status = 1;
        }

        public int AspNetUsersProfileID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserID { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string Dob { get; set; }
        public Gender Gender { get; set; }
        public int GenderID { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }
        public string AboutMe { get; set; }

        public byte Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}