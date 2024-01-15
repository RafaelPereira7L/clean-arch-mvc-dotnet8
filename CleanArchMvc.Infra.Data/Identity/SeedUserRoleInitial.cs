using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    
    public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            var user = new ApplicationUser();
            user.UserName = "usuario@localhost";
            user.Email = "usuario@localhost";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = _userManager.CreateAsync(user, "Teste@1234!").Result;
            
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "User").Wait();
            }
        }
        
        if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
        {
            var user = new ApplicationUser();
            user.UserName = "admin@localhost";
            user.Email = "admin@localhost";
            user.NormalizedUserName = "ADMIN@LOCALHOST";
            user.NormalizedEmail = "ADMIN@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = _userManager.CreateAsync(user, "Teste@1234!").Result;
            
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }

    public void SeedRoles()
    {
        if (!_roleManager.RoleExistsAsync("User").Result)
        {
            var role = new IdentityRole();
            role.Name = "User";
            role.NormalizedName = "USER";
            var roleResult = _roleManager.CreateAsync(role).Result;
        }
        
        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            var roleResult = _roleManager.CreateAsync(role).Result;
        }
    }
}