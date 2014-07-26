using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Live;
using System.Windows.Media.Imaging;
using pillsSV.Classes;
using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using sqlite.Classes;

namespace pillsSV.pages
{
    public partial class profile : PhoneApplicationPage
    {
        private LiveAuthClient auth;
        private UserInfo data = new UserInfo();
        private manageProfile _profile = new manageProfile();
        private cnnStatus cnnstatus = new cnnStatus();
        public profile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btnSignIn.Content.ToString() == "ingresar")
            {
                login(true);
                updateInfo();
            }
            else
                logout();
        }

        private void updateInfo()
        {
            if (cnnstatus.status())
            {
                WebClient w = new WebClient();

                Observable
                .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                .Subscribe(r =>
                {
                    var deserialized = JsonConvert.DeserializeObject<List<result>>(r.EventArgs.Result);

                    switch (deserialized[0].total)
                    {
                        case "0":
                            Console.Write("Error en el registro.");
                            break;
                        case "2":
                            MessageBox.Show("Intente de nuevo", "Error", MessageBoxButton.OK);
                            break;
                        default:
                            data.email = emailText.Text;
                            data.name = infoText.Text;
                            data.iduser = deserialized[0].total;
                            _profile.updateProfile(data);
                            break;
                    }
                });
                w.DownloadStringAsync(
                new Uri("http://register.php?name=" + infoText.Text + "&email=" + emailText.Text));
            }
            else
                MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
        }

        private void logout()
        {
            try
            {
                this.auth.Logout();
                stpInfo.Visibility = Visibility.Collapsed;
                profileImage.Source = null;
                btnSignIn.Content = "ingresar";

                data.iduser = "";
                data.name = "";
                data.email = "";

                _profile.updateProfile(data);
            }
            catch
            {
                lblErr.Text = "Intente otro momento";
            }
        }

        private async void btnSync_Click(object sender, RoutedEventArgs e)
        {
            if (btnSync.IsChecked == false)
            {
                dbSQLite cn = new dbSQLite();

                bool checkExist = await cn.FileExists();

                if (!checkExist)
                {
                    try
                    {
                        createDB cDB = new createDB();
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                    }
                }
            }

            newUpdateDate();
        }

        private void newUpdateDate()
        {
            data.updateFrequency = (int)daysNumber.Value;
            data.nextUpdate = data.lastUpdate.AddDays(daysNumber.Value);
            data.name = "";
            data.email = "";
            data.offlineData = (bool)btnDataOffline.IsChecked;
            data.autoUpdate = (bool)btnSync.IsChecked;

            _profile.updateProfile(data);
        }

        private void RadNumericUpDown_LostFocus(object sender, RoutedEventArgs e)
        {
            newUpdateDate();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            _profile.getStatus();

            data = _profile.getUserInfo();

            login(false);
        }

        private async void login(bool previous)
        {
            if (cnnstatus.status())
            {
                lblErr.Text = "";
                try
                {
                    auth = new LiveAuthClient("000000004011A732");
                    LiveLoginResult result = await auth.InitializeAsync(new string[] { "wl.basic", "wl.offline_access", "wl.signin", "wl.emails" });

                    if (previous == true)
                        if (result.Status != LiveConnectSessionStatus.Connected)
                            result = await auth.LoginAsync(new string[] { "wl.basic", "wl.offline_access", "wl.signin", "wl.emails" });

                    if (result.Status == LiveConnectSessionStatus.Connected)
                    {
                        var connect = new LiveConnectClient(auth.Session);
                        var opResult = await connect.GetAsync("me");
                        dynamic nameResult = opResult.Result;
                        var email = nameResult.emails;

                        this.infoText.Text = nameResult.name;
                        this.emailText.Text = email.preferred;

                        var photoResult = await connect.GetAsync("me/picture");
                        dynamic photoResultdyn = photoResult.Result;
                        var image = new BitmapImage(new Uri(photoResultdyn.location, UriKind.Absolute));
                        this.profileImage.Source = image;

                        stpInfo.Visibility = Visibility.Visible;
                        btnSignIn.Content = "salir";

                    }
                    else
                        this.lblErr.Text = "Intenta otro momento";

                }
                catch (LiveAuthException exc)
                {
                    this.lblErr.Text = "Error: " + exc.Message;
                }
                catch (LiveConnectException connExc)
                {
                    this.lblErr.Text = "Error making request: " + connExc.Message;
                }
                finally
                {
                    bar.Visibility = Visibility.Collapsed;
                    btnSignIn.IsEnabled = true;
                }
            }
            else
                MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
        }

        private void btnDataOffline_Click(object sender, RoutedEventArgs e)
        {
            btnSync.IsEnabled = !(bool)btnDataOffline.IsChecked;
            daysNumber.IsEnabled = !(bool)btnDataOffline.IsChecked;

            newUpdateDate();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            updateData uData = new updateData();

            bool resultData = await uData.checkData();

            if (resultData)
                uData.updateInfo(data.lastUpdate);

            data.lastUpdate = DateTime.Now;
            data.nextUpdate = DateTime.Now.AddDays(15);

            _profile.updateProfile(data);

        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/about.xaml", UriKind.Relative));
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/help.xaml", UriKind.Relative));

        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pivot = ((Pivot)sender).SelectedIndex;

            createAppBar(pivot);
        }

        private void createAppBar(int pivot)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarMenuItem[] AppMenu = new ApplicationBarMenuItem[2];

            for (int i = 0; i < 2; i++)
            {
                AppMenu[i] = new ApplicationBarMenuItem();

                switch (i)
                {
                    case 0:
                        AppMenu[i].Text = "ayuda";
                        AppMenu[i].Click += new EventHandler(menuHelp_Click);
                        break;
                    case 1:
                        AppMenu[i].Text = "acerca de";
                        AppMenu[i].Click += new EventHandler(menuAbout_Click);
                        break;
                }

                ApplicationBar.MenuItems.Add(AppMenu[i]);
            }

            if (pivot == 1)
            {
                ApplicationBarIconButton[] AppButtons = new ApplicationBarIconButton[1];

                AppButtons[0] = new ApplicationBarIconButton();

                AppButtons[0].IconUri = new Uri("/Assets/AppBar/download.png", UriKind.Relative);
                AppButtons[0].Text = "actualizar";
                AppButtons[0].Click += new EventHandler(btnUpdate_Click);

                ApplicationBar.Buttons.Add(AppButtons[0]);

            }
            else
                ApplicationBar.Mode = ApplicationBarMode.Minimized;
        }
    }
}