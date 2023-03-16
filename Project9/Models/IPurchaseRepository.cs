using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project9.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Buy> Buys { get; }

        void SaveBuy(Buy buy);
    }
}
