using Microsoft.AspNetCore.Mvc;
using form_whizz_api.Models;

namespace form_whizz_api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionResponseController : ControllerBase
{
    private readonly FormWhizzContext _context;
    public QuestionResponseController(FormWhizzContext context)
    {
        _context = context;
    }

    [HttpGet("{responseModelGroupId}")]
    public ActionResult<IEnumerable<QuestionResponseResponseModel>> Get(int responseModelGroupId)
    {
        var questionResponses = _context.questionResponses
            .Where(qr => qr.questionResponseGroupId == responseModelGroupId);

        if (questionResponses == null)
        {
            return NotFound();
        }

        return questionResponses.Select(
            questionResponse => QuestionResponseResponseModel.Get(questionResponse)
        ).ToList();
    }
}
