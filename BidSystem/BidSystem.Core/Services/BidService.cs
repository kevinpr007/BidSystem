using BidSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Core.Services
{
    public class BidService
    {
        private float rule { get; set; } 

        public BidService(float rule)
        {
            this.rule = rule;
        }

        public void GetActualOwner(ref Bid owner, ref Bid contender)
        {
            if (owner.MaxOffer > contender.MaxOffer)
            {
                if ((owner.CurrentBid + rule) > owner.MaxOffer)
                {
                    throw new Exception("Error");
                }
                owner.CurrentBid = contender.MaxOffer + rule;
                contender.CurrentBid = contender.MaxOffer;
            }
            else
            {
                if ((contender.CurrentBid + rule) > contender.MaxOffer)
                {
                    throw new Exception("Error");
                }

                contender.CurrentBid = owner.MaxOffer + rule;
                owner.CurrentBid = owner.MaxOffer;
            }
        }
    }
}
