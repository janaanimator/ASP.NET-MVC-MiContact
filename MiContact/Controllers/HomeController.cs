using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiContact.ViewModel;
using MiContact.Models;
using Microsoft.AspNet.Identity;

namespace MiContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _DbContext;
        public HomeController()
        {
            _DbContext = new ApplicationDbContext();
        }
        public string GetUserID()
        {
            return User.Identity.GetUserId();
        }
        public dynamic GetGender()
        {
            var md = _DbContext.Genders.Where(g => g.Status == 1).ToList();
            return md;
        }
        public dynamic GetBasic(int? Id)
        {
            var userid = Id;//GetUserID();
            var ds = _DbContext.BasicInfos.SingleOrDefault(g => g.BasicInfoID == userid);


            Session["BasicInfoID"] = ds.BasicInfoID;

            var mdd = new BasicInfo_ViewModel
            {
                AboutMe = ds.AboutMe,
                Address = ds.Address,
                BasicInfoID = ds.BasicInfoID,
                DateOfBirth = ds.DateOfBirth,
                FirstName = ds.FirstName,
                GenderID = ds.GenderID,
                LastName = ds.LastName,
                Mobile = ds.Mobile,
                Profession = ds.Profession,
                Email = ds.Email,
                ProfilePic = ds.ProfilePic == null ? "~/Uploads/DefaultProfile.jpg" : ds.ProfilePic,
                TempPicURL = ds.ProfilePic,
                Genders = GetGender()
            };

            return mdd;
        }

        [Authorize]
        public ActionResult Index()
        {
            Session["BasicInfoID"] = null;
            var userid = GetUserID();
            IEnumerable<BasicInfo_IE> basiclist = (from b in _DbContext.BasicInfos
                                                   where b.ApplicationUserID == userid
                                                   where b.Status == 1
                                                   select new BasicInfo_IE
                                                   {
                                                       AboutMe = b.AboutMe,
                                                       Address = b.Address,
                                                       BasicInfoID = b.BasicInfoID,
                                                       DateOfBirth = b.DateOfBirth,
                                                       FirstName = b.FirstName,
                                                       //GenderID = b.GenderID,
                                                       LastName = b.LastName,
                                                       Mobile = b.Mobile,
                                                       Profession = b.Profession,
                                                       Email = b.Email,
                                                       ProfilePic = b.ProfilePic == null ? "~/Uploads/DefaultProfile.jpg" : b.ProfilePic == "" ? "~/Uploads/DefaultProfile.jpg" : b.ProfilePic,
                                                   }).ToList();

            return View(basiclist.ToList());
        }
        public ActionResult About(int? Id)
        {
            if (Id != null)
            {
                var model = new ContactBig_ViewModel
                {
                    BasicInfo = GetBasic(Id),
                    Contact_IE = GetContact_IE(Id),
                    Social_IE = GetSocial_IE(Id),
                    Email_IE = GetEmail_IE(Id),
                    Image_IE = GetImage_IE(Id),
                };
                return View("About", model);

            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int? Id)
        {
            var model = new ContactBig_ViewModel
            {
                BasicInfo = GetBasic(Id),
                Contact_IE = GetContact_IE(Id),
                Social_IE = GetSocial_IE(Id),
                Email_IE = GetEmail_IE(Id),
                Image_IE = GetImage_IE(Id),

                BasicAction = "BasicUpdate",
                BasicActive = "active",
                BasicBtn = "Update",

                ContactAction = "ContactInsert",
                ContactActive = "",
                ContactBtn = "Add",

                SocialAction = "SocialInsert",
                SocialActive = "",
                SocialBtn = "Add",

                EmailAction = "EmailInsert",
                EmailActive = "",
                EmailBtn = "Add",

                ImageAction = "ImageInsert",
                ImageActive = "",
                ImageBtn = "Upload"
            };
            return View("Contact", model);

        }
        public ActionResult Delete(int? Id)
        {
            var ds = _DbContext.BasicInfos.Find(Id);
            ds.Status = 0;
            _DbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public dynamic GetBasic()
        {
            var userid = GetUserID();


            int id = int.Parse(_DbContext
                    .BasicInfos
                    .OrderByDescending(g => g.BasicInfoID)
                    .Where(g => g.ApplicationUserID == userid)
                    .Select(g => g.BasicInfoID)
                    .First().ToString());

            var ds = _DbContext.BasicInfos.SingleOrDefault(g => g.BasicInfoID == id);

            Session["BasicInfoID"] = 0;

            var md = new BasicInfo_ViewModel
            {
                Genders = GetGender(),
                BasicInfoID = Convert.ToInt32(Session["BasicInfoID"])
            };

            return md;
        }
        public dynamic GetContact_IE(int? Id)
        {
            var basicinfoid = GetBasicInfoID();
            var ds = (from c in _DbContext.Contacts
                      where c.Status == 1
                      where c.BasicInfoID == Id
                      select new Contact_ViewModel
                      {
                          ContactType = c.ContactType,
                          Name = c.Name,
                          Number = c.Number,
                          ContactID = c.ContactID
                      }).ToList();
            return ds;
        }
        public dynamic GetSocial_IE(int? Id)
        {
            var basicinfoid = GetBasicInfoID();
            var ds = (from s in _DbContext.Social
                      where s.Status == 1
                      where s.BasicInfoID == Id
                      select new Social_ViewModel
                      {
                          SocialID = s.SocialID,
                          Description = s.Description,
                          Link = s.Link,
                          URL = s.URL

                      }).ToList();
            return ds;
        }
        public dynamic GetEmail_IE(int? Id)
        {
            var basicinfoid = GetBasicInfoID();
            var ds = (from e in _DbContext.Emails
                      where e.BasicInfoID == Id
                      where e.Status == 1
                      select new Email_ViewModel
                      {
                          EmailID = e.EmailID,
                          Description = e.Description,
                          Email = e.Emails,
                          EmailType = e.EmailType
                      }).ToList();
            return ds;
        }
        public dynamic GetImage_IE(int? Id)
        {
            var basicinfoid = GetBasicInfoID();
            var ds = (from i in _DbContext.Images
                      where i.Status == 1
                      where i.BasicInfoID == Id
                      select new Image_ViewModel
                      {
                          ImageID = i.ImageID,
                          Description = i.Description,
                          Name = i.Name,
                          URL = i.URL

                      }).ToList();
            return ds;
        }
        public int GetBasicInfoID()
        {
            return Convert.ToInt32(Session["BasicInfoID"]);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public dynamic GetContact_IE(int? Id)
        //{
        //    var basicinfoid = Id;
        //    var ds = (from c in _DbContext.Contacts
        //              where c.Status == 1
        //              where c.BasicInfoID == basicinfoid
        //              select new Contact_ViewModel
        //              {
        //                  ContactType = c.ContactType,
        //                  Name = c.Name,
        //                  Number = c.Number,
        //                  ContactID = c.ContactID
        //              }).ToList();
        //    return ds;
        //}
        //public dynamic GetSocial_IE(int? Id)
        //{
        //    var basicinfoid = Id;
        //    var ds = (from s in _DbContext.Social
        //              where s.Status == 1
        //              where s.BasicInfoID == basicinfoid
        //              select new Social_ViewModel
        //              {
        //                  SocialID = s.SocialID,
        //                  Description = s.Description,
        //                  Link = s.Link,
        //                  URL = s.URL

        //              }).ToList();
        //    return ds;
        //}
        //public dynamic GetEmail_IE(int? Id)
        //{
        //    var basicinfoid = Id;
        //    var ds = (from e in _DbContext.Emails
        //              where e.BasicInfoID == basicinfoid
        //              where e.Status == 1
        //              select new Email_ViewModel
        //              {
        //                  EmailID = e.EmailID,
        //                  Description = e.Description,
        //                  Email = e.Emails,
        //                  EmailType = e.EmailType
        //              }).ToList();
        //    return ds;
        //}
        //public dynamic GetImage_IE(int? Id)
        //{
        //    var basicinfoid = Id;
        //    var ds = (from i in _DbContext.Images
        //              where i.Status == 1
        //              where i.BasicInfoID == basicinfoid
        //              select new Image_ViewModel
        //              {
        //                  ImageID = i.ImageID,
        //                  Description = i.Description,
        //                  Name = i.Name,
        //                  URL = i.URL

        //              }).ToList();
        //    return ds;
        //}
    }
}