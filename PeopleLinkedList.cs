using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Taxes
{
    public sealed class PeopleLinkedList
    {
        /// <summary>
        /// A Node class that consists of two properties: the citzen's info and a direction towards the next citzen's information
        /// </summary>
        private sealed class PersonNode
        {
            public Person person { get; set; }
            public PersonNode Link { get; set; }

            /// <summary>
            /// A constructor for a PersonNode object
            /// </summary>
            /// <param name="person">an object for the Person class</param>
            /// <param name="Link">an object for the direction towards the next citzen's information</param>
            public PersonNode(Person person, PersonNode Link)
            {
                this.person = person;
                this.Link = Link;
            }
        }
        private PersonNode current;
        private PersonNode head;
        private PersonNode tail;
        /// <summary>
        /// A constructor for a PeopleLinkedList object
        /// </summary>
        public PeopleLinkedList()
        {
            this.current = null;
            this.head = null;
            this.tail = null;
        }
        public PeopleLinkedList(PeopleLinkedList allPeople)
        {
            this.head=allPeople.head;
            this.tail=allPeople.tail;
            this.current = allPeople.current;
        }
        /// <summary>
        /// This method adds the information of a singular citizen at the end of the linked list
        /// </summary>
        /// <param name="person">an object for the Person class</param>
        public void AddPerson(Person person)
        {
            var add = new PersonNode(person, null);
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
        /// This method returns the required citizen's data
        /// </summary>
        /// <returns>the required citizen's data</returns>
        public Person GetPerson()
        {
            return current.person;
        }
        /// <summary>
        /// This method counts all the currently placed citizens in the linked list
        /// </summary>
        /// <returns>the amount of currently placed citizens in the linked list</returns>
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
        ///  This method gives the next value for the current variable using the linked list format
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
        /// This method sorts the required citizen linked list
        /// </summary>
        public void Sort()
        {
            for (PersonNode d1 = this.head; d1 != null; d1 = d1.Link)
            {
                PersonNode minv = d1;
                for (PersonNode d2 = d1.Link; d2 != null; d2 = d2.Link)
                {
                    if (d2.person < minv.person)
                    {
                        minv = d2;
                    }
                }
                Person curPerson = d1.person;
                d1.person = minv.person;
                minv.person = curPerson;
            }
        }
        /// <summary>
        /// This method removes the required citizen from the linked list
        /// </summary>
        /// <param name="needed">an object of the PersonNode class</param>
        public void Remove(Person needed)
        {
            if (head == null)
            {
                return;
            }

            if (head.person == needed)
            {
                head = head.Link;
                return;
            }

            PersonNode prev = head;
            while (prev.Link != null && prev.Link.person != needed)
            {
                prev = prev.Link;
            }

            if (prev.Link != null)
            {
                prev.Link = prev.Link.Link;
            }
        } 
    }
}