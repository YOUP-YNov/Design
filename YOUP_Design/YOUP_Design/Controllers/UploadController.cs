using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YOUP_Design.Controllers
{
    public class UploadController : Controller
    {
        private CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
        [HttpPost]
        public string UploadPicture()
        {
            HttpContext.Server.ScriptTimeout = 2400;
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("uploads");
            container.CreateIfNotExists();
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    string filepath = "";
                    if (string.IsNullOrEmpty(filepath))
                        filepath = file.FileName;

                    CloudBlockBlob blob = container.GetBlockBlobReference(filepath);
                    blob.UploadFromStream(file.InputStream);
                    return "https://ezdata.blob.core.windows.net/uploads/"+file.FileName;
                }
            }
            return "fail";
        }
    }
}
