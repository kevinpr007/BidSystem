using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Models
{
    public interface IAuditable
    {
        string EntryBy { get; set; }

        DateTime EntryDate { get; set; }

        string LastUpdateBy { get; set; }

        DateTime? LastUpdateDate { get; set; }
    }
}
