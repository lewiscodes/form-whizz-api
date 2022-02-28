using System.ComponentModel.DataAnnotations.Schema;

namespace form_whizz_api.Models
{
    public class QuestionResponseDatabaseModel
    {
        public QuestionResponseDatabaseModel()
        {
            
        }
        public QuestionResponseDatabaseModel(int newQuestionResponseGroupId, string newResponseText)
        {
            questionResponseGroupId = newQuestionResponseGroupId;
            responseText = newResponseText;
        }

        #region props
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int questionResponseGroupId { get; set; }
        public string responseText { get; set; }
        #endregion
    }

    public class UpdateQuestionResponseInputModel
    {
        public string responseText { get; set; }
    }
}