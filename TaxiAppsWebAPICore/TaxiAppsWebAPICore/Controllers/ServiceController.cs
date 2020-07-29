﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TaxiAppsWebAPICore.DataAccessLayer;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly TaxiAppzDBContext _context;
        public ServiceController(TaxiAppzDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("list")]
        [Authorize]
        public IActionResult List()
        {
            var data = User.ToAppUser();
            DAService dAService = new DAService();
            return this.OK<List<ServiceListModel>>(dAService.ListService(_context));
        }


        //TODO:: Duplicate record check
        [HttpPost]
        [Route("save")]
        [Authorize]
        public IActionResult Save([FromBody] ServiceInfo serviceInfo)
        {
            DAService dAService = new DAService();
            return this.OKResponse(dAService.AddService(_context, serviceInfo, User.ToAppUser()) ? "Inserted Successfully" : "Insertion Failed");
        }

        //TODO:: Duplicate record check
        [HttpPut]
        [Route("edit")]
        [Authorize]
        public IActionResult Edit([FromBody] ServiceInfo serviceInfo)
        {
            DAService dAService = new DAService();
            return this.OKResponse(dAService.EditService(_context, serviceInfo, User.ToAppUser()) ? "Updated Successfully" : "Updation Failed");
        }

        //TODO:: check parent record is deleted
        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public IActionResult Delete(long id)
        {
            DAService dAService = new DAService();
            return this.OKResponse(dAService.DeleteService(_context, id, User.ToAppUser()) ? "Deleted Successfully" : "Deletion Failed");
        }


        [HttpGet]
        [Route("getbyId")]
        [Authorize]
        public IActionResult GetbyId(long id)
        {
            DAService dAService = new DAService();
            return this.OK<ServiceInfo>(dAService.GetbyServiceId(_context, id));
        }
    }
}
