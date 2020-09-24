using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleEmp.EmpModels;

namespace SampleEmp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public EmployeeController(TaxiAppzDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("AddEmp")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            Employeectrl employeectrl = new Employeectrl();
            return this.OKResponse(employeectrl.InsertEmployee(_context,employee) ? "Inserted" : "Failed");
        }
    }
}
