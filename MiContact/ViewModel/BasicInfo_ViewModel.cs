using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.Sql;
using MiContact.Models;

namespace MiContact.ViewModel
{
    public class BasicInfo_ViewModel
    {
        public int? BasicInfoID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Gender")]
        public int GenderID { get; set; }

        public IEnumerable<Gender> Genders { get; set; }


        [Required]
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }


        [Required]
        [Display(Name = "Profession")]
        public string Profession { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "About Me")]
        public string AboutMe { get; set; }

        [Display(Name = "Email Id")]
        public string Email { get; set; }


        [Display(Name = "Picture")]
        public string ProfilePic { get; set; }

        public string TempPicURL { get; set; }
        public string GetprofilePic(HttpPostedFileBase file)
        {
            //if (file.ContentLength > 0)
            if (file != null)
            {
                var filename = Path.GetFileName(file.FileName);
                string[] fn = filename.Split('.');

                var name = string.Format(@"{0}." + fn[1].ToString(), Guid.NewGuid());
                //string fnn = Name + "." + fn[1].ToString();

                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), name);

                file.SaveAs(path);
                string f1 = path.Substring(path.LastIndexOf("\\"));
                string[] split = f1.Split('\\');
                string newpath = split[1];
                string imagePath = "~/Uploads/" + newpath;

                return ProfilePic = imagePath;
            }
            else
            {

                if (TempPicURL == "" || TempPicURL == null)
                {
                    return "~/Uploads/DefaultProfile.jpg";
                }
                else
                {
                    return TempPicURL;
                }
            }
        }

    }

    public class BasicInfo_IE
    {
        public int? BasicInfoID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int GenderID { get; set; }
        public string DateOfBirth { get; set; }
        public string Profession { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string AboutMe { get; set; }
        public string Email { get; set; }

        public string ProfilePic { get; set; }
    }
}