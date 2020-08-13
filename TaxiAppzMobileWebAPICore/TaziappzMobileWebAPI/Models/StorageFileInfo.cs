using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaziappzMobileWebAPI
{
    class StorageFileInfo
    {
        /// <summary>
        /// Forom file 
        /// </summary>
        public IFormFile FormFile { get; set; }

        /// <summary>
        /// File upload id
        /// </summary>
        public Guid UploadId { get; set; }

        /// <summary>
        /// File extension
        /// </summary>
        public string Extension { get; set; }
    }
}
