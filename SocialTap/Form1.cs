using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;                  
using Emgu.CV.CvEnum;           
using Emgu.CV.Structure;        
using Emgu.CV.UI;               

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
           drChosenFile = openFileDialog1.ShowDialog();

            Mat image;

            try
            {
                image = new Mat(openFileDialog1.FileName);
            }
            catch(Exception exp)
            {
                errorMessage.Text = "Wrong image format";
                image = null;
            }
            imageBox.Image = image;


        }
    }
}
