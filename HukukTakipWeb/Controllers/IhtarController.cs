using HukukTakipWeb.Data;
using HukukTakipWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HukukTakipWeb.Controllers
{
    [Route("Ihtar")]
    public class IhtarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IhtarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index(string? arama)
        {
            var query = _context.Ihtarlar
                .Include(x => x.Musteri)
                .Include(x => x.Urun)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(arama))
            {
                query = query.Where(x =>
                    (x.Musteri != null && x.Musteri.AdUnvan.Contains(arama)) ||
                    (x.Urun != null && x.Urun.UrunAdi.Contains(arama)) ||
                    (x.NoterAdi != null && x.NoterAdi.Contains(arama)) ||
                    (x.YevmiyeNo != null && x.YevmiyeNo.Contains(arama)) ||
                    (x.IhtarNo != null && x.IhtarNo.Contains(arama))
                );
            }

            ViewBag.Arama = arama;

            var ihtarlar = await query.ToListAsync();
            return View(ihtarlar);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            await DropdownlariHazirla();
            return View(new Ihtar());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Ihtar ihtar)
        {
            if (ihtar.MusteriId == 0)
                ModelState.AddModelError("MusteriId", "Borçlu seçilmelidir.");

            if (!ModelState.IsValid)
            {
                await DropdownlariHazirla();
                return View(ihtar);
            }

            _context.Ihtarlar.Add(ihtar);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var ihtar = await _context.Ihtarlar.FindAsync(id);

            if (ihtar == null)
                return NotFound();

            await DropdownlariHazirla();
            return View(ihtar);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Ihtar ihtar)
        {
            if (id != ihtar.IhtarId)
                return NotFound();

            if (ihtar.MusteriId == 0)
                ModelState.AddModelError("MusteriId", "Borçlu seçilmelidir.");

            if (!ModelState.IsValid)
            {
                await DropdownlariHazirla();
                return View(ihtar);
            }

            _context.Ihtarlar.Update(ihtar);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ihtar = await _context.Ihtarlar.FindAsync(id);

            if (ihtar != null)
            {
                _context.Ihtarlar.Remove(ihtar);
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

            ViewBag.Urunler = new SelectList(
                await _context.Urunler.ToListAsync(),
                "UrunId",
                "UrunAdi"
            );
        }
    }
}