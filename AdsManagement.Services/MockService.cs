using System;
using AdsManagement.DAL.Context;
using AdsManagement.DAL.Repository;
using AdsManagement.DAL.Models;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace AdsManagement.Services
{
    public class MockService : IMockService
    {
        public void InitDatabase()
        {
            throw new NotImplementedException();
        }

        public IAdsManagementRepository<Offer> SeedData() 
        {           
            var testDate = new DateTime(2017,04,01);
            List<Offer> Offers = new List<Offer>()
            {
                new Offer() { Id = 1, Description = "Offer description 1", Name = "Offer 1", StartDate = testDate, EndDate = new DateTime(2017,4,1).AddMonths(1),
                    Category = new OfferCategory()
                    {
                        Id = 1,
                        Name = "Offer category 1",
                    }
                },
                new Offer() { Id = 2, Description = "Offer description 2", Name = "Offer 2", StartDate =  testDate, EndDate = new DateTime(2017,4,1).AddMonths(120),
                    Category = new OfferCategory()
                    {
                        Id = 2,
                        Name = "Offer category 2",
                    }
                },
                new Offer() { Id = 3, Description = "Offer description 3", Name = "Offer 3", StartDate =  testDate, EndDate = new DateTime(2017,4,1).AddHours(22),
                    Category = new OfferCategory()
                    {
                        Id = 3,
                        Name = "Offer category 3",
                    }
                },
                new Offer() { Id = 4, Description = "Offer description 4", Name = "Offer 1", StartDate =  testDate, EndDate = new DateTime(2017,4,1).AddHours(33),
                    Category = new OfferCategory()
                    {
                        Id = 4,
                        Name = "Offer category 4",
                    }
                },
                new Offer() { Id = 5, Description = "Offer description 5", Name = "Offer  5", StartDate =  new DateTime(2016,3,1), EndDate = new DateTime(2016,04,01),
                    Category = new OfferCategory()
                    {
                        Id = 5,
                        Name = "Offer category 5",
                    }
                },

            };

            Mock<IAdsManagementRepository<Offer>> mockedRepository = new Mock<IAdsManagementRepository<Offer>>();
            
            mockedRepository.Setup(mr => mr.LoadAll()).Returns(() => { return Offers; });
            mockedRepository.Setup(
                mr => mr.LoadList(
                    It.IsAny<Expression<Func<Offer, bool>>>()
                )
                ).Returns(
                    (Expression<Func<Offer, bool>>  expressionFunction) => {
                        return Offers.AsQueryable().Where(expressionFunction).ToArray();
                    }
                );
            
            return mockedRepository.Object;
        }
    }
}
