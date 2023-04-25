namespace STEAM.Models.Contacts;
public class AddContactDTO
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Message { get; set; } = default!;
}