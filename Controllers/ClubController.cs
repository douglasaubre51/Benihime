using Benihime.Data;
using Microsoft.AspNetCore.Mvc;

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
            var clubs = _context.Clubs.ToList();
            return View(clubs);
        }

    }
}
