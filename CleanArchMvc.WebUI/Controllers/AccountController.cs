using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchMvc.WebUI.Controllers;

public class AccountController : Controller
{
    public readonly IAuthenticate _authenticate;
    
    public AccountController(IAuthenticate authenticate)
    {
        _authenticate = authenticate;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await _authenticate.RegisterUser(model.Email, model.Password);

        if (result) return Redirect("/");

        ModelState.AddModelError(string.Empty, "Invalid login attempt (wrong credentials)");
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Login(string? returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await _authenticate.Authenticate(model.Email, model.Password);
        
        if (result)
        {
            return string.IsNullOrEmpty(model.ReturnUrl) ? RedirectToAction("Index", "Home") : Redirect(model.ReturnUrl);
        }
        
        ModelState.AddModelError(string.Empty, "Invalid login attempt (wrong credentials)");
        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Logout() 
    {
        await _authenticate.Logout();
        return Redirect("/account/login");
    }
}