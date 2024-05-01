using System;
using System.Collections.Generic;
using System.Text;

namespace PetitBear.Models
{
    public class Token
    {
        public int ID { get; set; }
        public string access_token { get; set; }
        public DateTime expire_date { get; set; }
        public int expire_in { get; set; }
        public Token()
        {

        }
    }
}
