using System;
using Logic.ImageAnalysis;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Services.ImageAnalysis
{
    /// <summary>
    /// The Class recognizes liquid in a glass and calculates the percentage of 
    /// fullness of that glass. Currently, the bacground of the photo should be 
    /// bright and not obstructed by any visual components for the best performance.
    /// Usage: 
    /// 1) Create an instance of the class. 
    /// 2) Access percentage and VisualRepresentation properties.
    /// (C) - MMV
    /// </summary>
    public class RealPhotoAnalysis : ICalculateLiquidPercentage
    {
        private Image<Gray, byte> _img;
        //private Image<Gray, byte> _imgCopy;
        private VectorOfVectorOfPoint _contours;
        //private VectorOfVectorOfPoint _contoursCopy = new VectorOfVectorOfPoint();
        //private VectorOfPoint _redLineContour;
        //private VectorOfPoint _approxRedLineContour;
        private VectorOfPoint _liquidContour;
        private VectorOfPoint _approxLiquidContour;
        private VectorOfPoint _glassTopContour;
        private VectorOfPoint _approxGlassTopContour;

        private Point _topLiquidPoint1;
        private Point _topLiquidPoint2;
        private int _liquidVolume;
        private int _totalVolume;

        private int _percentage;

        private Lazy<Image<Bgr, byte>> _visualRepresentation;
        public Image<Bgr, byte> VisualRepresentation
        {
            get { return _visualRepresentation.Value; }
        }

        /// <summary>
        /// don't allow users to create instances without passing an image
        /// </summary>
        private RealPhotoAnalysis() { }

        /// <summary>
        /// All the private fields and public properties are set during the 
        /// construction of an objct
        /// </summary>
        /// <param name="img">Source image used to calculate the percentage of
        /// liquid</param>
        public RealPhotoAnalysis(Image<Bgr, byte> img) 
        {
            //Red line detection
            //Make a copy of the image for red line detection
            //Image<Bgr, byte> imgCopy = img.Clone();

            //Prepare copy for red line detection
            //_imgCopy = GetPixelMask(imgCopy, 20, 160); //Reddish params

            //set _contoursCopy to hold all contours of _imgCopy
            //_contours = new VectorOfVectorOfPoint();
            //CvInvoke.FindContours(_imgCopy, _contoursCopy, null, RetrType.External,
            //    ChainApproxMethod.ChainApproxSimple);

            //FindLineContour();
            //

            //Liquid detection
            //Prepare image for further processing
            _img = GetPixelMask(img, 30, 200); //Yellowish params

            //set _contours to hold all contours of _img
            _contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(_img, _contours, null, RetrType.External,
                ChainApproxMethod.ChainApproxSimple);

            FindLiquidContour();
            CalculateLiquidVolume();
            FindTopLiquidPoints();
            FindGlassTopContour();
            CalculateTotalVolume();
            CalculatePercentage();

            //GetVisualRepresentation();
            _visualRepresentation = new Lazy<Image<Bgr, byte>>(() => GetVisualRepresentation(_liquidContour, _approxLiquidContour,
                                                                    _glassTopContour, _approxGlassTopContour,
                                                                    _topLiquidPoint1, _topLiquidPoint2));
        }

        /// <summary>
        /// Sets the VisualRepresentation property to an image with all the 
        /// calculations illustrated.
        /// </summary>
        private Image<Bgr, byte> GetVisualRepresentation(VectorOfPoint liquidContour, VectorOfPoint approxLiquidContour, 
                                                         VectorOfPoint glassTopContour, VectorOfPoint approxGlassTopContour,
                                                         Point topLiquidPoint1, Point topLiquidPoint2,
                                                         DrawOptions drawOptions = DrawOptions.TopContour | DrawOptions.TopApproxContour | 
                                                         DrawOptions.LiquidContour | DrawOptions.ApproxLiquidContour)
        {
            Size imgSize = new Size(_img.Width, _img.Height);
            Image<Bgr, byte> img = new Image<Bgr, byte>(imgSize);
            Point[] points;

            if (_glassTopContour.Size != 0)
            {
                Point topPoint1 = new Point(topLiquidPoint1.X, glassTopContour.ToArray()[0].Y);
                Point topPoint2 = new Point(topLiquidPoint2.X, glassTopContour.ToArray()[1].Y);

                points = new Point[] { topPoint2, topLiquidPoint2,
                                   topLiquidPoint1, topPoint1};
                img.DrawPolyline(points, true, new Bgr(Color.DarkMagenta), 1);
            }

            points = liquidContour.ToArray();
            img.DrawPolyline(points, true, new Bgr(Color.Aqua), 2);

            points = approxLiquidContour.ToArray();
            img.DrawPolyline(points, true, new Bgr(Color.DeepPink), 4);

            points = glassTopContour.ToArray();
            img.DrawPolyline(points, true, new Bgr(Color.YellowGreen), 5);

            points = approxGlassTopContour.ToArray();
            img.DrawPolyline(points, true, new Bgr(Color.OrangeRed), 5);

            //points = _redLineContour.ToArray();
            //img.DrawPolyline(points, true, new Bgr(Color.Crimson), 5);

            //points = _approxRedLineContour.ToArray();
            //img.DrawPolyline(points, true, new Bgr(Color.Red), 5);

            return img;
        }

        /// <summary>
        /// 
        /// </summary>
        //private void FindLineContour()
        //{
        //    VectorOfPoint contour = new VectorOfPoint();
        //    VectorOfPoint approxContour = new VectorOfPoint();

        //    for (int i = 0; i < _contours.Size; i++)
        //    {
        //        contour = _contours[i];
        //        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, false) * 0.1, true);

        //        if (CvInvoke.ArcLength(contour, false) > _imgCopy.Width * 0.05)
        //        {
        //            break;
        //        }
        //    }

        //    _redLineContour = contour;
        //    _approxRedLineContour = approxContour;
        //}

        /// <summary>
        /// Finds the liquid contour and sets fields _approxLiquidContour 
        /// and _liquidContour.
        /// </summary>
        private void FindLiquidContour()
        {
            VectorOfPoint contour = new VectorOfPoint();
            VectorOfPoint approxContour = new VectorOfPoint();

            for (int i = 0; i < _contours.Size; i++)
            {
                contour = _contours[i];
                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);

                if (CvInvoke.ContourArea(approxContour, false) > 10000)
                {
                    break;
                }
            }

            _liquidContour = contour;
            _approxLiquidContour = approxContour;
        }

        /// <summary>
        /// Calculates the volume of liquid (uses _liquidContour) and sets
        /// _liquidVolume.
        /// </summary>
        private void CalculateLiquidVolume()
        {
            _liquidVolume = (int)CvInvoke.ContourArea(_liquidContour);
        }

        /// <summary>
        /// Finds two highest (with lowest Y value) points out of four from
        /// _approxLiquidContour and set __topLiquidPoint1 and _topLiquidPoint2.
        /// </summary>
        private void FindTopLiquidPoints()
        {
            //"zero" points for finding 2 top points of the approxLiquidContour
            // coordinates calculation in emguCV:
            //
            //  0/0---X--->
            //  |
            //  |
            //  Y
            //  |
            //  |
            //  v
            //

            _topLiquidPoint1 = new Point(0, _img.Height);
            _topLiquidPoint2 = new Point(0, _img.Height);

            Point[] points = _approxLiquidContour.ToArray();

            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].Y < _topLiquidPoint1.Y)
                {
                    _topLiquidPoint1 = points[i];
                }
                else if (points[i].Y < _topLiquidPoint2.Y)
                {
                    _topLiquidPoint2 = points[i];
                }
            }
        }

        /// <summary>
        /// Finds the top edge of the glass and sets _glassTopContour and 
        /// _approxGlassTopContour to its contour.
        /// </summary>
        private void FindGlassTopContour()
        {
            VectorOfPoint contour = new VectorOfPoint();
            VectorOfPoint approxContour = new VectorOfPoint();
            VectorOfPoint longestContour = new VectorOfPoint();
            VectorOfPoint longestContourApprox = new VectorOfPoint();

            int maxLength = 0;

            for (int i = 0; i < _contours.Size; i++)
            {
                contour = _contours[i];
                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.1, true);

                if (approxContour.Size == 2)
                {
                    if ((approxContour.ToArray()[0].Y > _topLiquidPoint1.Y) ||
                            (approxContour.ToArray()[1].Y > _topLiquidPoint2.Y))
                    {
                        continue;
                    }
                    if (maxLength < (int)CvInvoke.ArcLength(approxContour, false))
                    {
                        maxLength = (int)CvInvoke.ArcLength(approxContour, false);
                        longestContour = contour;
                        longestContourApprox = approxContour;
                    }
                }
            }

            _glassTopContour = longestContour;
            _approxGlassTopContour = approxContour;
        }

        /// <summary>
        /// Calculates the total volume of a glass (_liquidVolume + [gap]) and
        /// sets _totalVolume.
        /// </summary>
        private void CalculateTotalVolume()
        {
            if (_glassTopContour.Size == 0)
            {
                _totalVolume = _liquidVolume;
            }
            else
            {
                int topLength = _topLiquidPoint1.X - _topLiquidPoint2.X;
                topLength = (topLength > 0) ? topLength : (-1) * topLength;

                int gapHeight = _topLiquidPoint1.Y - _approxGlassTopContour.ToArray()[0].Y;

                _totalVolume = _liquidVolume + (gapHeight * topLength);

                if (_totalVolume < 0)
                {
                    throw new ValueBellowZeroException(_totalVolume.ToString() + "Percentage below 0!!");
                }
            }
        }

        /// <summary>
        /// Sets field percentage to the calculated fullness of a glass 
        /// in the _img.
        /// </summary>
        private void CalculatePercentage()
        {
          
            Func<int, int, int> percentage = delegate (int _liquidVolume, int _totalVolume) { return _liquidVolume * 100 / _totalVolume; };

            _percentage = percentage(_liquidVolume, _totalVolume);

            if (_percentage < 0)
            {
                throw new ValueBellowZeroException(_percentage.ToString() + "Percentage below 0!!");
            }
        }

        public class ValueBellowZeroException : Exception
        {
            public ValueBellowZeroException() { }

            public ValueBellowZeroException(string message) : base(message) { }

            public ValueBellowZeroException(string message, Exception innerException)
            : base(message, innerException) { }
        }


        /// <summary>
        /// Compute the yellowish pixel mask for the given image. 
        /// A yellowish pixel is a pixel where: 30 &lt; hue &lt; 200 AND saturation &gt; 10
        /// </summary>
        /// <param name="image">The color image to find yellowish mask from</param>
        /// <param name="lowerRange">The lower boundary of color mask the method gets.</param>
        /// <param name="upperRange">The upper boundary of color mask the method gets.</param>
        /// <returns>The yellowish pixel mask</returns>

        // &lt = "<" (less than)
        // &gt = ">" (greater than) 

        public static Image<Gray, Byte> GetPixelMask(Image<Bgr, byte> image, int lowerRange, int upperRange)
        {
            using (Image<Hsv, Byte> hsv = image.Convert<Hsv, Byte>())
            {
                //split (hue, saturation, value) image into channels by color

                Image<Gray, Byte>[] channels = hsv.Split();

                try
                {
                    //Using ScalarArrays for input in CVInvoke.InRange() method
                    //
                    ScalarArray SA1 = new ScalarArray(new MCvScalar(lowerRange));
                    ScalarArray SA2 = new ScalarArray(new MCvScalar(upperRange));

                    //channels[0] is the mask for hue less than 20 or larger than 160
                    CvInvoke.InRange(channels[0], SA1, SA2, channels[0]);
                    channels[0]._Not();

                    //channels[1] is the mask for satuation of at least 10, this is mainly used to filter out white pixels
                    channels[1]._ThresholdBinary(new Gray(10), new Gray(255.0));

                    CvInvoke.BitwiseAnd(channels[0], channels[1], channels[0]);
                }
                finally
                {
                    channels[1].Dispose();
                    channels[2].Dispose();
                }
                return channels[0];
            }
        }

        int ICalculateLiquidPercentage.CalculatePercentageOfLiquid()
        {
            return _percentage;
        }
    }
}
