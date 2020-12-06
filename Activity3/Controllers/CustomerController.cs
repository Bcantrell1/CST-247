using Cantrell_Brian_CST247_Activity3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cantrell_Brian_CST247_Activity3.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers;

        public CustomerController()
        {
            customers = new List<Customer>();
            customers.Add(new Customer(0, "Brian", 28));
            customers.Add(new Customer(1, "Nicolas", 26));
            customers.Add(new Customer(2, "Marty", 23));
            customers.Add(new Customer(3, "Kurt", 24));
            customers.Add(new Customer(4, "Michael", 32));
            customers.Add(new Customer(5, "Isaac", 25));
        }


        // GET: Customer
        public ActionResult Index()
        {
            Tuple<List<Customer>, Customer> tuple;

            tuple = new Tuple<List<Customer>, Customer>(customers, customers[0]);

            return View("Customer", tuple);
        }

        [HttpPost]
        public ActionResult OnSelectCustomer(string customerNumber)
        {
            Tuple<List<Customer>, Customer> tuple;

            tuple = new Tuple<List<Customer>, Customer>(customers, customers[Int32.Parse(customerNumber)]);

            return PartialView("_CustomerDetails", customers[Int32.Parse(customerNumber)]);
        }
    }
}