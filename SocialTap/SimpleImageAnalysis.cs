using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SocialTap
{
    class SimpleImageAnalysis
    {
        public static Bitmap CreateImage(String url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();

            return new Bitmap(responseStream);
        }

        public static int CountGlassVolume(Bitmap img)
        {
            Color borderPixel;
            int x = 0;
            int volume = 0;

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    Color pixel = img.GetPixel(j, i);

                    if ((pixel.R < 250) && (pixel.G < 250) && (pixel.B < 250)
                        && (pixel.R >= 0) && (pixel.G >= 0) && (pixel.B >= 0))
                    {
                        borderPixel = pixel;
                        x = j;

                        while ((pixel == borderPixel) && (j < img.Width - 1))
                        {
                            j++;
                            pixel = img.GetPixel(j, i);
                        }

                        while ((pixel != borderPixel) && (j < img.Width - 1))
                        {
                            j++;
                            pixel = img.GetPixel(j, i);
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

        public static int CountLiquidVolume(Bitmap img)
        {
            int volume = 0;

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if ((pixel.R == 0) && (pixel.G == 162) && (pixel.B == 232))
                    {
                        volume++;
                    }
                }
            }

            return volume;
        }

    }
}
