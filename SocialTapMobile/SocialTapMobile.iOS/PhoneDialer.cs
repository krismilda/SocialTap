using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using SocialTapMobile.iOS;

[assembly: Dependency(typeof(PhoneDialer))]
namespace SocialTapMobile.iOS
{
    public class PhoneDialer 
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}