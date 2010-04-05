using System;
using System.Web.Mvc;
using Gaddzeit.VetAdmin.Repository;

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
    }
}