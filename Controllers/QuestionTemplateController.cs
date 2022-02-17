using form_whizz_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace form_whizz_api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionTemplateController : ControllerBase
{
    private readonly FormWhizzContext _context;
    public QuestionTemplateController(FormWhizzContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<QuestionTemplateResponseModel>> GetAll()
    {
        var questionTemplates = _context.questionTemplates;
        if (questionTemplates == null)
        {
            return NotFound();
        }

        return questionTemplates.Select(
            questionTemplate => QuestionTemplateResponseModel.Get(questionTemplate)
        ).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<QuestionTemplateResponseModel> GetById(int id)
    {
        var questionTemplate = _context.questionTemplates.Find(id);
        if (questionTemplate == null)
        {
            return NotFound();
        }

        return QuestionTemplateResponseModel.Get(questionTemplate);
    }
}