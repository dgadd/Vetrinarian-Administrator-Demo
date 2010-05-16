﻿using System.Linq;
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

        public ViewResult SavePet(AddPetFormResponse addPetFormResponse)
        {
            if (ModelState.IsValid)
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
                ViewData.Add("message", string.Format("{0} has been added to VetAdmin.", addPetFormResponse.Name));
            }
            else
            {
                ViewData.Add("message", addPetFormResponse.Error);
            }
            return View();            
        }

        public ViewResult FindAll(int howManyRowsPerPage, int? whichPage)
        {
            var petsSubset = _petRepository.FindAll().AsQueryable();
            var paginatedPets = new PaginatedList<Pet>(petsSubset, whichPage ?? 0, howManyRowsPerPage);

            
            //.Skip((whichPage - 1)* howManyRowsPerPage)
                //.Take(howManyRowsPerPage)
                //.ToList();

            //var upcomingDinners = dinnerRepository.FindUpcomingDinners();
            //var paginatedDinners = new PaginatedList<Dinner>(upcomingDinners, page ?? 0, pageSize);

            return View(paginatedPets);
        }
    }
}