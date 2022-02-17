namespace form_whizz_api.Models

{
    public class FormTemplateResponseModel
    {

        public FormTemplateResponseModel (FormTemplateDatabaseModel formTemplate)
        {
            id = formTemplate.id;
            name = formTemplate.name;
            isPrimary = formTemplate.isPrimary;
            // response models allow me to have calculated properties that dont come directly from the DB
            isIdEven = formTemplate.id % 2 == 0;
        }

        public static FormTemplateResponseModel Get(FormTemplateDatabaseModel formTemplate)
        {
            return new FormTemplateResponseModel(formTemplate);
        }

        #region props
        public int id { get; set; }
        public string name { get; set; }
        public bool isPrimary { get; set; }
        public bool isIdEven { get; set; }
        #endregion
    }
}