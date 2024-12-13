using CrazyMusicians.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CrazyMusiciansController : ControllerBase
    {
        private static readonly List<Musicians> crazyMusicians = new List<Musicians>
        {
            new Musicians { Id = 1, Name = "Ahmet Çalgý", Job = "Ünlü Çalgý Çalar", Description = "Her zaman yanlýþ nota çalar, ama çok eðlenceli" },
            new Musicians { Id = 2, Name = "Zeynep Melodi", Job = "Popüler Melodi Yazarý", Description = "Þarkýlarý yanlýþ anlaþýlýr ama çok popüler" },
            new Musicians { Id = 3, Name = "Cemil Akor", Job = "Çýlgýn Akorist", Description = "Akorlarý sýk deðiþtirir, ama þaþýrtýcý derecede yetenekli" },
            new Musicians { Id = 4, Name = "Fatma Nota", Job = "Sürpriz Nota Üreticisi", Description = "Nota üretirken sürekli sürprizler hazýrlar" },
            new Musicians { Id = 5, Name = "Hasan Ritim", Job = "Ritim Canavarý", Description = "Her ritmi kendi tarzýnda yapar, hiç uymaz ama komiktir" },
            new Musicians { Id = 6, Name = "Elif Armoni", Job = "Armoni Ustasý", Description = "Armonilerini bazen yanlýþ çalar, ama çok yaratýcýdýr" },
            new Musicians { Id = 7, Name = "Ali Perde", Job = "Perde Uygulayýcý", Description = "Her perdeyi farklý þekilde çalar; her zaman sürprizlidir" },
            new Musicians { Id = 8, Name = "Ayþe Rezonans", Job = "Rezonans Uzmaný", Description = "Rezonans konusunda uzman, ama bazen çok gürültü çýkarýr" },
            new Musicians { Id = 9, Name = "Murat Ton", Job = "Tonlama Meraklýsý", Description = "Tonlamalarýndaki farklýlýklar bazen komik, ama oldukça ilginç" },
            new Musicians { Id = 10,Name = "Selin Akor", Job = "Akor Sihirbazý", Description = "Akorlarý deðiþtirdiðinde bazen sihirli bir hava yaratýr" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Musicians>> Get()
        {
            return Ok(crazyMusicians);
        }

        [HttpGet("{id}")]
        public ActionResult<Musicians> Get(int id)
        {
            var musician = crazyMusicians.FirstOrDefault(x => x.Id == id);
            if (musician == null) return NotFound();
            return Ok(musician);
        }

        [HttpPost]
        public ActionResult<Musicians> Post([FromBody] Musicians musician)
        {
            musician.Id = crazyMusicians.Max(x => x.Id) + 1;
            crazyMusicians.Add(musician);
            return CreatedAtAction(nameof(Get), new { id = musician.Id }, musician);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Musicians updatedMusician)
        {
            var musician = crazyMusicians.FirstOrDefault(x => x.Id == id);
            if (musician == null) return NotFound();

            musician.Name = updatedMusician.Name;
            musician.Job = updatedMusician.Job;
            musician.Description = updatedMusician.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var musician = crazyMusicians.FirstOrDefault(c => c.Id == id);
            if (musician == null) return NotFound();
            crazyMusicians.Remove(musician);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var result = crazyMusicians.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!result.Any()) return NotFound("No musicians found with the given name.");
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDescription(int id, [FromBody] string updatedDescription)
        {
            var musician = crazyMusicians.FirstOrDefault(a => a.Id == id);
            if (musician == null) return NotFound("Musician not found.");
            if (string.IsNullOrEmpty(updatedDescription))
                return BadRequest("Description cannot be empty.");

            musician.Description = updatedDescription;
            return NoContent();
        }
    }
}