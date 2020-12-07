using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public class Facture
    {
        public string Client { get; set; }
        public int Number { get; set; }
        public Dates Dates_Ticket { get; set; }
        public AmountDue AmountDue_Ticket { get; set; }

        public Facture(string client_name, int number, Dates dates, AmountDue amount)
        {
            Client = client_name;
            Number = number;
            Dates_Ticket = dates;
            AmountDue_Ticket = amount;
        }
    }

    public struct Dates
    {
        public DateTime SentOn { get; set; }
        public DateTime Deadline { get; set; }

        public Dates(int sentOn_modifier, int deadline_modifier)
        {
            SentOn = DateTime.Today.AddDays(sentOn_modifier); 
            Deadline = DateTime.Today.AddDays(deadline_modifier);
        }
    }

    public struct AmountDue
    {
        public float ToPay { get; set; }
        public float Paid { get; set; }

        public AmountDue(float toPay, float paid)
        {
            ToPay = toPay; Paid = paid;
        }
    }
}
