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
        public Bitmap bitmap;
        GlassInformation glassInformation = new GlassInformation();

        public MainForm()
        {
            InitializeComponent();
            TopList t = new TopList();
            List<GlassInformationFile> list=t.getTopList();
            for (int i = 0; i < 5; i++)
            {
                dataTopList.Rows.Add(list[i].Name, list[i].Address, list[i].Average);
            }

        }
        public async void GetAllGlassInformation()
        {
            await glassInformation.GetGlassInformation(bitmap);
            lblName.Text = glassInformation.Name;
            lblAddress.Text = glassInformation.Address;
            lblPercentage.Text = glassInformation.Percentage.ToString();
            WritingToFile writing = new WritingToFile();
            writing.Write(glassInformation);
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult drChosenFile;
            drChosenFile = openFileDialog.ShowDialog();
            Mat image;
           
            try
            {
                string path = openFileDialog.FileName;
                image = new Mat(path);
                imageBox.Image = image;
                bitmap = new Bitmap(image.Bitmap);
                GetAllGlassInformation();

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
                    GlassInformation glass = new GlassInformation();
                    glass.Name = nearbyPlacesData.placesList[i].name;
                    glass.Address = nearbyPlacesData.placesList[i].address;
                    TblNearbyLocation.Rows.Add(i + 1, glass.Name, glass.Address, FoodServiceAverage.getAverageOfLiquid(glass));

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