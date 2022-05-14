using Raneen.Data;
using Raneen.Validators;
using Raneen.Validators.Rules;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Raneen.ViewModels
{
    /// <summary>
    /// ViewModel for add contact page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AddressPageViewModel : LoginViewModel
    {
        private List<String> states;

        public List<String> States
        {
            get { return AddressData.states; }
            set { states = value; }
        }

        private List<String> cities;

        public List<String> Cities
        {
            get { return cities; }
            set { cities = value; }
        }


        #region Fields

        private ValidatableObject<string> fname;
        private ValidatableObject<string> lname;
        private ValidatableObject<string> phone;
        private ValidatableObject<string> state;
        private ValidatableObject<string> city;
        private ValidatableObject<string> street;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public AddressPageViewModel()
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

        public ValidatableObject<string> State
        {
            get
            {
                return this.state;
            }

            set
            {
                if (this.state == value)
                {
                    return;
                }
                this.SetProperty(ref this.state, value);
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
        public ValidatableObject<string> City
        {
            get
            {
                return this.city;
            }

            set
            {
                if (this.city == value)
                {
                    return;
                }

                this.SetProperty(ref this.city, value);
            }
        }

        public ValidatableObject<string> Street
        {
            get
            {
                return this.street;
            }

            set
            {
                if (this.street == value)
                {
                    return;
                }

                this.SetProperty(ref this.street, value);
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
            bool isCityValid = this.City.Validate();
            bool isfNameValid = this.fName.Validate();
            bool issNameValid = this.sName.Validate();
            bool isPhoneValid = this.Phone.Validate();
            bool isStateValid = this.State.Validate();
            bool isStreetValid = this.Street.Validate();
            return isCityValid && isfNameValid && issNameValid && isStateValid && isStreetValid && isPhoneValid;
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.fName = new ValidatableObject<string>();
            this.sName = new ValidatableObject<string>();
            this.Street = new ValidatableObject<string>();
            this.State = new ValidatableObject<string>();
            this.Phone = new ValidatableObject<string>();
            this.City = new ValidatableObject<string>();
        }

        /// <summary>
        /// this method contains the validation rules
        /// </summary>
        private void AddValidationRules()
        {
            this.fName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name Required" });
            this.sName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Second Name Required" });
            this.Street.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Street Required" });
            this.Phone.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phone Required" });
            this.State.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "State Required" });
            this.City.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "City Required" });
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
