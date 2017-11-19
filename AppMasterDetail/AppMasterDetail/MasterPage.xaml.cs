using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();

            buttonA.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new RegisterPage());

            };

            buttonB.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new LoginPage());
            };

            buttonScan.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new ScanPage());

            };
        }
    }
}