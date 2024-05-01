using System;
using System.Collections.Generic;
using System.Text;

namespace PetitBear.Models
{
    public class NewsFeedModel
    {
        public string From { get; set; }
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Likes { get; set; }
        public DateTime  TimePublished{ get; set; }
        public string ImgURL { get { return $"https://loremflickr.com/1000/1000/dog"; } } // /{id}

        public Type TargetType { get; set; }
    }
}
