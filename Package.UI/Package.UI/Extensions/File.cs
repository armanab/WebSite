using FroalaEditor;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Package.UI.Extensions
{
    /// <summary>
    /// File functionality.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Content type string used in http multipart.
        /// </summary>
        public static string MultipartContentType = "multipart/form-data";

        /// <summary>
        /// File default options.
        /// </summary>
        public static FroalaEditor.FileOptions defaultOptions = new FroalaEditor.FileOptions();

        /// <summary>
        /// Check http request content type.
        /// </summary>
        /// <returns>true if content type is multipart.</returns>
        public static bool CheckContentType(HttpContext httpContext)
        {       
            bool isMultipart = httpContext.Request.ContentType.StartsWith(MultipartContentType);

            return isMultipart;
        }

    
        /// <summary>
        /// Get absolute server path.
        /// </summary>
        /// <param name="path">Relative path.</param>
        /// <returns>Absolute path.</returns>
        public static String GetAbsoluteServerPath(string path) 
        {

            return path;
        }

        /// <summary>
        /// Delete a file from disk.
        /// </summary>
        /// <param name="src">Server file path.</param>
        public static void Delete(string filePath)
        {
            filePath = "wwwroot" + filePath;
            // Will throw an exception if an error occurs.
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        internal static object Upload(HttpContext httpContext, string fileRoute, FroalaEditor.FileOptions options)
        {
            //Use default file options.
            //if (options == null)
            //{
            //    options = defaultOptions;
            //}

            if (!CheckContentType(httpContext))
            {
                throw new Exception("Invalid contentType. It must be " + MultipartContentType);
            }

            var httpRequest = httpContext.Request;

            int filesCount = 0;
            filesCount = httpRequest.Form.Files.Count;


            if (filesCount == 0)
            {
                throw new Exception("No file found");
            }

            // Get HTTP posted file based on the fieldname. 
            var file = httpRequest.Form.Files.GetFile(options.Fieldname);

            if (file == null)
            {
                throw new Exception("Fieldname is not correct. It must be: " + options.Fieldname);
            }

            // Generate Random name.
            string extension = Utils.GetFileExtension(file.FileName);
            string name = Utils.GenerateUniqueString() + "." + extension;

            string link = fileRoute + name;

            // Create directory if it doesn't exist.
            FileInfo dir = new FileInfo(fileRoute);
            dir.Directory.Create();

            // Copy contents to memory stream.
            Stream stream;
            stream = new MemoryStream();
            file.CopyTo(stream);
            stream.Position = 0;

            String serverPath = GetAbsoluteServerPath(link);

            // Save file to disk.
            //Save(stream, serverPath, options);

            // Check if the file is valid.
            if (options.Validation != null && !options.Validation.Check(serverPath, file.ContentType))
            {
                // Delete file.
                Delete(serverPath);
                throw new Exception("File does not meet the validation.");
            }

            // Make sure it is compatible with ASP.NET Core.
            return new { link = link.Replace("wwwroot", "") };
        }
    }
}
