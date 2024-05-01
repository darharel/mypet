using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PetitBear.Models
{
    public class CommentModel
    {

        //special properties
        public event PropertyChangedEventHandler PropertyChanged;
        public Type TargetType { get; }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } // should delete "set" when implmented API

        //Const Properties
        private string _from;
        private string _to;
        private string _content;
        private string _date; //(DateTime)

        //variable Properties
        public string From
        {
            get { return _from; }
            set
            {
                if (_from == value)
                    return;
                _from = value;
                OnPropertyChanged();
            }
        }
        public string To
        {
            get { return _to; }
            set
            {
                if (_to == value)
                    return;
                _to = value;
                OnPropertyChanged();
            }
        }
        public string Content
        {
            get { return $"This supplier is a very good one. you should order from him."; } // /{id}
            set
            {
                if (_content == value)
                    return;
                _content = value;
                OnPropertyChanged();
            }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                if (_date == value)
                    return;
                _date = value;
                OnPropertyChanged();
            }
        }


        private void OnPropertyChanged([CallerMemberName] string PropertName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertName));
        }


    }
}
