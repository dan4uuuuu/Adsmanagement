using AdsManagement.DAL.Models;
using AdsManagement.DAL.Repository;

namespace AdsManagement.Services
{
    public interface IMockService
    {
        void InitDatabase();
        IAdsManagementRepository<Offer> SeedData();
    }
}
