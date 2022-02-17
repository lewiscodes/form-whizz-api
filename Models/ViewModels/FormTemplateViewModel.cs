namespace form_whizz_api.Models
{
    public class FormTemplateStructureViewModel
    {
        public int ID { get; set; }
        public int Order { get; set; }
        public QuestionTemplateViewModel Question { get; set; }
    }
}