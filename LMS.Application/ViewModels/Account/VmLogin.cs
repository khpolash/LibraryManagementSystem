using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Account;

public class VmLogin
{
    [Required]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}