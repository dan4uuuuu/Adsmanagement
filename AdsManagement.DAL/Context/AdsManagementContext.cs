using AdsManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsManagement.DAL.Context
{
    public class AdsManagementContext : DbContext
    {
        public AdsManagementContext()
        : base()
        {

        }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<OfferCategory> OfferCatefory { get; set; }
    }
}
