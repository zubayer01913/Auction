using AuctionBd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuctionBd.Context
{
    public class AuctionContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}