namespace form_whizz_api.Models
{
    public class QuestionTemplateListItemResponseModel
    {
        public QuestionTemplateListItemResponseModel (QuestionTemplateDatabaseModel questionTemplate)
        {
            id = questionTemplate.id;
            questionId = questionTemplate.questionId;
            version = questionTemplate.version;
            text = questionTemplate.text;
            questionTypeId = questionTemplate.questionTypeId;
            questionResponseGroupId = questionTemplate.questionResponseGroupId;
        }

        public static QuestionTemplateListItemResponseModel Get(QuestionTemplateDatabaseModel questionTemplate)
        {
            return new QuestionTemplateListItemResponseModel(questionTemplate);
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
}