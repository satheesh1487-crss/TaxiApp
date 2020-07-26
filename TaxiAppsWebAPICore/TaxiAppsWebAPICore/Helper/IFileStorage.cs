using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TaxiAppsWebAPICore.Models;

namespace TaxiAppsWebAPICore.Helper.InterFace
{
    interface IFileStorage
    {
        /// <summary>
        /// Save form file to disk / blob etc
        /// </summary>
        /// <param name="file"></param>
        string Save(StorageFileInfo file);

        /// <summary>
        /// Download file given location
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uniqueId"></param>
        FileInfo GetDownloadFile(string fileName, string uniqueId);

        /// <summary>
        /// Move File one  location to another location
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uniqueId"></param>
        void MoveToPersistant(string fileName, string uniqueId);

        /// <summary>
        /// Move File from upload folder to delete folder
        /// </summary>
        /// <param name="fileName"></param>
        void DeleteUpload(string uniqueId);

        /// <summary>
        /// Revert an artifact deletion
        /// </summary>
        /// <param name="uniqueId"></param>
        void UndoDeletion(string uniqueId);

        /// <summary>
        /// Move file fro persistent to temp location
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <param name="artifactId"></param>
        void MoveToTemp(string fileName, string uniqueId);

        /// <summary>
        /// Make necessary configuration zip and make persistent
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="uniqueId"></param>
        string MoveToPersistantConfiguration(FileInfo taskFile, string path, string fileName, string uniqueId);

        /// <summary>
        /// Revert persistent configuration to local
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="uniqueId"></param>
        void RevertPeristantConfiguration(string path, string fileName, string uniqueId);

        /// <summary>
        /// Get the temporary file
        /// </summary>
        /// <param name="metaData"></param>
        /// <returns></returns>
        FileInfo GetTempFile(string metaData);
    }
}
