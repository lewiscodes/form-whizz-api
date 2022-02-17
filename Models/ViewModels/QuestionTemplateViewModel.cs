namespace form_whizz_api.Models
{
    public class QuestionTemplateViewModel
    {
        public int ID { get; set; }
        public int QuestionId { get; set; }
        public int Version { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public QuestionResponseGroupViewModel? ResponseGroup { get; set; }
    }
}