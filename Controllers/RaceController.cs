using System.Threading.Tasks;
using Benihime.Data;
using Benihime.Interfaces;
using Benihime.Models;
using Benihime.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benihime.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _repository;
        private readonly IPhotoService _photoService;
        public RaceController(IRaceRepository repository, IPhotoService photoService)
        {
            _repository = repository;
            _photoService = photoService;
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
        public async Task<ActionResult> Create(CreateRaceViewModel raceVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(raceVM.Image);

                var race = new Race
                {
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        State = raceVM.Address.State,
                        City = raceVM.Address.City,
                        Street = raceVM.Address.Street,
                    }
                };
                _repository.Add(race);
                return RedirectToAction("Index");
            }

            else
            {
                return View(raceVM);
            }
        }
    }
}