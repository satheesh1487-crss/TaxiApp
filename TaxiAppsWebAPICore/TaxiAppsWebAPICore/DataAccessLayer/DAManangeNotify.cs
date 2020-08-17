using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAManangeNotify
    {
        public List<ManageEmailOption> ListEmail(TaxiAppzDBContext context)
        {
            try
            {
                List<ManageEmailOption> manageEmail = new List<ManageEmailOption>();
                var listEmail = context.TabManageEmail.ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var Email in listEmail)
                {
                    manageEmail.Add(new ManageEmailOption()
                    {
                        EmailTitle = Email.Emailtitle,
                        Id = Email.ManageEmailid,
                        IsActive = Email.IsActive,
                        Description = Email.Description
                    });
                }
                return manageEmail != null ? manageEmail : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListEmail", context);
                return null;
            }

        }

        public bool EditEmail(TaxiAppzDBContext context, ManageEmailOption manageEmailOption, LoggedInUser loggedInUser)
        {

            var emailid = context.TabManageEmail.FirstOrDefault(t => t.ManageEmailid == manageEmailOption.Id);
            if (emailid == null)
                throw new DataValidationException($"Email does not already exists.");

            var updatedate = context.TabManageEmail.Where(r => r.ManageEmailid == manageEmailOption.Id).FirstOrDefault();
            if (updatedate != null)
            { 
                updatedate.ManageEmailid = manageEmailOption.Id;
                updatedate.Description = manageEmailOption.Description;
                updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now); ;
                updatedate.UpdatedBy = loggedInUser.Email;
                context.Update(updatedate);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        public ManageEmailOption GetbyEmailId(TaxiAppzDBContext context, long id)
        {
            try
            {
                ManageEmailOption manageEmailOption = new ManageEmailOption();
                var listEmail = context.TabManageEmail.FirstOrDefault(t => t.ManageEmailid == id);
                if (listEmail != null)
                {
                    manageEmailOption.Id = listEmail.ManageEmailid;
                    manageEmailOption.EmailTitle = listEmail.Emailtitle;
                    manageEmailOption.IsActive = listEmail.IsActive;
                    manageEmailOption.Description = listEmail.Description;

                    List<ManageSMSHint> manageSMSHints = new List<ManageSMSHint>();
                    var listHintSms = context.TabManageEmailHints.Where(t => t.ManageEmailid == listEmail.ManageEmailid).ToList();
                    foreach (var item in listHintSms)
                    {
                        ManageSMSHint sMSHint = new ManageSMSHint();
                        sMSHint.Id = item.ManageEmailHint;
                        sMSHint.Keyword = item.HintKeyword;
                        sMSHint.HintMsg = item.HintDescription;
                        manageSMSHints.Add(sMSHint);
                    }
                }

                return manageEmailOption != null ? manageEmailOption : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyEmailId", context);
                return null;
            }
        }

        public bool StatusEmail(TaxiAppzDBContext context, long id, bool isStatus, LoggedInUser loggedInUser)
        {
            var emailid = context.TabManageEmail.FirstOrDefault(t => t.ManageEmailid == id);
            if (emailid == null)
                throw new DataValidationException($"Email does not already exists.");

            var updatedate = context.TabManageEmail.Where(r => r.ManageEmailid == id).FirstOrDefault();
            if (updatedate != null)
            {
                updatedate.IsActive = isStatus == true;
                updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now); ;
                updatedate.UpdatedBy = loggedInUser.UserName;
                context.Update(updatedate);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<ManageSMSOption> ListSms(TaxiAppzDBContext context)
        {
            try
            {
                List<ManageSMSOption> manageSms = new List<ManageSMSOption>();
                var listSms = context.TabManageSms.ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var sms in listSms)
                {
                    manageSms.Add(new ManageSMSOption()
                    {
                        SMSTitle = sms.Smstitle,
                        Id = sms.ManageSmsid,
                        Description = sms.Description,
                        IsActive = sms.IsActive
                    });
                }
                return manageSms != null ? manageSms : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListSms", context);
                return null;
            }

        }

        public bool EditSms(TaxiAppzDBContext context, ManageSMSOption manageSMSOption, LoggedInUser loggedInUser)
        {
            var emailid = context.TabManageSms.FirstOrDefault(t =>t.ManageSmsid == manageSMSOption.Id);
            if (emailid == null)
                throw new DataValidationException($"Sms does not already exists.");

            var updatedate = context.TabManageSms.Where(r => r.ManageSmsid == manageSMSOption.Id).FirstOrDefault();
            if (updatedate != null)
            {
                updatedate.ManageSmsid = manageSMSOption.Id;
                updatedate.Description = manageSMSOption.Description;
                updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                updatedate.UpdatedBy = loggedInUser.Email;
                context.Update(updatedate);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        public ManageSMSOption GetbySmsId(TaxiAppzDBContext context, long id)
        {
            try
            {
                ManageSMSOption manageSMSOption = new ManageSMSOption();
                var listSms = context.TabManageSms.FirstOrDefault(t => t.ManageSmsid == id);
                if (listSms != null)
                {
                    manageSMSOption.Id = listSms.ManageSmsid;
                    manageSMSOption.SMSTitle = listSms.Smstitle;
                    manageSMSOption.IsActive = listSms.IsActive;
                    manageSMSOption.Description = listSms.Description;
                    List<ManageSMSHint> manageSMSHints = new List<ManageSMSHint>();
                    var listHintSms = context.TabManageSmsHints.Where(t => t.ManageSmsid == listSms.ManageSmsid).ToList();
                    foreach (var item in listHintSms)
                    {
                        ManageSMSHint sMSHint = new ManageSMSHint();
                        sMSHint.Id = item.ManageSmshint;
                        sMSHint.Keyword = item.HintKeyword;
                        sMSHint.HintMsg = item.HintDescription;
                        manageSMSHints.Add(sMSHint);
                    }
                }

                return manageSMSOption != null ? manageSMSOption : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbySmsId", context);
                return null;
            }
        }

        public bool StatusSms(TaxiAppzDBContext context, long id, bool isStatus, LoggedInUser loggedInUser)
        {

            var emailid = context.TabManageSms.FirstOrDefault(t => t.ManageSmsid == id);
            if (emailid == null)
                throw new DataValidationException($"Sms does not already exists.");

            var updatedate = context.TabManageSms.Where(r => r.ManageSmsid == id).FirstOrDefault();
            if (updatedate != null)
            {
                updatedate.IsActive = isStatus == true;
                updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                updatedate.UpdatedBy = loggedInUser.UserName;
                context.Update(updatedate);
                context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
