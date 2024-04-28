using LMS.Application.Repositories.Base;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Application.Repositories.Entities;

public interface IAuthorRepository : IBaseRepository<Author>
{
    public Task<IEnumerable<SelectListItem>> GetDropdownAsync();
}