using GasAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GasController : ControllerBase
    {
        private static readonly List<Gas> Gases = new()
        {
            new Gas { Name = "LPG", MinLevel = 0.1, MaxLevel = 2.5 },
            new Gas { Name = "Propane", MinLevel = 0.1, MaxLevel = 2.1 },
            new Gas { Name = "Hydrogen", MinLevel = 0.01, MaxLevel = 0.1 },
            new Gas { Name = "Methane", MinLevel = 0.1, MaxLevel = 5.0 },
            new Gas { Name = "Smoke", MinLevel = 0.0, MaxLevel = 0.2 },
            new Gas { Name = "CO", MinLevel = 0.0, MaxLevel = 35.0 },
            new Gas { Name = "Alcohol", MinLevel = 0.01, MaxLevel = 0.1 },
            new Gas { Name = "Ethanol", MinLevel = 0.01, MaxLevel = 0.3 },
            new Gas { Name = "Benzine", MinLevel = 0.05, MaxLevel = 0.15 }
        };

        [HttpPost("check")]
        public ActionResult<string> CheckGasLevel([FromBody] GasLevelInput input)
        {
            var gas = Gases.FirstOrDefault(g => g.Name.Equals(input.Name, StringComparison.OrdinalIgnoreCase));

            if (gas == null)
                return NotFound($"Gas '{input.Name}' not found.");

            string status;

            if (input.Level > gas.MaxLevel)
                status = "DANGER";
            else if (input.Level >= gas.MinLevel && input.Level <= gas.MaxLevel)
                status = "CAUTION";
            else
                status = "SAFE";

            return Ok($"Gas: {gas.Name}, Level: {input.Level}, Status: {status}");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Gas>> GetAllGases()
        {
            return Ok(Gases);
        }


        [HttpGet("{name}")]
        public ActionResult<Gas> GetGasByName(string name)
        {
            var gas = Gases.FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return gas == null ? NotFound($"Gas {name}' not found."): Ok(gas);
        }
    }
}
