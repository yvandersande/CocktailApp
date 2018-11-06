using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CocktailApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            btnRegister.Clicked += delegate
            {
                Navigation.PushAsync(new RegisterPage());
            };

            btnLogin.Clicked += delegate
            {
                if (loginUsername.Text != null && loginPassword.Text != null)
                {
                    Boolean saved = Controllers.UsersController.LoginUser(loginUsername.Text, loginPassword.Text);

                    if (saved)
                    {
                        Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        DisplayAlert("Failed", "Wrong username and password combination", "OK");
                    }
                }
            };
        }
    }
}
