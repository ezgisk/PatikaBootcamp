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
            new Musicians { Id = 1, Name = "Ahmet �alg�", Job = "�nl� �alg� �alar", Description = "Her zaman yanl�� nota �alar, ama �ok e�lenceli" },
            new Musicians { Id = 2, Name = "Zeynep Melodi", Job = "Pop�ler Melodi Yazar�", Description = "�ark�lar� yanl�� anla��l�r ama �ok pop�ler" },
            new Musicians { Id = 3, Name = "Cemil Akor", Job = "��lg�n Akorist", Description = "Akorlar� s�k de�i�tirir, ama �a��rt�c� derecede yetenekli" },
            new Musicians { Id = 4, Name = "Fatma Nota", Job = "S�rpriz Nota �reticisi", Description = "Nota �retirken s�rekli s�rprizler haz�rlar" },
            new Musicians { Id = 5, Name = "Hasan Ritim", Job = "Ritim Canavar�", Description = "Her ritmi kendi tarz�nda yapar, hi� uymaz ama komiktir" },
            new Musicians { Id = 6, Name = "Elif Armoni", Job = "Armoni Ustas�", Description = "Armonilerini bazen yanl�� �alar, ama �ok yarat�c�d�r" },
            new Musicians { Id = 7, Name = "Ali Perde", Job = "Perde Uygulay�c�", Description = "Her perdeyi farkl� �ekilde �alar; her zaman s�rprizlidir" },
            new Musicians { Id = 8, Name = "Ay�e Rezonans", Job = "Rezonans Uzman�", Description = "Rezonans konusunda uzman, ama bazen �ok g�r�lt� ��kar�r" },
            new Musicians { Id = 9, Name = "Murat Ton", Job = "Tonlama Merakl�s�", Description = "Tonlamalar�ndaki farkl�l�klar bazen komik, ama olduk�a ilgin�" },
            new Musicians { Id = 10,Name = "Selin Akor", Job = "Akor Sihirbaz�", Description = "Akorlar� de�i�tirdi�inde bazen sihirli bir hava yarat�r" }
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