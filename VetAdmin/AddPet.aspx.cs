using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gaddzeit.VetAdmin.Repository;
using Gaddzeit.VetAdmin.View;
using Gaddzeit.VetAdmin.Presenter;

namespace VetAdmin
{
    public partial class AddPet : System.Web.UI.Page, IAddPetView
    {
        private AddPetPresenter _addPetPresenter;
        private Guid _newPetId;

        protected override void OnInit(EventArgs e)
        {
            _addPetPresenter = new AddPetPresenter(new FakePetRepository(), this);
            base.OnInit(e);
        }

        protected void btnAddPet_Click(object sender, EventArgs e)
        {
            if (this.SavePet != null) this.SavePet(this, EventArgs.Empty);
        }

        public event EventHandler SavePet;

        public string Name
        {
            get { return txtName.Text; }
        }

        public string Breed
        {
            get { return txtBreed.Text; }
        }

        public int Age
        {
            get { return int.Parse(txtAge.Text); }
        }

        public Guid Id
        {
            get
            {
                if(_newPetId == Guid.Empty)
                {
                    _newPetId = Guid.NewGuid();
                }
                return _newPetId;
            }
        }
    }
}
