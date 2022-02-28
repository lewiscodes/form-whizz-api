namespace form_whizz_api.Models
{
    public class QuestionTemplateFullResponseModel : QuestionTemplateListItemResponseModel
    {
        public QuestionTemplateFullResponseModel (QuestionTemplateDatabaseModel questionTemplate, IEnumerable<QuestionResponseResponseModel>? responses)
            : base(questionTemplate)
        {
            questionResponses = responses;
        }

        public static QuestionTemplateFullResponseModel Get(QuestionTemplateDatabaseModel questionTemplate, IEnumerable<QuestionResponseResponseModel>? responses)
        {
            return new QuestionTemplateFullResponseModel(questionTemplate, responses);
        }

        #region props
        public IEnumerable<QuestionResponseResponseModel>? questionResponses { get; set; }
        #endregion
    }
}