using LMS.Application.Repositories.Base;
using LMS.SharedKernel.Entities;

namespace LMS.Application.Repositories.Entities;

public interface IBorrowdBookRepository : IBaseRepository<BorrowdBook>
{
    Task<int> TotalBorrowBook();
}