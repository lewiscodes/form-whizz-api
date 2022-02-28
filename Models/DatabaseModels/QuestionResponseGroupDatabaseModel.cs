using System.ComponentModel.DataAnnotations.Schema;

namespace form_whizz_api.Models
{
    public class QuestionResponseGroupDatabaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }
}