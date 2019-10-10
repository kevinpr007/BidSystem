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
        public Bid() { }
        public Bid(int CurrentBid, int MaxOffer, Item item)
        {
            this.CurrentBid = CurrentBid;
            this.MaxOffer = MaxOffer;
            this.item = item;
        }

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
        public float CurrentBid { get; set; }

        [Required]
        [Display(Name = "MaxOffer for the item")]
        public float MaxOffer { get; set; }

        [Required]
        [Display(Name = "BidOut of the offer")]
        public bool BidOut { get; set; }

        [Display(Name = "Item of the Bid")]
        [Required]
        //[Column(TypeName = "varchar")]
        public Guid ItemId { get; set; }

        // Navigation Properties.
        [ForeignKey("ItemId")]
        public virtual Item item { get; set; }

    }
}
