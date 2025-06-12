using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KsiazkaController : ControllerBase
    {
        private static int idGen = 6;
        private static List<Ksiazka> ksiazki = new()
    {
            new Ksiazka { Id = 1, Tytul = "Zbrodnia i kara", Autor = "Fiodor Dostojewski", Gatunek = "Powieść psychologiczna", Rok = 1866 },
            new Ksiazka { Id = 2, Tytul = "Pan Tadeusz", Autor = "Adam Mickiewicz", Gatunek = "Epopeja narodowa", Rok = 1834 },
            new Ksiazka { Id = 3, Tytul = "Rok 1984", Autor = "George Orwell", Gatunek = "Dystopia", Rok = 1949 },
            new Ksiazka { Id = 4, Tytul = "Wiedźmin: Ostatnie życzenie", Autor = "Andrzej Sapkowski", Gatunek = "Fantasy", Rok = 1993 },
            new Ksiazka { Id = 5, Tytul = "Duma i uprzedzenie", Autor = "Jane Austen", Gatunek = "Romans", Rok = 1813 }
    };

        [HttpGet]
        public ActionResult<IEnumerable<Ksiazka>> GetAll() => ksiazki;

        [HttpGet("{id}")]
        public ActionResult<Ksiazka> GetById(int id)
        {
            var ksiazka = ksiazki.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null) return NotFound();
            return ksiazka;
        }

        [HttpPost]
        public IActionResult Post(KsiazkaBody body)
        {
            var ksiazka = new Ksiazka
            {
                Id = idGen++,
                Tytul = body.Tytul,
                Autor = body.Autor,
                Gatunek = body.Gatunek,
                Rok = body.Rok
            };

            ksiazki.Add(ksiazka);
            return CreatedAtAction(nameof(GetById), new { id = ksiazka.Id }, ksiazka);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, KsiazkaBody body)
        {
            var ksiazka = ksiazki.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null) return NotFound();

            ksiazka.Tytul = body.Tytul;
            ksiazka.Autor = body.Autor;
            ksiazka.Gatunek = body.Gatunek;
            ksiazka.Rok = body.Rok;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ksiazka = ksiazki.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null) return NotFound();

            ksiazki.Remove(ksiazka);
            return NoContent();
        }
    }
}