using Microsoft.Extensions.FileProviders;

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.Helper.InterFace;
using TaxiAppsWebAPICore.Models;

namespace TaxiAppsWebAPICore.Helper
{
    class FileSystemStorage : IFileStorage
    {

        private const string UPLOAD = "Upload";
        private const string TEMP = "Temp";
        private const string DELETED = "Deleted";

        /// <summary>
        /// Data base path
        /// </summary>
        private string DataPath { get; set; }

        /// <summary>
        /// Tenant id
        /// </summary>
        private string TenantId { get; set; }

        /// <summary>
        /// Save file to disk 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>MDF5 Hash</returns>

        public FileSystemStorage(string tenantId, string dataPath)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
                tenantId = "Default";

            DataPath = dataPath;
            TenantId = tenantId;
        }

        /// <summary>
        /// Get base data folder
        /// </summary>
        /// <returns></returns>

        private DirectoryInfo GetBaseRelativeDir(string relativePath)
        {
            return Reflections.GetRootRelativeDir($"{DataPath}/{TenantId}/{relativePath}");
        }

        /// <summary>
        /// Get file relative to base
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        private FileInfo GetBaseRelativeFile(string relativePath)
        {
            return Reflections.GetRootRelativeFile($"{DataPath}/{TenantId}/{relativePath}");
        }

        /// <summary>
        /// Save the file to locations
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string Save(StorageFileInfo file)
        {
            var destFile = GetBaseRelativeFile($"{TEMP}/{file.UploadId.ToString()}{Path.GetExtension(file.FormFile.FileName)}");

            if (!destFile.Directory.Exists)
                destFile.Directory.Create();

            using (var stream = new FileStream(destFile.FullName, FileMode.Create))
                file.FormFile.CopyTo(stream);

            return GetMD5HashFromFile(destFile.FullName);
        }

        /// <summary>
        /// Compute md5 hash
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetMD5HashFromFile(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }

        /// <summary>
        /// move file from temporary location to final location
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public void MoveToPersistant(string fileName, string uniqueId)
        {
            MoveRootRelative($"{TEMP}/{fileName}", $"{UPLOAD}/{uniqueId}/{fileName}");
        }


        /// <summary>
        /// Convert the file to deployable zip and move
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uniqueId"></param>
        public string MoveToPersistantConfiguration(FileInfo taskFile, string path, string fileName, string uniqueId)
        {
            path = path.TrimStart('/');
            path = path.TrimStart('\\');

            var sourceFile = GetBaseRelativeFile($"{TEMP}/{fileName}");

            var objectIdName = Path.GetFileNameWithoutExtension(sourceFile.FullName);

            var zipFile = GetBaseRelativeFile($"{TEMP}/{objectIdName}.zip");


            if (zipFile.Exists)
                zipFile.Delete();

            using (ZipArchive archive = ZipFile.Open(zipFile.FullName, ZipArchiveMode.Create))
            {
                var entry = archive.CreateEntry($"Source/{path}");

                if (!taskFile.Exists)
                    throw new FileNotFoundException("Task file not found. Please check server settings");

                using (Stream inputStream = File.OpenRead(sourceFile.FullName))
                {
                    using (Stream outputStream = entry.Open())
                    {
                        inputStream.CopyTo(outputStream);
                    }
                }

                archive.CreateEntryFromFile(taskFile.FullName, "TaskList.json");
            }

            var hash = GetMD5HashFromFile(zipFile.FullName);

            MoveToPersistant(zipFile.Name, uniqueId);

            return hash;
        }

        /// <summary>
        /// Revert a configuration which was persisted
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="uniqueId"></param>
        public void RevertPeristantConfiguration(string path, string fileName, string uniqueId)
        {
            path = path.TrimStart('/');
            path = path.TrimStart('\\');

            var destFile = GetBaseRelativeFile($"{UPLOAD}/{uniqueId}/{fileName}");

            var objectIdName = Path.GetFileNameWithoutExtension(destFile.FullName);

            var zipFile = GetBaseRelativeFile($"{UPLOAD}/{uniqueId}/{objectIdName}.zip");


            using (ZipArchive archive = ZipFile.Open(zipFile.FullName, ZipArchiveMode.Read))
            {
                var entry = archive.GetEntry($"Source/{path}");

                using (Stream outputStream = File.OpenWrite(destFile.FullName))
                {
                    using (Stream inputStream = entry.Open())
                    {
                        inputStream.CopyTo(outputStream);
                    }
                }
            }

            zipFile.Delete();

            MoveToTemp(fileName, uniqueId);

        }

        /// <summary>
        /// Move file to deleted location
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public void DeleteUpload(string uniqueId)
        {
            MoveFolder($"{UPLOAD}/{uniqueId}", $"{DELETED}/{uniqueId}");
        }


        /// <summary>
        /// Restore the deleted artifact folder to uploads folder
        /// </summary>
        /// <param name="uniqueId"></param>
        public void UndoDeletion(string uniqueId)
        {
            MoveFolder($"{DELETED}/{uniqueId}", $"{UPLOAD}/{uniqueId}");
        }

        /// <summary>
        /// Move directory between relative paths
        /// </summary>
        /// <param name="sourcePathRelative"></param>
        /// <param name="detinationPathRelative"></param>
        private void MoveFolder(string sourcePathRelative, string detinationPathRelative)
        {
            var sourceDir = GetBaseRelativeDir(sourcePathRelative);
            var destDir = GetBaseRelativeDir(detinationPathRelative);

            if (sourceDir.Exists)
            {
                if (destDir.Exists)
                    destDir.Delete(true);

                if (!destDir.Parent.Exists)
                    destDir.Parent.Create();

                sourceDir.MoveTo(destDir.FullName);
            }
        }

        /// <summary>
        /// Read the file content
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public FileInfo GetDownloadFile(string fileName, string uniqueId)
        {
            return GetBaseRelativeFile($"{UPLOAD}/{uniqueId}/{fileName}");
        }

        /// <summary>
        /// Get temp file
        /// </summary>
        /// <param name="metaData"></param>
        /// <returns></returns>
        public FileInfo GetTempFile(string metaData)
        {
            return GetBaseRelativeFile($"{TEMP}/{metaData}");
        }

        /// <summary>
        /// Move file from upload folder to temp folder
        /// </summary>
        /// <param name="fileName"></param>
        public void MoveToTemp(string fileName, string uniqueId)
        {
            MoveRootRelative($"{UPLOAD}/{uniqueId}/{fileName}", $"{TEMP}/{fileName}");

            var sourcePath = GetBaseRelativeFile($"{UPLOAD}/{uniqueId}/{fileName}");

            if (sourcePath.Directory.Exists)
            {
                try
                {
                    sourcePath.Directory.Delete();
                }
                catch (System.IO.IOException)
                {
                    //Ignore this exception, we would like
                    //to delete the folder only if is empty.
                }
            }
        }

        /// <summary>
        /// Move files from entry assembly relative folder
        /// </summary>
        /// <param name="relativeSourceFile"></param>
        /// <param name="relativeDestinationFile"></param>
        private void MoveRootRelative(string relativeSourceFile, string relativeDestinationFile)
        {
            var sourcePath = GetBaseRelativeFile(relativeSourceFile);
            var destPath = GetBaseRelativeFile(relativeDestinationFile);

            Move(sourcePath, destPath);
        }

        /// <summary>
        /// Move file to destination
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        private static void Move(FileInfo sourceFile, FileInfo destinationFile)
        {
            if (!destinationFile.Directory.Exists)
                destinationFile.Directory.Create();

            //Strategy to overwrite any existing file, as guid maintains uniqueness
            if (destinationFile.Exists)
                destinationFile.Delete();

            sourceFile.MoveTo(destinationFile.FullName);
        }



    }
}
