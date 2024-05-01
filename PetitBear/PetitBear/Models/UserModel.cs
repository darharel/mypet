using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PetitBear.Models
{
    public class UserModel
    {
        //special properties
        public event PropertyChangedEventHandler PropertyChanged;
        public Type TargetType { get; }
        public int id { get; }
        public string Password { get; }

        //Const Properties
        private string _firstName;
        private string _lastName;
        private string _fullName;
        private string _email;

        public IEnumerable<PetDetailsModel> MyPets { get; set; }

        //variable Properties
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                    return;

                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName == value)
                    return;

                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName == value)
                    return;

                _fullName = _firstName + _lastName;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == value)
                    return;

                _email = value;
                OnPropertyChanged();
            }
        }


        private void OnPropertyChanged([CallerMemberName] string PropertName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertName));
        }
    }
}
