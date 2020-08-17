using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAFAQ
    {
        public List<ManageFAQList> ListFAQ(TaxiAppzDBContext context)
        {
            try
            {
                List<ManageFAQList> manageFAQ = new List<ManageFAQList>();
                var listFAQ = context.TabFaq.Where(t => t.IsDelete == false).ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var FAQ in listFAQ)
                {
                    manageFAQ.Add(new ManageFAQList()
                    {
                        Complaint_Type = FAQ.ComplaintType,
                        FAQ_Answer = FAQ.FaqAnswer,
                        FAQ_Question = FAQ.FaqQuestion,
                        Id = FAQ.Faqid,
                        IsActive = FAQ.IsActive,
                        Servicelocid = FAQ.Servicelocid

                    });
                }
                return manageFAQ != null ? manageFAQ : null;

            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "ListFAQ", context);
                return null;
            }

        }

        public bool EditFAQ(TaxiAppzDBContext context, ManageFAQList manageFAQList, LoggedInUser loggedInUser)
        {     
            var updatedate = context.TabFaq.Where(r => r.Faqid == manageFAQList.Id && r.IsDelete == false).FirstOrDefault();
            if (updatedate != null)
            {
                updatedate.FaqQuestion = manageFAQList.FAQ_Question;
                updatedate.FaqAnswer = manageFAQList.FAQ_Answer;
                updatedate.ComplaintType = manageFAQList.Complaint_Type; 
                updatedate.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                updatedate.UpdatedBy = loggedInUser.Email;
                context.Update(updatedate);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ManageFAQInfo GetbyFAQId(TaxiAppzDBContext context, long id)
        {
            try
            {
                ManageFAQInfo manageFAQInfo = new ManageFAQList();
                var listFAQ = context.TabFaq.FirstOrDefault(t => t.Faqid == id && t.IsDelete == false);
                if (listFAQ != null)
                {
                    manageFAQInfo.Id = listFAQ.Faqid;
                    manageFAQInfo.FAQ_Answer = listFAQ.FaqAnswer;
                    manageFAQInfo.FAQ_Question = listFAQ.FaqQuestion;
                    manageFAQInfo.Complaint_Type = listFAQ.ComplaintType;
                }
                return manageFAQInfo != null ? manageFAQInfo : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyFAQId", context);
                return null;
            }
        }

        public bool SaveFAQ(TaxiAppzDBContext context, ManageFAQInfo manageFAQInfo, LoggedInUser loggedInUser)
        {

            var faq = context.TabServicelocation.FirstOrDefault(t => t.IsDeleted == 0 && t.Servicelocid == manageFAQInfo.Servicelocid);
            if (faq == null)
                throw new DataValidationException($"Service location doest not  exists.");

            TabFaq tabFaq = new TabFaq();
            tabFaq.ComplaintType = manageFAQInfo.Complaint_Type;
            tabFaq.FaqAnswer = manageFAQInfo.FAQ_Answer;
            tabFaq.FaqQuestion = manageFAQInfo.FAQ_Question;
           
            tabFaq.Servicelocid = manageFAQInfo.Servicelocid;
           
            tabFaq.CreatedAt = tabFaq.UpdatedAt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            tabFaq.UpdatedBy = tabFaq.CreatedBy = loggedInUser.Email;

            context.TabFaq.Add(tabFaq);
            context.SaveChanges();
            return true;

        }

        public bool StatusFAQ(TaxiAppzDBContext context, long id, bool isStatus, LoggedInUser loggedInUser)
        {

            var faq = context.TabFaq.FirstOrDefault(t => t.IsDelete == false && t.Faqid == id);
            if (faq == null)
                throw new DataValidationException($"FAQ doest not exists.");

            var updatedate = context.TabFaq.Where(t => t.Faqid == id && t.IsDelete == false).FirstOrDefault();
            if (updatedate != null)
            {
                updatedate.IsActive = isStatus;
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
