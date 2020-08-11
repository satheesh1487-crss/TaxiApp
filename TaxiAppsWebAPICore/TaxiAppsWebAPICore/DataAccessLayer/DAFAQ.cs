using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var listFAQ = context.TabFaq.ToList().OrderByDescending(t => t.UpdatedAt);
                foreach (var FAQ in listFAQ)
                {
                    manageFAQ.Add(new ManageFAQList()
                    {
                        Complaint_Type = FAQ.ComplaintType,
                        FAQ_Answer = FAQ.FaqAnswer,
                        FAQ_Question = FAQ.FaqQuestion,
                        Id = FAQ.Faqid,
                        //IsActive = FAQ.IsActive,
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
            try
            {

                var updatedate = context.TabFaq.Where(r => r.Faqid == manageFAQList.Id && r.IsDelete == false).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.FaqQuestion = manageFAQList.FAQ_Question;
                    updatedate.FaqAnswer = manageFAQList.FAQ_Answer;
                    updatedate.ComplaintType = manageFAQList.Complaint_Type;
                    updatedate.Faqid = manageFAQList.Id;
                    updatedate.Servicelocid = manageFAQList.Servicelocid;
                    updatedate.UpdatedAt = DateTime.UtcNow;
                    updatedate.UpdatedBy = loggedInUser.Email;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "EditFAQ", context);
                return false;
            }
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

        public bool DeleteFAQ(TaxiAppzDBContext context, long id, LoggedInUser loggedInUser)
        {
            try
            {

                var updatedate = context.TabFaq.Where(r => r.Faqid == id && r.IsDelete == false).FirstOrDefault();
                if (updatedate != null)
                {


                    updatedate.IsDelete = true;
                    updatedate.DeletedAt = DateTime.UtcNow;
                    updatedate.DeletedBy = loggedInUser.Email;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "DeleteFAQ", context);
                return false;
            }
        }

        public bool StatusFAQ(TaxiAppzDBContext context, long id, bool isStatus, LoggedInUser loggedInUser)
        {
            try
            {

                var updatedate = context.TabFaq.Where(r => r.Faqid == id).FirstOrDefault();
                if (updatedate != null)
                {
                    updatedate.IsActive = isStatus == true;
                    updatedate.UpdatedAt = DateTime.UtcNow;
                    updatedate.UpdatedBy = loggedInUser.UserName;
                    context.Update(updatedate);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "StatusFAQ", context);
                return false;
            }
        }
    }
}
