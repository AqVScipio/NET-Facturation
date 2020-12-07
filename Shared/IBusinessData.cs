using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public interface IBusinessData
    {
        IEnumerable<Facture> Factures { get; }
        float GetCurrentRevenue();
    }
}
