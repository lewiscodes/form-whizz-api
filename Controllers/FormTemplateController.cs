using form_whizz_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace form_whizz_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FormTemplateController : ControllerBase
{
    private readonly FormWhizzContext _context;
    public FormTemplateController(FormWhizzContext context)
    {
        _context = context;

        if (_context.formTemplates.Count() == 0)
        {
            _context.formTemplates.Add(new FormTemplateDatabaseModel { name = "Primary Form Template", isPrimary = true });
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<FormTemplateResponseModel>> GetAll()
    {
        var formTemplates = _context.formTemplates;
        if (formTemplates == null)
        {
            return NotFound();
        }

        return formTemplates.Select(
            formTemplate => FormTemplateResponseModel.Get(formTemplate)
        ).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<FormTemplateResponseModel> GetById(int id)
    {
        var formTemplate = _context.formTemplates.Find(id);
        if (formTemplate == null)
        {
            return NotFound();
        }

        return FormTemplateResponseModel.Get(formTemplate);
    }
}
