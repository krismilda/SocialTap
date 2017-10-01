using System;
using System.Windows.Forms;
using Emgu.CV;
using System.Drawing;
using social_tap;
using System.Threading;
using System.Threading.Tasks;

using Services;
using System.Globalization;
using Services.Utilities;
using Services.ImageAnalysis;
using log4net;

namespace SocialTap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public async void GetLocationInformation()
        {
            GooglePlacesApiData googleApiData = new GooglePlacesApiData();
            GooglePlacesApiResponse responseData = await googleApiData.GetApiResponseData("");
            lblName.Text = responseData.results[0].name;
            lblAddress.Text = responseData.results[0].vicinity;
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult drChosenFile;
            drChosenFile = openFileDialog.ShowDialog();
            Mat image;
            GetLocationInformation();
            try
            {
                string path = openFileDialog.FileName;
                image = new Mat(path);
                imageBox.Image = image;
                Bitmap bitmap = new Bitmap(image.Bitmap);
                SimpleImageAnalysis imageInformation = new SimpleImageAnalysis(bitmap);
                int percentageOfLiquid = imageInformation.CalculatePercentageOfLiquid();
                lblPercentage.Text = percentageOfLiquid.ToString();

                //var culture = new CultureInfo("en-GB");
                //DateTime localDate = DateTime.Now;

                //Log.WriteLineToFile(localDate.ToString(culture) + " " + percentageOfLiquid + "%");
                log.Info("Liquid in the picture: " + percentageOfLiquid + "%");



                EmguCVImageAnalysis imgAnalysis = new EmguCVImageAnalysis();
                //imageBox2.Image = imgAnalysis.FindContours(path);

                //imageBox2.Image = imgAnalysis.CannyDetection(path);
                Mat modelImage = new Mat(@"../../TestImages/GlassTemplate.jpg");
                imageBox2.Image = EmguCVImageAnalysis.Draw(modelImage, image);
            }
            catch (ArgumentException)
            {
                errorMessage.Text = "Wrong image format";
            }

        }

        private void btnFindMap_Click(object sender, EventArgs e)
        {
            GetMap();

        }
        private async void GetMap()
        {
            GoogleStaticMapApiData nearbyPlacesData = new GoogleStaticMapApiData();
            string type = cmbType.Text;
            string zoom = cmdZoom.Text;
            try
            {
                Bitmap map = await nearbyPlacesData.GetMapResponseDataAsync(type, zoom);
                TblNearbyLocation.Rows.Clear();
                ImageBoxMap.Image = map;
                lblImageError.Text= "";
                for (int i = 0; i < 5; i++)
                {
                    TblNearbyLocation.Rows.Add(i + 1, nearbyPlacesData.placesList[i].name, nearbyPlacesData.placesList[i].address, nearbyPlacesData.placesList[i].percentage);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                TblNearbyLocation.Rows.Clear();
                ImageBoxMap.Image = null;
                lblImageError.Text = "Cannot load information";
            }



        }

    }
}