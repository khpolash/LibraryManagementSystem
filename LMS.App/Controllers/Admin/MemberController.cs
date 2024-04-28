using AutoMapper;
using LMS.Application.Repositories.Entities;
using LMS.Application.ViewModels.VmEntities;
using LMS.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Controllers.Admin;

public class MemberController : Controller
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public MemberController(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var memberList = await _memberRepository.GetAllAsync();
        return View(_mapper.Map<List<VmMember>>(memberList));
    }

    public async Task<IActionResult> Details(long id)
    {
        var author = await _memberRepository.FirstOrDefaultAsync(id);
        return View(_mapper.Map<VmMember>(author));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        return id switch
        {
            0 => View(new VmMember()),
            _ => View(_mapper.Map<VmMember>(await _memberRepository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(long id, VmMember viewModel)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {


                        await _memberRepository.InsertAsync(_mapper.Map<Member>(viewModel));
                        TempData["SuccessMessage"] = $" Member added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Member : {ex.Message}";
                }

                break;
            default:
                try
                {
                    var existing = await _memberRepository.FirstOrDefaultAsync(viewModel.Id);
                    if (ModelState.IsValid)
                    {

                        var author = _mapper.Map<Member>(viewModel);
                        await _memberRepository.UpdateAsync(existing.Id, author);

                        TempData["SuccessMessage"] = $" Member update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Member : {ex.Message}";
                }
                break;
        }
        return View(new VmMember());
    }


    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await _memberRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}
