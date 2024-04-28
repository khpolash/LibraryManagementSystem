using LMS.Application.Repositories.Base;
using LMS.Infrastructure.Persistence;
using LMS.SharedKernel.Core;
using LMS.SharedKernel.Entities;

namespace LMS.Application.Repositories.Entities;

public class BorrowdBookRepository : BaseRepository<BorrowdBook>, IBorrowdBookRepository
{
    public BorrowdBookRepository(LMSDbContext context) : base(context)
    {
    }

    public Task<int> TotalBorrowBook()
    {
        var issuedBooks = GetAll().Where(book => book.Status == BookStatus.Borrowed);
        return Task.FromResult(issuedBooks.Count());
    }
}
