using PetitBear.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PetitBear.Services
{
    public class NewsFeedService
    {
        private IEnumerable<NewsFeedModel> _newsFeed;

        public NewsFeedService()
        {
            _newsFeed = new ObservableCollection<NewsFeedModel> 
            {
                new NewsFeedModel { From="Eli Elazra", id = 1, Description = "Your Facebook friend Jenny Dalby is on Instagram." },
                new NewsFeedModel { From="Haim Moshe", id = 2, Description = "Jonv started following you" },
                new NewsFeedModel { From="Ninet Taib", id = 3, Description = "RachelMartin liked your photo and started following you" },
                new NewsFeedModel { From="Gila Almagor", id = 4, Description = "Your Facebook friend Nivan Jay is on Instagram." },
                new NewsFeedModel { From="Omer Adam", id = 5, Description = "SanazZ sent a photo posted by @brookeisep and started following you" },
                new NewsFeedModel { From="Dudu Topaz", id = 6, Description = "NextLab started following you." },
                new NewsFeedModel { From="Alex B", id = 7, Description = "Your Facebook friend Alex B is on Instagram." },
                new NewsFeedModel { From="Tara Chang", id = 8, Description = "Your Facebook friend Tara Chang is on Instagram." },
                new NewsFeedModel { From="Tom ", id = 9, Description = "Your Facebook friend Tom K is on Instagram." }
            } ;
            
        }

        public IEnumerable<NewsFeedModel> GetNewsFeed(int userId)
        {
            return _newsFeed.Where(c => c.id == userId);

        }

        public IEnumerable<NewsFeedModel> GetAllNewsFeed()
        {
            return _newsFeed;
        }
    }
}
