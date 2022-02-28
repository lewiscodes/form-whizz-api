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

    [HttpGet("/QuestionTemplates")]
    public ActionResult<IEnumerable<QuestionTemplateListItemResponseModel>> GetAll()
    {
        var questionTemplates = _context.questionTemplates;
            // .GroupBy(questionTemplate => questionTemplate.questionId);
        if (questionTemplates == null)
        {
            return NotFound();
        }

        return questionTemplates.Select(
            questionTemplate => QuestionTemplateListItemResponseModel.Get(questionTemplate)
        ).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<QuestionTemplateFullResponseModel> GetById(int id)
    {
        var questionTemplate = GetQuestion(id);
        if (questionTemplate == null)
        {
            return NotFound();
        }

        return questionTemplate;
    }

    [HttpPost("Add")]
    public async Task<ActionResult<QuestionTemplateFullResponseModel>> Create([FromBody]CreateQuestionTemplateInputModel newQuestionTemplateData)
    {
        var questionType = _context.questionTypes.Find(newQuestionTemplateData.questionTypeId);
        if (questionType == null)
        {
            return NotFound();
        }

        var nextQuestionId = GetNextQuestionId();
        QuestionResponseGroupDatabaseModel newQuestionResponseGroup = new QuestionResponseGroupDatabaseModel();
        if (questionType != null && questionType.usesQuestionResponseGroups == true)
        {
            _context.questionResponseGroups.Add(newQuestionResponseGroup);
            await _context.SaveChangesAsync();
            if (newQuestionResponseGroup.id != null)
            {
                var newQuestionResponse = new QuestionResponseDatabaseModel(newQuestionResponseGroup.id, "Default Response Text");
                _context.questionResponses.Add(newQuestionResponse);
                await _context.SaveChangesAsync();
            }
        }

        QuestionTemplateDatabaseModel newQuestionTemplate = new QuestionTemplateDatabaseModel(nextQuestionId, 1, null, questionType.id, newQuestionResponseGroup.id);
        _context.questionTemplates.Add(newQuestionTemplate);
        await _context.SaveChangesAsync();
        return GetQuestionTemplate(newQuestionTemplate.id);
    }

    [HttpPatch("{id}/Edit")]
    public async Task<ActionResult<QuestionTemplateFullResponseModel>> Update(int id, [FromBody]UpdateQuestionTemplateInputModel updatedQuestionTemplateData)
    {
        var questionTemplate = GetQuestion(id);
        if (questionTemplate == null)
        {
            return NotFound();
        }

        var updatedQuestionTypeId = updatedQuestionTemplateData.questionTypeId ?? questionTemplate.questionTypeId;
        QuestionTemplateDatabaseModel newQuestionTemplate = new QuestionTemplateDatabaseModel(questionTemplate.questionId, questionTemplate.version + 1, updatedQuestionTemplateData.text, updatedQuestionTypeId, questionTemplate.questionResponseGroupId);
        _context.questionTemplates.Add(newQuestionTemplate);
        await _context.SaveChangesAsync();

        return GetQuestionTemplate(newQuestionTemplate.id);
    }

    private QuestionTemplateFullResponseModel GetQuestionTemplate(int questionTemplateId)
    {
        var questionTemplate = _context.questionTemplates.Find(questionTemplateId);
        var questionResponses = GetQuestionResponses(questionTemplate.questionResponseGroupId);
        return QuestionTemplateFullResponseModel.Get(questionTemplate, questionResponses) ?? null;
    }

    private QuestionTemplateFullResponseModel GetQuestion(int questionId)
    {
        var questionTemplate = _context.questionTemplates
            .Where(questionTemplate => questionTemplate.questionId == questionId)
            .OrderBy(questionTemplate => questionTemplate.version)
            .Last();
        
        var questionResponses = GetQuestionResponses(questionTemplate.questionResponseGroupId);

        return QuestionTemplateFullResponseModel.Get(questionTemplate, questionResponses) ?? null;
    }

    private IEnumerable<QuestionResponseResponseModel> GetQuestionResponses(int? questionResponseGrouId)
    {
        var questionResponses = _context.questionResponses
            .Where(questionResponse => questionResponse.questionResponseGroupId == questionResponseGrouId);

        return questionResponses.Select(questionResponse => QuestionResponseResponseModel.Get(questionResponse)).ToList();
    }

    private int GetNextQuestionId()
    {
        var questionTemplates = _context.questionTemplates.ToList();

        if (questionTemplates.Count() == 0)
        {
            return 1;
        }
        
        var sortedQuestionTemplates = questionTemplates.OrderByDescending(questionTemplate => questionTemplate.questionId)
            .First();

        return sortedQuestionTemplates.questionId + 1;
    }
}