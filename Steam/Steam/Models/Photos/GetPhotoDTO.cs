namespace STEAM.Models.Photos;

public class GetPhotoDTO
{
    public int Id { get; set; }        
    public int ProjectId  { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Url  { get; set; } = default!;
}
