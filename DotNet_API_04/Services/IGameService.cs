using DotNet_API_04.Entities.Dtos;

namespace DotNet_API_04.Services
{
    public interface IGameService
    {
        public Task<List<GetAllGamesDto>> GetAllGames();
        public Task<GetGamesByIdDto?> GetGameById(int id);
        public Task<GetGamesByIdDto?> CreateGame(CreateGameDto createGame);
        public Task<bool> UpdateGame(int id,UpdateGameDto updateGame);
        public Task<bool> DeleteGame(int id);
    }
}
