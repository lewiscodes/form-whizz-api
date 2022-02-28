namespace form_whizz_api.Models
{
    public class QuestionTemplateDatabaseModel
    {
        public QuestionTemplateDatabaseModel()
        {
            
        }
        public QuestionTemplateDatabaseModel(int newQuestionId, int newVersion, string? newText, int newQuestionTypeId, int? newQuestionResponseGroupId)
        {
            questionId = newQuestionId;
            version = newVersion;
            text = newText;
            questionTypeId = newQuestionTypeId;
            questionResponseGroupId = newQuestionResponseGroupId;
        }

        #region props
        public int id { get; set; }
        public int questionId { get; set; }
        public int version { get; set; }
        public string? text { get; set; }
        public int questionTypeId { get; set; }
        public int? questionResponseGroupId { get; set; }
        #endregion
    }

    public class CreateQuestionTemplateInputModel
    {
        public int questionTypeId { get; set; }
    }

    public class UpdateQuestionTemplateInputModel
    {
        public string? text { get; set; }
        public int? questionTypeId { get; set; }
    }
}