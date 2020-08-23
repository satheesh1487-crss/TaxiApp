using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaziappzMobileWebAPI.Helper;
using TaziappzMobileWebAPI.Models;
using TaziappzMobileWebAPI.TaxiModels;

namespace TaziappzMobileWebAPI.DALayer
{
    public class DADriverCommon
    {
        public List<GetProfileModel> GetProfile(TaxiAppzDBContext context, GeneralModel generalModel, LoggedInUser loggedInUser)
        {
            var profileexist = context.TabDrivers.FirstOrDefault(t => t.IsDelete == false && t.IsActive == true && t.Driverid == generalModel.Id && t.Token == null);
            if (profileexist != null)
                throw new DataValidationException($"Driver does not have a permission");

            List<GetProfileModel> getProfileModels = new List<GetProfileModel>();
            Driver driver = new Driver();
            var listProfile = context.TabDrivers.Include(t=>t.Type).FirstOrDefault(t => t.Driverid == generalModel.Id && t.IsDelete == false && t.IsActive == true);
            if (listProfile == null) throw new DataValidationException($" Driver Profile Not Exist");
            if (listProfile != null)
            {
                driver.Id = listProfile.Driverid;               
                driver.FirstName = listProfile.FirstName;
                driver.LastName = listProfile.LastName;
                driver.Login_By = listProfile.LoginBy;
                driver.Login_Method = listProfile.LoginMethod;
                driver.Phone = listProfile.ContactNo;
                driver.Profile_Pic = "";
                driver.Token = listProfile.Token;
                driver.Email = listProfile.Email;
                driver.Is_Active = listProfile.IsActive;
                driver.Is_Approve = listProfile.IsApproved;
                driver.Is_Available = listProfile.IsAvailable;
                driver.Car_Model = listProfile.Carmodel;
                driver.Car_Number = listProfile.Carnumber;
                driver.Total_Reward_Point = listProfile.RewardPoint;
                driver.Type_Icon = listProfile.Type.Typename;
                driver.Type_Name = listProfile.Type.Imagename;
            }
            getProfileModels.Add(new GetProfileModel()
            {
                Driver = driver
            });
            return getProfileModels;
        }
    }
}
