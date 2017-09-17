using System;
using System.Windows.Forms;
using Emgu.CV;
using System.Drawing;
using social_tap;

namespace SocialTap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult drChosenFile;
            drChosenFile = openFileDialog.ShowDialog();
            Mat image;

            try
            {
                image = new Mat(openFileDialog.FileName);
            }
            catch (Exception exp)
            {
                errorMessage.Text = "Wrong image format";
                image = null;
            }

            imageBox.Image = image;
            Bitmap bitmap = new Bitmap(image.Bitmap);
            SimpleImageAnalysis imageInformation = new SimpleImageAnalysis(bitmap);
            int percentageOfLiquid = imageInformation.CalculatePercentageOfLiquid();
            lblPercentage.Text = percentageOfLiquid.ToString();

        }
    }
}
