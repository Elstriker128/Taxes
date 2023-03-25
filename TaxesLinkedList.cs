using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxes
{
    public sealed class TaxesLinkedList
    {
        /// <summary>
        /// A Node class that consists of two properties: the tax's info and a direction towards the next tax's information
        /// </summary>
        private sealed class TaxNode
        {
            public Tax tax { get; set; }
            public TaxNode Link { get; set; }
            /// <summary>
            ///  A constructor for a TaxNode object
            /// </summary>
            /// <param name="tax">an object for the Person class</param>
            /// <param name="Link">an object for the direction towards the next tax's information</param>
            public TaxNode(Tax tax, TaxNode Link)
            {
                this.tax = tax;
                this.Link = Link;
            }

        }
        private TaxNode current;
        private TaxNode head;
        private TaxNode tail;
        /// <summary>
        /// A constructor for a TaxesLinkedList object
        /// </summary>
        public TaxesLinkedList()
        {
            this.current = null;
            this.head = null;
            this.tail = null;
        }
        /// <summary>
        /// This method adds the information of a singular tax at the end of the linked list
        /// </summary>
        /// <param name="tax">an object of the Tax class</param>
        public void AddTax(Tax tax)
        {
            var add = new TaxNode(tax, null);
            if (head != null)
            {
                tail.Link = add;
                tail = add;
            }
            else
            {
                head = add;
                tail = add;
            }
        }
        /// <summary>
        /// This method returns the required tax's data
        /// </summary>
        /// <returns>the required tax's data</returns>
        public Tax GetTax()
        {
            return current.tax;
        }
        /// <summary>
        /// This method counts all the currently placed taxes in the linked list
        /// </summary>
        /// <returns>the amount of currently placed taxes in the linked list</returns>
        public int Count()
        {
            int count = 0;
            for (this.Begin(); this.Exist(); this.Next())
            {
                count++;
            }
            return count;
        }
        /// <summary>
        /// This method places the primary value for the current variable that's going to bee used in calculations
        /// </summary>
        public void Begin()
        {
            current = head;
        }
        /// <summary>
        /// This method gives the next value for the current variable using the linked list format
        /// </summary>
        public void Next()
        {
            current = current.Link;
        }
        /// <summary>
        /// This method checks if there are the upcoming value for the current variable is not null
        /// </summary>
        /// <returns>returns either true of false depending on if the upcoming value for the current variable is not null</returns>
        public bool Exist()
        {
            return current != null;
        }
        /// <summary>
        /// This method gets the necesarry tax information based on it's name
        /// </summary>
        /// <param name="tax">an object of the Tax class</param>
        /// <returns>the necesarry tax information</returns>
        public Tax GetTaxByName(string tax)
        {
            for (this.Begin(); this.Exist(); this.Next())
            {
                Tax curTax = this.GetTax();
                if (curTax.TaxName == tax)
                {
                    return curTax;
                }
            }
            return null;
        }
    }
}