using LMS.Application.Repositories.Base;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Application.Repositories.Entities;

public interface IMemberRepository : IBaseRepository<Member>
{
    Task<IEnumerable<SelectListItem>> GetDropdownAsync();
}