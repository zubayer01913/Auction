using AuctionBd.Authoize;
using AuctionBd.Context;
using AuctionBd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AuctionBd.Controllers
{
    
    public class AuctionsController : Controller
    {
       
        private AuctionContext db = new AuctionContext();
        // GET: Auctions
        [Authorize]
        public ActionResult Index(string auctionCategory, string searchString)
        {
            
            AuctionContext context = new AuctionContext();
            //var auctions = context.Auctions.ToList();

            var CategoryLst = new List<string>();
            var CategoryQry = from d in db.Auctions
                           select d.Category;

            CategoryLst.AddRange(CategoryQry.Distinct());
            ViewBag.auctionCategory = new SelectList(CategoryLst);


            var auctions = from m in db.Auctions
                        select m;

            if(!String.IsNullOrEmpty(searchString))
            {
                auctions = auctions.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(auctionCategory))
            {
                auctions = auctions.Where(x => x.Category == auctionCategory);
            }


            return View(auctions);
        }



        public ActionResult Auction(long id)
        {
            AuctionContext context = new AuctionContext();
            var auction = db.Auctions.Find(id);

            return View(auction);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Bid(Bid bid)
        {
            AuctionContext context = new AuctionContext();
            var auction = db.Auctions.Find(bid.AuctionId);

            if (auction == null)
            {
                ModelState.AddModelError("AuctionId", "Auction not found!");
            }
            else if (auction.CurrentPrice >= bid.Amount)
            {
                ModelState.AddModelError("Amount", "Bid amount must exceed current bid");
            }
            else
            {
                bid.Username = User.Identity.Name;
                auction.Bids.Add(bid);
                auction.CurrentPrice = bid.Amount;
                db.SaveChanges();
            }

            if (!Request.IsAjaxRequest())
                return RedirectToAction("Auction", new { id = bid.AuctionId });

            return Json(new
            {
                CurrentPrice = bid.Amount.ToString("C"),
                BidCount = auction.BidCount
            });
        }


        // GET: Auctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Auction Auction = db.Auctions.Find(id);
            if (Auction == null)
                return HttpNotFound();
            return View(Auction);
        }
         
        // GET: Auctions/Create
        //[CustomAuthorizeUser(Users = "zubayer01913@gmail.com")]
        [Authorize(Users = "zubayer01913@gmail.com")]
        [HttpGet]
        public ActionResult Create()
        {
            var categoryList = new SelectList(new[] { "House", "Car", "Land", "Laptop", "Electric", "Computer Accessories", "Mobile Accessories", "Books", "Furniture", "Camera", "Monitor", "Bikes" });
            ViewBag.CategoryList = categoryList;

            return View();
        }

        // POST: Auctions/Create
       // [CustomAuthorizeUser(Users = "zubayer01913@gmail.com")]
        [Authorize(Users = "zubayer01913@gmail.com")]
        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Auctions.Add(auction);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(auction);
            }
        }

        [Authorize(Users = "zubayer01913@gmail.com")]
        // GET: Auctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
                return HttpNotFound();
            return View(auction);
        }


        [Authorize(Users = "zubayer01913@gmail.com")]
        // POST: Auctions/Edit/5
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(auction).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(auction);

            }

            catch
            {
                return View();
            }
        }

        [Authorize(Users = "zubayer01913@gmail.com")]
        // GET: Auctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Auction auction = db.Auctions.Find(id);
            if (auction == null)
                return HttpNotFound();
            return View(auction);
        }

        [Authorize(Users = "zubayer01913@gmail.com")]
        // POST: Auctions/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Auction auc)
        {
            try
            {
                Auction auction = new Auction();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    auction = db.Auctions.Find(id);
                    if (auction == null)
                        return HttpNotFound();
                    db.Auctions.Remove(auction);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(auction);
            }
            catch
            {
                return View();
            }
        }
    }
}
