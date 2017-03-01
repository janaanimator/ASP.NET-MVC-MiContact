using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.Sql;

namespace MiContact.ViewModel
{
    public class Image_ViewModel //: System.Web.UI.Page
    {
        public int? BasicInfoID { get; set; }
        public int? ImageID { get; set; }


        [Required]
        [Display(Name = "Image Name")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Image URL")]
        public string URL { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }

        public string TempPicURL { get; set; }

        public string GetImageFile(HttpPostedFileBase file)
        {
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

                return URL = imagePath;
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
}