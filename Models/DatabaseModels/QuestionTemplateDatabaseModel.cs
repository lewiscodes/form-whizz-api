namespace form_whizz_api.Models
{
    public enum QuestionType
    {
        Text, Number, Boolean, Radio, Select
    }
    public class QuestionTemplateDatabaseModel
    {
        public int id { get; set; }
        public int questionId { get; set; }
        public int version { get; set; }
        public string text { get; set; }
        public QuestionType questionType { get; set; }
        public int questionResponseGroupId { get; set; }
    }
}