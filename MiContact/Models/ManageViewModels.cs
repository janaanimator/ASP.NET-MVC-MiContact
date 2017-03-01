using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;

namespace MiContact.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }

        public AspNetUsersProfileViewModel AspNetUsersProfileViewModels { get; set; }
        public AspNetUsersImagesViewModel AspNetUsersImagesViewModel { get; set; }
        public IEnumerable<AspImg_IE> AspNetUserImages_IE { get; set; }
        public string Profile_active { get; set; }
        public string Images_active { get; set; }
        public string Security_active { get; set; }
    }

    public class AspImg_IE
    {
        public string ImageURL { get; set; }
        public string ImageType { get; set; }
        public string ToSetProfilePic { get; set; }
        public string ToSetBannerPic { get; set; }
        public string ImageDescription { get; set; }


    }



    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class AspNetUsersProfileViewModel
    {
        public int AspNetUsersProfileID { get; set; }

        public string ApplicationUserID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public string Dob { get; set; }
        public IEnumerable<Gender> Genders { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int GenderID { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "About Me")]
        public string AboutMe { get; set; }
    }

    public class AspNetUsersImagesViewModel
    {
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        [Required]
        [Display(Name = "Image Type")]
        public string ImageType { get; set; }
        public string ToSetProfilePic { get; set; }
        public string ToSetBannerPic { get; set; }

        [Required]
        [Display(Name = "Image Description")]
        public string ImageDescription { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}