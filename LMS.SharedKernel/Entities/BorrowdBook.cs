using LMS.SharedKernel.Core;
using LMS.SharedKernel.Entities.BaseEntities;

namespace LMS.SharedKernel.Entities;

public class BorrowdBook : AuditableEntity
{
    public long MemberId { get; set; }
    public Member Member { get; set; }

    public long BookId { get; set; }
    public Book Book { get; set; }

    public DateTimeOffset BorrowDate { get; set; }
    public DateTimeOffset ReturnDate { get; set; }
    public BookStatus Status { get; set; }

}
