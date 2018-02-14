using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Models
{
    public class BindableBase : INotifyPropertyChanged, IDataErrorInfo  //INotifyPropertyChanged is used to generate notify change and IDataErrorInfo for validation
    {

        #region IDataErrorInfo implementation
        public string this[string columnName]
        {
            get
            {
                return OnValidate(columnName);
            }
        }

        public string Error
        {
            get
            {
                throw new NotSupportedException("Validation Error supporting is not supported");
            }
        }

        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };
            var result = new Collection<ValidationResult>();
            var isValide = Validator.TryValidateObject(this, context, result, true);
            if (!isValide)
            {
                var error = result.FirstOrDefault(x => x.MemberNames.Contains(context.MemberName)); // From all the error, error corresponding to the property is only returned.
                if (error != null)
                   return error.ErrorMessage;
            }
            return null;
        }
        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
