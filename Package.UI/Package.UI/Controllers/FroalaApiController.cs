using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FroalaEditor;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Package.UI.Extensions;
//using ImageMagick;

namespace Package.UI.Controllers
{
    public class FroalaApiController : Controller
    {
        string fileRoute = "wwwroot/uploads/content/";
        public FroalaApiController()
        {
        }
        [HttpPost]
        [Produces("application/json")]
        public IActionResult UploadImage()
        {
      

            try
            {
                var result = Image.Upload(HttpContext, fileRoute);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        // Convert file path to url

        public IActionResult UploadFile()
        {


            object response;
            try
            {
                response = FroalaEditor.File.Upload(HttpContext, fileRoute);
                return Json(response);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }



        public IActionResult UploadImageResize()
        {

            MagickGeometry resizeGeometry = new MagickGeometry(300, 300);
            resizeGeometry.IgnoreAspectRatio = true;

            ImageOptions options = new ImageOptions()
            {
                ResizeGeometry = resizeGeometry

            };

            try
            {
                return Json(Image.Upload(HttpContext, fileRoute, options));
            }
            catch (Exception e)
            {
                return Json(e);
            }

        }

        public IActionResult UploadImageValidation()
        {


            Func<string, string, bool> validationFunction = (filePath, mimeType) =>
            {

                MagickImageInfo info = new MagickImageInfo(filePath);

                if (info.Width != info.Height)
                {
                    return false;
                }

                return true;
            };

            ImageOptions options = new ImageOptions
            {
                Fieldname = "myImage",
                Validation = new ImageValidation(validationFunction)
            };

            try
            {
                return Json(Image.Upload(HttpContext, fileRoute, options));

            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public IActionResult UploadFileValidation()
        {

            Func<string, string, bool> validationFunction = (filePath, mimeType) => {

                long size = new System.IO.FileInfo(filePath).Length;
                if (size > 10 * 1024 * 1024)
                {
                    return false;
                }

                return true;
            };

            FroalaEditor.FileOptions options = new FroalaEditor.FileOptions
            {
                Fieldname = "myFile",
                Validation = new FileValidation(validationFunction)
            };

            try
            {
                return Json(Image.Upload(HttpContext, fileRoute, options));
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public IActionResult DeleteFile()
        {
            try
            {
                FroalaEditor.File.Delete(HttpContext.Request.Form["src"]);
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public IActionResult DeleteImage()
        {

            try
            {
                Image.Delete(HttpContext.Request.Form["src"]);
                return Json(true);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public IActionResult S3Signature()
        {

            S3Config config = new S3Config
            {
                Bucket = Environment.GetEnvironmentVariable("AWS_BUCKET"),
                Region = Environment.GetEnvironmentVariable("AWS_REGION"),
                KeyStart = Environment.GetEnvironmentVariable("AWS_KEY_START"),
                Acl = Environment.GetEnvironmentVariable("AWS_ACL"),
                AccessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY"),
                SecretKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY")
            };

            return Json(FroalaEditor.S3.GetHash(config));

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
