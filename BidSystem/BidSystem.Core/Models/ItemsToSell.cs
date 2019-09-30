using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public class ItemsToSell
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemsToSellId { get; set; }

        [Display(Name = "Rule of the Item")]
        [Range(1, 100, ErrorMessage = "The rule should be between 0 and 100")]
        public Decimal Rule { get; set; }
        
        //public Guid ItemId { get; set; }
        //public Item item { get; set; }

        //public Guid UserId { get; set; }
        //public Users owner { get; set; }
    }
}
