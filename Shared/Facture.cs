using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Facturation.Shared
{
    public class Facture
    {
        public static int CLOSETODEADLINE = 5;

        [Required(ErrorMessage = "Champ requis")]
        public string client { get; set; }
        public string reference { get; set; }
        public Dates dates_Ticket { get; set; }
        public AmountDue amountDue_Ticket { get; set; }

        public Facture() { }
        public Facture(string client_name, string number, Dates dates, AmountDue amount)
        {
            client = client_name;
            reference = number;
            dates_Ticket = dates;
            amountDue_Ticket = amount;
        }

        public static string CalculateRemainingDays(DateTime deadline, out double numberOfDays)
        {
            numberOfDays = (deadline - DateTime.Today).TotalDays;

            return numberOfDays >= 0 ? (numberOfDays + " jour(s) restants.") : ("Dépassée de " + numberOfDays + " jours.");
        }
        public static double CalculateRemainingDays(DateTime deadline)
        {
            return (deadline - DateTime.Today).TotalDays;

            
        }
        public static string CalculateRemainingDaysAsString(DateTime deadline)
        {
            double numberOfDays = CalculateRemainingDays(deadline);
            return numberOfDays >= 0 ? (numberOfDays + " jour(s) restants.") : ("Dépassée de " + numberOfDays + " jours.");
        }

        public static float CalculateRemainingAmountDue(float total, float paid)
        {
            return (total - paid);
        }
        public static string CalculateRemainingAmountDueAsString(float total, float paid)
        {
            return CalculateRemainingAmountDue(total, paid) + " €";
        }
    }

    public class Dates
    {
        public DateTime sentOn { get; set; }
        public DateTime deadline { get; set; }

        public Dates() { }

        public Dates(int sentOn_modifier, int deadline_modifier)
        {
            sentOn = DateTime.Today.AddDays(sentOn_modifier);
            deadline = DateTime.Today.AddDays(deadline_modifier);
        }

        public bool IsCloseToDeadline()
        {
            return (deadline - DateTime.Today).TotalDays <= Facture.CLOSETODEADLINE;
        }
    }

    public class AmountDue
    {
        public float toPay { get; set; }
        public float paid { get; set; }

        public AmountDue() { }

        public AmountDue(float toPay, float paid)
        {
            this.toPay = toPay; this.paid = paid;
        }
    }
}
