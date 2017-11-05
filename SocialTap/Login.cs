using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Web.Security;

namespace SocialTap
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginError.Text = "";
            Boolean loginValidation = Membership.ValidateUser(textUsername.Text, textPassword.Text);
            if (loginValidation)
            {
                new MainForm(textUsername.Text).Show();
                this.Close();
            }

            else
            {
                loginError.Text = "Wrong username or password";
                loginError.ForeColor = Color.Red;
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new Registration().Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Close();
        }
    }
}
