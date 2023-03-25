using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxes
{
    public class Person
    {
        /// <summary>
        /// A data class for all the possible citizens
        /// </summary>
        public string SurnameAndName { get; private set; }
        public string Address { get; private set; }
        public string PaidMonth { get; private set; }
        public string PaidCode { get; private set; }
        public int PaidAmount { get; private set; }
        public double FullPaid { get; set; }

        /// <summary>
        /// A constructor for a Person class object
        /// </summary>
        /// <param name="surnameAndName">the surname and name of the citizen</param>
        /// <param name="address">the address of the citizen</param>
        /// <param name="paidMonth">the month that the citizen paid taxes for</param>
        /// <param name="paidCode">the code of the tax that the citizen paid for</param>
        /// <param name="paidAmount">the amount of singular packets a citizen paid for</param>
        /// <param name="fullPaid">the whole amount a citizen for in taxes</param>
        public Person(string surnameAndName, string address, string paidMonth, string paidCode, int paidAmount, double fullPaid)
        {
            SurnameAndName = surnameAndName;
            Address = address;
            PaidMonth = paidMonth;
            PaidCode = paidCode;
            PaidAmount = paidAmount;
            FullPaid = fullPaid;
        }
        /// <summary>
        /// An overlaid ">" operator used for sorting
        /// </summary>
        /// <param name="a">an object of the Person class</param>
        /// <param name="b">an object of the Person class</param>
        /// <returns>either truth or false if a is more than b</returns>
        public static bool operator >(Person a, Person b)
        {
            if (a.Address != b.Address)
            {
                return string.Compare(a.Address, b.Address) > 0;
            }
            else if (a.SurnameAndName != b.SurnameAndName)
            {
                return string.Compare(a.SurnameAndName, b.SurnameAndName) > 0;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// An overlaid "<" operator used for sorting
        /// </summary>
        /// <param name="a">an object of the Person class</param>
        /// <param name="b">an object of the Person class</param>
        /// <returns>either truth or false if a is less than b</returns>
        public static bool operator <(Person a, Person b)
        {
            if (a.Address != b.Address)
            {
                return string.Compare(a.Address, b.Address, StringComparison.CurrentCulture) < 0;
            }
            else if (a.SurnameAndName != b.SurnameAndName)
            {
                return string.Compare(a.SurnameAndName, b.SurnameAndName, StringComparison.CurrentCulture) < 0;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// An overriden ToString method to print the required citizen data
        /// </summary>
        /// <returns>a string that is used to print the required citizen data</returns>
        public override string ToString()
        {

            return String.Format($"{this.SurnameAndName,-28} | {this.Address,-15} | {this.PaidMonth,-15} | {this.PaidCode,15} | {this.PaidAmount,18} |");
        }
    }
}