using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PetitBear.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color BackgroundColor{ get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string title, string iconSource, Color color, Type target)
        {
            Title = title;
            IconSource = iconSource;
            BackgroundColor = color;
            TargetType = target;

        }


    }
}
