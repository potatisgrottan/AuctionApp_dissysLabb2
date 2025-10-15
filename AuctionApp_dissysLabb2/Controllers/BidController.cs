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
                _bidService.PlaceBid(collection.AuctionId,User.Identity.Name, collection.Amount);
                
                //db call här
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
