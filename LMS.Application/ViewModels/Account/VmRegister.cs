using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Account;

public class VmRegister
{
    [Required]
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(100, ErrorMessage =
        "The {0} must be at least {2} characters long.", MinimumLength = 4)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage =
        "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
