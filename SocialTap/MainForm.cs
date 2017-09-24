using System;
using System.Windows.Forms;
using Emgu.CV;
using System.Drawing;
using social_tap;
using System.Threading;
using System.Threading.Tasks;

using SocialTap.Maps;
using SocialTap.Utilities;
using System.Globalization;

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
            GooglePlacesApiResponse responseData = await googleApiData.GetApiResponseData();
            lblName.Text = responseData.results[0].name;
            lblAddress.Text = responseData.results[0].vicinity;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult drChosenFile;
            drChosenFile = openFileDialog.ShowDialog();
            Mat image;
            GetLocationInformation();
            try
            {
                image = new Mat(openFileDialog.FileName);
                imageBox.Image = image;
                Bitmap bitmap = new Bitmap(image.Bitmap);
                SimpleImageAnalysis imageInformation = new SimpleImageAnalysis(bitmap);
                int percentageOfLiquid = imageInformation.CalculatePercentageOfLiquid();
                lblPercentage.Text = percentageOfLiquid.ToString();

                var culture = new CultureInfo("en-GB");
                DateTime localDate = DateTime.Now;

                Log.WriteLineToFile(localDate.ToString(culture) + " " + percentageOfLiquid + "%");
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
            Bitmap map = await nearbyPlacesData.GetMapResponseDataAsync(type, zoom);
            TblNearbyLocation.Rows.Clear();
            lblZoomText.Image = map;
            for (int i = 0; i < 5; i++)
            {
                   TblNearbyLocation.Rows.Add(i+1, nearbyPlacesData.placesList[i].name, nearbyPlacesData.placesList[i].address, nearbyPlacesData.placesList[i].percentage);
            }


        }

    }
}