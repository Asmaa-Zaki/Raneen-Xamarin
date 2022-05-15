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
    }
}