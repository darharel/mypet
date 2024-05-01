using System;
using System.Collections.Generic;
using System.Text;

namespace PetitBear.Models
{
    public class SettingItemsModel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }




        public SettingItemsModel()
        {
            TargetType = typeof(SettingItemsModel);
        }
       


    }
}
