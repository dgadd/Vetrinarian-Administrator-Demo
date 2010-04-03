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
            var pet = new Pet(_addPetView.Name, _addPetView.Breed, _addPetView.Age, _addPetView.Id);
            _petRepository.SavePet(pet);
        }
    }
}