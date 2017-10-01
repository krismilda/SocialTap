using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Services.ImageAnalysis
{
    public class EmguCVImageAnalysis
    {
        public Image<Gray, byte> CannyDetection(string path)
        {
            Image<Bgr, byte> sourceImage = new Image<Bgr, byte>(path);
            Image<Gray, byte> imgCanny = new Image<Gray, byte>(sourceImage.Width, sourceImage.Height, new Gray(0));
            imgCanny = sourceImage.Canny(50, 200);
            return imgCanny;
        }

        public Image<Gray, float> SobelDetection(string path)
        {
            Image<Bgr, byte> sourceImage = new Image<Bgr, byte>(path);
            Image<Gray, byte> sourceImageGray = sourceImage.Convert<Gray, byte>(); 
            Image<Gray, float> imgSobel = new Image<Gray, float>(sourceImage.Width, sourceImage.Height, new Gray(0));
            imgSobel = sourceImageGray.Sobel(1, 1, 3);
            return imgSobel;
        }

        public Image<Gray, float> LaplacianDetection(string path)
        {
            Image<Bgr, byte> sourceImage = new Image<Bgr, byte>(path);
            Image<Gray, byte> sourceImageGray = sourceImage.Convert<Gray, byte>();
            Image<Gray, float> imgLaplacian = new Image<Gray, float>(sourceImage.Width, sourceImage.Height, new Gray(0));
            imgLaplacian = sourceImageGray.Laplace(3);
            return imgLaplacian;
        }

        public Image<Bgr, Byte> FindContours(string path)
        {
            Image<Bgr, Byte> img =
               new Image<Bgr, byte>(path)
               .Resize(400, 400, Emgu.CV.CvEnum.Inter.Linear, true);

            UMat uimage = new UMat();
            CvInvoke.CvtColor(img, uimage, ColorConversion.Bgr2Gray);

            UMat pyrDown = new UMat();
            CvInvoke.PyrDown(uimage, pyrDown);
            CvInvoke.PyrUp(pyrDown, uimage);

            double cannyThreshold = 180.0;
            double cannyThresholdLinking = 120.0;
            UMat cannyEdges = new UMat();
            CvInvoke.Canny(uimage, cannyEdges, cannyThreshold, cannyThresholdLinking);

            LineSegment2D[] lines = CvInvoke.HoughLinesP(
               cannyEdges,
               1, //Distance resolution in pixel-related units
               Math.PI / 45.0, //Angle resolution measured in radians.
               20, //threshold
               30, //min Line width
               10); //gap between lines

            Image<Bgr, Byte> lineImage = img.CopyBlank();
            foreach (LineSegment2D line in lines)
                lineImage.Draw(line, new Bgr(Color.Green), 2);

            return lineImage;
        }
    }
}
