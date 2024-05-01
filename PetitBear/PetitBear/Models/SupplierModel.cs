using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PetitBear.Models
{
    public class SupplierModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ImgURL { get { return $"https://loremflickr.com/320/240"; } } // /{id}
        public string BGImgURL { get { return $"https://loremflickr.com/320/240"; } } // /{id}
        public string GPS { get; set; }
        public string Waze { get; set; }
        public string Description { get; set; }
        public string Profession { get; set; }
        public List<CommentModel> CommmentsList   = new List<CommentModel> 
            {
                new CommentModel { From="Eli Elazra", ID = 1, To = "Your", Content=" Facebook friend Jenny Dalby is on Instagram.", Date="Dec 2016" },
                new CommentModel { From="Haim Moshe", ID = 2, To = "Jonv" , Content= "started following you" , Date = "Dec 2016" },
                new CommentModel { From="Ninet Taib", ID = 3, To = "RachelMartin",  Content= "liked your photo and started following you" , Date="Dec 2016"},
                new CommentModel { From="Gila Almagor", ID = 4, To = "Sami", Content= "Facebook friend Nivan Jay is on Instagram." , Date="Dec 2016"},
                new CommentModel { From="Omer Adam", ID = 5, To = "SanazZ", Content= "sent a photo posted by @brookeisep and started following you" , Date="Dec 2016"},
    
            } ; 


        public Type TargetType { get; set; }
    }
}
    