namespace STEAM.Models.Photos;
public class AddPhotoDTO
{
        public int ProjectId  { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Url  { get; set; } = default!;
}