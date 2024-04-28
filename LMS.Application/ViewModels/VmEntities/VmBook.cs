using LMS.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.VmEntities;

public class VmBook : BaseEntity
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(85, ErrorMessage = "Title cannot exceed 85 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "ISBN is required")]
    [MaxLength(20, ErrorMessage = "ISBN cannot exceed 20 characters")]
    public string ISBN { get; set; }

    [Required(ErrorMessage = "Published date is required")]
    [Display(Name = "Published Date")]
    [DataType(DataType.Date)]
    public DateTimeOffset PublishedDate { get; set; }

    [Required(ErrorMessage = "Available copies is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Available copies must be a non-negative number")]
    [Display(Name = "Available")]
    public int AvailableCopies { get; set; }

    [Required(ErrorMessage = "Total copies is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Total copies must be a non-negative number")]
    [Display(Name = "Total")]
    public int TotalCopies { get; set; }

    [Required(ErrorMessage = "Author is required")]
    [Display(Name = "Author")]
    public long AuthorId { get; set; }

    [Display(Name = "Author")]
    public string AuthorName { get; set; }
}