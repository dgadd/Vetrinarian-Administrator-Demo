﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gaddzeit.VetAdmin.Domain;
using Gaddzeit.VetAdmin.Repository;
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
            return View();
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
                              HealthHistory = addPetFormResponse.HealthHistory
                          };
                _petRepository.SavePet(pet);
                ViewData.Add("message", "Pet details have been saved.");
            }
            else
            {
                ViewData.Add("message", addPetFormResponse.Error);
            }
            return View();            
        }

        public ViewResult FindAll(int howManyRowsPerPage, int whichPage)
        {
            var petsSubset = _petRepository.FindAll()
                .Skip((whichPage - 1)* howManyRowsPerPage)
                .Take(howManyRowsPerPage)
                .ToList();

            return View(petsSubset);
        }
    }
}