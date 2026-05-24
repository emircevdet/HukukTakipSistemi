using HukukTakipWeb.Data;
using HukukTakipWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HukukTakipWeb.Controllers
{
    [Route("Urun")]
    public class UrunController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UrunController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index(string? arama)
        {
            var query = _context.Urunler
                .Include(x => x.Musteri)
                .Include(x => x.Avukat)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(arama))
            {
                query = query.Where(x =>
                    (x.UrunAdi != null && x.UrunAdi.Contains(arama)) ||
                    (x.KrediMudiNo != null && x.KrediMudiNo.Contains(arama)) ||
                    (x.Musteri != null && x.Musteri.AdUnvan.Contains(arama)) ||
                    (x.Avukat != null && x.Avukat.Adi.Contains(arama)) ||
                    (x.Avukat != null && x.Avukat.Soyadi.Contains(arama))
                );
            }

            ViewBag.Arama = arama;

            var urunler = await query.ToListAsync();
            return View(urunler);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            await DropdownlariHazirla();
            return View(new Urun());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Urun urun)
        {
            if (urun.MusteriId == 0)
                ModelState.AddModelError("MusteriId", "Borçlu müşteri seçilmelidir.");

            if (string.IsNullOrWhiteSpace(urun.UrunAdi))
                ModelState.AddModelError("UrunAdi", "Ürün adı boş bırakılamaz.");

            if (!ModelState.IsValid)
            {
                await DropdownlariHazirla();
                return View(urun);
            }

            _context.Urunler.Add(urun);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);

            if (urun == null)
                return NotFound();

            await DropdownlariHazirla();
            return View(urun);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Urun urun)
        {
            if (id != urun.UrunId)
                return NotFound();

            if (urun.MusteriId == 0)
                ModelState.AddModelError("MusteriId", "Borçlu müşteri seçilmelidir.");

            if (string.IsNullOrWhiteSpace(urun.UrunAdi))
                ModelState.AddModelError("UrunAdi", "Ürün adı boş bırakılamaz.");

            if (!ModelState.IsValid)
            {
                await DropdownlariHazirla();
                return View(urun);
            }

            _context.Urunler.Update(urun);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);

            if (urun != null)
            {
                _context.Urunler.Remove(urun);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task DropdownlariHazirla()
        {
            ViewBag.Musteriler = new SelectList(
                await _context.Musteriler.ToListAsync(),
                "MusteriId",
                "AdUnvan"
            );

            var avukatlar = await _context.Avukatlar.ToListAsync();

            ViewBag.Avukatlar = new SelectList(
                avukatlar.Select(x => new
                {
                    x.AvukatId,
                    AdSoyad = x.Adi + " " + x.Soyadi
                }),
                "AvukatId",
                "AdSoyad"
            );
        }
    }
}