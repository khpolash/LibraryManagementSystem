using LMS.Application.Repositories.Base;
using LMS.Application.ViewModels.VmEntities;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Application.Repositories.Entities;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book> GetBookById(long bookId);
    Task DecrementAvailableCopies(long bookId);
    Task IncrementAvailableCopies(long bookId);
    Task<IEnumerable<SelectListItem>> GetDropdownAsync();
}