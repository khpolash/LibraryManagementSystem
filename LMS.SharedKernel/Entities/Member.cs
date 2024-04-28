using LMS.SharedKernel.Entities.BaseEntities;

namespace LMS.SharedKernel.Entities;

public class Member : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTimeOffset RegistrationDate { get; set; }

    public ICollection<BorrowdBook> BorrowdBooks { get; set; } = [];
}
