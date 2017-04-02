using AdsManagement.DAL.Models;
using AdsManagement.Models;
using AutoMapper;

namespace AdsManagement.Extensions
{
    public static class ObjectMapping
    {
        public static void Initialize()
        {
            Mapper.Initialize(
                config =>
                {
                    config.CreateMap<OffersViewModel, Offer>();

                    config.CreateMap<Offer, OffersViewModel>();

                    config.CreateMap<OfferCategory, OfferCategoryViewModel>().ReverseMap();
                }
            );
        }
    }
}   