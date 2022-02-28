using Microsoft.EntityFrameworkCore;
using form_whizz_api.Models;

namespace form_whizz_api
{
    public class FormWhizzContext : DbContext
    {
        public FormWhizzContext(DbContextOptions<FormWhizzContext> options) : base(options)
        {

        }
        public DbSet<FormTemplateDatabaseModel> formTemplates { get; set; }
        public DbSet<FormTemplateStructureDatabaseModel> formTemplateStructures { get; set; }
        public DbSet<QuestionResponseDatabaseModel> questionResponses { get; set; }
        public DbSet<QuestionResponseGroupDatabaseModel> questionResponseGroups { get; set; }
        public DbSet<QuestionTemplateDatabaseModel> questionTemplates { get; set; }
        public DbSet<QuestionTypeDatabaseModel> questionTypes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=form_whizz;Username=sa;Password=pass");
    }
}