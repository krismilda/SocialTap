namespace SocialTapApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new SocialTapApp.App());
        }
    }
}