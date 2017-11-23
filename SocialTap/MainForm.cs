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
using Database.HistoryData;

using Database.News;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Services.TwitterAPI;
using Tweetinvi.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace SocialTap
{
    public partial class MainForm : Form
    {
        RestaurantInformation restaurantInformation = new RestaurantInformation();
        Drink drinkInfo = new Drink();
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
                Task restaurantInformationTask = restaurantInformation.GetRestaurantInformation(path, imageBox2, _Username);
                int mililiter = 0;
                errorMililiter.Text = "";
                lblCateg.Text = "";
                try
                {
                    mililiter = int.Parse(textBoxMililiter.Text);
                }
                catch (FormatException)
                {
                    errorMililiter.Text = "Incorrect format of mililiter";
                    errorMililiter.ForeColor = Color.Red;
                }
                string category = comboBoxCategory.Text;
                new Regex_BMI().RegexValidation(@"\d+", comboBoxCategory, lblCateg, "Category");
                if (lblCateg.Text == "Category InValid")
                    category = "Unkown Category";
                await restaurantInformationTask;
                drinkInfo.GetDrinkInformation(restaurantInformation.Percentage, mililiter, category);
                lblName.Text = restaurantInformation.Name;
                lblAddress.Text = restaurantInformation.Address;
                lblPercentage.Text = restaurantInformation.Percentage.ToString();
                lblDate.Text = string.Format("{0:d}", restaurantInformation.Date);
                lblCategoryT.Text = drinkInfo.Category;
                lblMililiterT.Text = drinkInfo.Volume.ToString();
                WritingToFileSerialize<RestaurantInformation> writing = new WritingToFileSerialize<RestaurantInformation>();
                writing.Write(restaurantInformation, ConfigurationManager.AppSettings["FileName"]);
                WriteToDbDrinkInfo<Drink> write = new WriteToDbDrinkInfo<Drink>();
                write.Write(drinkInfo);
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
            List<RestaurantInformationAverage> restaurantList = mostVisitedList.GetMostVisitedList(cmbMostVisited.Text, cmdUser.Text, _Username);
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

        private void btnHistory_Click(object sender, EventArgs e)
        {
            HistoryList historyList = new HistoryList();
            List<HistoryInfoSum> list = historyList.GetHistoryList(comboBoxDate.Text);
            int size;
            size = list.Count;
            dataGridHistory.Rows.Clear();
            for (int i = 0; i < size; i++)
            {
                dataGridHistory.Rows.Add(list[i].Category, list[i].SumOfMl);
            }
        }

        private void btnWriteNew_Click(object sender, EventArgs e)
        {
            New news = new New(_Username, textBoxMessage.Text);

            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(news);

                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = client.PostAsync("http://localhost:58376/api/News", httpContent).Result;
            }
            textBoxMessage.Text = "";
        }

        private void btnGetNews_Click(object sender, EventArgs e)
        {
            IList<New> newsList = null;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync("http://localhost:58376/api/News").Result)
            using (HttpContent content = response.Content)
            {
                string result = content.ReadAsStringAsync().Result;

                newsList = JsonConvert.DeserializeObject<IList<New>>(result);
            }
               
            dataGridNews.Rows.Clear();
            
            for(int i=newsList.Count-1; i>=0; i--)
            {
                dataGridNews.Rows.Add(newsList[i].Date, newsList[i].Username, newsList[i].Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Main().Show();
        }

        public int lastSize = 0;
        private void btnTweets_Click(object sender, EventArgs e)
        {
            
            var resp = new ListByTag();
            var res =  resp.GetListByTag(label, lastSize);
            
            var tweetsList = res.ToList();
            dataGridTweets.Rows.Clear();
            var size = tweetsList.Count();

            for (int i = 0; i < size; i++)
            {
                dataGridTweets.Rows.Add(tweetsList[i].CreatedAt, tweetsList[i].Text, tweetsList[i].FavoriteCount);
            }

            lastSize = size;
        }

    }
}