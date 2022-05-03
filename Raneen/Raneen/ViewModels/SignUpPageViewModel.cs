using Raneen.Validators;
using Raneen.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Raneen.ViewModels
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        #region Fields

        private ValidatableObject<string> fname;
        private ValidatableObject<string> lname;
        private ValidatableObject<string> email;
        private ValidatableObject<string> phone;
        private ValidatableObject<string> password;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
        }
        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public ValidatableObject<string> fName
        {
            get
            {
                return this.fname;
            }

            set
            {
                if (this.fname == value)
                {
                    return;
                }

                this.SetProperty(ref this.fname, value);
            }
        }

        public ValidatableObject<string> sName
        {
            get
            {
                return this.lname;
            }

            set
            {
                if (this.lname == value)
                {
                    return;
                }

                this.SetProperty(ref this.lname, value);
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
                if (this.email == value)
                {
                    return;
                }
                this.SetProperty(ref this.email, value);
            }
        }

        public ValidatableObject<string> Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                if (this.phone == value)
                {
                    return;
                }
                this.SetProperty(ref this.phone, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
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
        #endregion

        #region Methods

        /// <summary>
        /// Initialize whether fieldsvalue are true or false.
        /// </summary>
        /// <returns>true or false </returns>
        public bool AreFieldsValid()
        {
            bool isEmailValid = this.Email.Validate();
            bool isfNameValid = this.fName.Validate();
            bool issNameValid = this.sName.Validate();
            bool isPhoneValid = this.Phone.Validate();
            bool isPasswordValid = this.Password.Validate();
            return isPasswordValid && isfNameValid && issNameValid && isEmailValid && isPhoneValid;
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.fName = new ValidatableObject<string>();
            this.sName = new ValidatableObject<string>();
            this.Password = new ValidatableObject<string>();
            this.Email = new ValidatableObject<string>();
            this.Phone = new ValidatableObject<string>();
        }

        /// <summary>
        /// this method contains the validation rules
        /// </summary>
        private void AddValidationRules()
        {
            this.fName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name Required" });
            this.sName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Second Name Required" });
            this.Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            this.Phone.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phone Required" });
            this.Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
        }

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            // Do something
               
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            if (this.AreFieldsValid())
            {
                // Do something
            }
        }

        #endregion
    }
}