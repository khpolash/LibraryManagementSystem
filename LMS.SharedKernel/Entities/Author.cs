using LMS.SharedKernel.Entities.BaseEntities;

namespace LMS.SharedKernel.Entities;

public class Author : AuditableEntity
{
    public string AuthorName { get; set; }
    public string AuthorBio { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}
