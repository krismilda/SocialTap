using Microsoft.AspNet.Identity.EntityFramework;

namespace DataModels
{
    public class SocialTapUser : IdentityUser
    {
        //todo create required props for user
        public int Age { get; set; } 
    }
}
