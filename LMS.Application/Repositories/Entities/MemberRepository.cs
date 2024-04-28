using LMS.Application.Repositories.Base;
using LMS.Infrastructure.Persistence;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Application.Repositories.Entities;

public class MemberRepository(LMSDbContext context) : BaseRepository<Member>(context), IMemberRepository
{
    public async Task<IEnumerable<SelectListItem>> GetDropdownAsync()
    {
        var list = await GetAllAsync();
        return list.Select(x => new SelectListItem { Text = (x.FirstName + " " + x.LastName), Value = x.Id.ToString() });
    }
}
