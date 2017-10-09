using System;
using System.Collections.Generic;
using Google.Cloud.Vision.V1;
using System.Drawing;

namespace Services.ImageAnalysis
{
    class ImageDetails
    {
        public List<string> GetDetails(string path)
        {
            throw new NotImplementedException();
            //List<string> description = new List<string>();
            /*  
            var client = ImageAnnotatorClient.Create();
            var image = Image.FromFile(path);
            
            var response = client.DetectLabels(image);
            foreach (var annotation in response)
            {
                if (annotation.Description != null)
                    description.Add(annotation.Description);
            }
            */
            //return description;
        }
    }
}
