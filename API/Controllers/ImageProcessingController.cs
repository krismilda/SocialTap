using Emgu.CV;
using Emgu.CV.Structure;
using Logic.ImageAnalysis;
using Services.ImageAnalysis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace API.Controllers
{
    public class ImageProcessingController : ApiController
    {
     public IHttpActionResult Post()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                Bitmap bmp = null;
                
                Request.Content.LoadIntoBufferAsync().Wait();
                var t = Request.Content.ReadAsMultipartAsync<MultipartMemoryStreamProvider>(
                        new MultipartMemoryStreamProvider()).ContinueWith((task) =>
                        {
                            MultipartMemoryStreamProvider provider = task.Result;
                            var content = provider.Contents[0];
                            Stream stream = content.ReadAsStreamAsync().Result;
                            Image image = Image.FromStream(stream);
                            bmp = new Bitmap(stream);
                            return RealPhotoAnalysis.GetPercentage(bmp);
                        });
                return Ok(t.Result);
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(
                        HttpStatusCode.NotAcceptable,
                        "This request is not properly formatted"));
            }
        }
    }
}
