using DotNet_API_04.Entities.Dtos;
using DotNet_API_04.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_API_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<GetAllGamesDto>>> GetAllGames()
        {
            var games = await _gameService.GetAllGames();
            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetGamesByIdDto>> GetGameById(int id)
        {
            var game = await _gameService.GetGameById(id);
            if (game == null)
                return BadRequest($"Game with ID:{id} is not available 😢");

            return Ok(game);
        }

        [HttpPost("CreateGame")]
        public async Task<ActionResult<GetGamesByIdDto?>> CreateGame(CreateGameDto game)
        {
            if (game is null)
                return BadRequest("Invalid game data");

            var createGame = await _gameService.CreateGame(game);
            return CreatedAtAction(nameof(CreateGame), new { id = createGame?.GameId }, createGame);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteGameById(int id)
        {
            var game = await _gameService.DeleteGame(id);

            if(!game)
                return BadRequest($"Game with ID:{id} is not available 😢");

            return Ok(game);

        }


    }
}
