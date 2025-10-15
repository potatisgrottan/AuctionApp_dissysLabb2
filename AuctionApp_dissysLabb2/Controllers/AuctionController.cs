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
            List<Auction> auctions = _auctionService.GetActiveAuctions();
            List<AuctionViewModel> vmAuctions = new List<AuctionViewModel>();
            foreach (Auction auction in auctions)
            {
                vmAuctions.Add(AuctionViewModel.FromAuction(auction));
            }
            vmAuctions = vmAuctions.OrderBy(a => a.EndTime).ToList();
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
            if (DateTime.Now > collection.EndDate)
            {
                ModelState.AddModelError("EndDate", "Auction end date is in the past");
                return View("Create", collection);
            }
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
            var auction = _auctionService.GetAuctionDetails(id);
            if (auction == null)
                return NotFound();
            if (!auction.Seller.Equals(User.Identity.Name))
            {
                return Forbid();
            }
            
            var auctionEditVM = new AuctionEditViewModel
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description
            };
            
            return View(auctionEditVM);
            
            
        }

        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuctionEditViewModel auctionEditVM)
        {
            if (!ModelState.IsValid)
                return View(auctionEditVM);
            try
            { 
                _auctionService.EditDescription(
                    auctionEditVM.Id, 
                    User.Identity!.Name!,
                    auctionEditVM.Description);
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
