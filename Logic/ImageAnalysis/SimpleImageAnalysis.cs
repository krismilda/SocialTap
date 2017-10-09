using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace social_tap
{
   public class SimpleImageAnalysis
    {
        private Bitmap _img;

        public SimpleImageAnalysis(Bitmap img)
        {
            _img = img;
        }

        public static Bitmap CreateImage(String url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();

            return new Bitmap(responseStream);
        }

        private int CountGlassVolume()
        {
            Color borderPixel;
            int x = 0;
            int volume = 0;

            for (int i = 0; i < _img.Height; i++)
            {
                for (int j = 0; j < _img.Width; j++)
                {
                    Color pixel = _img.GetPixel(j, i);

                    if ((pixel.R < 250) && (pixel.G < 250) && (pixel.B < 250)
                        && (pixel.R >= 0) && (pixel.G >= 0) && (pixel.B >= 0))
                    {
                        borderPixel = pixel;
                        x = j;

                        while ((pixel == borderPixel) && (j < _img.Width - 1))
                        {
                            j++;
                            pixel = _img.GetPixel(j, i);
                        }

                        while ((pixel != borderPixel) && (j < _img.Width - 1))
                        {
                            j++;
                            pixel = _img.GetPixel(j, i);
                        }

                        if (pixel == borderPixel)
                        {
                            volume += j - x;
                        }

                    }
                }
            }

            return volume;
        }

        private int CountLiquidVolume()
        {
            int volume = 0;

            for (int i = 0; i < _img.Width; i++)
            {
                for (int j = 0; j < _img.Height; j++)
                {
                    Color pixel = _img.GetPixel(i, j);

                    if ((pixel.R == 0) && (pixel.G == 162) && (pixel.B == 232))
                    {
                        volume++;
                    }
                }
            }

            return volume;
        }

        public int CalculatePercentageOfLiquid()
        {
            int volumeOfGlass;
            int volumeOfLiquid;
            int percentage;

            volumeOfGlass = this.CountGlassVolume();
            volumeOfLiquid = this.CountLiquidVolume();
            percentage = (volumeOfLiquid * 100) / volumeOfGlass;

            return percentage;
        }

    }
}