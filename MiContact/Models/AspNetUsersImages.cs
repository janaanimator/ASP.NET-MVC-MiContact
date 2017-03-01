using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiContact.Models
{
    [Table("AspNetUsersImages")]
    public class AspNetUsersImages
    {
        public AspNetUsersImages()
        {
            CreatedOn = DateTime.Now;
            Status = 1;
            UpdateOn = DateTime.Now;
        }
        public int AspNetUsersImagesID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserID { get; set; }

        [StringLength(1000)]
        public string ImageURL { get; set; }

        [StringLength(1000)]
        public string ImageType { get; set; }

        [StringLength(50)]
        public string ToSetProfilePic { get; set; }

        [StringLength(50)]
        public string ToSetBannerPic { get; set; }
        public string ImageDescription { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}