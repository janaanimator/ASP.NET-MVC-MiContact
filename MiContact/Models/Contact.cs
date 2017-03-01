using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiContact.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
        //public string ApplicationUserID { get; set; }

        public int BasicInfoID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Number { get; set; }

        [StringLength(100)]
        public string ContactType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public byte Status { get; set; }
    }
}