using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10Assignment.Models;

namespace Mission10Assignment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlerInfoController : ControllerBase
    {
        private readonly BowlingLeagueContext _context;

        public BowlerInfoController(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        [HttpGet(Name = "GetBowlerInfo")]
        public IActionResult Get()
        {
            var bowlerList = _context.Bowlers
                .Include(b => b.Team)
                .Where(b => (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")) //only selects Marlins and Sharks
                .Select(b => new BowlerDto
                {
                    BowlerId = b.BowlerId,
                    BowlerName = b.BowlerFirstName + " " + (b.BowlerMiddleInit != null ? b.BowlerMiddleInit + " " : "") + b.BowlerLastName,
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity,
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber,
                    TeamName = b.Team != null ? b.Team.TeamName : null
                })
                .ToList();

            return Ok(bowlerList);
        }
    }
}
