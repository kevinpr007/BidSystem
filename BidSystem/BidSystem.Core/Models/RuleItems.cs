using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public class RuleItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RuleItemId { get; set; }

        [Display(Name = "Rule minimun value of the Item")]
        [Range(1, 100, ErrorMessage = "The rule should be between 0 and 100")]
        public Decimal RuleMin { get; set; }

        [Display(Name = "Rule maximun value of the Item")]
        [Range(1, 100, ErrorMessage = "The rule should be between 0 and 100")]
        public Decimal RuleMax { get; set; }

        [Display(Name = "Assign value for Bid")]
        [Range(1, 100, ErrorMessage = "The rule should be between 0 and 100")]
        public Decimal ValueToBid { get; set; }
    }
}
