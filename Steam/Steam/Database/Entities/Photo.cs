using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace STEAM.Database.Entities
{
        public class Photo
    {
        //Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //Foreign Key
        public int ProjectId  { get; set; } = default!;

        //Properties
        public string Name { get; set; } = default!;
        public string Url  { get; set; } = default!;

        //Navigations
        public Project Project { get; set; } = default!;
    }

    internal class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {

        }
    }
}
