using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiContact.ViewModel
{
    public class ContactBig_ViewModel
    {
        public BasicInfo_ViewModel BasicInfo { get; set; }

        public IEnumerable<BasicInfo_IE> Basic_IE { get; set; }
        public Contact_ViewModel Contact { get; set; }
        public IEnumerable<Contact_ViewModel> Contact_IE { get; set; }
        public Email_ViewModel Email { get; set; }
        public IEnumerable<Email_ViewModel> Email_IE { get; set; }
        public Social_ViewModel Social { get; set; }
        public IEnumerable<Social_ViewModel> Social_IE { get; set; }
        public Image_ViewModel Image { get; set; }
        public IEnumerable<Image_ViewModel> Image_IE { get; set; }

        public string BasicActive { get; set; }
        public string BasicAction { get; set; }
        public string BasicBtn { get; set; }

        public string ContactActive { get; set; }
        public string ContactAction { get; set; }
        public string ContactBtn { get; set; }


        public string SocialActive { get; set; }
        public string SocialAction { get; set; }
        public string SocialBtn { get; set; }

        public string EmailActive { get; set; }
        public string EmailAction { get; set; }
        public string EmailBtn { get; set; }

        public string ImageActive { get; set; }
        public string ImageAction { get; set; }
        public string ImageBtn { get; set; }





    }
}