﻿using System;
using ClickDummy.Shared.Helpers;
using ClickDummy.Shared.Models;
using ClickDummy.Shared.Services;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClickDummy.Shared.Views.Login
{
    public sealed partial class LoginStatus : UserControl
    {
        private string _welcomeText;

        public LoginStatus()
        {
            this.InitializeComponent();
            AuthenticationService.Instance.LoggedIn += Instance_LoggedIn;
            AuthenticationService.Instance.LoggedOut += Instance_LoggedOut;
            var resourceLoader = ResourceLoader.GetForCurrentView();
            _welcomeText = resourceLoader.GetString("WelcomeText");
            this.UpdateLoginState();
        }

        private void Instance_LoggedOut(object sender, EventArgs e)
        {
            this.UpdateLoginState();
        }

        private void Instance_LoggedIn(object sender, EventArgs e)
        {
            this.UpdateLoginState();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginForm = new LoginForm();
            _ = loginForm.ShowOneAtATimeAsync();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationService.Instance.Logout();
        }

        private void UpdateLoginState()
        {
            if (AuthenticationService.Instance.CurrentPrincipal != null && AuthenticationService.Instance.CurrentPrincipal.Identity.IsAuthenticated)
            {
                VisualStateManager.GoToState(this, "loggedIn", true);
                welcomeText.Text = string.Format(
                    _welcomeText, 
                    ((User)AuthenticationService.Instance.CurrentPrincipal.Identity).FriendlyName);
            }
            else
            {
                VisualStateManager.GoToState(this, "loggedOut", true);
                welcomeText.Text = string.Empty;
            }
        }
    }
}
