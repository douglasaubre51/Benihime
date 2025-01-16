using Benihime.Data;
using Benihime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benihime.Controllers
{
    public class ClubController : Controller
    {
        // GET: ClubController
        private readonly ApplicationDBContext _context;
        public ClubController(ApplicationDBContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }

        public ActionResult Details(int id)
        {
            Club club = _context.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == id);

            return View(club);
        }
    }
}
