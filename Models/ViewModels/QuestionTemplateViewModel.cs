namespace form_whizz_api.Models
{
    public class QuestionTemplateViewModel
    {
        public int id { get; set; }
        public int questionId { get; set; }
        public int version { get; set; }
        public string text { get; set; }
        // public int QuestionType { get; set; }
        public QuestionResponseGroupViewModel? ResponseGroup { get; set; }
    }
}