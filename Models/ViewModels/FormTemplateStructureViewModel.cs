namespace form_whizz_api.Models

{
    public class FormTemplateViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isPrimary { get; set; }
        public ICollection<FormTemplateStructureViewModel> Structure { get; set; }
    }
}