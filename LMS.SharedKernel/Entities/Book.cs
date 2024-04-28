using LMS.SharedKernel.Entities.BaseEntities;

namespace LMS.SharedKernel.Entities;

public class Book : AuditableEntity
{
    public string Title { get; set; }
    public string ISBN { get; set; } //International Standard Book Number
    public DateTimeOffset PublishedDate { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalCopies { get; set; }
    public long AuthorId { get; set; }
    public Author Author { get; set; }

    public ICollection<BorrowdBook> BorrowdBooks { get; set; } = [];
}
