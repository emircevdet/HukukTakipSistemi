using HukukTakipWeb.Data;
using HukukTakipWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HukukTakipWeb.Controllers
{
    [Route("Musteri")]
    public class MusteriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusteriController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index(string? arama)
        {
            var query = _context.Musteriler.AsQueryable();

            if (!string.IsNullOrWhiteSpace(arama))
            {
                query = query.Where(x =>
                    (x.AdUnvan != null && x.AdUnvan.Contains(arama)) ||
                    (x.BorcluSoyadi != null && x.BorcluSoyadi.Contains(arama)) ||
                    (x.Tckn != null && x.Tckn.Contains(arama)) ||
                    (x.MusteriNo != null && x.MusteriNo.Contains(arama))
                );
            }

            ViewBag.Arama = arama;

            var musteriler = await query.ToListAsync();
            return View(musteriler);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new Musteri());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Musteri musteri)
        {
            if (string.IsNullOrWhiteSpace(musteri.AdUnvan))
                ModelState.AddModelError("AdUnvan", "Ad / Ünvan boş bırakılamaz.");

            if (string.IsNullOrWhiteSpace(musteri.Tckn))
                ModelState.AddModelError("Tckn", "TCKN boş bırakılamaz.");

            if (!string.IsNullOrWhiteSpace(musteri.Tckn) && (musteri.Tckn.Length != 11 || !musteri.Tckn.All(char.IsDigit)))
                ModelState.AddModelError("Tckn", "TCKN 11 haneli ve sadece rakamlardan oluşmalıdır.");

            if (!string.IsNullOrWhiteSpace(musteri.Tckn))
            {
                bool tcknVarMi = await _context.Musteriler.AnyAsync(x => x.Tckn == musteri.Tckn);

                if (tcknVarMi)
                    ModelState.AddModelError("Tckn", "Bu TCKN ile kayıtlı müşteri zaten var.");
            }

            if (!ModelState.IsValid)
                return View(musteri);

            _context.Musteriler.Add(musteri);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);

            if (musteri == null)
                return NotFound();

            return View(musteri);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Musteri musteri)
        {
            if (id != musteri.MusteriId)
                return NotFound();

            if (string.IsNullOrWhiteSpace(musteri.AdUnvan))
                ModelState.AddModelError("AdUnvan", "Ad / Ünvan boş bırakılamaz.");

            if (string.IsNullOrWhiteSpace(musteri.Tckn))
                ModelState.AddModelError("Tckn", "TCKN boş bırakılamaz.");

            if (!string.IsNullOrWhiteSpace(musteri.Tckn) && musteri.Tckn.Length != 11)
                ModelState.AddModelError("Tckn", "TCKN 11 haneli olmalıdır.");

            bool tcknBaskaMusterideVarMi = await _context.Musteriler
                .AnyAsync(x => x.Tckn == musteri.Tckn && x.MusteriId != musteri.MusteriId);

            if (tcknBaskaMusterideVarMi)
                ModelState.AddModelError("Tckn", "Bu TCKN başka bir müşteriye ait.");

            if (!ModelState.IsValid)
                return View(musteri);

            _context.Musteriler.Update(musteri);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);

            if (musteri != null)
            {
                _context.Musteriler.Remove(musteri);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}