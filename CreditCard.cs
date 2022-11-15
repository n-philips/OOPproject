using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CreditCard
    {
        public string OwnerName { get; set; }
        public string CreditCardNumber { get; set; }
        public Date ExpirationDate { get; set; }
        public string CVV { get; set; }
        public decimal Charges { get; set; }

        public CreditCard(string name, string cardnum, Date expdate, string cvv, decimal charges)
        {
            //DateTime expdate = new DateTime(year, month, 00);
            
            this.OwnerName = name;
            this.CreditCardNumber = cardnum;
            this.ExpirationDate = expdate;
            this.CVV = cvv;
            this.Charges = charges;
        }

        //copy ctor
        public CreditCard(CreditCard card): this(card.OwnerName, card.CreditCardNumber, card.ExpirationDate, card.CVV, card.Charges)
        {

        }

        public override string ToString()
        {
            return $"Credit card info: \nCardholder name: {OwnerName}\nCard number: {CreditCardNumber}\nExpiration date: {ExpirationDate}\nCharges: {Charges:C}";
        }

        /*public static CreditCard Parse(string v)
        {
            throw new NotImplementedException();
        }*/
    }
}
