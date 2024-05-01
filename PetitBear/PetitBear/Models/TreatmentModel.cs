using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PetitBear.Models
{
    public class TreatmentModel
    {
        //special properties
        public event PropertyChangedEventHandler PropertyChanged;
        public Type TargetType { get; }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } // should delete "set" when implmented API

        //Const Properties
        private string _name;
        private string _period;
        private string _imageUrl;
        private DateTime _lastShot;

        //variable Properties
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
        public string Period
        {
            get { return _period; }
            set
            {
                if (_period == value)
                    return;
                _period = value;
               OnPropertyChanged(); 
            }
        }
        public string ImgUrl
        {
            get { return $"https://loremflickr.com/320/240/paris,girl/all"; } // /{id}
            set
            {
                if (_imageUrl == value)
                    return;
                _imageUrl = value;
                OnPropertyChanged(); 
            }
        }
        public DateTime LastShot
        {
            get { return _lastShot; }
            set
            {
                if (_lastShot == value)
                    return;
                _lastShot = value;
                OnPropertyChanged(); 
            }
        }


        private void OnPropertyChanged([CallerMemberName] string PropertName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertName));
        }
    }
}
