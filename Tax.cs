using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxes
{
    public class Tax
    {
        /// <summary>
        /// A data class for all the possible taxes
        /// </summary>
        public string TaxCode { get; private set; }
        public string TaxName { get; private set; }
        public double TaxCost { get; private set; }

        /// <summary>
        /// A constructor for a Tax class object
        /// </summary>
        /// <param name="taxCode">the code of the tax</param>
        /// <param name="taxName">the name of the tax</param>
        /// <param name="taxCost">the cost of the tax</param>
        public Tax(string taxCode, string taxName, double taxCost)
        {
            TaxCode = taxCode;
            TaxName = taxName;
            TaxCost = taxCost;
        }
        /// <summary>
        /// An overriden ToString method to print the required tax data
        /// </summary>
        /// <returns>a string that is used to print the required tax data</returns>
        public override string ToString()
        {
            return String.Format($"{this.TaxCode,15} | {this.TaxName,-20} | {this.TaxCost,8} |");
        }
    }
}