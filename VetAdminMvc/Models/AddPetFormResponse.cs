using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace VetAdminMvc.Models
{
    public class AddPetFormResponse : IDataErrorInfo
    {
        private string _errorMessage;

        public string Name { get; set; }
        public string Breed { get; set; }
        public int? Age { get; set; }
        public string HealthHistory { get; set; }

        #region IDataErrorInfo Members

        public string Error
        {
            get { return _errorMessage; }
        }

        public string this[string columnName]
        {
            get
            {
                if ((columnName == "Name") && string.IsNullOrEmpty(this.Name))
                    _errorMessage += "Please enter the pet's name.";
                else if ((columnName == "Breed") && string.IsNullOrEmpty(this.Breed))
                    _errorMessage += "Please enter the pet's breed.";
                else if ((columnName == "Age") && !this.Age.HasValue || this.Age == 0)
                    _errorMessage += "Please enter the pet's age.";
                return null;
            }
        }

        #endregion
    }
}
