using System;
using System.Linq;
using System.Web.Mvc;
using Gaddzeit.VetAdmin.Domain.Entities;
using Gaddzeit.VetAdmin.Repository;
using Gaddzeit.VetAdmin.Shared;
using VetAdminMvc2.Models;

namespace VetAdminMvc2.Controllers
{
    public class PetManagementController : Controller
    {
        private readonly IPetRepository _petRepository;

        public PetManagementController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public ViewResult AddPet()
        {
            ViewData.Add("message", "Please enter details for this pet.");
            var model = new AddPetFormResponse();
            return View(model);
        }

        public ActionResult SavePet(AddPetFormResponse addPetFormResponse)
        {
            if (ModelState.IsValid)
            {
                SavePetFormDataToRepository(addPetFormResponse);
                TempData.Add("message", string.Format("{0} has been added to VetAdmin.", addPetFormResponse.Name));
                return RedirectToAction("Success");
            }
            else
            {
                //ModelState.AddModelError(string.Empty, addPetFormResponse.Error);
                return View("AddPet",addPetFormResponse);
                //ViewData.Add("message", addPetFormResponse.Error);
            }
        }

        private void SavePetFormDataToRepository(AddPetFormResponse addPetFormResponse)
        {
            var pet = new Pet
                          {
                              Name = addPetFormResponse.Name,
                              Breed = addPetFormResponse.Breed,
                              Age = addPetFormResponse.Age.Value,
                              HealthHistory = addPetFormResponse.HealthHistory,
                              ModifiedBy = "anonymous web user"
                          };
            _petRepository.SavePet(pet);
        }

        public ViewResult FindAll(int? page)
        {
            const int howManyRowsPerPage = 8;

            var petsSubset = _petRepository.FindAll().AsQueryable();
            var paginatedPets = new PaginatedList<Pet>(petsSubset, page ?? 0, howManyRowsPerPage);

            return View(paginatedPets);
        }

        public ActionResult Success()
        {
            if (TempData["message"] != null)
            {
                var message = TempData["message"].ToString();
                ViewData.Add("message", message);
            }

            return View();

        }
    }
}