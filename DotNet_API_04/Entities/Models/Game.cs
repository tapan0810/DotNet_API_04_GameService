namespace DotNet_API_04.Entities.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public required string GameName { get; set; }
        public required string GameVersion { get; set; }
        public string GameDescription { get; set; }= string.Empty;
    }
}
