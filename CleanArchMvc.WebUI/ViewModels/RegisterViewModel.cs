using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Email is required!")]
    [EmailAddress(ErrorMessage = "The email is not valid!")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required!")]
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}