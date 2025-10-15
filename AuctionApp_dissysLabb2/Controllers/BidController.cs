using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;
using AuctionApp_dissysLabb2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp_dissysLabb2.Controllers
{
    public class BidController : Controller
    {
        IBidService _bidService;
        
        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }
        // GET: BidController
        public ActionResult Index()
        {
            List<Bid> bids = _bidService.GetBidsForBidder(User.Identity.Name);
            List<BidViewModel> vmBids = new List<BidViewModel>();
            foreach (Bid bid in bids)
            {
                vmBids.Add(BidViewModel.FromBid(bid));
            }
            return View(vmBids);
        }

        // GET: BidController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BidController/Create
        public ActionResult Create(int auctionId)
        {
            return View(new BidCreateViewModel() {AuctionId = auctionId });
        }

        // POST: BidController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BidCreateViewModel collection)
        {
            
            
            try
            {
                if (!_bidService.PlaceBid(collection.AuctionId, User.Identity.Name, collection.Amount))
                {
                    ModelState.AddModelError(string.Empty, "Your bid is too low. Please enter a higher amount.");
                    return View("Create", collection);
                }

                //db call här
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create",collection);
            }
        }

        // GET: BidController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BidController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BidController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BidController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
