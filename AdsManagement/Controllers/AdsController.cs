using AdsManagement.DAL.Models;
using AdsManagement.DAL.Repository;
using AdsManagement.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdsManagement.Controllers
{
    public class AdsController : BaseController
    {
        private IAdsManagementRepository<Offer> _repository;
        public AdsController()
        {
            _repository = this.m_Repository;
        }
        // GET: Ads
        public ActionResult Index()
        {
            List<Offer> data = _repository.LoadList(opt => opt.EndDate >= DateTime.Now).ToList();
            var afterMap = Mapper.Map<List<OffersViewModel>>(data);
            return View(afterMap);
        }

        public ActionResult ShowAdsByCategory(int categoryId = 1)
        {
            List<Offer> data = _repository.LoadList(opt => opt.EndDate >= DateTime.Now && opt.Category.Id == categoryId).ToList();
            var afterMap = Mapper.Map<List<OffersViewModel>>(data);
            return View(afterMap);
        }

        public ActionResult AddOffer()
        {
            List<OfferCategory> data = _repository.LoadList(opt => opt.EndDate >= DateTime.Now).Select(x => x.Category).ToList();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in data)
            {
                listItems.Add(
                    new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = item.Id == 1 ? true : false
                    });
            }
            var model = new OffersViewModel()
            {
                Categories = listItems
            };

            return View(model); 
        }
        [HttpPost]
        public ActionResult AddOffer(OffersViewModel model)
        {
            var afterMap = Mapper.Map<Offer>(model);
            _repository.Save(afterMap);
            return RedirectToAction("Index");
        }
    }
}