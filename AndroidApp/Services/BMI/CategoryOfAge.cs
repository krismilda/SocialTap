using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp.Services.BMI
{
    public class CategoryOfAge
    {
        int category = 22;
        public int GetCategoryOfAge(int age)
        {
            if (age >= 19 && age < 24)
                category += 1;

            else if (age >= 25 && age < 34)
                category += 2;

            else if (age >= 35 && age < 44)
                category += 3;

            else if (age >= 45 && age < 54)
                category += 4;

            else if (age >= 55 && age < 64)
                category += 5;

            else if (age >= 64)
                category += 6;

            return category;
        }
    }
}