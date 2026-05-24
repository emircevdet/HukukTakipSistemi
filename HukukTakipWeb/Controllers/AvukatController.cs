using HukukTakipWeb.Data;
using HukukTakipWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HukukTakipWeb.Controllers
{
    [Route("Avukat")]
    public class AvukatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvukatController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index(string? arama)
        {
            var query = _context.Avukatlar.AsQueryable();

            if (!string.IsNullOrWhiteSpace(arama))
            {
                query = query.Where(x =>
                    (x.Adi != null && x.Adi.Contains(arama)) ||
                    (x.Soyadi != null && x.Soyadi.Contains(arama)) ||
                    (x.KullaniciAdi != null && x.KullaniciAdi.Contains(arama)) ||
                    (x.Tckn != null && x.Tckn.Contains(arama)) ||
                    (x.VergiNo != null && x.VergiNo.Contains(arama))
                );
            }

            ViewBag.Arama = arama;

            var avukatlar = await query.ToListAsync();
            return View(avukatlar);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new Avukat
            {
                DosyaDagitim = true,
                HesapAktifMi = true
            });
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Avukat avukat)
        {
            if (string.IsNullOrWhiteSpace(avukat.Adi))
                ModelState.AddModelError("Adi", "Adı boş bırakılamaz.");

            if (string.IsNullOrWhiteSpace(avukat.Soyadi))
                ModelState.AddModelError("Soyadi", "Soyadı boş bırakılamaz.");

            if (!ModelState.IsValid)
                return View(avukat);

            _context.Avukatlar.Add(avukat);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var avukat = await _context.Avukatlar.FindAsync(id);

            if (avukat == null)
                return NotFound();

            return View(avukat);
        }

       [HttpPost("Edit/{id}")]
public async Task<IActionResult> Edit(int id, Avukat avukat)
{
    if (id != avukat.AvukatId)
        return NotFound();

    if (!ModelState.IsValid)
        return View(avukat);

    _context.Avukatlar.Update(avukat);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}
        

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var avukat = await _context.Avukatlar.FindAsync(id);

            if (avukat != null)
            {
                _context.Avukatlar.Remove(avukat);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}