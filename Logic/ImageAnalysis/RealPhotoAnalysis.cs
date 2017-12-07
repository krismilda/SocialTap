using System;
using Logic.ImageAnalysis;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Services.ImageAnalysis
{
    public class RealPhotoAnalysis : ICalculateLiquidPercentage
    {
        private Image<Gray, byte> _img;
        private VectorOfVectorOfPoint _contours;
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
        private RealPhotoAnalysis() { }

        public RealPhotoAnalysis(Image<Bgr, byte> img) 
        {
            _img = GetPixelMask(img, 30, 200); 

            _contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(_img, _contours, null, RetrType.External,
                ChainApproxMethod.ChainApproxSimple);

            FindLiquidContour();
            CalculateLiquidVolume();
            FindTopLiquidPoints();
            FindGlassTopContour();
            CalculateTotalVolume();
            CalculatePercentage();

            _visualRepresentation = new Lazy<Image<Bgr, byte>>(() => GetVisualRepresentation(_liquidContour, _approxLiquidContour,
                                                                    _glassTopContour, _approxGlassTopContour,
                                                                    _topLiquidPoint1, _topLiquidPoint2));
        }

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

            return img;
        }

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

        private void CalculateLiquidVolume()
        {
            _liquidVolume = (int)CvInvoke.ContourArea(_liquidContour);
        }

        private void FindTopLiquidPoints()
        {
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

        private void CalculatePercentage()
        {
          
            Func<int, int, int> percentage = delegate (int _liquidVolume, int _totalVolume) { return _liquidVolume * 100 / _totalVolume; };

            _percentage = percentage(_liquidVolume, _totalVolume);

            if (_percentage < 0)
            {
                throw new ValueBellowZeroException(_percentage.ToString() + "Percentage below 0!!");
            }
        }

        public static Image<Gray, Byte> GetPixelMask(Image<Bgr, byte> image, int lowerRange, int upperRange)
        {
            using (Image<Hsv, Byte> hsv = image.Convert<Hsv, Byte>())
            {

                Image<Gray, Byte>[] channels = hsv.Split();

                try
                {

                    ScalarArray SA1 = new ScalarArray(new MCvScalar(lowerRange));
                    ScalarArray SA2 = new ScalarArray(new MCvScalar(upperRange));

                    CvInvoke.InRange(channels[0], SA1, SA2, channels[0]);
                    channels[0]._Not();

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

        public static int GetPercentage(Bitmap bmp)
        {
            ICalculateLiquidPercentage rpa = new RealPhotoAnalysis(new Image<Bgr, byte>(bmp));
            return rpa.CalculatePercentageOfLiquid();
        }
    }
}
