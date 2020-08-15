using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text; 
using TaziappzMobileWebAPI.Helper.InterFace;

namespace TaziappzMobileWebAPI.Helper
{
    static class StorageFactory
    {

        /// <summary>
        /// get storage 
        /// </summary>
        /// <returns></returns>
        internal static IFileStorage GetStorage()
        {
            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile(Reflections.GetRootRelativeFile("appsettings.json").FullName, true, true)
              .Build();

            var appSettingsSection = configuration.GetSection("AppSettings");

            var appSettings = appSettingsSection.Get<StoragAppSettings>();


            if (appSettings == null || string.IsNullOrEmpty(appSettings.DataPath))
                return new FileSystemStorage("Default", "../Data");
            else
                return new FileSystemStorage("Default", appSettings.DataPath);
        }

        /// <summary>
        /// Storgae settings
        /// </summary>
        internal class StoragAppSettings
        {
            /// <summary>
            /// Path where data will be stored
            /// </summary>
            public string DataPath { get; set; }
        }
    }
}
