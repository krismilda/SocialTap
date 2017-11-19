using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using DataModels;

namespace DataAccess
{
    public class AuthRepository : IDisposable
    {
        private SocialTapContext _ctx;

        private UserManager<SocialTapUser> _userManager;

        public AuthRepository()
        {
            _ctx = new SocialTapContext();
            _userManager = new UserManager<SocialTapUser>(new UserStore<SocialTapUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            SocialTapUser user = new SocialTapUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<SocialTapUser> FindUser(string userName, string password)
        {
            SocialTapUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
