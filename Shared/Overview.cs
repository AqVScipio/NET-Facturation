using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturation.Shared
{
    public class Overview
    {
        public float currentAmountReceived { get; set; }
        public List<Facture> factures { get; set; }
        public float remainingIncomeToGet { get; set; }

        public float min_total { get; set; }
        public float max_total { get; set; }

        public Overview() { }
        public Overview(IEnumerable<Facture> factures) {
            this.factures = new List<Facture>(factures);
            foreach (Facture item in factures)
            {
                currentAmountReceived += item.amountDue_Ticket.paid;
            }
        }

        public string GetMaxDeadline()
        {
            DateTime deadline = factures.OrderByDescending(x => x.dates_Ticket.deadline).ToList()[0].dates_Ticket.deadline;
            foreach (Facture fac in factures)
            {
                max_total += fac.amountDue_Ticket.toPay;
            }
            return deadline.ToShortDateString();
        }
        public string GetMinDeadline()
        {
            Facture fac = factures.OrderBy(x => x.dates_Ticket.deadline).ToList()[0];
            foreach (Facture facture in factures)
            {
                min_total += facture.amountDue_Ticket.paid;
            }
            min_total += (fac.amountDue_Ticket.toPay - fac.amountDue_Ticket.paid);
            return fac.dates_Ticket.deadline.ToShortDateString();
        }
    }
}
