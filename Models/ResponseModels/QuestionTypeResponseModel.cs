namespace form_whizz_api.Models
{
    public class QuestionTypeResponseModel
    {
        public QuestionTypeResponseModel (QuestionTypeDatabaseModel questionType)
        {
            id = questionType.id;
            type = questionType.type;
        }

        public static QuestionTypeResponseModel Get(QuestionTypeDatabaseModel questionType)
        {
            return new QuestionTypeResponseModel(questionType);
        }

        #region props
        public int id { get; set; }
        public string type { get; set; }
        #endregion
    }
}