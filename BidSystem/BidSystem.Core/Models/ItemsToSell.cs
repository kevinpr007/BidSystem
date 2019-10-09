using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public class ItemToSell
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemToSellId { get; set; }

        [Display(Name = "User of the item")]
        [Required]
        //[Column(TypeName = "varchar")]
        public Guid UserId { get; set; }

        // Navigation Properties.
        [ForeignKey("UserId")]
        public virtual User owner { get; set; }

        [Display(Name = "Rule of the Item")]
        //TODO: Check all decimal ranges
        [Range(1, 100, ErrorMessage = "The rule should be between 0 and 100")]
        public Decimal Rule { get; set; }
        
        [Display(Name = "ID of the item")]
        [Required]
        //[Column(TypeName = "varchar")]
        public Guid ItemId { get; set; }

        // Navigation Properties.
        [ForeignKey("ItemId")]
        public virtual Item item { get; set; }






        //[Display(Name = "line of business identifier")]
        //[Required]
        //[MaxLength(2)]
        //[Column(TypeName = "varchar")]
        //public string LOBID { get; set; }

        //// Navigation Properties.
        //[ForeignKey("LOBID")]
        //public virtual LOB LOB { get; set; }
    }
}
