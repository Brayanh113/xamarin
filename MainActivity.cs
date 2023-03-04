using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Google.Android.Material.BottomNavigation;
using Android.Views;



namespace Entrega
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        //menu
        BottomNavigationView navigationMenu;

        // Button of main
        Button signUpButton;
        Button loginButton;

        // Button of sign up
        Button btnBack;
        Button btnSUSignUp;

        //text login
        EditText txtPassword;
        EditText txtUserName;

        // text sign up
        EditText txtSUSuerName;
        EditText txtSUPassword;
        EditText txtSUCPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Sign up
            signUpButton = FindViewById<Button>(Resource.Id.btnSignUp);
            signUpButton.Click += SignUpLayout;

            //Validate login form
            loginButton = FindViewById<Button>(Resource.Id.btnLogin);
            loginButton.Click += LoginLayout;
        }
        private void LoginLayout(object sender, EventArgs e)
        {
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtUserName = FindViewById<EditText>(Resource.Id.txtUserName);
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowAlertDialog("Error", "Please enter a valid user name and password", "OK");
            }
            else
            {
                SetContentView(Resource.Layout.welcome);
                BottomNavigationView navigationMenu = FindViewById<BottomNavigationView>(Resource.Id.navigation);
                navigationMenu.NavigationItemSelected += (sender, e) =>
                {

                    
                    switch (e.Item.ItemId)
                    {
                        case Resource.Id.idPQR:
                            // El elemento de inicio ha sido seleccionado
                            pqr();
                            break;

                        case Resource.Id.navigation_dashboard:
                            // El elemento de dashboard ha sido seleccionado
                            break;

                    }
                };


            }

        }
        private void pqr()
        {
            SetContentView(Resource.Layout.pqr);
        }


        //Inflar el menu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.navigation, menu);
            return true;
        }



        private void SignUpLayout(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.signUp);

            //Bact to main
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            //Validate Sign up form
            btnSUSignUp = FindViewById<Button>(Resource.Id.btnSUSignUp);
            btnSUSignUp.Click += ValidateSignUp;
        }

        private void ValidateSignUp(object sender, EventArgs e)
        {
            txtSUSuerName = FindViewById<EditText>(Resource.Id.txtSUSuerName);
            txtSUPassword = FindViewById<EditText>(Resource.Id.txtSUPassword);
            txtSUCPassword = FindViewById<EditText>(Resource.Id.txtSUCPassword);

            if (string.IsNullOrEmpty(txtSUSuerName.Text))
            {
                ShowAlertDialog("Error", "Please enter a valid user name", "OK");
            }
            else if (string.IsNullOrEmpty(txtSUPassword.Text))
            {
                ShowAlertDialog("Error", "Please enter a valid password", "OK");
            }
            else if (string.IsNullOrEmpty(txtSUCPassword.Text))
            {
                ShowAlertDialog("Error", "Please enter a valid confirm password", "OK");
            }
            else
            {
                string passwordOne = txtSUCPassword.Text;
                string passwordTwo = txtSUPassword.Text;

                if (passwordOne == passwordTwo)
                {
                    Intent intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    ShowAlertDialog("Success", "Registered Successfully", "OK");
                    
                }
                else
                {
                    ShowAlertDialog("Error", "Passwords do not match", "OK");
                }

            }
        }

        private void ShowAlertDialog(string title, string message, string positiveButtonText)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            builder.SetTitle(title);
            builder.SetMessage(message);
            builder.SetPositiveButton(positiveButtonText, (s, e) => { });
            builder.Show();
        }




        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }

}