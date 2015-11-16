using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionBd.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int MobailNumber { get; set; }
        public string TextDescription { get; set; }
    }
}