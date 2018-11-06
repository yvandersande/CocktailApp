using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CocktailApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        public RegisterPage()
        {
            InitializeComponent();
            btnSaveUser.Clicked += BtnSaveUser_Clicked;
        }

        private void BtnSaveUser_Clicked(object sender, EventArgs e)
        {
            if (registerUsername.Text != null && registerFullName.Text != null && registerPassword.Text != null && registerDateOfBirth.Date != null)
            {
                Models.User user = new Models.User()
                {
                    Username = registerUsername.Text,
                    FullName = registerFullName.Text,
                    Password = registerPassword.Text,
                    DayOfBirth = registerDateOfBirth.Date
                };

                Boolean saved = Controllers.UsersController.SaveUser(user);

                if (saved)
                {
                    DisplayAlert("Success", "You have been registered", "OK");
                    Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    DisplayAlert("Failed", "Username has already been taken", "OK");
                }
            }
        }
    }
}