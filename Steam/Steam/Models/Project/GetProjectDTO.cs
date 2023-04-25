using STEAM.Models.Photos;

namespace STEAM.Models.Project;

public class GetProjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime Date { get; set; } = default!;
    public List<GetPhotoDTO> Photos { get; set; } = default!;
}
