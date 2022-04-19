using Microsoft.AspNetCore.Mvc;
using Sparks_Task_1.Models;
using System.Linq;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _customers;
        public HomeController(AppDbContext customers)
        {
            _customers = customers;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customers()
        {
            var user = _customers.Customers.ToList();

            return View(user);
        }

        public IActionResult CusInfo(int id, TransactionVM transaction , string fake)
        {
            ViewBag.cusList = _customers.Customers.Where(d => d.Id == id).FirstOrDefault();
            ViewBag.customer = _customers.Customers.ToList();
            var customer =( new Transaction() { Amount = transaction.Amount, Sender = ViewBag.cusList.Name, Receiver = transaction.Reciever });
            return View(transaction);
        }

        [HttpPost]
        public IActionResult CusInfo(int id, TransactionVM transaction)
        {
            var customer = _customers.Customers.Where(d => d.Id == id).FirstOrDefault();
            _customers.transactions.Add(new Transaction() { Amount = transaction.Amount, Sender = customer.Name, Receiver = transaction.Reciever });
            var reciever = transaction.Reciever;
            var receiverID=0;
            string recieverString = reciever.ToString();



            foreach (var item in _customers.Customers)
            {
                if (item.Name == transaction.Reciever)
                {
                    receiverID = item.Id;
                }
            }
            var receiver = _customers.Customers.Where(d => d.Id == receiverID).FirstOrDefault();
            customer.Balance -= double.Parse(transaction.Amount);
            receiver.Balance += double.Parse(transaction.Amount);

            _customers.SaveChanges();
            return RedirectToAction("transactions", "Home");
        }

        public IActionResult transactions()
        {
            var user = _customers.transactions.ToList();

            return View(user);
        }
    }
}
