using AdsManagement.DAL.Models;
using AdsManagement.DAL.Repository;
using AdsManagement.Extensions;
using AdsManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdsManagement.Controllers
{
    public class BaseController : Controller
    {
        protected IAdsManagementRepository<Offer> m_Repository;
        public BaseController(IAdsManagementRepository<Offer> repository)
        {
            m_Repository = repository;
        }

        public BaseController()
        {
            var service = new MockService();
            m_Repository = service.SeedData();
        }
    }
}