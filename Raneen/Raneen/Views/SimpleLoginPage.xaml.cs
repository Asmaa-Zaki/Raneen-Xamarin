using Raneen.Models;
using Raneen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Raneen.Views
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleLoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoginPage" /> class.
        /// </summary>
        public SimpleLoginPage()
        {
            this.InitializeComponent();
        }

        private void SignUp(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SimpleSignUpPage());
        }

        private void LoginFaceBook(object sender, System.EventArgs e)
        {

        }

        private  async void SignIn(object sender, System.EventArgs e)
        {
            if (PasswordEntry.Text == String.Empty || EmailEntry.Text == String.Empty ||
                PasswordEntry.Text == null || EmailEntry.Text == null)
            {
                await DisplayAlert("Error", "Complete data", "OK");
            }
            else
            {
                var u = await User.getAllUsers();
                List<UserModel> users = u.ToList();
                int flag = 0;
                foreach (var user in users)
                {
                    if (user.Email == EmailEntry.Text)
                    {
                        flag = 1;
                       if(user.Password == PasswordEntry.Text)
                        {
                            Application.Current.Properties["Fname"] = user.FirstName;
                            Application.Current.Properties["Lname"] = user.LastName;
                            Application.Current.Properties["Email"] = EmailEntry.Text;
                            App.Current.MainPage = new AppShell();
                        }
                       else
                        {
                            await DisplayAlert("Password Problem", "Password is wrong, Try Again!", "Ok");
                        }
                    }
                }
                if (flag == 0)
                {
                   await DisplayAlert("Login Problem", "U R Not signed, Sign Up First!", "Ok");
                }
              
            }
        }
    }
}