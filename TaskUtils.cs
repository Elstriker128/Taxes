using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxes
{
    public class TaskUtils
    {
        private PeopleLinkedList peopleLinkedList;
        public TaskUtils(PeopleLinkedList peopleLinkedList)
        {
            this.peopleLinkedList = peopleLinkedList;
        }

        /// <summary>
        /// This method finds the month during which all the taxes were the cheapest and its sum
        /// </summary>
        /// <param name="cheapest">the sum of cheapest taxes</param>
        /// <param name="taxes">an object of the TaxesLinkedList class</param>
        /// <returns>the month during which all the taxes were the cheapest and its sum</returns>
        private string CheapestMonth(out double cheapest, TaxesLinkedList taxes)
        {
            string month = string.Empty;
            cheapest = double.MaxValue;
            for (peopleLinkedList.Begin(); peopleLinkedList.Exist(); peopleLinkedList.Next())
            {
                Person curPerson = peopleLinkedList.GetPerson();
                double taxSum = 0;
                string curMonth = curPerson.PaidMonth;
                PeopleLinkedList curPeople = new PeopleLinkedList(peopleLinkedList);
                for (curPeople.Begin(); curPeople.Exist(); curPeople.Next())
                {
                    Person secondPerson = peopleLinkedList.GetPerson();
                    if (secondPerson.PaidMonth == curMonth)
                    {
                        taxSum += FindHowMuchPersonPaid(secondPerson, taxes);
                    }
                }
                if (taxSum < cheapest)
                {
                    cheapest = taxSum;
                    month = curMonth;
                }
            }
            return month;
        }
        /// <summary>
        /// This method finds all the taxes that were paid during the cheapest month for taxes
        /// </summary>
        /// <param name="month">the name of the cheapest month for taxes</param>
        /// <param name="taxes">an object of the TaxesLinkedList class</param>
        /// <param name="filteredTaxes">an object of TaxesLinkedList class that consists of the filtered taxes</param>
        public TaxesLinkedList AllTheCheapestTaxes(ref string month, TaxesLinkedList taxes)
        {
            TaxesLinkedList filteredTaxes = new TaxesLinkedList();
            double cheapest;
            month = CheapestMonth(out cheapest, taxes);
            for (peopleLinkedList.Begin(); peopleLinkedList.Exist(); peopleLinkedList.Next())
            {
                Person curPerson = peopleLinkedList.GetPerson();
                if (curPerson.PaidMonth == month)
                {
                    for (taxes.Begin(); taxes.Exist(); taxes.Next())
                    {
                        Tax curTax = taxes.GetTax();
                        if (curPerson.PaidCode == curTax.TaxCode)
                        {
                            filteredTaxes.AddTax(curTax);
                        }
                    }
                }
            }
            return filteredTaxes;
        }
        /// <summary>
        /// This method finds the sum of all the paid taxes of all citizens that are given in the primary data file
        /// </summary>
        /// <param name="taxes">an object of the TaxesLinkedList class</param>
        /// <returns>the sum of all the paid taxes of all citizens that are given in the primary data file</returns>
        public double FindAllTaxSum(TaxesLinkedList taxes)
        {
            double sum = 0;
            for (peopleLinkedList.Begin(); peopleLinkedList.Exist(); peopleLinkedList.Next())
            {
                Person curPerson = peopleLinkedList.GetPerson();
                for (taxes.Begin(); taxes.Exist(); taxes.Next())
                {
                    Tax curTax = taxes.GetTax();
                    if (curPerson.PaidCode == curTax.TaxCode)
                    {
                        sum += FindHowMuchPersonPaid(curPerson, taxes);
                    }
                }
            }
            return sum;
        }
        /// <summary>
        /// This method finds the amount of taxes that a person has paid in a single month
        /// </summary>
        /// <param name="taxes">an object of the TaxesLinkedList class</param>
        /// <returns>the amount of taxes that a person has paid in a single month</returns>
        private double FindHowMuchPersonPaid(Person current, TaxesLinkedList taxes)
        {
            for (taxes.Begin(); taxes.Exist(); taxes.Next())
            {
                Tax curTax = taxes.GetTax();
                if (current.PaidCode == curTax.TaxCode)
                {
                    return current.FullPaid = (current.PaidAmount * curTax.TaxCost);
                }
            }
            return 0;
        }
        /// <summary>
        /// This method finds the average amount of taxes paid in a year
        /// </summary>
        /// <param name="taxes">an object of the TaxesLinkedList class</param>
        /// <returns>the average amount of taxes paid in a year</returns>
        private double Average(TaxesLinkedList taxes)
        {
            double sum = FindAllTaxSum(taxes) * 12;
            return sum / peopleLinkedList.Count();
        }
        /// <summary>
        /// This method adds all the citizens who paid less taxes in a year than the average cost
        /// </summary>
        /// <param name="taxes">an object of the TaxesLinkedList class</param>
        /// <param name="filered">an object of PeopleLinkedList class that consists of the filtered citizens</param>
        public PeopleLinkedList AddWhoPaidLessThanAverage(TaxesLinkedList taxes)
        {
            PeopleLinkedList filtered = new PeopleLinkedList();
            double average = this.Average(taxes);
            for (peopleLinkedList.Begin(); peopleLinkedList.Exist(); peopleLinkedList.Next())
            {
                Person curPerson = peopleLinkedList.GetPerson();
                if (FindHowMuchPersonPaid(curPerson, taxes) * 12 < average)
                {
                    filtered.AddPerson(curPerson);
                }
            }
            return filtered;
        }
        /// <summary>
        /// This method filters the citizen linked list of all people who didn't pay the given tax during the given month
        /// </summary>
        /// <param name="month">the given month</param>
        /// <param name="tax">the given tax</param>
        /// <param name="taxes">an object of the TaxesLinkedList class</param>
        public void RemoveWhoDidntPayAtRequired(string month, string tax, TaxesLinkedList taxes)
        {
            Tax requiredTax = taxes.GetTaxByName(tax);
            for (peopleLinkedList.Begin(); peopleLinkedList.Exist(); peopleLinkedList.Next())
            {
                Person curPerson = peopleLinkedList.GetPerson();
                if ((curPerson.PaidCode != requiredTax.TaxCode) || (curPerson.PaidMonth != month))
                {
                    peopleLinkedList.Remove(curPerson);
                }
            }
        }
    }
}