using HukukTakipWeb.Data;
using HukukTakipWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HukukTakipWeb.Controllers
{
    [Route("IcraTakip")]
    public class IcraTakipController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IcraTakipController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var liste = await _context.IcraTakipler
                .Include(x => x.Musteri)
                .Include(x => x.Urun)
                .Include(x => x.Avukat)
                .Include(x => x.Ihtar)
                .ToListAsync();

            return View(liste);
        }

        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            await DropdownDoldur();

            return View(new IcraTakip
            {
                IcraDosyaYili = DateTime.Now.Year.ToString()
            });
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(IcraTakip model)
        {
            if (model.MusteriId == null || model.MusteriId == 0)
                ModelState.AddModelError("MusteriId", "Borçlu seçilmelidir.");

            if (model.UrunId == 0)
                ModelState.AddModelError("UrunId", "Ürün seçilmelidir.");

            if (model.AvukatId == 0)
                ModelState.AddModelError("AvukatId", "Avukat seçilmelidir.");

            if (!ModelState.IsValid)
            {
                await DropdownDoldur();
                return View(model);
            }

            _context.IcraTakipler.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var kayit = await _context.IcraTakipler.FindAsync(id);

            if (kayit == null)
                return NotFound();

            await DropdownDoldur();

            return View(kayit);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, IcraTakip model)
        {
            if (id != model.IcraTakipId)
                return NotFound();

            if (model.MusteriId == null || model.MusteriId == 0)
                ModelState.AddModelError("MusteriId", "Borçlu seçilmelidir.");

            if (model.UrunId == 0)
                ModelState.AddModelError("UrunId", "Ürün seçilmelidir.");

            if (model.AvukatId == 0)
                ModelState.AddModelError("AvukatId", "Avukat seçilmelidir.");

            if (!ModelState.IsValid)
            {
                await DropdownDoldur();
                return View(model);
            }

            _context.IcraTakipler.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kayit = await _context.IcraTakipler.FindAsync(id);

            if (kayit != null)
            {
                _context.IcraTakipler.Remove(kayit);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("MusteriAvukatGetir/{musteriId}")]
        public async Task<IActionResult> MusteriAvukatGetir(int musteriId)
        {
            var urun = await _context.Urunler
                .Where(x => x.MusteriId == musteriId && x.AvukatId != null)
                .OrderByDescending(x => x.UrunId)
                .FirstOrDefaultAsync();

            if (urun == null || urun.AvukatId == null)
            {
                return Json(new
                {
                    avukatId = "",
                    urunId = ""
                });
            }

            return Json(new
            {
                avukatId = urun.AvukatId,
                urunId = urun.UrunId
            });
        }

        [HttpGet("MusteriIhtarlariGetir/{musteriId}")]
        public async Task<IActionResult> MusteriIhtarlariGetir(int musteriId)
        {
            var ihtarlar = await _context.Ihtarlar
                .Where(x => x.MusteriId == musteriId)
                .Select(x => new
                {
                    ihtarId = x.IhtarId,
                    ihtarNo = "İhtar ID: " + x.IhtarId
                })
                .ToListAsync();

            return Json(ihtarlar);
        }

        [HttpGet("MusteriUrunleriGetir/{musteriId}")]
        public async Task<IActionResult> MusteriUrunleriGetir(int musteriId)
        {
            var urunler = await _context.Urunler
                .Where(x => x.MusteriId == musteriId)
                .Select(x => new
                {
                    urunId = x.UrunId,
                    urunAdi = x.UrunAdi
                })
                .ToListAsync();

            return Json(urunler);
        }

        private async Task DropdownDoldur()
        {
            var musteriler = await _context.Musteriler.ToListAsync();

            ViewBag.Musteriler = new SelectList(
                musteriler.Select(x => new
                {
                    x.MusteriId,
                    Bilgi =
                        (x.MusteriNo ?? "") +
                        " - " +
                        x.MusteriId +
                        " - " +
                        (x.BorcluTuru ?? "") +
                        " - " +
                        (x.AdUnvan ?? "") +
                        " " +
                        (x.BorcluSoyadi ?? "")
                }),
                "MusteriId",
                "Bilgi"
            );

            ViewBag.Urunler = new SelectList(
                await _context.Urunler.ToListAsync(),
                "UrunId",
                "UrunAdi"
            );

            ViewBag.Avukatlar = new SelectList(
                (await _context.Avukatlar.ToListAsync()).Select(x => new
                {
                    x.AvukatId,
                    AdSoyad =
                        x.AvukatId +
                        " - " +
                        (x.Adi ?? "") +
                        " " +
                        (x.Soyadi ?? "")
                }),
                "AvukatId",
                "AdSoyad"
            );

            ViewBag.Ihtarlar = new SelectList(
                (await _context.Ihtarlar.ToListAsync()).Select(x => new
                {
                    x.IhtarId,
                    IhtarBilgi = "İhtar ID: " + x.IhtarId
                }),
                "IhtarId",
                "IhtarBilgi"
            );
        }
    }
}