using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Taxes
{
    public partial class UIForClient : System.Web.UI.Page
    {
        /// <summary>
        /// This method prints the citizens' data to a table
        /// </summary>
        /// <param name="people">an object of the PeopleLinkedList class</param>
        /// <param name="required">an object of the Table class</param>
        private void InsertCitizenData(PeopleLinkedList people, Table required)
        {
            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = "Citizen data";
            called.ColumnSpan = 5;
            prow.Cells.Add(called);
            required.Rows.Add(prow);

            TableRow frow = new TableRow();

            TableCell fname = new TableCell();
            fname.Text = "Surname and name";

            TableCell faddress = new TableCell();
            faddress.Text = "Address";

            TableCell fmonth = new TableCell();
            fmonth.Text = "Tax month";

            TableCell fcode = new TableCell();
            fcode.Text = "Tax code";

            TableCell fpackage = new TableCell();
            fpackage.Text = "Singular packages";


            frow.Cells.Add(fname);
            frow.Cells.Add(faddress);
            frow.Cells.Add(fmonth);
            frow.Cells.Add(fcode);
            frow.Cells.Add(fpackage);

            required.Rows.Add(frow);

            for (people.Begin(); people.Exist(); people.Next())
            {
                Person curPerson = people.GetPerson();

                TableRow row = new TableRow();

                TableCell name = new TableCell();
                name.Text = curPerson.SurnameAndName;

                TableCell address = new TableCell();
                address.Text = curPerson.Address;

                TableCell month = new TableCell();
                month.Text = curPerson.PaidMonth;

                TableCell code = new TableCell();
                code.Text = curPerson.PaidCode;

                TableCell package = new TableCell();
                package.Text = curPerson.PaidAmount.ToString();

                row.Cells.Add(name);
                row.Cells.Add(address);
                row.Cells.Add(month);
                row.Cells.Add(code);
                row.Cells.Add(package);

                required.Rows.Add(row);
            }

        }
        /// <summary>
        /// This method prints the citizens' data to a table 
        /// </summary>
        /// <param name="taxes">an object of the TaxesLinkedList class</param>
        /// <param name="required">an object of the Table class</param>
        private void InsertTaxData(TaxesLinkedList taxes, Table required)
        {
            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = "Tax data";
            called.ColumnSpan = 3;
            prow.Cells.Add(called);
            required.Rows.Add(prow);

            TableRow frow = new TableRow();

            TableCell fname = new TableCell();
            fname.Text = "Name";

            TableCell fcode = new TableCell();
            fcode.Text = "Tax code";

            TableCell fcost = new TableCell();
            fcost.Text = "Cost";


            frow.Cells.Add(fname);
            frow.Cells.Add(fcode);
            frow.Cells.Add(fcost);

            required.Rows.Add(frow);
            for (taxes.Begin(); taxes.Exist(); taxes.Next())
            {
                Tax curTax = taxes.GetTax();

                TableRow row = new TableRow();

                TableCell name = new TableCell();
                name.Text = curTax.TaxName;

                TableCell code = new TableCell();
                code.Text = curTax.TaxCode;

                TableCell cost = new TableCell();
                cost.Text = curTax.TaxCost.ToString();

                row.Cells.Add(name);
                row.Cells.Add(code);
                row.Cells.Add(cost);

                required.Rows.Add(row);
            }
        }
        /// <summary>
        /// This method prints the filtered citizens to a table
        /// </summary>
        /// <param name="filtered">an object of the TaxesLinkedList class</param>
        /// <param name="required">an object of the Table class</param>
        private void InsertFilteredData(PeopleLinkedList filtered, Table required)
        {
            TableRow prow = new TableRow();

            TableCell called = new TableCell();
            called.Text = "Filtered citizen data";
            called.ColumnSpan = 2;
            prow.Cells.Add(called);
            required.Rows.Add(prow);


            TableRow frow = new TableRow();

            TableCell fname = new TableCell();
            fname.Text = "Surname and name";

            TableCell faddress = new TableCell();
            faddress.Text = "Address";

            frow.Cells.Add(fname);
            frow.Cells.Add(faddress);

            required.Rows.Add(frow);

            for (filtered.Begin(); filtered.Exist(); filtered.Next())
            {
                Person curPerson = filtered.GetPerson();

                TableRow row = new TableRow();

                TableCell name = new TableCell();
                name.Text = curPerson.SurnameAndName;

                TableCell address = new TableCell();
                address.Text = curPerson.Address;

                row.Cells.Add(name);
                row.Cells.Add(address);

                required.Rows.Add(row);
            }

        }
        /// <summary>
        /// This method gives a button the ability to remove all the data from result and data tables and labels
        /// </summary>
        /// <param name="sender">the object variable</param>
        /// <param name="e">an object of the EventArgs class</param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Table1.Rows.Clear();
            Table2.Rows.Clear();
            Table3.Rows.Clear();
            Table4.Rows.Clear();
            TextBox5.Text = string.Empty;
            TextBox4.Text = string.Empty;
            Label3.Text = string.Empty;
            Label4.Text = string.Empty;
        }
    }
}