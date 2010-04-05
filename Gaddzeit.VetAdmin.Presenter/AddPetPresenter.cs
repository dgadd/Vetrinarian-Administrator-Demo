using Gaddzeit.VetAdmin.Domain;
using Gaddzeit.VetAdmin.Repository;
using Gaddzeit.VetAdmin.View;

namespace Gaddzeit.VetAdmin.Presenter
{
    public class AddPetPresenter
    {
        private readonly IPetRepository _petRepository;
        private readonly IAddPetView _addPetView;

        public AddPetPresenter(IPetRepository petRepository, IAddPetView addPetView)
        {
            _petRepository = petRepository;
            _addPetView = addPetView;

            _addPetView.SavePet += new System.EventHandler(AddPetViewSavePet);
        }

        void AddPetViewSavePet(object sender, System.EventArgs e)
        {
            if (!AreViewInputsValid()) return;
            var pet = new Pet(_addPetView.Name, _addPetView.Breed, _addPetView.Age);
            pet.HealthHistory = _addPetView.HealthHistory;
            _petRepository.SavePet(pet);
            _addPetView.Message = "Saved. (No page redirect yet.)";
        }

        private bool AreViewInputsValid()
        {
            var isValid = true;
            _addPetView.Message = "";

            if(_addPetView.Name.Length == 0)
            {
                _addPetView.Message += "You must provide a name.<br/>";
                isValid = false;
            }
            if (_addPetView.Breed.Length == 0)
            {
                _addPetView.Message += "You must provide a breed.<br/>";
                isValid = false;
            }
            if (_addPetView.Age == 0)
            {
                _addPetView.Message += "You must provide an age.<br/>";
                isValid = false;
            }
            return isValid;
        }
    }
}