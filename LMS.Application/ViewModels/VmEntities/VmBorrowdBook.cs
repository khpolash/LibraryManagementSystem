using LMS.SharedKernel.Core;
using LMS.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.VmEntities;

public class VmBorrowdBook : BaseEntity
{
    [Required(ErrorMessage = "Member is required")]
    [Display(Name = "Member")]
    public long MemberId { get; set; }

    [Required(ErrorMessage = "Book is required")]
    [Display(Name = "Book")]
    public long BookId { get; set; }

    [Required(ErrorMessage = "Borrow date is required")]
    [Display(Name = "Borrow Date")]
    [DataType(DataType.Date)]
    public DateTimeOffset BorrowDate { get; set; }

    [Required(ErrorMessage = "Return date is required")]
    [Display(Name = "Return Date")]
    [DataType(DataType.Date)]
    public DateTimeOffset ReturnDate { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public BookStatus Status { get; set; }

    [Display(Name = "Book Title")]
    public string BookTitle { get; set; }

    [Display(Name = "Member")]
    public string MemberName { get; set; }

    public IEnumerable<SelectListItem> BookDropdown { get; set; } = new List<SelectListItem>();

    public IEnumerable<SelectListItem> MamberDropdown { get; set; } = new List<SelectListItem>();

}