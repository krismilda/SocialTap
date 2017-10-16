using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace SocialTap
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                MembershipUser user;
                user = Membership.CreateUser(textBoxUsername.Text, textBoxPassword.Text);
                MessageBox.Show(textBoxUsername.Text + " is created successfully");
                this.Dispose();
                this.Close();
            }
            catch (MembershipCreateUserException)
            {
                
                errorRegistration.Text = "Username or password format is wrong";
                errorRegistration.ForeColor = Color.Red;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
