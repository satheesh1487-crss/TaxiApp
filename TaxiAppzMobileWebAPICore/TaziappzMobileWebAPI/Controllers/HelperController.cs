using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaziappzMobileWebAPI.DALayer;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        public readonly TaxiAppzDBContext _context;
        public HelperController(TaxiAppzDBContext context)
        {
            _context = context;
          
        }
        /// <summary>
        /// Use to List Country
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getCountry")]
        public IActionResult GetCountry()
        {
            DAOTP dAOTP = new DAOTP();
            List<CountryModel> countryModel = new List<CountryModel>();
            countryModel = dAOTP.GetCountryList(_context);
            return this.OK<List<CountryModel>>(countryModel, countryModel.Count == 0 ? "No Data Found" : "Country_List", countryModel.Count == 0 ? 0 : 1);
        }
        /// <summary>
        /// Use to List Service Opertaion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ServiceOperation")]
        public IActionResult List(long id)
        {
            DAOTP dAOTP = new DAOTP();
            List<ServiceLocationModel> serviceLocationModels = new List<ServiceLocationModel>();
            serviceLocationModels = dAOTP.ListService(id, _context);
            return this.OK<List<ServiceLocationModel>>(serviceLocationModels, serviceLocationModels.Count == 0 ? "No Data Found" : "ServiceOperation_List", serviceLocationModels.Count == 0 ? 0 : 1);
        }

      
        /// <summary>
        /// Use to List type Opertaion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("typebyServicelocid")]
        public IActionResult ListType(long servicelocid)
        {
            DAOTP dAOTP = new DAOTP();
            List<TypeModel> listZone = new List<TypeModel>();
            listZone = dAOTP.ListType(servicelocid, _context);
            return this.OK<List<TypeModel>>(listZone, listZone.Count == 0 ? "No Data Found" : "Type_List", listZone.Count == 0 ? 0 : 1);
        }

    }
}
