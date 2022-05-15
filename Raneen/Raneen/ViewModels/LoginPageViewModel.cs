using FacebookLogin.Models;
using Newtonsoft.Json;
using Plugin.FacebookClient;
using Raneen.Models;
using Raneen.Services;
using Raneen.Validators;
using Raneen.Validators.Rules;
using Raneen.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Raneen.ViewModels
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        #region Fields

        private ValidatableObject<string> password;
        private ValidatableObject<string> email;

        private IFacebookClient facebookClient;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);
            this.facebookClient = CrossFacebookClient.Current;
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public ValidatableObject<string> Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.SetProperty(ref this.password, value);
            }
        }

        public ValidatableObject<string> Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if(this.email == value)
                {
                    return;
                }
                this.SetProperty(ref this.email, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Check the password is null or empty
        /// </summary>
        /// <returns>Returns the fields are valid or not</returns>
        public bool AreFieldsValid()
        {
            bool isEmailValid = this.Email.Validate();
            bool isPasswordValid = this.Password.Validate();
            return isEmailValid && isPasswordValid;
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.Password = new ValidatableObject<string>();
            this.Email = new ValidatableObject<string>();
        }

        /// <summary>
        /// Validation rule for password
        /// </summary>
        private void AddValidationRules()
        {
            this.Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            this.Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
        }

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            if (this.AreFieldsValid())
            {
                // Do Something
            }
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            // Do Something
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ForgotPasswordClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void SocialLoggedIn(object obj)
        {
            // Do something
            Debug.WriteLine("HERE!!");
            try
            {
                if (facebookClient.IsLoggedIn)
                {
                    facebookClient.Logout();
                }

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    if (e == null) return;

                    switch (e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            try
                            {

                                Debug.WriteLine("Data:" + e.Data);
                                Debug.WriteLine("Message:" + e.Message);

                                var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                                Console.WriteLine(facebookProfile.email);
                                //Preferences.Set("userEmail", facebookProfile.email);
                                //Application.Current.Properties.Add("userLogin", facebookProfile);
                                await App.Current.MainPage.Navigation.PushModalAsync(new CategoryPage());


                                Application.Current.Properties["Fname"] = facebookProfile.first_name;
                                Application.Current.Properties["Lname"] = facebookProfile.last_name;
                                Application.Current.Properties["Email"] = facebookProfile.email;

                               var u =  await User.getAllUsers();
                                List<UserModel> users = u.ToList();
                                int flag = 0;
                                foreach (var user in users)
                                {
                                    if (user.Email == facebookProfile.email)
                                        flag = 1;
                                }
                                if (flag == 0)
                                {
                                    await User.AddUser(facebookProfile.first_name, facebookProfile.last_name, 
                                        facebookProfile.email, "", "");
                                }
                             
                            }
                            catch (Exception ex)
                            {

                                Debug.WriteLine("Exception: " + ex);
                            }
                            break;
                        case FacebookActionStatus.Canceled:
                            Debug.WriteLine("Facebook Auth canceled");
                            break;
                    }

                    //Xamarin essential shared pref

                    facebookClient.OnUserData -= userDataDelegate;
                };

                facebookClient.OnUserData += userDataDelegate;

                string[] fbRequestFields = { "email", "first_name", "birthday", "last_name" };
                string[] fbPermisions = { "email" };
                FacebookResponse<string> faceResponse = await facebookClient.RequestUserDataAsync(fbRequestFields, fbPermisions);

                Debug.WriteLine("FaceResponse: " + faceResponse.Data + "||" + faceResponse.Status + "||" + faceResponse.Message);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        #endregion
    }
}