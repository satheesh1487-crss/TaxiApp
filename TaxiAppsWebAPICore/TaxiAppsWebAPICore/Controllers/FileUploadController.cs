using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.TaxiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiAppsWebAPICore.Helper;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public FileUploadController(TaxiAppzDBContext context)
        {
            _context = context;
        }
        
         [HttpPost(@"upload")]

        public IActionResult Upload(IFormFile uploadedFile)
        {
            try
            {
                var storage = StorageFactory.GetStorage();
                var storagefile = uploadedFile.GetStorageFile();
                var hash = storage.Save(storagefile);

                return Ok();
            }
            catch (DataValidationException vx)
            {
                return null;
            }
        }

    }
}
