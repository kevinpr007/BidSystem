using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemId { get; set; }

        [Display(Name = "Name of the Item")]
        //[Column(TypeName = "nvarchar")]
        //[Required(ErrorMessage = "{0} is a mandatory field")]
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string Name { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "The property {0} should have {1} maximum characters")]
        public string Description { get; set; }
    }
}
