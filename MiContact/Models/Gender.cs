using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiContact.Models
{
    [Table("Gender")]
    public class Gender
    {

        public int GenderID { get; set; }

        [Column("Gender")]
        [StringLength(100)]
        public string Name { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}