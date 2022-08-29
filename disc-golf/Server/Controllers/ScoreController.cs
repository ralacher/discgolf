using discgolf.Shared;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace disc_golf.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly string FILENAME = "games.json";

        private readonly ILogger<ScoreController> _logger;

        public ScoreController(ILogger<ScoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Score> Get()
        {
            string? FileContent = System.IO.File.ReadAllText(FILENAME);
            if (FileContent is not null)
            {
                return JsonSerializer.Deserialize<List<Score>>(FileContent)!;
            }
            else
            {
                return new List<Score>();
            }
        }

        [HttpGet("{Date}")]
        public List<Score> Get(string Date)
        {
            string? FileContent = System.IO.File.ReadAllText(FILENAME);
            if (FileContent is not null)
            {
                List<Score> Scores = JsonSerializer.Deserialize<List<Score>>(FileContent)!;
                List<Score> Output = Scores.FindAll(score => score.Date == Date);
                return Output;
            }
            else
            {
                return new List<Score>();
            }
        }

        [HttpPost]
        public IResult Post(List<Score> Game)
        {
            string? FileContent = System.IO.File.ReadAllText(FILENAME);
            if (FileContent is not null)
            {
                List<Score> Scores = JsonSerializer.Deserialize<List<Score>>(FileContent)!;
                foreach (var Score in Game)
                {
                    Scores.Add(Score);
                }
                System.IO.File.WriteAllText(
                        FILENAME,
                        JsonSerializer.Serialize<List<Score>>(Scores));
                return Results.Ok();
            }
            else
            {
                return Results.BadRequest();
            }
        }
    }
}