using MeineRestApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeineRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuchController : ControllerBase
    {

        private static List<Buch> buecher = new List<Buch>();
        private static long naechsteId = 1;

        /// <summary>
        /// Gibt alle Bücher zurück.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Buch>> GetAlleBuecher()
        {
            return buecher;
        }

        /// <summary>
        /// Gibt ein Buch mit der angegebenen Id zurück.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Buch> GetBuch(long id)
        {
            var buch = buecher.FirstOrDefault(b => b.Id == id);
            if (buch == null)
            {
                return NotFound();
            }
            return buch;
        }

        /// <summary>
        /// Erstellt ein neues Buch.
        /// </summary>
        [HttpPost]
        public ActionResult<Buch> NeuesBuch(Buch buch)
        {
            buch.Id = naechsteId++;
            buecher.Add(buch);
            return CreatedAtAction(nameof(GetBuch), new { id = buch.Id }, buch);
        }

        /// <summary>
        /// Aktualisiert ein bestehendes Buch.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult BuchAktualisieren(long id, Buch buch)
        {
            var vorhandenesBuch = buecher.FirstOrDefault(b => b.Id == id);
            if (vorhandenesBuch == null)
            {
                return NotFound();
            }
            vorhandenesBuch.Titel = buch.Titel;
            vorhandenesBuch.Autor = buch.Autor;
            vorhandenesBuch.Erscheinungsjahr = buch.Erscheinungsjahr;
            return NoContent();
        }

        /// <summary>
        /// Löscht ein Buch mit der angegebenen Id.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult BuchLoeschen(long id)
        {
            var buch = buecher.FirstOrDefault(b => b.Id == id);
            if (buch == null)
            {
                return NotFound();
            }
            buecher.Remove(buch);
            return NoContent();
        }
    }
}
