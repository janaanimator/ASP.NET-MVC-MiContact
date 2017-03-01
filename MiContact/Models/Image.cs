using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiContact.Models
{
    [Table("Image")]
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        //public string ApplicationUserID { get; set; }

        public int BasicInfoID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string URL { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public byte Status { get; set; }
    }
}