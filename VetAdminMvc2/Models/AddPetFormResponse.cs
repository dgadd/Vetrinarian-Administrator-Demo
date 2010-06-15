using System.ComponentModel;

namespace VetAdminMvc2.Models
{
    public class AddPetFormResponse : IDataErrorInfo
    {
        private string _errorMessage;

        [DisplayName("Name of Pet")]     
        public string Name { get; set; }

        public string Breed { get; set; }
        
        public int? Age { get; set; }

        [DisplayName("Health History")]
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
