using STEAM.Database.Enums;

namespace STEAM.Models.Contacts;
public class UpdateContactDTO
{
    public int Id { get; set; }
    public string? Notes { get; set; } = default!;
    public ContactStatus Status { get; set; } = default!;
}