using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.VetAdmin.Presenter;
using Gaddzeit.VetAdmin.View;
using NUnit.Framework;
using Rhino.Mocks;

namespace Gaddzeit.VetAdmin.Tests.Unit
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
    }
}
