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
using log4net.Appender;
using Database.File;
using System.Collections.Generic;
using Database;

namespace SocialTap
{
    public partial class MainForm : Form
    {
        RestaurantInformation glassInformation = new RestaurantInformation();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click_1(object sender, EventArgs e)
        {
            DialogResult drChosenFile;
            drChosenFile = openFileDialog.ShowDialog();
            Mat image;

            try
            {
                string path = openFileDialog.FileName;
                image = new Mat(path);
                imageBox.Image = image;
                Bitmap bitmap = new Bitmap(image.Bitmap);
                GetAllGlassInformation(bitmap);

                //var culture = new CultureInfo("en-GB");
                //DateTime localDate = DateTime.Now;

                //Log.WriteLineToFile(localDate.ToString(culture) + " " + percentageOfLiquid + "%");
                log.Info("Liquid in the picture: " + glassInformation.Percentage + "%");

                IAppender[] appenders = log.Logger.Repository.GetAppenders();
                // Check each appender this logger has
                foreach (IAppender appender in appenders)
                {

                }


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

        private void btnFindMap_Click_1(object sender, EventArgs e)
        {
            GetMap();
        }

        private void btnUploadTopList_Click(object sender, EventArgs e)
        {
            TopList customTopList = new TopList();
            List<RestaurantInformationAverage> list = customTopList.GetTopList(cmbTopList.Text);
            int size;
            size = list.Count;
            if (list.Capacity < 5)
            {
                size = list.Count;
            }
            else
            {
                size = 5;
            }
            dataTopList.Rows.Clear();
            for (int i = 0; i < size; i++)
            {
                dataTopList.Rows.Add(list[i].Name, list[i].Address, list[i].AverageOfPercentage);
            }
        }
        public async void GetAllGlassInformation(Bitmap bitmap)
        {
            await glassInformation.GetRestaurantInformation(bitmap);
            lblName.Text = glassInformation.Name;
            lblAddress.Text = glassInformation.Address;
            lblPercentage.Text = glassInformation.Percentage.ToString();
            lblDate.Text = string.Format("{0:d}", glassInformation.Date);
            WritingToFile writing = new WritingToFile();
            writing.Write(glassInformation);
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
                lblImageError.Text = "";

                for (int i = 0; i < 5; i++)
                {
                    RestaurantInformation glass = new RestaurantInformation();
                    glass.Name = nearbyPlacesData.placesList[i].name;
                    glass.Address = nearbyPlacesData.placesList[i].address;
                    RestaurantAverageOfPercentage restaurantAverageOfPercentage = new RestaurantAverageOfPercentage();
                    TblNearbyLocation.Rows.Add(i + 1, glass.Name, glass.Address, restaurantAverageOfPercentage.GetAverageOfLiquid(glass));
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