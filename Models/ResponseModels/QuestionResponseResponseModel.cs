namespace form_whizz_api.Models
{
    public class QuestionResponseResponseModel
    {
        public QuestionResponseResponseModel(QuestionResponseDatabaseModel questionResponse)
        {
            id = questionResponse.id;
            responseText = questionResponse.responseText;
        }

        public static QuestionResponseResponseModel Get(QuestionResponseDatabaseModel questionResponse)
        {
            return new QuestionResponseResponseModel(questionResponse);
        }

        #region props
        public int id { get; set; }
        public string responseText { get; set; }
        #endregion
    }
}