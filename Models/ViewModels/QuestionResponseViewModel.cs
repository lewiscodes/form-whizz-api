namespace form_whizz_api.Models
{
    public class QuestionResponseGroupViewModel
    {
        public int ID { get; set; }
        public ICollection<QuestionResponseViewModel> QuestionResponses { get; set; }
    }
}