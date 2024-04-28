using AutoMapper;
using LMS.Application.Repositories.Entities;
using LMS.Application.ViewModels.VmEntities;
using LMS.SharedKernel.Entities;
using LMS.SharedKernel.Core;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Controllers.Admin;

public class BorrowdBookController : Controller
{
    private readonly IBorrowdBookRepository _borrowdBookRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public BorrowdBookController(IBorrowdBookRepository borrowdBookRepository, IMapper mapper, IBookRepository bookRepository, IMemberRepository memberRepository)
    {
        _borrowdBookRepository = borrowdBookRepository;
        _mapper = mapper;
        _bookRepository = bookRepository;
        _memberRepository = memberRepository;
    }

    public async Task<IActionResult> Index()
    {
        var memberList = await _borrowdBookRepository.GetAllAsync(x => x.Book, x => x.Member);
        return View(_mapper.Map<List<VmBorrowdBook>>(memberList));
    }

    public async Task<IActionResult> Details(long id)
    {
        var author = await _borrowdBookRepository.FirstOrDefaultAsync(id, x => x.Book, x => x.Member);
        return View(_mapper.Map<VmBorrowdBook>(author));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        ViewData["BookId"] = await _bookRepository.GetDropdownAsync();
        ViewData["MemberId"] = await _memberRepository.GetDropdownAsync();
        return id switch
        {
            0 => View(new VmBorrowdBook()),
            _ => View(_mapper.Map<VmBorrowdBook>(await _borrowdBookRepository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(long id, VmBorrowdBook viewModel)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        await _borrowdBookRepository.InsertAsync(_mapper.Map<BorrowdBook>(viewModel));
                        await _bookRepository.DecrementAvailableCopies(viewModel.BookId);
                        TempData["SuccessMessage"] = $" BorrowdBook added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding BorrowdBook : {ex.Message}";
                }

                break;
            default:
                try
                {
                    var existing = await _borrowdBookRepository.FirstOrDefaultAsync(viewModel.Id);
                    if (ModelState.IsValid)
                    {

                        var author = _mapper.Map<BorrowdBook>(viewModel);
                        await _borrowdBookRepository.UpdateAsync(existing.Id, author);

                        TempData["SuccessMessage"] = $" BorrowdBook update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating BorrowdBook : {ex.Message}";
                }
                break;
        }
        ViewData["BookId"] = await _bookRepository.GetDropdownAsync();
        ViewData["MemberId"] = await _memberRepository.GetDropdownAsync();
        return View(new VmBorrowdBook());
    }


    public async Task<ActionResult> ReturnBook(long id)
    {
        if (id > 0)
        {
            var borrowBook = await _borrowdBookRepository.FirstOrDefaultAsync(id);
            borrowBook.Status = BookStatus.Returned;
            await _borrowdBookRepository.UpdateAsync(id, borrowBook);
            await _bookRepository.IncrementAvailableCopies(borrowBook.BookId);
            TempData["SuccessMessage"] = $" Item return successfully";
            return RedirectToAction(nameof(Index));
        }
        TempData["ErrorMessage"] = $"Error return : return has some issue";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await _borrowdBookRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}
