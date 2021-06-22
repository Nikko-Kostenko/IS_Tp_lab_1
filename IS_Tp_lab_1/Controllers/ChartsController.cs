using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IS_Tp_lab_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly GameIndustryContext _context;

        public ChartsController(GameIndustryContext context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]

        public JsonResult JsonData()
        {
            var genr = _context.Platforms.Include(g => g.Games).ToList();

            List<object> genrGames = new List<object>();
            genrGames.Add(new[] {"платформа", "кількість ігор"});

            foreach (var x in genr)
            {
                
                genrGames.Add(new object[] {x.Name, x.Games.Count()});
            }

            return new JsonResult(genrGames);
        }

        [HttpGet("JsonData2")]

        public JsonResult JsonData2()
        {
            var studios = _context.GameStudios.Include(g => g.Games).ToList();

            List<object> genrGames = new List<object>();
            genrGames.Add(new[] { "студія", "кількість ігор" });

            foreach (var x in studios)
            {

                genrGames.Add(new object[] { x.Name, x.Games.Count() });
            }

            return new JsonResult(genrGames);
        }

    }
}
