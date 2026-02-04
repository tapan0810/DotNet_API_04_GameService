namespace DotNet_API_04.Entities.Dtos
{
    public class GetAllGamesDto
    {
        public int GameId { get; set; }
        public required string GameName { get; set; }
    }
}
