using LMS.Application.Repositories.Entities;
using LMS.Application.ViewModels.VmEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.App.Controllers.Admin;

public class DashboardController : Controller
{
    private readonly IBookRepository _bookRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IBorrowdBookRepository _borrowdBookRepository;
    private readonly IAuthorRepository _authorRepository;

    public DashboardController(IBookRepository bookRepository, IMemberRepository memberRepository, IBorrowdBookRepository borrowdBookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _memberRepository = memberRepository;
        _borrowdBookRepository = borrowdBookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<IActionResult> Index()
    {
        var dashboard = new VmDashboard
        {
            TotalAuthor = await _authorRepository.GetAll().CountAsync(),
            TotalBook = await _bookRepository.GetAll().CountAsync(),
            TotalMember = await _memberRepository.GetAll().CountAsync(),
            TotalBookIssue = await _borrowdBookRepository.TotalBorrowBook(),
        };
        return View(dashboard);
    }
}
