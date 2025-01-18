using Benihime.Data;
using Benihime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benihime.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDBContext _context;
        public RaceController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: RaceController
        public ActionResult Index()
        {
            List<Race> races = _context.Races.Include(e => e.Address).ToList();

            return View(races);
        }

        public ActionResult Details(int Id)
        {
            Race race = _context.Races.Include(a => a.Address).FirstOrDefault(a => a.Id == Id);

            return View(race);
        }

    }
}