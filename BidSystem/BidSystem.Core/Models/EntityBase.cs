using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public abstract class EntityBase : IAuditable
    {
        [Required]
        public bool Active { get; set; }

        [Display(Name = "entered by")]
        [Required]
        [MaxLength(35)]
        [Column(TypeName = "varchar")]
        public string EntryBy { get; set; }

        [Display(Name = "entered date")]
        [Required]
        public DateTime EntryDate { get; set; }

        [Display(Name = "updated by")]
        [MaxLength(35)]
        [Column(TypeName = "varchar")]
        public string LastUpdateBy { get; set; }

        [Display(Name = "updated date")]
        public DateTime? LastUpdateDate { get; set; }

    }
}
