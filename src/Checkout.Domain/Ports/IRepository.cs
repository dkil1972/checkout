using System.Collections.Generic;
using Checkout.Domain;
using System.Linq;

namespace Checkout.Domain.Ports
{
    public interface IPricingRepository
    {
        IList<SpecialOffer> Get(IList<string> productName);
    }

    public interface IProductRepository
    {
        IList<Product> Get(char [] goods);
    }
}

