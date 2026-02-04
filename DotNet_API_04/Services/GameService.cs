using DotNet_API_04.Data;
using DotNet_API_04.Entities.Dtos;
using DotNet_API_04.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_API_04.Services
{
    public class GameService : IGameService
    {
        private readonly GameDbContext _context;

        public GameService(GameDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllGamesDto>> GetAllGames()
        {
            return await _context.Games
                .Select(s => new GetAllGamesDto
                {
                    GameId = s.GameId,
                    GameName = s.GameName
                })
                .ToListAsync();
        }

        public async Task<GetGamesByIdDto?> GetGameById(int id)
        {
            return await _context.Games
                .Where(s => s.GameId == id)
                .Select(s => new GetGamesByIdDto
                {
                    GameId = s.GameId,
                    GameName = s.GameName,
                    GameVersion = s.GameVersion,
                    GameDescription = s.GameDescription
                })
                .FirstOrDefaultAsync();
        }

        public async Task<GetGamesByIdDto?> CreateGame(CreateGameDto createGame)
        {
            var game = new Game
            {
                GameName = createGame.GameName,
                GameVersion = createGame.GameVersion,
                GameDescription = createGame.GameDescription
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return new GetGamesByIdDto
            {
                GameId = game.GameId,
                GameName = game.GameName,
                GameVersion = game.GameVersion,
                GameDescription = game.GameDescription
            };
        }

        public async Task<bool> UpdateGame(int id, UpdateGameDto updateGame)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.GameId == id);
            if (game is null)
                return false;

            game.GameName = updateGame.GameName;
            game.GameVersion = updateGame.GameVersion;
            game.GameDescription = updateGame.GameDescription;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGame(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.GameId == id);
            if (game is null)
                return false;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
