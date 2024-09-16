using Microsoft.AspNetCore.Mvc;
using WebApiDemo3_22_10.Dtos;
using WebApiDemo3_22_10.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo3_22_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public static List<Player> Players { get; set; } = new List<Player>
        {
            new Player
            {
                Id = 1,
                City="Baku",
                PlayerName="Leyla",
                Score=98
            },
            new Player
            {
                Id = 2,
                City="Gence",
                PlayerName="Arif",
                Score=100
            },
            new Player
            {
                Id = 3,
                City="Sumqayit",
                PlayerName="Aysel",
                Score=55
            }
        };

        //GET 
        //POST
        //PUT
        //DELETE
        //PATCH  ?

        //localhost:7015/api/Player   GET
        //localhost:7015/api/Player/2   GET
        //localhost:7015/api/Player   POST
        //localhost:7015/api/Player   PUT
        //localhost:7015/api/Player/2   DELETE

        // GET: api/<PlayerController>
        //[HttpGet]
        //public IEnumerable<PlayerDto> Get()
        //{
        //    var result = Players.Select(p => new PlayerDto
        //    {
        //        PlayerName = p.PlayerName,
        //        City = p.City,
        //        Score = p.Score
        //    });
        //    return result;
        //}

        // GET: api/<PlayerController>
        [HttpGet("BestStudents")]
        public IEnumerable<PlayerDto> GetBestPlayers()
        {
            var result = Players.Where(p => p.Score >= 80).Select(p => new PlayerDto
            {
                PlayerName = p.PlayerName,
                City = p.City,
                Score = p.Score
            });
            return result;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public IEnumerable<PlayerExtendedDto> Search(string key = "")
        {
            var result = Players.Where(p => key == "" || p.PlayerName.ToLower().Contains(key.ToLower())).Select(p => new PlayerExtendedDto
            {
                Id = p.Id,
                PlayerName = p.PlayerName,
                City = p.City,
                Score = p.Score
            });
            return result;
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var player = Players.FirstOrDefault(x => x.Id == id);
            if (player != null)
            {
                var dto = new PlayerDto
                {
                    Score = player.Score,
                    City = player.City,
                    PlayerName = player.PlayerName,
                };
                return Ok(dto);
            }
            return NotFound();
        }

        // POST api/<PlayerController>
        [HttpPost]
        public IActionResult Post([FromBody] PlayerDto dto)
        {
            if (dto.Score > 0)
            {
                var player = new Player
                {
                    City = dto.City,
                    Score = dto.Score,
                    PlayerName = dto.PlayerName,
                    Id = (new Random()).Next(10, 1000)
                };
                Players.Add(player);
                return Ok(player);
            }
            return BadRequest("Score is not valid");
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PlayerDto dto)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                player.PlayerName = dto.PlayerName;
                player.Score = dto.Score;
                player.City = dto.City;
                return Ok(player);
            }
            return NotFound();
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);
            if (player == null) return NotFound();
            Players.Remove(player);
            return NoContent();
        }
    }
}
