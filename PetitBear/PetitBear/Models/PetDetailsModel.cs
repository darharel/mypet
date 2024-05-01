using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace PetitBear.Models
{
    public class PetDetailsModel : INotifyPropertyChanged
    {
        //special properties
        public event PropertyChangedEventHandler PropertyChanged;
        public Type TargetType { get; }

        [PrimaryKey,AutoIncrement]
        public int ID { get; set; } // when implment API there should be no "set"

      
        //public TrainerModel _trainer;
        //public VetDetailModel _vetDetails { get; set; }
        //public TreatmentModel _treatment{ get; set; }
        //Const Properties
        private string _name;
        private string _gender;
        private double _age;
        private string _race;
        private string _size;
        private string _ownerName;
        private string _city;
        private int _weight;
        //private List<PetDetailsModel> _friendsList;
        public bool isNewPet = true;
        //variable Properties
        [MaxLength(255)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;

                _name = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender == value)
                    return;

                _gender = value;
                OnPropertyChanged();
            }
        }
        public double Age
        {
            get { return _age; }
            set
            {
                if (_age == value)
                    return;
                _age = value;
                OnPropertyChanged();

            }
        }
        public string Race
        {
            get { return _race; }
            set
            {
                if (_race == value)
                    return;

                _race = value;
                OnPropertyChanged();
            }
        }
        public string Size
        {
            get { return _size; }
            set
            {
                if (_size == value)
                    return;

                _size = value;
                OnPropertyChanged();
            }
        }
        public string OwnerName
        {
            get { return _ownerName; }
            set
            {
                if (_ownerName == value)
                    return;

                _ownerName = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                if (_city == value)
                    return;

                _city = value;
                OnPropertyChanged();
            }
        }
        public int Weight
        {
            get { return _weight; }
            set
            {
                if (_weight == value)
                    return;

                _weight = value;
                OnPropertyChanged();
            }
        }
        //public List<PetDetailsModel> FriendsList
        //{
        //    get { return _friendsList; }
        //    set
        //    {
        //        if (_friendsList == value)
        //            return;

        //        _friendsList = value;
        //        OnPropertyChanged();
        //    }
        //}

        public string BGImgURL { get { return $"https://loremflickr.com/320/240/paris,girl/all"; } } // /{id}
        public string ImgURL { get { return $"https://loremflickr.com/320/240/dog"; } } // /{id}

        public string Description { get; set; }
        public int Likes { get; set; }
        public int Friends { get; set; }
        public string Color { get; set; }


        private void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
