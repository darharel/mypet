using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PetitBear.Models
{
    public class VetDetailModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime NextVisit { get; set; }
        
        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set
            {
                if (value.Equals(_createdAt))
                {
                    return;
                }
                _createdAt = value;
                OnPropertyChanged();
            }
        }
        
        private DateTime _modifiedAt;
        public DateTime ModifiedAt
        {
            get { return _modifiedAt; }
            set
            {
                if (value.Equals(_modifiedAt))
                {
                    return;
                }
                _modifiedAt = value;
                OnPropertyChanged();
            }
        }
        
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public VetDetailModel()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }

    }
}
