using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiContact.Models
{
    [Table("BasicInfo")]
    public class BasicInfo
    {
        [Key]
        public int BasicInfoID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserID { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int GenderID { get; set; }

        [StringLength(50)]
        public string DateOfBirth { get; set; }

        [StringLength(1000)]
        public string Profession { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }
        public string AboutMe { get; set; }

        [StringLength(500)]
        public string ProfilePic { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public byte Status { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}