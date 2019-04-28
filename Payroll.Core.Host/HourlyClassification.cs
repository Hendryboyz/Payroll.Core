using System;
using System.Collections;

namespace Payroll.Core.Host
{
    public class HourlyClassification : PaymentClassification
    {
        private readonly Hashtable _timeCards; 
        public double HourlyRate { get; set; }
        

        public HourlyClassification(double hourlyRate)
        {
            HourlyRate = hourlyRate;
            _timeCards = new Hashtable();
        }

        public void AddTimeCard(TimeCard timeCard)
        {
            _timeCards.Add(timeCard.Date, timeCard);
        }

        public TimeCard GetTimeCard(DateTime workingDay)
        {
            return _timeCards[workingDay] as TimeCard;
        }

        public override double CalculatePay(PayCheck payCheck)
        {
            throw new NotImplementedException();
        }
    }
}