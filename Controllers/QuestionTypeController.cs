using form_whizz_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace form_whizz_api;

[ApiController]
[Route("[controller]")]

public class QuestionTypeController : ControllerBase
{
    private readonly FormWhizzContext _context;

    public QuestionTypeController(FormWhizzContext context)
    {
        _context = context;

        if (_context.questionTypes.Count() == 0)
        {
            _context.questionTypes.Add(new QuestionTypeDatabaseModel { type = "Text", usesQuestionResponseGroups = false });
            _context.questionTypes.Add(new QuestionTypeDatabaseModel { type = "Number", usesQuestionResponseGroups = false });
            _context.questionTypes.Add(new QuestionTypeDatabaseModel { type = "Boolean", usesQuestionResponseGroups = false });
            _context.questionTypes.Add(new QuestionTypeDatabaseModel { type = "Radio", usesQuestionResponseGroups = true });
            _context.questionTypes.Add(new QuestionTypeDatabaseModel { type = "Select", usesQuestionResponseGroups = true });

            _context.SaveChanges();
        }
    }

    [HttpGet("/QuestionTypes")]
    public ActionResult<IEnumerable<QuestionTypeResponseModel>> GetAll()
    {
        var questionTypes = _context.questionTypes;
        if (questionTypes == null)
        {
            return NotFound();
        }

        return questionTypes.Select(
            questionType => QuestionTypeResponseModel.Get(questionType)
        ).ToList();
    }
}