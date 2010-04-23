using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Presenter;
using Gaddzeit.VetAdmin.View;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace Gaddzeit.VetAdmin.Tests.Unit.Presenters
{
    [TestFixture]
    public class HomePresenterTests
    {
        private MockRepository _mockRepository;
        private IHomeView _homeView;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _homeView = _mockRepository.StrictMock<IHomeView>();
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
            _homeView.Initialize += null;
            LastCall.IgnoreArguments();

            _mockRepository.ReplayAll();

            var sut = new HomePresenter(_homeView);
        }

        [Test]
        public void InitializeEvent_Raised_SetsTitleToWelcome()
        {
            _homeView.Initialize += null;
            var initializeEvent = LastCall.IgnoreArguments().GetEventRaiser();
            _homeView.PageTitle = string.Format("Welcome to M-V-P site. Logged in at {0}", DateTime.Now.ToString()); 
            
            _mockRepository.ReplayAll();

            var sut = new HomePresenter(_homeView);
            initializeEvent.Raise(_homeView, EventArgs.Empty);
        }
    }
}
