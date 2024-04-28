using LMS.Application.Repositories.Base;
using LMS.Infrastructure.Persistence;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Application.Repositories.Entities;

public class AuthorRepository(LMSDbContext context) : BaseRepository<Author>(context), IAuthorRepository
{
    public async Task<IEnumerable<SelectListItem>> GetDropdownAsync()
    {
        var list = await GetAllAsync();
        return list.Select(x => new SelectListItem { Text = x.AuthorName, Value = x.Id.ToString() });
    }
}
