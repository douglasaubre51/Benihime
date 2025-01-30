using Benihime.Data;
using Benihime.Interfaces;
using Benihime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benihime.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _repository;
        public RaceController(IRaceRepository repository)
        {
            _repository = repository;
        }
        // GET: RaceController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Race> races = await _repository.GetAll();
            return View(races);
        }
        public async Task<ActionResult> Details(int Id)
        {
            Race race = await _repository.GetByIdAsync(Id);
            return View(race);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Race race)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(race);
                return RedirectToAction("Index");
            }

            else
            {
                return View(race);
            }
        }
    }
}