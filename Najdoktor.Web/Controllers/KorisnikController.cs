using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Najdoktor.DAL;
using Najdoktor.Web.Models;
using Najdoktor.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Najdoktor.Web.Controllers
{
	public class KorisnikController : Controller
	{
		private DataManagerDbContext _dbContext;
		public KorisnikController(DataManagerDbContext dbContext)
		{
			this._dbContext = dbContext;
		}
		public IActionResult Index()
		{
            
            return View();
		}

		[HttpPost]
		public IActionResult RecenzijaTable(RecenzijaFilterModel filter)
		{
			var recenzije = _dbContext.Recenzije.Include(r => r.Doktor).ThenInclude(d => d.Bolnica).ThenInclude(b => b.Grad).
			Include(r => r.Doktor).ThenInclude(d => d.Specijalizacija).Include(r => r.Pacijent).ToList();
			if (!string.IsNullOrWhiteSpace(filter.Grad))
				recenzije = recenzije.Where(r => r.Doktor.Bolnica.Grad.Naziv.ToLower().Contains(filter.Grad.ToLower())).ToList();

			if (!string.IsNullOrWhiteSpace(filter.Specijalizacija))
				recenzije = recenzije.Where(r => r.Doktor.Specijalizacija.NazivSpecijalizacije.ToLower().Contains(filter.Specijalizacija.ToLower())).ToList();

			if (!filter.Ocjena.Equals(0))
				recenzije = recenzije.Where(r => r.Ocjena == filter.Ocjena).ToList();

			return PartialView("_RecenzijaTable", recenzije);
		}
		public IActionResult CreatePacijent()
		{
			this.FillDropdownGradovi();
			return View();
		}

		[HttpPost]
		public IActionResult CreatePacijent(Pacijent model)
		{
			ModelState.Remove("Grad");
            model.Grad = _dbContext.Gradovi.Find(model.GradID);
            if (ModelState.IsValid)
			{
				_dbContext.Pacijenti.Add(model);
				_dbContext.SaveChanges();

				return RedirectToAction(nameof(Index));
			}
			else
			{
				this.FillDropdownGradovi();
				return View();
			}
		}
		public IActionResult CreateRecenzija()
		{
			this.FillDropdownPacijenti();
			this.FillDropdownDoktori();
			return View();
		}

		[HttpPost]
		public IActionResult CreateRecenzija(Recenzija model)
		{
			ModelState.Remove("Doktor");
			ModelState.Remove("Pacijent");
			if (ModelState.IsValid)
			{
				_dbContext.Recenzije.Add(model);
				_dbContext.SaveChanges();

				return RedirectToAction(nameof(Index));
			}
			else
			{
				this.FillDropdownPacijenti();
				this.FillDropdownDoktori();
				return View();
			}
		}
		public IActionResult RecenzijaDetails(int id)
		{
			var recenzija = _dbContext.Recenzije.Include(r => r.Doktor).ThenInclude(d => d.Bolnica).ThenInclude(b => b.Grad).
			Include(r => r.Doktor).ThenInclude(d => d.Specijalizacija).Include(r => r.Pacijent).FirstOrDefault(r => r.ID == id);
			return View(recenzija);
		}



		private void FillDropdownGradovi()
		{
			var selectItems = new List<SelectListItem>();

			//Polje je opcionalno
			var listItem = new SelectListItem();
			listItem.Text = "- odaberite grad -";
			listItem.Value = "";
			selectItems.Add(listItem);

			foreach (var category in _dbContext.Gradovi)
			{
				listItem = new SelectListItem(category.Naziv, category.ID.ToString());
				selectItems.Add(listItem);
			}

			ViewBag.Gradovi = selectItems;
		}
		private void FillDropdownPacijenti()
		{
			var selectItems = new List<SelectListItem>();

			//Polje je opcionalno
			var listItem = new SelectListItem();
			listItem.Text = "- odaberite pacijenta -";
			listItem.Value = "";
			selectItems.Add(listItem);

			foreach (var category in _dbContext.Pacijenti)
			{
				listItem = new SelectListItem(category.ImePrezime, category.ID.ToString());
				selectItems.Add(listItem);
			}

			ViewBag.Pacijenti = selectItems;
		}
		private void FillDropdownDoktori()
		{
			var selectItems = new List<SelectListItem>();

			//Polje je opcionalno
			var listItem = new SelectListItem();
			listItem.Text = "- odaberite doktora -";
			listItem.Value = "";
			selectItems.Add(listItem);

			foreach (var category in _dbContext.Doktori)
			{
				listItem = new SelectListItem(category.ImePrezime, category.ID.ToString());
				selectItems.Add(listItem);
			}

			ViewBag.Doktori = selectItems;
		}
	}
}
