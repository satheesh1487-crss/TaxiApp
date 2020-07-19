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
    public class ManageNotification : ControllerBase
    {
        private readonly TaxiAppzDBContext _content;
        public ManageNotification(TaxiAppzDBContext content)
        {
            _content = content;
        }
        [HttpGet]
        [Route("ManagePush")]
        [Authorize]
        public IActionResult ManagePush()
        {
            List<ManagePushNotification> managepushnotification = new List<ManagePushNotification>();
            managepushnotification.Add(new ManagePushNotification()
            {
                Sno = 1,
                Title = "happy diwali",
                Message = "hello..happy diwali",
                Sendon = "2020-07-04 08:27 am"
            });
            managepushnotification.Add(new ManagePushNotification()
            {
                Sno = 1,
                Title = "happy diwali",
                Message = "hello..happy diwali",
                Sendon = "2020-07-04 08:27 am"
            });
            managepushnotification.Add(new ManagePushNotification()
            {
                Sno = 2,
                Title = "my offer",
                Message = "please assemble our new brand showroom opening permanence",
                Sendon = "2020-06-22 05:12 am"
            });
            managepushnotification.Add(new ManagePushNotification()
            {
                Sno = 1,
                Title = "Announcement",
                Message = "This is an announcement due to covid-19.....",
                Sendon = "2020-06-04 09:22 am"
            });
            managepushnotification.Add(new ManagePushNotification()
            {
                Sno = 1,
                Title = "Push test",
                Message = "this is for testing purpose",
                Sendon = "2020-06-04 12:49 pm"
            });
            return this.OK<List<ManagePushNotification>>(managepushnotification);
        }
        [HttpGet]
        [Route("ManageSMSOption")]
        [Authorize]
        public IActionResult ManageSMSOption()
        {
            List<ManageSMSOption> manageSMSOptions = new List<ManageSMSOption>();
            manageSMSOptions.Add(new ManageSMSOption()
            {
                Sno = 1,
                SMSTitle  = "Sms otp",
                IsActive=true
            });
            manageSMSOptions.Add(new ManageSMSOption()
            {

                Sno = 2,
                SMSTitle = "Forgot password sms",
                IsActive = true
            });
            manageSMSOptions.Add(new ManageSMSOption()
            {

                Sno = 3,
                SMSTitle = "Request sms",
                IsActive = true
            });
            manageSMSOptions.Add(new ManageSMSOption()
            {

                Sno = 4,
                SMSTitle = "Request accept sms to user",
                IsActive = true
            });
            manageSMSOptions.Add(new ManageSMSOption()
            {
                Sno = 5,
                SMSTitle = "Request accept sms to Driver",
                IsActive = false
            });
            return this.OK<List<ManageSMSOption>>(manageSMSOptions);
        }

        [HttpGet]
        [Route("ManageEmailOption")]
        [Authorize]
        public IActionResult ManageEmailOption()
        {
            List<ManageEmailOption> manageEmailOptions = new List<ManageEmailOption>();
            manageEmailOptions.Add(new ManageEmailOption()
            {
                Sno = 1,
                EmailTitle = "Welcome email",
                IsActive = false
            });
            manageEmailOptions.Add(new ManageEmailOption()
            {

                Sno = 2,
                EmailTitle = "Request email",
                IsActive = true
            });
            manageEmailOptions.Add(new ManageEmailOption()
            {

                Sno = 3,
                EmailTitle = "Driver approved email",
                IsActive = true
            });
            manageEmailOptions.Add(new ManageEmailOption()
            {

                Sno = 4,
                EmailTitle = "Request accept email to user",
                IsActive = true
            });
            manageEmailOptions.Add(new ManageEmailOption()
            {
                Sno = 5,
                EmailTitle = "Request complete email to user",
                IsActive = true
            });
            return this.OK<List<ManageEmailOption>>(manageEmailOptions);
        }
    }
}
