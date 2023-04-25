using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using STEAM.Database.Enums;

namespace STEAM.Database.Entities
{
    public class Contact
    {
          //Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Properties
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Message { get; set; } = default!;
        public ContactStatus Status { get; set; } = default!;
        public string? Notes { get; set; } 
    }

    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {

        }
    }
}