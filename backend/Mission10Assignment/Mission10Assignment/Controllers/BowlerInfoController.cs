using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10Assignment.Models;

namespace Mission10Assignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerInfoController : ControllerBase
    {
        private BowlingLeagueContext _context;

        public BowlerInfoController(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        [HttpGet(Name = "GetBowlerInfo")]
        public IEnumerable<Bowler> Get()
        {
            var bowlerList = _context.Bowlers.ToList();

            return bowlerList;
        }
    }
}
