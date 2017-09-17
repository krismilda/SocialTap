using System;
using System.Windows.Forms;
using Emgu.CV;


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


        }
    }
}
