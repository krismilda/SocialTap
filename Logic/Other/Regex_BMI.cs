using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

namespace Services.BMIregex
{
    public class Regex_BMI
    {
        public void RegexValidation(String re, ComboBox cb, Label lbl, string s)
        {
            Regex regex = new Regex(re);

            if (regex.IsMatch(cb.Text))
            {
                lbl.Text = "";
            }
            else
            {

                lbl.ForeColor = Color.Red;
                lbl.Text = s + " InValid";
            }

        }

    }
}
