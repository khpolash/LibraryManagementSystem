using LMS.Application.Repositories.Base;
using LMS.Application.ViewModels.VmEntities;
using LMS.Infrastructure.Persistence;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LMS.Application.Repositories.Entities;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly LMSDbContext _context;
    public BookRepository(LMSDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Book> GetBookById(long bookId)
    {
        return await FirstOrDefaultAsync(bookId);
    }

    public async Task DecrementAvailableCopies(long bookId)
    {
        var book = await FirstOrDefaultAsync(bookId) ?? throw new ArgumentException("Book not found.");
        if (book.AvailableCopies <= 0)
            throw new InvalidOperationException("No available copies left for this book.");

        book.AvailableCopies--;
        await _context.SaveChangesAsync();
    }

    public async Task IncrementAvailableCopies(long bookId)
    {
        var book = await FirstOrDefaultAsync(bookId) ?? throw new ArgumentException("Book not found.");
        book.AvailableCopies++;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SelectListItem>> GetDropdownAsync()
    {
        var list = await GetAllAsync(x => x.Author);
        return list.Where(x => x.AvailableCopies > 0)
            .Select(x => new SelectListItem
            {
                Text = $"{x.Title} - ({x.Author.AuthorName})",
                Value = x.Id.ToString()
            });
    }


}
