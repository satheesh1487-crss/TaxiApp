using System;
using System.Collections.Generic;
using System.Text;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
   public class DACurrency
    {
        //TODO:: Please update this methode  comment item check 
        public bool AddCurrency(TaxiAppzDBContext context, CurrencyInfo roles)
        {
            try
            {

                TabRoles Insertdata = new TabRoles();

                //Insertdata.CurrencyID = roles.CurrencyID;
                //Insertdata.DisplayName = roles.StandardId;
                //Insertdata.Description = roles.CurrencyName;
                //Insertdata.IsActive = 1;
                //Insertdata.AllRights = roles.CurrencySymbol;


                Insertdata.Locked = 1;
                Insertdata.CreatedBy = "Admin";
                context.TabRoles.Add(Insertdata);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddRole", context);
                return false;
            }
        }

        //TODO:: Please update this methode  comment item check 
        public bool EditCurrency(TaxiAppzDBContext context, CurrencyInfo roles)
        {
            try
            {

                TabRoles Insertdata = new TabRoles();

                //Insertdata.CurrencyID = roles.CurrencyID;
                //Insertdata.DisplayName = roles.StandardId;
                //Insertdata.Description = roles.CurrencyName;
                //Insertdata.IsActive = 1;
                //Insertdata.AllRights = roles.CurrencySymbol;


                Insertdata.Locked = 1;
                Insertdata.CreatedBy = "Admin";
                context.TabRoles.Add(Insertdata);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Extention.insertlog(ex.Message, "Admin", "AddRole", context);
                return false;
            }
        }
    }
}
