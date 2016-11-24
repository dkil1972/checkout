using System.Collections.Generic;

namespace Checkout.Domain.Ports
{
    public interface IScanItems
    {
        IList<Product> Scan(string goods);
    }
}
