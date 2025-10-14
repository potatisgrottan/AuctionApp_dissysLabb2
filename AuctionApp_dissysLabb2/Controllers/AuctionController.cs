using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;
using AuctionApp_dissysLabb2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp_dissysLabb2.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
        // GET: AuctionController
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAllActiveAuctions();
            List<AuctionViewModel> vmAuctions = new List<AuctionViewModel>();
            foreach (Auction auction in auctions)
            {
                vmAuctions.Add(AuctionViewModel.FromAuction(auction));
            }
            return View(vmAuctions);
        }

        // GET: AuctionController/Details/5
        public ActionResult Details(int id)
        {
            Auction auction = _auctionService.GetAuctionDetails(id);
            if(auction == null) return BadRequest();
            
            AuctionDetailsViewModel detailsVM = AuctionDetailsViewModel.FromAuction(auction);
            return View(detailsVM);
        }

        // GET: AuctionController/Create
        public ActionResult Create()
        {
            return View(new AuctionCreateViewModel());
        }

        // POST: AuctionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuctionCreateViewModel collection)
        {
            try
            {
                _auctionService.CreateAuction(
                    collection.ItemName,
                    collection.Description,
                    User.Identity.Name,
                    collection.StartingPrice,
                    collection.EndDate);
                
                //skicka till db implementeras här
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: AuctionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctionController/Edit/5
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

        // GET: AuctionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionController/Delete/5
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
