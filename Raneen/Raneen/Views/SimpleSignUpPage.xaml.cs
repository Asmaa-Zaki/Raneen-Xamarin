using Raneen.Models;
using Raneen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Raneen.Views
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleSignUpPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleSignUpPage" /> class.
        /// </summary>
        public SimpleSignUpPage()
        {
            this.InitializeComponent();
        }

        private void SignIn(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SimpleLoginPage());
        }

        private async void SignUp(object sender, System.EventArgs e)
        {
            if (FirstNameEntry.Text == String.Empty || SecondNameEntry.Text == String.Empty || PhoneEntry.Text == String.Empty ||
                PasswordEntry.Text == String.Empty || EmailEntry.Text == String.Empty ||
                FirstNameEntry.Text == null || SecondNameEntry.Text == null ||
                PhoneEntry.Text == null ||
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
                        flag = 1;
                }
                if (flag == 0)
                {
                    string FirstName = FirstNameEntry.Text;
                    string LastName = SecondNameEntry.Text;
                    string Phone = PhoneEntry.Text;
                    string Email = EmailEntry.Text;
                    string Password = PasswordEntry.Text;

                    await User.AddUser(FirstName, LastName, Email, Phone, Password);

                    Application.Current.Properties["Fname"] = FirstName;
                    Application.Current.Properties["Lname"] = LastName;
                    Application.Current.Properties["Email"] = Email;


                    App.Current.MainPage = new AppShell();

                }

            }
        }
    }
}