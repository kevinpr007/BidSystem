using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public class Bid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BidId { get; set; }

        [Display(Name = "User of the Bid")]
        [Required]
        //[Column(TypeName = "varchar")]
        public Guid UserId { get; set; }

        // Navigation Properties.
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        [Display(Name = "CurrentBid of the item")]
        public Decimal CurrentBid { get; set; }

        [Required]
        [Display(Name = "MaxOffer for the item")]
        public Decimal MaxOffer { get; set; }

        [Required]
        [Display(Name = "BidOut of the offer")]
        public bool BidOut { get; set; }

    }
}
