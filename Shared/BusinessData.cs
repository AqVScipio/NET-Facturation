using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public class BusinessData : IBusinessData
    {
        public IEnumerable<Facture> Factures => new List<Facture> {
            new Facture("Client 1", 141, new Dates(-10, 5), new AmountDue(150f, 0f)),
            new Facture("Client 2", 172, new Dates(-5, 15), new AmountDue(233f, 117.7f)),
            new Facture("Client 3", 180, new Dates(-3, 9), new AmountDue(55f, 44.8f)),
            new Facture("Client Quatre", 181, new Dates(-3, 9), new AmountDue(38f, 38f)),
            new Facture("Client Five", 189, new Dates(-2, 18), new AmountDue(944f, 212.57f))
        };

        public float GetCurrentRevenue()
        {
            float sum = 0;
            foreach (Facture facture in Factures)
            {
                sum += facture.AmountDue_Ticket.Paid;
            }
            return sum;
        }
    }
}
