using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public class PlayRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PlayRoomId { get; set; }

        [Display(Name = "Item to sell")]
        [Required]
        //[Column(TypeName = "varchar")]
        public Guid ItemToSellId { get; set; }

        // Navigation Properties.
        [ForeignKey("ItemToSellId")]
        public virtual ItemToSell ItemToSell { get; set; }

        [Required]
        public DateTime TimeToEnd { get; set; }

        //TODO: Check this area
        public ICollection<Bid> Bids { get; set; }
    }
}
