using Benihime.Data;
using Benihime.Interfaces;
using Benihime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benihime.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IRaceRepository _repository;
        public RaceController(ApplicationDBContext context, IRaceRepository repository)
        {
            _context = context;
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
    }
}