using Benihime.ViewModels;
using Benihime.Data;
using Benihime.Interfaces;
using Benihime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;

namespace Benihime.Controllers
{
    public class ClubController : Controller
    {
        // GET: ClubController
        private readonly IClubRepository _repository;
        private readonly IPhotoService _photoService;
        public ClubController(IClubRepository repository, IPhotoService photoService)
        {
            _repository = repository;
            _photoService = photoService;
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
        public async Task<ActionResult> Create(CreateClubViewModel clubVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(clubVM.Image);

                var club = new Club
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        State = clubVM.address.State,
                        City = clubVM.address.City,
                        Street = clubVM.address.Street,
                    }
                };

                _repository.Add(club);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "photo upload failed!");
            }

            return View(clubVM);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var club = await _repository.GetByIdAsync(id);

            if (club == null)
                return View("Error");

            var clubVM = new EditClubViewModel
            {
                Id = club.Id,
                Title = club.Title,
                Description = club.Description,
                ClubCategory = club.ClubCategory,
                AddressId = club.AddressId,
                Address = club.Address,
                URL = club.Image
            };

            return View(clubVM);
        }
    }
}