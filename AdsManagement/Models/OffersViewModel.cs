using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdsManagement.Models
{
    public class OffersViewModel
    {
        public int Id { get; set; }

        [MaxLength(25)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [MaxLength(255)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        [DisplayName("Category")]
        public virtual OfferCategoryViewModel Category { get; set; }

        [DisplayName("Categories")]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}