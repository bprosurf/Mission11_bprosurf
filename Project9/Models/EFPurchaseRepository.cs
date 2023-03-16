using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project9.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;
        public EFPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Buy> Buys => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);


        public void SaveBuy(Buy buy)
        {
            context.AttachRange(buy.Lines.Select(x => x.Book));

            if (buy.PurchaseId == 0)
            {
                context.Purchases.Add(buy);
            }

            context.SaveChanges();
        }
    }
}
