using STEAM.Database.Enums;

namespace STEAM.Models.Contacts;

public class GetContactDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Message { get; set; } = default!;
    public string? Notes { get; set; } 
    public ContactStatus Status { get; set; } = default!;
}
