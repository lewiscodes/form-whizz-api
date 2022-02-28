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

    // [HttpGet("/QuestionResponseGroup/{id}")]
    // public ActionResult<IEnumerable<QuestionResponseResponseModel>> Get(int responseModelGroupId)
    // {
    //     var questionResponses = _context.questionResponses
    //         .Where(qr => qr.questionResponseGroupId == responseModelGroupId);

    //     if (questionResponses == null)
    //     {
    //         return NotFound();
    //     }

    //     return questionResponses.Select(
    //         questionResponse => QuestionResponseResponseModel.Get(questionResponse)
    //     ).ToList();
    // }

    [HttpPost("{questionId}/Add")]
    public async Task<ActionResult<QuestionResponseResponseModel>> Create(int questionId)
    {
        // TODO: this needs replacing the the commented out code below when i can figure out how to use a method from another controller
        var questionTemplate = _context.questionTemplates
            .Where(questionTemplate => questionTemplate.questionId == questionId)
            .OrderByDescending(questionTemplate => questionTemplate.id)
            .First();
        // var questionTemplateController = new QuestionTemplateController(_context);
        // var questionTemplate = questionTemplateController.GetQuestion(questionId);

        if (questionTemplate == null || questionTemplate.questionResponseGroupId == null)
        {
            return NotFound();
        }

        var newQuestionResponse = new QuestionResponseDatabaseModel(questionTemplate.questionResponseGroupId ?? 0, "Default Response Text");
        _context.questionResponses.Add(newQuestionResponse);
        await _context.SaveChangesAsync();

        return QuestionResponseResponseModel.Get(_context.questionResponses.Find(newQuestionResponse.id));
    }

    [HttpPatch("{questionResponseId}/Edit")]
    public async Task<ActionResult<QuestionResponseResponseModel>> Update(int questionResponseId, [FromBody]UpdateQuestionResponseInputModel updatedQuestionResponse)
    {
        var questionResponse = _context.questionResponses
            .Where(questionResponse => questionResponse.id == questionResponseId)
            .First();

        if (questionResponse == null)
        {
            return NotFound();
        }

        questionResponse.responseText = updatedQuestionResponse.responseText;
        await _context.SaveChangesAsync();
        return QuestionResponseResponseModel.Get(questionResponse);
    }
}
