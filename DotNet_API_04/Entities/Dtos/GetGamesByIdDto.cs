namespace DotNet_API_04.Entities.Dtos
{
    public class GetGamesByIdDto
    {
        public int GameId { get; set; }
        public required string GameName { get; set; }
        public required string GameVersion { get; set; }
        public string GameDescription { get; set; } = string.Empty;
    }
}
