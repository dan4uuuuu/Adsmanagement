using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdsManagement.Models
{
    public class OfferCategoryViewModel
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public virtual IList<OffersViewModel> Offers { get; set; }
    }
}