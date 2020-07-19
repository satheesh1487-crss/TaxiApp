using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public TransactionController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("TransactionList")]
        [Authorize]
        public IActionResult TransactionList()
        {
            List<Transaction> transactionlist = new List<Transaction>();
            transactionlist.Add(new Transaction()
            {
                Sno = 1,
                RequestID = "RES_43179",
                UserName = "dilip ashok",
                DriverName = "Sundar",
                PromoDiscount = Convert.ToDecimal(0.00),
                AdminAmount = Convert.ToDecimal(2.00),
                DriverAmount = Convert.ToDecimal(0.00),
                ReferalAmount = Convert.ToDecimal(0.00),
                ServiceTaxinPercentage = Convert.ToDecimal(0.20),
                Total = Convert.ToDecimal(2.20),
                Payment = "Cash",
                IsPaid = "Paid"
            }); 
            transactionlist.Add(new Transaction()
            {
                Sno = 2,
                RequestID = "RES_99178",
                UserName = "Praveen User",
                DriverName = "Praveen Test",
                PromoDiscount = Convert.ToDecimal(0.00),
                ReferalAmount = Convert.ToDecimal(0.00),
                AdminAmount = Convert.ToDecimal(2.00),
                DriverAmount = Convert.ToDecimal(0.45),
                ServiceTaxinPercentage = Convert.ToDecimal(0.25),
                Total = Convert.ToDecimal(2.71),
                Payment = "Cash",
                IsPaid = "Paid"
            });
            transactionlist.Add(new Transaction()
            {
                Sno = 3,
                RequestID = "RES_43179",
                UserName = "dilip ashok",
                DriverName = "Sundar Ganesh",
                PromoDiscount = Convert.ToDecimal(0.00),
                AdminAmount = Convert.ToDecimal(2.00),
                DriverAmount = Convert.ToDecimal(1.96),
                ReferalAmount = Convert.ToDecimal(0.00),
                ServiceTaxinPercentage = Convert.ToDecimal(0.40),
                Total = Convert.ToDecimal(4.40),
                Payment = "Cash",
                IsPaid = "Paid"
            });
            transactionlist.Add(new Transaction()
            {
                Sno = 4,
                RequestID = "RES_19172",
                UserName = "dilip ashok",
                DriverName = "Sachin",
                PromoDiscount = Convert.ToDecimal(0.00),
                AdminAmount = Convert.ToDecimal(2.00),
                DriverAmount = Convert.ToDecimal(1.96),
                ReferalAmount = Convert.ToDecimal(0.00),
                ServiceTaxinPercentage = Convert.ToDecimal(0.20),
                Total = Convert.ToDecimal(2.20),
                Payment = "Cash",
                IsPaid = "Paid"
            });
            return this.OK<List<Transaction>>(transactionlist);
        }
    }
}
