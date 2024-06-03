using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Najdoktor.DAL;
using Najdoktor.Model;

namespace Najdoktor.Web.Controllers
{
	public class DoktorController : Controller
	{
		private DataManagerDbContext _dbContext;
		public DoktorController(DataManagerDbContext dbContext)
		{
			this._dbContext = dbContext;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult CreateDoktor()
		{
			this.FillDropdownBolnice();
			this.FillDropdownSpecijalizacije();
			return View();
		}

		[HttpPost]
		public IActionResult CreateDoktor(Doktor model)
		{
			ModelState.Remove("Bolnica");
			ModelState.Remove("Specijalizacija");
			if (ModelState.IsValid)
			{
				_dbContext.Doktori.Add(model);
				_dbContext.SaveChanges();

				return RedirectToAction(nameof(Index));
			}
			else
			{
				this.FillDropdownBolnice();
				this.FillDropdownSpecijalizacije();
				return View();
			}
		}
		private void FillDropdownBolnice()
		{
			var selectItems = new List<SelectListItem>();

			//Polje je opcionalno
			var listItem = new SelectListItem();
			listItem.Text = "- odaberite bolnicu -";
			listItem.Value = "";
			selectItems.Add(listItem);

			foreach (var category in _dbContext.Bolnice)
			{
				listItem = new SelectListItem(category.Naziv, category.ID.ToString());
				selectItems.Add(listItem);
			}

			ViewBag.Bolnice = selectItems;
		}
		private void FillDropdownSpecijalizacije()
		{
			var selectItems = new List<SelectListItem>();

			//Polje je opcionalno
			var listItem = new SelectListItem();
			listItem.Text = "- odaberite spec. -";
			listItem.Value = "";
			selectItems.Add(listItem);

			foreach (var category in _dbContext.Specijalizacije)
			{
				listItem = new SelectListItem(category.NazivSpecijalizacije, category.ID.ToString());
				selectItems.Add(listItem);
			}

			ViewBag.Specijalizacije = selectItems;
		}
	}
}
