using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserModel : BindableBase
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _fathersName = string.Empty;
        private string _highestEducation = string.Empty;
        private string _emailAddress = null;
        private string _permanentAddress = string.Empty;
        private string _primaryContactNumber = string.Empty;

        [Required(AllowEmptyStrings = true, ErrorMessage = "First name must not be empty.")]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters is allowed.")]
        public string FirstName { get { return _firstName; } set { _firstName = value; OnPropertyChanged("FirstName"); } }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Last name must not be empty.")]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters is allowed.")]
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged("LastName"); } }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Father's name must not be empty.")]
        [MaxLength(60, ErrorMessage = "Maximum of 60 characters is allowed.")]
        public string FathersName { get { return _fathersName; } set { _fathersName = value; OnPropertyChanged("FathersName"); } }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Highest education name must not be empty.")]
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters is allowed.")]
        public string HighestEducation { get { return _highestEducation; } set { _highestEducation = value; OnPropertyChanged("HighestEducation"); } }


        [EmailAddress(ErrorMessage = "Invalid email id")]
        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
               // if (value != null)
                {
                    _emailAddress = value;
                    OnPropertyChanged("EmailAddress");
                }
            }
        }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Address must not be empty.")]
        public string PermanentAddress { get { return _permanentAddress; } set { _permanentAddress = value; OnPropertyChanged("PermanentAddress"); } }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Phone number is not valid")]
        //[] Regular expression needed for phone number validation
        public string PrimaryContactNumber
        {
            get { return _primaryContactNumber; }
            set
            {
                if (value != string.Empty)
                {
                    _primaryContactNumber = value;
                    OnPropertyChanged("PrimaryContactNumber");
                }
            }
        }
    }
}
