using Benihime.Data;
using Benihime.Interfaces;
using Benihime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benihime.Controllers
{
    public class ClubController : Controller
    {
        // GET: ClubController
        private readonly ApplicationDBContext _context;
        private readonly IClubRepository _repository;
        public ClubController(ApplicationDBContext context, IClubRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task<ActionResult> Index()
        {
            IEnumerable<Club> clubs = await _repository.GetAll();
            return View(clubs);
        }
        public async Task<ActionResult> Details(int id)
        {
            Club club = await _repository.GetByIdAsync(id);
            return View(club);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Club club)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(club);
                return RedirectToAction("Index");
            }

            return View(club);
        }
    }
}