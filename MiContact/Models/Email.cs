using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiContact.Models
{
    [Table("Email")]
    public class Email
    {
        [Key]
        public int EmailID { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        //public string ApplicationUserID { get; set; }
        public int BasicInfoID { get; set; }

        [StringLength(50)]
        [Column("Email")]
        public string Emails { get; set; }

        [StringLength(100)]
        public string EmailType { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public byte Status { get; set; }
    }
}