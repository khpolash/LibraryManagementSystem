using AutoMapper;
using LMS.Application.Repositories.Entities;
using LMS.Application.ViewModels.VmEntities;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Controllers.Admin;

public class AuthorController : Controller
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var authorList = await _authorRepository.GetAllAsync();
        return View(_mapper.Map<List<VmAuthor>>(authorList));
    }

    public async Task<IActionResult> Details(long id)
    {
        var author = await _authorRepository.FirstOrDefaultAsync(id);
        return View(_mapper.Map<VmAuthor>(author));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        return id switch
        {
            0 => View(new VmAuthor()),
            _ => View(_mapper.Map<VmAuthor>(await _authorRepository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(long id, VmAuthor viewModel)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {


                        await _authorRepository.InsertAsync(_mapper.Map<Author>(viewModel));
                        TempData["SuccessMessage"] = $" Author added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Author : {ex.Message}";
                }

                break;
            default:
                try
                {
                    var existing = await _authorRepository.FirstOrDefaultAsync(viewModel.Id);
                    if (ModelState.IsValid)
                    {

                        var author = _mapper.Map<Author>(viewModel);
                        await _authorRepository.UpdateAsync(existing.Id, author);

                        TempData["SuccessMessage"] = $" Author update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Author : {ex.Message}";
                }
                break;
        }

        return View(new VmAuthor());
    }


    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await _authorRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}
