using Formula1_WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Formula1_WebApplication.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(UserManager<IdentityUser> userManager) =>
        _userManager = userManager;

        public async Task SeedUserAsync()
        {
                var user = new IdentityUser
                {
                    UserName = "admin",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                await _userManager.CreateAsync(user, "f1test2018");
            
        }

    }
}
