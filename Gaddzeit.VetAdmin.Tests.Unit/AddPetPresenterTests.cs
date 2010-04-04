using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Presenter;
using Gaddzeit.VetAdmin.Repository;
using Gaddzeit.VetAdmin.View;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Gaddzeit.VetAdmin.Domain;

namespace Gaddzeit.VetAdmin.Tests.Unit
{
    [TestFixture]
    public class AddPetPresenterTests
    {
        private MockRepository _mockRepository;
        private IPetRepository _petRepository;
        private IAddPetView _addPetView;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _petRepository = _mockRepository.StrictMock<IPetRepository>();
            _addPetView = _mockRepository.StrictMock<IAddPetView>();
        }

        [TearDown]
        public void TearDown()
        {
            _mockRepository.ReplayAll();

            _mockRepository.VerifyAll();
        }

        [Test]
        public void Constructor_ViewInput_AttachesEvents()
        {
            _addPetView.SavePet += null;
            LastCall.IgnoreArguments();

            _mockRepository.ReplayAll();

            var sut = new AddPetPresenter(_petRepository, _addPetView);
        }

        [Test]
        public void SavePetEvent_Raised_SavesPetWithName()
        {
            _addPetView.SavePet += null;
            var savePetEvent = LastCall.IgnoreArguments().GetEventRaiser();
            const string petName = "Fido";
            const string breed = "pug";
            const int age = 8;
            const string healthHistory = "Has had cysts removed on 3 occasions, risk of diabetes.";
            var id = Guid.NewGuid();

            Expect.Call(_addPetView.Name).Return(petName).Repeat.AtLeastOnce();
            Expect.Call(_addPetView.Breed).Return(breed).Repeat.AtLeastOnce();
            Expect.Call(_addPetView.Age).Return(age).Repeat.AtLeastOnce();
            Expect.Call(_addPetView.Id).Return(id).Repeat.AtLeastOnce();
            Expect.Call(_addPetView.HealthHistory).Return(healthHistory).Repeat.AtLeastOnce();
            _addPetView.Message = "";
            var pet = new Pet(petName, breed, age, id);
            pet.HealthHistory = healthHistory;
            _petRepository.SavePet(pet);
            _addPetView.Message = "Saved. (No page redirect yet.)";

            _mockRepository.ReplayAll();

            var sut = new AddPetPresenter(_petRepository, _addPetView);
            savePetEvent.Raise(_addPetView, EventArgs.Empty);

        }
    }
}
