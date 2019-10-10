using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Display(Name = "UserName of the User")]
        //[Column(TypeName = "nvarchar")]
        //[Required(ErrorMessage = "{0} is a mandatory field")]
        [Required]
        [Index("IX_UserName", 1, IsUnique = true)]
        //TODO: Remove duplicate messages
        //TODO: Check Lenght with the database
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string UserName { get; set; }

        [Display(Name = "Name of the User")]
        //[Column(TypeName = "nvarchar")]
        //[Required(ErrorMessage = "{0} is a mandatory field")]
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string Name { get; set; }

        [Display(Name = "LastName of the User")]
        //[Column(TypeName = "nvarchar")]
        //[Required(ErrorMessage = "{0} is a mandatory field")]
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string LastName { get; set; }

        [Display(Name = "Email of the User")]
        //[Column(TypeName = "nvarchar")]
        //[Required(ErrorMessage = "{0} is a mandatory field")]
        [Required]
        [Index("IX_Email", 2, IsUnique = true)]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string Email { get; set; }

        public ICollection<ItemToSell> ItemsToSell { get; set; }

    }
}
