using AuctionApp_dissysLabb2.Core;
using AuctionApp_dissysLabb2.Core.Interfaces;
using AuctionApp_dissysLabb2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp_dissysLabb2.Controllers
{
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
            List<Auction> auctions = _auctionService.GetAllAuctions();
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
            return View();
        }

        // GET: AuctionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
