using System;
using System.Collections;
using Payroll.Core.Domain;

namespace Payroll.Core.Classifications
{
    public class HourlyClassification : PaymentClassification
    {
        private const int NORMAL_WORKING_HOURS = 8;
        private const double OVERTIME_RATE = 1.5;
        public double HourlyRate { get; set; }
        private readonly Hashtable _timeCards; 

        public HourlyClassification(double hourlyRate)
        {
            HourlyRate = hourlyRate;
            _timeCards = new Hashtable();
        }

        public void AddTimeCard(int employeeId, DateTime workingDate, double workingHours)
        {
            TimeCard timeCard = new TimeCard(employeeId, workingDate, workingHours);
            _timeCards.Add(timeCard.Date, timeCard);
        }

        public TimeCard GetTimeCard(DateTime workingDay)
        {
            return _timeCards[workingDay] as TimeCard;
        }

        public override double CalculatePay(PayCheck payCheck)
        {
            double totalPay = 0.0;
            foreach (TimeCard eachCard in _timeCards.Values)
            {
                if (InPayPeriod(eachCard.Date, payCheck.PayDate))
                {
                    totalPay += CalculatePayForPeriod(eachCard.Hours);
                }
            }
            return totalPay;
        }

        private bool InPayPeriod(DateTime workingDate, DateTime payDate)
        {
            DateTime payPeriodStart = payDate.AddDays(-5);
            return payPeriodStart <= workingDate && workingDate <= payDate;
        }

        private double CalculatePayForPeriod(double workingHours)
        {
            if (workingHours < NORMAL_WORKING_HOURS)
            {
                return CalculateHourlyPay(workingHours);
            }
            else
            {
                double normalPay = CalculateHourlyPay(NORMAL_WORKING_HOURS);
                double overHours = workingHours - NORMAL_WORKING_HOURS;
                return normalPay + CalculateHourlyPay(overHours * OVERTIME_RATE);
            }
        }

        private double CalculateHourlyPay(double hours)
        {
            return hours * HourlyRate;
        }
    }
}