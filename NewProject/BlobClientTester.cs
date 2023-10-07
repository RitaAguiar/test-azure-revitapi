using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace NewProject
{
    public class BlobClientTester
    {
        public static async Task ListContainerFiles()
        {
            string connectionString = "<connection-string>";
            string containerName = "<container-name>";
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var fileNames = ListFilesInContainer(containerClient);
            TaskDialog.Show($"Files in Container: {containerName}", $"{fileNames}");
        }

        static IEnumerable<string> ListContainers(BlobServiceClient blobServiceClient)
        {
            foreach (var containerItem in blobServiceClient.GetBlobContainers())
            {
                yield return containerItem.Name;
            }
        }

        static List<string> ListFilesInContainer(BlobContainerClient containerClient)
        {
            var fileNames = new List<string>();
            foreach (BlobItem blobItem in containerClient.GetBlobs())
            {
                fileNames.Add($"File Name: {blobItem.Name}, Size: {blobItem.Properties.ContentLength} bytes");
            }
            return fileNames;
        }
    }
}
