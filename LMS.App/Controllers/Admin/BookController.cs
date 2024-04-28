using AutoMapper;
using LMS.Application.Repositories.Entities;
using LMS.Application.ViewModels.VmEntities;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Controllers.Admin;

public class BookController : Controller
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public BookController(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _authorRepository = authorRepository;
    }


    public async Task<IActionResult> Index()
    {
        var authorList = await _bookRepository.GetAllAsync(x => x.Author);
        return View(_mapper.Map<List<VmBook>>(authorList));
    }

    public async Task<IActionResult> Details(long id)
    {
        var author = await _bookRepository.FirstOrDefaultAsync(id, x => x.Author);
        return View(_mapper.Map<VmBook>(author));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        ViewData["AuthorId"] = await _authorRepository.GetDropdownAsync();
        return id switch
        {
            0 => View(new VmBook()),
            _ => View(_mapper.Map<VmBook>(await _bookRepository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(long id, VmBook viewModel)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {


                        await _bookRepository.InsertAsync(_mapper.Map<Book>(viewModel));
                        TempData["SuccessMessage"] = $" Book added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Book : {ex.Message}";
                }

                break;
            default:
                try
                {
                    var existing = await _bookRepository.FirstOrDefaultAsync(viewModel.Id);
                    if (ModelState.IsValid)
                    {

                        var author = _mapper.Map<Book>(viewModel);
                        await _bookRepository.UpdateAsync(existing.Id, author);

                        TempData["SuccessMessage"] = $" Book update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Book : {ex.Message}";
                }
                break;
        }
        ViewData["AuthorId"] = await _authorRepository.GetDropdownAsync();
        return View(new VmBook());
    }


    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await _bookRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}
