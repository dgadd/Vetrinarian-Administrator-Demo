using System;
using System.Web.Mvc;
using Gaddzeit.VetAdmin.Domain;
using Gaddzeit.VetAdmin.Repository;
using VetAdminMvc.Models;

namespace VetAdminMvc.Controllers
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
            return View();
        }

        public ViewResult SavePet(AddPetFormResponse addPetFormResponse)
        {
            if (ModelState.IsValid)
            {
                var pet = new Pet(addPetFormResponse.Name, addPetFormResponse.Breed, addPetFormResponse.Age.Value) {HealthHistory = addPetFormResponse.HealthHistory};
                _petRepository.SavePet(pet);
                ViewData.Add("message", "Pet details have been saved.");
            }
            else
            {
                ViewData.Add("message", addPetFormResponse.Error);
            }
            return View();            
        }
    }
}