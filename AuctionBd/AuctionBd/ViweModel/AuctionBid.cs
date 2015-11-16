using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionBd.ViweModel
{
    public class AuctionBid
    {
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, MinimumLength = 5)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public DateTime Timestamp { get; set; }

        public string Username { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        
    }
}