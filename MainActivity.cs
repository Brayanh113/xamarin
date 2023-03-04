using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Google.Android.Material.BottomNavigation;



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

        //PQR
        Button btnSend;
        EditText txtFullName;
        EditText txtPhone;
        EditText txtId;
        EditText txtQuestion;
        Spinner spinnerPqr;


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
        EditText txtSUEmail;

        //Forgor password

        EditText txtFUserName;
        EditText txtFEmail;
        EditText txtFCEmail;
        Button btnFSend;

        Button btnForgot;

        Button btnFBack;


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

            //Forgot paswword
            btnForgot = FindViewById<Button>(Resource.Id.btnForgot);
            btnForgot.Click += forgotPassword;


        }
        private void forgotPassword(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.forgotPass);
            //Bact to main
            btnFBack = FindViewById<Button>(Resource.Id.btnFBack);
            btnFBack.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            btnFSend = FindViewById<Button>(Resource.Id.btnFSend);
            btnFSend.Click += ForgotBtnFSend;

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
                menu();
            }

        }

        private void menu()
        {
            BottomNavigationView navigationMenu = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigationMenu.NavigationItemSelected += (sender, e) =>
            {


                switch (e.Item.ItemId)
                {
                    case Resource.Id.idPQR:
                        pqr();
                        break;

                    case Resource.Id.home:
                        welcome();
                        break;

                    case Resource.Id.exitId:
                        exit();
                        break;

                }
            };

        }

        private void welcome()
        {
            SetContentView(Resource.Layout.welcome);
            menu();
        }

        private void pqr()
        {
            SetContentView(Resource.Layout.pqr);
            menu();
            btnSend = FindViewById<Button>(Resource.Id.btnSend);
            btnSend.Click += (sender, e) =>
            {

                txtFullName = FindViewById<EditText>(Resource.Id.txtFullName);
                txtId = FindViewById<EditText>(Resource.Id.txtId);
                txtPhone = FindViewById<EditText>(Resource.Id.txtPhone);
                txtQuestion = FindViewById<EditText>(Resource.Id.txtQuestion);
                spinnerPqr = FindViewById<Spinner>(Resource.Id.spinnerPqr);

                if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtQuestion.Text) || spinnerPqr.SelectedItem.ToString() == "Seleccione")
                {
                    ShowAlertDialog("Error", "Please complete all fields", "OK");
                }
                else
                {
                    txtFullName.Text = "";
                    txtId.Text = "";
                    txtPhone.Text = "";
                    txtQuestion.Text = "";
                    //spinnerPqr.SelectedItemPosition = -1;
                    ShowAlertDialog("Success", "PQR sent Successfully", "OK");

                }

            };
                
        }
        private void exit()
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }



        private void ForgotBtnFSend(object sender, EventArgs e)
        {
            
            txtFCEmail = FindViewById<EditText>(Resource.Id.txtFCEmail);
            txtFEmail = FindViewById<EditText>(Resource.Id.txtFEmail);
            txtFUserName = FindViewById<EditText>(Resource.Id.txtFUserName);

            if (string.IsNullOrEmpty(txtFUserName.Text) || string.IsNullOrEmpty(txtFCEmail.Text) || string.IsNullOrEmpty(txtFEmail.Text))
            {
                ShowAlertDialog("Error", "Please enter a valid user data", "OK");
            }
            else
            {
                if (txtFCEmail.Text == txtFEmail.Text)
                {
                    Intent intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    ShowAlertDialog("Success", "Password sent your email", "OK");
                }
                else
                {
                    ShowAlertDialog("Error", "Passwords do not match", "OK");
                }
            }
            
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
            txtSUEmail = FindViewById<EditText>(Resource.Id.txtSUEmail);

            if (string.IsNullOrEmpty(txtSUSuerName.Text))
            {
                ShowAlertDialog("Error", "Please enter a valid user name", "OK");
            }
            else if(string.IsNullOrEmpty(txtSUEmail.Text))
            {
                ShowAlertDialog("Error", "Please enter a valid user email", "OK");
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