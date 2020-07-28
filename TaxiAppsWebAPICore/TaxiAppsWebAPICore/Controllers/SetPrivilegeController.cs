using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetPrivilegeController : ControllerBase
    {
        private readonly TaxiAppzDBContext context;
        public SetPrivilegeController(TaxiAppzDBContext _context)
        {
            context = _context;
        }
        [HttpGet]
        [Authorize]
        [Route("ListMenu")]
        public IActionResult ListMenu(long roleid)
        {
            DASetPrivilege dASetPrivilege = new DASetPrivilege();
            return this.OK<List<GrandParentMenuhierarchy>>(dASetPrivilege.GetMenuList(roleid,context));
        }
    }
}
