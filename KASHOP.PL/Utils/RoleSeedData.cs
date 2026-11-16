using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace KASHOP.PL.Utils
{
    public class RoleSeedData : ISeedData
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleSeedData (RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task DataSeed()
        {
            String[] Roles = { "SuperAdmin", "Admin", "User" };
            foreach (var role in Roles) 
            { 
                if(!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
