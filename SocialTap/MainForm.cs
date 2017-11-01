using System;
using System.Windows.Forms;
using Emgu.CV;
using System.Drawing;
using Services;
using Database.File;
using System.Collections.Generic;
using Database;
using Database.RestaurantData;
using Logic;
using Services.BMIregex;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web;
using System.Runtime.Remoting.Contexts;

namespace SocialTap
{
    public partial class MainForm : Form
    {
        RestaurantInformation restaurantInformation = new RestaurantInformation();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _Username;

        public MainForm(string username)
        {
            InitializeComponent();
            _Username = username;
            lblusername.Text = "Welcome " + _Username;
        }

        private void btnOpenFile_Click_1(object sender, EventArgs e)
        {
            DialogResult drChosenFile;
            drChosenFile = openFileDialog.ShowDialog();
            Mat image;

            try
            {
                errorMessage.Text = "";
                string path = openFileDialog.FileName;
                image = new Mat(path);
                imageBox.Image = image;
                GetAllGlassInformation(path, imageBox2);
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
        public async void GetAllGlassInformation(String path, PictureBox imageBox2)
        {
            try
            {
                await restaurantInformation.GetRestaurantInformation(path, imageBox2, _Username);
                lblName.Text = restaurantInformation.Name;
                lblAddress.Text = restaurantInformation.Address;
                lblPercentage.Text = restaurantInformation.Percentage.ToString();
                lblDate.Text = string.Format("{0:d}", restaurantInformation.Date);
                WritingToFileSerialize<RestaurantInformation> writing = new WritingToFileSerialize<RestaurantInformation>();
                writing.Write(restaurantInformation, ConfigurationManager.AppSettings["FileName"]);
            }
            catch (ArgumentOutOfRangeException)
            {
                errorMessage.Text = "Cannot load information";
            }
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
                    RestaurantInformation restaurantInfo = new RestaurantInformation();
                    restaurantInfo.Name = nearbyPlacesData.placesList[i].Name;
                    restaurantInfo.Address = nearbyPlacesData.placesList[i].Address;
                    RestaurantAverageOfPercentage restaurantAverageOfPercentage = new RestaurantAverageOfPercentage();
                    TblNearbyLocation.Rows.Add(i + 1, restaurantInfo.Name, restaurantInfo.Address, restaurantAverageOfPercentage.GetAverageOfLiquid(restaurantInfo));
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                TblNearbyLocation.Rows.Clear();
                ImageBoxMap.Image = null;
                lblImageError.Text = "Cannot load information";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelRecommend.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelBMI.Visible = false;
        }

        private void Recomendations_Click(object sender, EventArgs e)
        {
            panelRecommend.Visible = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            new Regex_BMI().RegexValidation(@"\d+", Year, labelYear, "Year");
            if (labelYear.Text == "Year InValid")
            { panelBMI.Visible = false; }
            else
            {
                double bmi;
                double wgh = double.Parse(Weight.Value.ToString());
                double hgh2 = Math.Pow(double.Parse(Height.Value.ToString()), 2);

                bmi = new CountBMI().GetBMI(wgh, hgh2);


                if (bmi.ToString().Length > 5)
                {
                    textBox1.Text = (wgh / hgh2).ToString().Remove(5);
                    textBox2.Text = (wgh / hgh2).ToString().Remove(5);
                }
                else
                {
                    textBox1.Text = (wgh / hgh2).ToString();
                    textBox2.Text = (wgh / hgh2).ToString();
                }

                if (bmi < 16.5 && bmi > 11)

                {
                    label15.Visible = true;
                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = false;
                    label19.Visible = false;
                }
                else if (bmi < 18.5 && bmi > 16.5)
                {
                    label15.Visible = false;
                    label16.Visible = true;
                    label17.Visible = false;
                    label18.Visible = false;
                    label19.Visible = false;
                }
                else if (bmi < 25 && bmi > 18.5)
                {
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = true;
                    label18.Visible = false;
                    label19.Visible = false;
                }
                else if (bmi < 30 && bmi > 25)
                {
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = true;
                    label19.Visible = false;
                }
                else if (bmi > 30)
                {
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = false;
                    label19.Visible = true;
                }
                panelBMI.Visible = true;
            }
        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = Year.SelectedIndex;
            year = year.CalibrateAge();
            label14.Text = year.ToString();
        }
        private void btnUploadMostVisited_Click(object sender, EventArgs e)
        {
            MostVisitedList mostVisitedList = new MostVisitedList();
            List<RestaurantInformationAverage> restaurantList = mostVisitedList.GetMostVisitedList(cmbMostVisited.Text);
            int size;
            size = restaurantList.Count;
            if (restaurantList.Capacity < 5)
            {
                size = restaurantList.Count;
            }
            else
            {
                size = 5;
            }
            dataMostVisited.Rows.Clear();
            for (int i = 0; i < size; i++)
            {
                dataMostVisited.Rows.Add(restaurantList[i].Name, restaurantList[i].Address, restaurantList[i].Times, restaurantList[i].AverageOfPercentage);
            }

        }


    }
}