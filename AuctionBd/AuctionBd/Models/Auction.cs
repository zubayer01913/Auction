using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionBd.Models
{
    public class Auction
    {


        [Required]
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, MinimumLength = 5)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Starting Price")]
        public decimal StartPrice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Current Bid Price")]
        public decimal? CurrentPrice { get; set; }

        public virtual Collection<Bid> Bids { get; private set; }

        public int BidCount
        {
            get { return Bids.Count; }
        }

        public Auction()
        {
            Bids = new Collection<Bid>();
        }
    }
}