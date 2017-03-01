using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiContact.ViewModel;
using MiContact.Models;
using Microsoft.AspNet.Identity;
using System.Web.Routing;

namespace MiContact.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _DbContext;


        public ContactController()
        {
            _DbContext = new ApplicationDbContext();
        }

        #region Basic
        public dynamic GetGender()
        {
            var md = _DbContext.Genders.Where(g => g.Status == 1).ToList();
            return md;
        }
        public dynamic GetBasic(bool isSaved)
        {
            var userid = GetUserID();

            if (isSaved != true)
            {
                Session["BasicInfoID"] = 0;
                var md = new BasicInfo_ViewModel
                {
                    Genders = GetGender(),
                    BasicInfoID = Convert.ToInt32(Session["BasicInfoID"])
                };
                return md;
            }
            else
            {
                int Uid = Convert.ToInt32(Session["BasicInfoID"]);

                var ds = _DbContext.BasicInfos.Where(g => g.BasicInfoID == Uid).FirstOrDefault();

                var md = new BasicInfo_ViewModel
                {
                    Genders = GetGender(),
                    AboutMe = ds.AboutMe,
                    Address = ds.Address,
                    DateOfBirth = ds.DateOfBirth,
                    FirstName = ds.FirstName,
                    GenderID = ds.GenderID,
                    LastName = ds.LastName,
                    Mobile = ds.Mobile,
                    Profession = ds.Profession,
                    ProfilePic = ds.ProfilePic,
                    Email = ds.Email,
                    BasicInfoID = Convert.ToInt32(Session["BasicInfoID"])
                };
                return md;
            }

        }
        public string GetUserID()
        {
            return User.Identity.GetUserId();
        }
        public int GetBasicInfoID()
        {
            return Convert.ToInt32(Session["BasicInfoID"]);
        }
        public ActionResult BasicInsert(ContactBig_ViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var md = new BasicInfo
                {
                    ApplicationUserID = GetUserID(),
                    FirstName = model.BasicInfo.FirstName,
                    LastName = model.BasicInfo.LastName,
                    GenderID = model.BasicInfo.GenderID,
                    DateOfBirth = model.BasicInfo.DateOfBirth,
                    Address = model.BasicInfo.Address,
                    Mobile = model.BasicInfo.Mobile,
                    Profession = model.BasicInfo.Profession,
                    AboutMe = model.BasicInfo.AboutMe,
                    Email = model.BasicInfo.Email,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    ProfilePic = model.BasicInfo.GetprofilePic(file),
                    Status = 1,
                };

                _DbContext.BasicInfos.Add(md);
                _DbContext.SaveChanges();

                Session["BasicInfoID"] = md.BasicInfoID;

                //return RedirectToAction("Contact", new { isSaved = true });
                return RedirectToAction("Contact", new { isSaved = true, basincbtn = "Update" });
            }
            else
            {
                return RedirectToAction("Contact", new { isSaved = true });
            }
        }
        public ActionResult BasicUpdate(ContactBig_ViewModel model, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ds = _DbContext.BasicInfos.Find(model.BasicInfo.BasicInfoID);

                    ds.FirstName = model.BasicInfo.FirstName;
                    ds.LastName = model.BasicInfo.LastName;
                    ds.GenderID = model.BasicInfo.GenderID;
                    ds.DateOfBirth = model.BasicInfo.DateOfBirth;
                    ds.Address = model.BasicInfo.Address;
                    ds.Mobile = model.BasicInfo.Mobile;
                    ds.Profession = model.BasicInfo.Profession;
                    ds.AboutMe = model.BasicInfo.AboutMe;
                    ds.ProfilePic = model.BasicInfo.GetprofilePic(file);
                    ds.Email = model.BasicInfo.Email;
                    ds.UpdatedOn = DateTime.Now;

                    _DbContext.SaveChanges();
                    Session["BasicInfoID"] = model.BasicInfo.BasicInfoID;

                    return RedirectToAction("Contact", new { isSaved = true, basincbtn = "Update" });
                }
                else
                {
                    return RedirectToAction("Contact", new { isSaved = true });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact", new { isSaved = true });
            }
        }
        #endregion

        #region Contact
        [Authorize]
        public ActionResult Contact(bool isSaved, string basincbtn)
        {

            string _basicBtn, _basicAction;
            if (basincbtn == "Update")
            {
                _basicBtn = "Update";
                _basicAction = "BasicUpdate";
            }
            else
            {
                _basicBtn = "Save Changes";
                _basicAction = "BasicInsert";
            }

            var model = new ContactBig_ViewModel
            {
                BasicInfo = GetBasic(isSaved),
                Contact_IE = GetContact_IE(),
                Social_IE = GetSocial_IE(),
                Email_IE = GetEmail_IE(),
                Image_IE = GetImage_IE(),

                BasicAction = _basicAction,
                BasicActive = "active",

                BasicBtn = _basicBtn,

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
        public ActionResult ContactInsert(ContactBig_ViewModel model)
        {
            var basicinfoid = GetBasicInfoID();
            try
            {
                if (ModelState.IsValid)
                {
                    var md = new Contact
                    {
                        BasicInfoID = basicinfoid,
                        ContactType = model.Contact.ContactType,
                        Name = model.Contact.Name,
                        Number = model.Contact.Number,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now,
                        Status = 1
                    };
                    _DbContext.Contacts.Add(md);
                    _DbContext.SaveChanges();
                    return RedirectToAction("GetContact", new { basincbtn = "Update" });
                }
                else
                {
                    return RedirectToAction("GetContact", new { basincbtn = "Update" });
                }
            }
            catch (Exception ex) { return RedirectToAction("Contact"); }
        }
        public ActionResult ContactUpdate(ContactBig_ViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ds = _DbContext.Contacts.Find(model.Contact.ContactID);
                    ds.ContactType = model.Contact.ContactType;
                    ds.Name = model.Contact.Name;
                    ds.Number = model.Contact.Number;
                    ds.UpdatedOn = DateTime.Now;
                    _DbContext.SaveChanges();

                    return RedirectToAction("GetContact", new { basincbtn = "Update" });
                }
                else
                {
                    return RedirectToAction("GetContact", new { basincbtn = "Update" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
        public ActionResult ContactDelete(int? Id)
        {
            try
            {
                var ds = _DbContext.Contacts.Find(Id);
                ds.Status = 0;
                _DbContext.SaveChanges();

                return RedirectToAction("GetContact");
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetContact");

            }
        }
        public ActionResult ContactEdit(int? Id)
        {
            try
            {
                var con = _DbContext.Contacts.Find(Id);
                var cnt = new Contact_ViewModel
                {
                    ContactID = con.ContactID,
                    ContactType = con.ContactType,
                    Name = con.Name,
                    Number = con.Number,
                };
                var ct = new ContactBig_ViewModel
                {
                    Contact = cnt,
                    BasicInfo = GetBasic(true),
                    Contact_IE = GetContact_IE(),
                    Social_IE = GetSocial_IE(),
                    Email_IE = GetEmail_IE(),
                    Image_IE = GetImage_IE(),

                    BasicAction = "BasicInsert",
                    BasicActive = "",
                    BasicBtn = "Save Changes",

                    ContactAction = "ContactUpdate",
                    ContactActive = "active",
                    ContactBtn = "Update",

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

                return View("Contact", ct);
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetContact");
            }
        }
        public dynamic GetContact_IE()
        {
            var basicinfoid = GetBasicInfoID();
            var ds = (from c in _DbContext.Contacts
                      where c.Status == 1
                      where c.BasicInfoID == basicinfoid
                      select new Contact_ViewModel
                      {
                          ContactType = c.ContactType,
                          Name = c.Name,
                          Number = c.Number,
                          ContactID = c.ContactID
                      }).ToList();
            return ds;
        }
        public ActionResult GetContact(string basincbtn)
        {
            try
            {
                //var gen = new BasicInfo_ViewModel { Genders = GetGender() };

                string _basicBtn, _basicAction;
                if (basincbtn == "Update")
                {
                    _basicBtn = "Update";
                    _basicAction = "BasicUpdate";
                }
                else
                {
                    _basicBtn = "Save Changes";
                    _basicAction = "BasicInsert";
                }

                var cot = new ContactBig_ViewModel
                {
                    BasicInfo = GetBasic(true),
                    Contact_IE = GetContact_IE(),
                    Social_IE = GetSocial_IE(),
                    Email_IE = GetEmail_IE(),
                    Image_IE = GetImage_IE(),

                    BasicAction = _basicAction,
                    BasicActive = "",
                    BasicBtn = _basicBtn,

                    ContactAction = "ContactInsert",
                    ContactActive = "active",
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

                return View("Contact", cot);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }

        #endregion Contact

        #region Social
        public ActionResult SocialInsert(ContactBig_ViewModel model)
        {
            var basicinfoid = GetBasicInfoID();
            try
            {
                if (ModelState.IsValid)
                {
                    var social = new Social
                    {
                        BasicInfoID = basicinfoid,
                        Description = model.Social.Description,
                        Link = model.Social.Link,
                        Status = 1,
                        URL = model.Social.URL,
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    };

                    _DbContext.Social.Add(social);
                    _DbContext.SaveChanges();

                    return RedirectToAction("Social", new { basincbtn = "Update" });
                }
                else
                {
                    return RedirectToAction("Social", new { basincbtn = "Update" });
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
        public ActionResult SocialEdit(int? Id, string basincbtn)
        {
            try
            {

                string _basicBtn, _basicAction;
                if (basincbtn == "Update")
                {
                    _basicBtn = "Update";
                    _basicAction = "BasicUpdate";
                }
                else
                {
                    _basicBtn = "Save Changes";
                    _basicAction = "BasicInsert";
                }

                if (Id != null)
                {
                    var dt = _DbContext.Social.Find(Id);
                    var social = new Social_ViewModel
                    {
                        SocialID = dt.SocialID,
                        Description = dt.Description,
                        Link = dt.Link,
                        URL = dt.URL
                    };

                    var model = new ContactBig_ViewModel
                    {
                        Social = social,
                        BasicInfo = GetBasic(true),
                        Contact_IE = GetContact_IE(),
                        Social_IE = GetSocial_IE(),
                        Email_IE = GetEmail_IE(),
                        Image_IE = GetImage_IE(),

                        BasicAction = _basicAction,
                        BasicActive = "",
                        BasicBtn = _basicBtn,

                        ContactAction = "ContactInsert",
                        ContactActive = "",
                        ContactBtn = "Add",

                        SocialAction = "SocialUpdate",
                        SocialActive = "active",
                        SocialBtn = "Update",

                        EmailAction = "EmailInsert",
                        EmailActive = "",
                        EmailBtn = "Add",

                        ImageAction = "ImageInsert",
                        ImageActive = "",
                        ImageBtn = "Upload"
                    };

                    return View("Contact", model);
                }
                else
                {
                    return RedirectToAction("Contact");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
        public ActionResult SocialUpdate(ContactBig_ViewModel model)
        {
            try
            {
                if (model.Social.SocialID != null)
                {
                    var data = _DbContext.Social.Find(model.Social.SocialID);
                    data.Description = model.Social.Description;
                    data.Link = model.Social.Link;
                    data.LinkType = model.Social.Link;
                    data.URL = model.Social.URL;
                    data.UpdatedOn = DateTime.Now;

                    _DbContext.SaveChanges();

                    return RedirectToAction("Social", new { basincbtn = "Update" });
                }
                else
                {
                    return RedirectToAction("Social", new { basincbtn = "Update" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
        public ActionResult SocialDelete(int? Id)
        {
            try
            {
                if (Id != null)
                {
                    var ds = _DbContext.Social.Find(Id);
                    ds.Status = 0;
                    ds.UpdatedOn = DateTime.Now;
                    _DbContext.SaveChanges();

                    return RedirectToAction("Social", new { basincbtn = "Update" });
                }
                else
                {
                    return RedirectToAction("Social", new { basincbtn = "Update" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Social");
            }
        }
        public ActionResult Social(string basincbtn)
        {
            try
            {
                string _basicBtn, _basicAction;
                if (basincbtn == "Update")
                {
                    _basicBtn = "Update";
                    _basicAction = "BasicUpdate";
                }
                else
                {
                    _basicBtn = "Save Changes";
                    _basicAction = "BasicInsert";
                }

                var social = new ContactBig_ViewModel
                {
                    BasicInfo = GetBasic(true),
                    Contact_IE = GetContact_IE(),
                    Social_IE = GetSocial_IE(),
                    Email_IE = GetEmail_IE(),
                    Image_IE = GetImage_IE(),

                    BasicAction = _basicAction,
                    BasicActive = "",
                    BasicBtn = _basicBtn,

                    ContactAction = "ContactInsert",
                    ContactActive = "",
                    ContactBtn = "Add",

                    SocialAction = "SocialInsert",
                    SocialActive = "active",
                    SocialBtn = "Add",

                    EmailAction = "EmailInsert",
                    EmailActive = "",
                    EmailBtn = "Add",

                    ImageAction = "ImageInsert",
                    ImageActive = "",
                    ImageBtn = "Upload"
                };
                return View("Contact", social);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
        public dynamic GetSocial_IE()
        {
            var basicinfoid = GetBasicInfoID();
            var ds = (from s in _DbContext.Social
                      where s.Status == 1
                      where s.BasicInfoID == basicinfoid
                      select new Social_ViewModel
                      {
                          SocialID = s.SocialID,
                          Description = s.Description,
                          Link = s.Link,
                          URL = s.URL

                      }).ToList();
            return ds;
        }

        #endregion Social

        #region Email
        public ActionResult Email(string basincbtn)
        {
            try
            {
                string _basicBtn, _basicAction;
                if (basincbtn == "Update")
                {
                    _basicBtn = "Update";
                    _basicAction = "BasicUpdate";
                }
                else
                {
                    _basicBtn = "Save Changes";
                    _basicAction = "BasicInsert";
                }

                var model = new ContactBig_ViewModel
                {
                    BasicInfo = GetBasic(true),
                    Contact_IE = GetContact_IE(),
                    Social_IE = GetSocial_IE(),
                    Email_IE = GetEmail_IE(),
                    Image_IE = GetImage_IE(),

                    BasicAction = _basicAction,
                    BasicActive = "",
                    BasicBtn = _basicBtn,

                    ContactAction = "ContactInsert",
                    ContactActive = "",
                    ContactBtn = "Add",

                    SocialAction = "SocialInsert",
                    SocialActive = "",
                    SocialBtn = "Add",

                    EmailAction = "EmailInsert",
                    EmailActive = "active",
                    EmailBtn = "Add",

                    ImageAction = "ImageInsert",
                    ImageActive = "",
                    ImageBtn = "Upload"

                };
                return View("Contact", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
        public ActionResult EmailInsert(ContactBig_ViewModel model)
        {
            var basicinfoid = GetBasicInfoID();
            try
            {
                if (ModelState.IsValid)
                {
                    var md = new Email
                    {
                        BasicInfoID = basicinfoid,
                        Emails = model.Email.Email,
                        EmailType = model.Email.EmailType,
                        Description = model.Email.Description,
                        Status = 1,
                        UpdatedOn = DateTime.Now,
                        CreatedOn = DateTime.Now
                    };

                    _DbContext.Emails.Add(md);
                    _DbContext.SaveChanges();

                    return RedirectToAction("Email", new { basincbtn = "Update" });
                }
                else
                {
                    return RedirectToAction("Email", new { basincbtn = "Update" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
        public ActionResult EmailUpdate(ContactBig_ViewModel model)
        {
            try
            {
                var ds = _DbContext.Emails.Find(model.Email.EmailID);
                ds.Description = model.Email.Description;
                ds.Emails = model.Email.Email;
                ds.EmailType = model.Email.EmailType;
                _DbContext.SaveChanges();

                return RedirectToAction("Email", new { basincbtn = "Update" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Email", new { basincbtn = "Update" });
            }
        }
        public ActionResult EmailEdit(int? Id)
        {
            try
            {



                var ds = _DbContext.Emails.Find(Id);
                var emil = new Email_ViewModel
                {
                    EmailID = ds.EmailID,
                    Description = ds.Description,
                    Email = ds.Emails,
                    EmailType = ds.EmailType
                };

                var md = new ContactBig_ViewModel
                {
                    BasicInfo = GetBasic(true),
                    Contact_IE = GetContact_IE(),
                    Email_IE = GetEmail_IE(),
                    Social_IE = GetSocial_IE(),
                    Image_IE = GetImage_IE(),
                    Email = emil,

                    BasicAction = "BasicInsert",
                    BasicActive = "",
                    BasicBtn = "Save Changes",

                    ContactAction = "ContactInsert",
                    ContactActive = "",
                    ContactBtn = "Add",

                    SocialAction = "SocialInsert",
                    SocialActive = "",
                    SocialBtn = "Add",

                    EmailAction = "EmailUpdate",
                    EmailActive = "active",
                    EmailBtn = "Update",

                    ImageAction = "ImageInsert",
                    ImageActive = "",
                    ImageBtn = "Upload"
                };

                return View("Contact", md);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Email");
            }
        }
        public ActionResult EmailDelete(int? Id)
        {
            try
            {
                var ds = _DbContext.Emails.Find(Id);
                ds.Status = 0;
                _DbContext.SaveChanges();

                return RedirectToAction("Email", new { basincbtn = "Update" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Email", new { basincbtn = "Update" });
            }
        }
        public dynamic GetEmail_IE()
        {
            var basicinfoid = GetBasicInfoID();
            var ds = (from e in _DbContext.Emails
                      where e.BasicInfoID == basicinfoid
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
        #endregion

        #region Image
        public dynamic GetImage_IE()
        {
            var basicinfoid = GetBasicInfoID();
            var ds = (from i in _DbContext.Images
                      where i.Status == 1
                      where i.BasicInfoID == basicinfoid
                      select new Image_ViewModel
                      {
                          ImageID = i.ImageID,
                          Description = i.Description,
                          Name = i.Name,
                          URL = i.URL
                      }).ToList();
            return ds;
        }
        public ActionResult Image(string basincbtn)
        {
            try
            {
                string _basicBtn, _basicAction;
                if (basincbtn == "Update")
                {
                    _basicBtn = "Update";
                    _basicAction = "BasicUpdate";
                }
                else
                {
                    _basicBtn = "Save Changes";
                    _basicAction = "BasicInsert";
                }

                var model = new ContactBig_ViewModel
                {
                    BasicInfo = GetBasic(true),
                    Contact_IE = GetContact_IE(),
                    Social_IE = GetSocial_IE(),
                    Email_IE = GetEmail_IE(),
                    Image_IE = GetImage_IE(),

                    BasicAction = _basicAction,
                    BasicActive = "",
                    BasicBtn = _basicBtn,

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
                    ImageActive = "active",
                    ImageBtn = "Upload"
                };

                return View("Contact", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }

        [HttpPost]
        public ActionResult ImageInsert(ContactBig_ViewModel model, HttpPostedFileBase file)
        {
            var basicinfoid = GetBasicInfoID();
            try
            {
                if (!ModelState.IsValid)
                {
                    var md = new Image
                    {
                        BasicInfoID = basicinfoid,
                        CreatedOn = DateTime.Now,
                        Description = model.Image.Description,
                        Name = model.Image.Name,
                        UpdatedOn = DateTime.Now,
                        Status = 1,
                        URL = model.Image.GetImageFile(file),
                    };

                    _DbContext.Images.Add(md);
                    _DbContext.SaveChanges();

                    return RedirectToAction("Image", new { basincbtn = "Update" });
                }
                else
                {
                    return RedirectToAction("Image", new { basincbtn = "Update" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
        public ActionResult ImageDelete(int? Id)
        {
            if (Id != null)
            {


                var img = _DbContext.Images.Find(Id);
                img.Status = 0;

                _DbContext.SaveChanges();

                return RedirectToAction("Image");
            }
            else
            {
                return RedirectToAction("Image");
            }

        }
        public ActionResult ImageEdit(int? Id)
        {
            if (Id != null)
            {

                var img = _DbContext.Images.Find(Id);
                var image = new Image_ViewModel
                {
                    ImageID = img.ImageID,
                    Description = img.Description,
                    Name = img.Name,
                    TempPicURL = img.URL
                };

                var model = new ContactBig_ViewModel
                {
                    BasicInfo = GetBasic(true),
                    Contact_IE = GetContact_IE(),
                    Social_IE = GetSocial_IE(),
                    Email_IE = GetEmail_IE(),
                    Image_IE = GetImage_IE(),
                    Image = image,

                    BasicAction = "BasicInsert",
                    BasicActive = "",
                    BasicBtn = "Save Changes",

                    ContactAction = "ContactInsert",
                    ContactActive = "",
                    ContactBtn = "Add",

                    SocialAction = "SocialInsert",
                    SocialActive = "",
                    SocialBtn = "Add",

                    EmailAction = "EmailInsert",
                    EmailActive = "",
                    EmailBtn = "Add",

                    ImageAction = "ImageUpdate",
                    ImageActive = "active",
                    ImageBtn = "Upload"
                };

                return View("Contact", model);
            }
            else
            {
                return RedirectToAction("Image");
            }
        }
        public ActionResult ImageUpdate(ContactBig_ViewModel model, HttpPostedFileBase file)
        {
            var img = _DbContext.Images.Find(model.Image.ImageID);
            if (img != null)
            {
                img.Description = model.Image.Description;
                img.Name = model.Image.Name;
                img.URL = model.Image.GetImageFile(file);
                img.UpdatedOn = DateTime.Now;

                _DbContext.SaveChanges();

                return RedirectToAction("Image");
            }
            else
            {
                return RedirectToAction("Image");
            }
        }

        #endregion
    }

}