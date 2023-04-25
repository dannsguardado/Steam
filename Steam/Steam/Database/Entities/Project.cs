using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace STEAM.Database.Entities
{
    public class Project
    {
        //Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Properties
        public string Name { get; set; } = default!;
        public DateTime Date { get; set; } = default!;

        //Navigations
        public List<Photo> Photos { get; set; } = default!;
    }

    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasMany(x => x.Photos)
                   .WithOne(x => x.Project)
                   .HasForeignKey(x => x.ProjectId);
        }
    }
}
