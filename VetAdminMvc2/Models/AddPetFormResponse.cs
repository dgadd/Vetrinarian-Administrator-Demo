using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VetAdminMvc2.Models
{
    public class AddPetFormResponse
    {
        private string _errorMessage;

        [Required(ErrorMessage = "You must provide a pet name.")]
        [DisplayName("Name of Pet")]     
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a pet breed.")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "You must provide the age of the pet.")]
        public int? Age { get; set; }

        [DisplayName("Health History")]
        public string HealthHistory { get; set; }
    }
}
