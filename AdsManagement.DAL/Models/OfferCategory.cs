using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsManagement.DAL.Models
{
    public class OfferCategory : ModelBase
    {
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual IList<Offer>  Offers { get; set; }
    }
}
