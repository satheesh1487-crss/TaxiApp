using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper;
using TaxiAppsWebAPICore.Models;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore.DataAccessLayer
{
    public class DAFiles
    {
        public Int64 SaveFiles(IFormFile files,string fileId, TaxiAppzDBContext context, LoggedInUser loggedIn)
        {
            try
            {
                TabUploadfiledetails tabUploadfiledetails = new TabUploadfiledetails();
                tabUploadfiledetails.Filename = fileId + Path.GetExtension(files.FileName);
                tabUploadfiledetails.Mimetype = files.ContentType;
                tabUploadfiledetails.Size = files.Length;
                tabUploadfiledetails.Extention = Path.GetExtension(files.FileName);                
                tabUploadfiledetails.UpdatedAt = tabUploadfiledetails.CreatedAt= Extention.GetDateTime();
                tabUploadfiledetails.UpdatedBy = tabUploadfiledetails.CreatedBy = loggedIn.UserName;
                context.TabUploadfiledetails.Add(tabUploadfiledetails);
                context.SaveChanges();

                return tabUploadfiledetails.Fileid;
            }
            catch (DataValidationException ex)
            {
                return 0;
                // throw;
            }
        }
    }
}
