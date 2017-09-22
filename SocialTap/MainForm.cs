using System;
using System.Windows.Forms;
using Emgu.CV;
using System.Drawing;
using social_tap;
using System.Threading;
using System.Threading.Tasks;

namespace SocialTap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            getLocationInformation();
        }
        public async void getLocationInformation()
        {
            CurrentLocationName googleApiData = new CurrentLocationName();
            GooglePlacesApiResponse responseData = await googleApiData.GetApiResponseData();
            lblName.Text = responseData.results[0].name;
            lblAddress.Text = responseData.results[0].vicinity;
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult drChosenFile;
            drChosenFile = openFileDialog.ShowDialog();
            Mat image;

            try
            {
                image = new Mat(openFileDialog.FileName);
                imageBox.Image = image;
                Bitmap bitmap = new Bitmap(image.Bitmap);
                SimpleImageAnalysis imageInformation = new SimpleImageAnalysis(bitmap);
                int percentageOfLiquid = imageInformation.CalculatePercentageOfLiquid();
                lblPercentage.Text = percentageOfLiquid.ToString();
            }
            catch (ArgumentException)
            {
                errorMessage.Text = "Wrong image format";
            }
        }

    }
}