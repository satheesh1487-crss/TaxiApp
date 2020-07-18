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
    public class CompanyController : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public CompanyController(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("CompanyList")]
        [Authorize]
        public IActionResult CompanyList()
        {
            List<Company> companylist = new List<Company>();
            companylist.Add(new Company() { Companyid = 1, CompanyName = "nPlus", OperatorName= "newtest",Phone="9894996328",Email= "sasi28it@gmail.com", PaymentType="Fixed" ,IsActive = true });
            companylist.Add(new Company() { Companyid = 2, CompanyName = "mi", OperatorName = "sasi", Phone = "9894996328", Email = "sasikumarnplus@gmail.com", PaymentType = "Fixed", IsActive = true });
            companylist.Add(new Company() { Companyid = 3, CompanyName = "nPlus", OperatorName = "Something", Phone = "9894996328", Email = "company@mail.com", PaymentType = "Fixed", IsActive = true });
              return this.OK<List<Company>>(companylist);
        }
    }
}
