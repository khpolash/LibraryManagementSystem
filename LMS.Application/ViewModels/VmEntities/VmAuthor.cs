using LMS.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.VmEntities;

public class VmAuthor : BaseEntity
{
    [Required]
    [Display(Name = "Author Name")]
    public string AuthorName { get; set; }
    [Required]
    [Display(Name = "Author Bio")]
    [DataType(DataType.MultilineText)]
    public string AuthorBio { get; set; }
}
