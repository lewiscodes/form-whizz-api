namespace form_whizz_api.Models
{
    public class QuestionTemplateResponseModel
    {
        public QuestionTemplateResponseModel (QuestionTemplateDatabaseModel questionTemplate)
        {
            id = questionTemplate.id;
            questionId = questionTemplate.questionId;
            version = questionTemplate.version;
            text = questionTemplate.text;
            questionType = questionTemplate.questionType;
        }

        public static QuestionTemplateResponseModel Get(QuestionTemplateDatabaseModel questionTemplate)
        {
            return new QuestionTemplateResponseModel(questionTemplate);
        }

        #region props
        public int id { get; set; }
        public int questionId { get; set; }
        public int version { get; set; }
        public string text { get; set; }
        public QuestionType questionType { get; set; }
        #endregion
    }
}