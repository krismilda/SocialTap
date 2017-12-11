using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        Button btnLoginForm;
        EditText InputEmailLoginForm;
        EditText InputPasswordLoginForm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            btnLoginForm = FindViewById<Button>(Resource.Id.btnLoginForm);
            InputEmailLoginForm = FindViewById<EditText>(Resource.Id.inputEmailLoginForm);
            InputPasswordLoginForm = FindViewById<EditText>(Resource.Id.inputPasswordLoginForm);
            
            btnLoginForm.Click += BtnLogin_Click;
        }
        void BtnLogin_Click(object sender, System.EventArgs e)
        {
            DataService.Login(InputEmailLoginForm.Text, InputPasswordLoginForm.Text);
        }
    }
}