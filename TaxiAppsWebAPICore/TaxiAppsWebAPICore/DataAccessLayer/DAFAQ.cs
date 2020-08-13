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
                var listFAQ = context.TabFaq.Where(t=>t.IsDelete==false).ToList().OrderByDescending(t => t.UpdatedAt);
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
          
                var roleExist = context.TabServicelocation.FirstOrDefault(t => t.IsDeleted == 0 && t.Servicelocid == manageFAQList.Servicelocid);
                if (roleExist != null)
                    throw new DataValidationException($"Service location doest not '{roleExist.Name}' exists.");

                var updatedate = context.TabFaq.Where(r => r.Faqid == manageFAQList.Id && r.IsDelete == false).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.FaqQuestion = manageFAQList.FAQ_Question;
                    updatedate.FaqAnswer = manageFAQList.FAQ_Answer;
                    updatedate.ComplaintType = manageFAQList.Complaint_Type;                 
                    updatedate.Servicelocid = manageFAQList.Servicelocid;
                    updatedate.UpdatedAt = DateTime.UtcNow;
                    updatedate.UpdatedBy = loggedInUser.Email;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
           
        }

        public ManageFAQList GetbyFAQId(TaxiAppzDBContext context, long id)
        {
            try
            {               
                ManageFAQList manageFAQList = new ManageFAQList();
                var listFAQ = context.TabFaq.FirstOrDefault(t => t.Faqid == id && t.IsDelete == false);
                if (listFAQ != null)
                {
                    manageFAQList.FAQ_Answer = listFAQ.FaqAnswer;
                    manageFAQList.FAQ_Question = listFAQ.FaqQuestion;
                    manageFAQList.Complaint_Type = listFAQ.ComplaintType;
                    manageFAQList.Id = listFAQ.Faqid;
                    manageFAQList.Servicelocid = listFAQ.Servicelocid;
                }
                return manageFAQList != null ? manageFAQList : null;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "GetbyFAQId", context);
                return null;
            }
        }

        public bool SaveFAQ(TaxiAppzDBContext context, ManageFAQList manageFAQList, LoggedInUser loggedInUser)
        {
             
                var roleExist = context.TabServicelocation.FirstOrDefault(t => t.IsDeleted == 0 && t.Servicelocid == manageFAQList.Servicelocid);
                if (roleExist != null)
                    throw new DataValidationException($"Service location doest not '{roleExist.Name}' exists.");

                TabFaq tabFaq = new TabFaq();
                tabFaq.ComplaintType = manageFAQList.Complaint_Type;
                tabFaq.FaqAnswer = manageFAQList.FAQ_Answer;
                tabFaq.FaqQuestion = manageFAQList.FAQ_Question;
                tabFaq.Faqid = manageFAQList.Id;
                tabFaq.Servicelocid = manageFAQList.Servicelocid;
                tabFaq.CreatedAt = DateTime.UtcNow;
                tabFaq.UpdatedAt = DateTime.UtcNow;
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
                 
                var updatedate = context.TabFaq.Where(t => t.Faqid == id && t.IsDelete==false).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.IsActive = isStatus;
                    updatedate.UpdatedAt = DateTime.UtcNow;
                    updatedate.UpdatedBy = loggedInUser.UserName;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            
        }
    }
}
