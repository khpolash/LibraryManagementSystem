using LMS.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.VmEntities;

public class VmMember : BaseEntity
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(85, ErrorMessage = "First name cannot exceed 85 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(85, ErrorMessage = "Last name cannot exceed 85 characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(85, ErrorMessage = "Email cannot exceed 85 characters")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Registration date is required")]
    [Display(Name = "Registration Date")]
    [DataType(DataType.Date)]
    public DateTimeOffset RegistrationDate { get; set; }

}

