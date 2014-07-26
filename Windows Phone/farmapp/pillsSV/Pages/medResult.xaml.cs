using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using pillsSV.Classes;
using sqlite.Classes;
using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Maps.Controls;

namespace pillsSV.pages
{
    public partial class medResult : PhoneApplicationPage
    {
        createMap cm;
        private UserInfo data = new UserInfo();
        private manageProfile _profile = new manageProfile();
        private cnnStatus cnnstatus = new cnnStatus();
        public medResult()
        {
            InitializeComponent();
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "5b810a60-9962-4e48-a3c0-2f41a27a7961";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "lPWk0ZKoahL1w2CbtCGKDw";

            _profile.getStatus();

            data = _profile.getUserInfo();

            cm = new createMap(mapResult);
            cm.setCenter(13.794185, -88.89653, 8);

            GetSinglePositionAsync(false);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string id = NavigationContext.QueryString["id"];

            List<med_medicine> medicine;

            if (data.offlineData)
            {
                try
                {
                    dbSQLite cn = new dbSQLite();
                    cn.open();

                    string query = "SELECT * FROM med_medicine WHERE idmedicine=" + id;
                    medicine = cn.db.Query<med_medicine>(query);

                    if (medicine.Count > 0)
                    {
                        txtName.Text = medicine[0].name;
                        txtConcentration.Text = medicine[0].concentration;
                        txtUnits.Text = medicine[0].units;
                        txtPrice.Text = medicine[0].price;
                        txtCat.Text = medicine[0].cat;
                        setDrugstores(id);
                    }
                    cn.close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            else
            {
                if (cnnstatus.status())
                {
                    WebClient w = new WebClient();

                    Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        medicine = JsonConvert.DeserializeObject<List<med_medicine>>(r.EventArgs.Result);

                        if (medicine.Count > 0)
                        {
                            txtName.Text = medicine[0].name;
                            txtConcentration.Text = medicine[0].concentration;
                            txtUnits.Text = medicine[0].units;
                            txtPrice.Text = medicine[0].price;
                            txtCat.Text = medicine[0].cat;
                            setDrugstores(id);
                        }
                    });
                    w.DownloadStringAsync(
                    new Uri("http://getFMedicine.php?id=" + id));
                }
                else
                    MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
            }
        }

        private void setDrugstores(string id)
        {
            List<drugstores> drugstore;

            if (data.offlineData)
            {
                try
                {
                    dbSQLite cn = new dbSQLite();
                    cn.open();

                    string query = @"SELECT drugstores.iddrugstore, drugstores.name,
                                    (address || ', ' || cities.name || ', ' || states.name) address, rating, latitude, longitude
                                    FROM drugstores
                                    INNER JOIN medDrug ON drugstores.iddrugstore = medDrug.iddrugstore
                                    INNER JOIN cities ON cities.idcity=drugstores.idcity
                                    INNER JOIN states ON states.idstate=cities.idstate
                                    WHERE medDrug.idmedicine=" + id;
                    drugstore = cn.db.Query<drugstores>(query);

                    if (drugstore.Count > 0)
                        llsResultsDS.ItemsSource = drugstore;

                    cn.close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }
            else
            {
                if (cnnstatus.status())
                {
                    WebClient w = new WebClient();

                    Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        drugstore = JsonConvert.DeserializeObject<List<drugstores>>(r.EventArgs.Result);

                        if (drugstore.Count > 0)
                            llsResultsDS.ItemsSource = drugstore;
                    });
                    w.DownloadStringAsync(
                    new Uri("http://getSDrugMed.php?id=" + id));
                }
                else
                    MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
            }
        }

        private void llsResultsDS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                drugstores p = item.SelectedItem as drugstores;

                string url = "/Pages/drugResult.xaml?id=" + p.iddrugstore.ToString() + "&lat=" + p.latitude.ToString() + "&lng=" + p.longitude.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }
        }

        private void menuProfile_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/profile.xaml", UriKind.Relative));
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/help.xaml", UriKind.Relative));
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/about.xaml", UriKind.Relative));
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/shareOptions.xaml", UriKind.Relative));
        }

        private void menuReport_Click(object sender, EventArgs e)
        {
            GetSinglePositionAsync(true);
        }

        public async void GetSinglePositionAsync(bool report)
        {
            if (cnnstatus.status())
            {
                Windows.Devices.Geolocation.Geolocator geolocator = null;
                Windows.Devices.Geolocation.Geoposition geoposition = null;

                try
                {

                    geolocator = new Windows.Devices.Geolocation.Geolocator();

                    geoposition = await geolocator.GetGeopositionAsync();

                    if (report)
                    {
                        ShareStatusTask shareStatusTask = new ShareStatusTask();

                        shareStatusTask.Status = "@Defensoria_910 #Abuso " + txtName.Text + " http://bing.com/maps/?cp=" + Math.Round(geoposition.Coordinate.Latitude, 5).ToString() + "~" + Math.Round(geoposition.Coordinate.Longitude, 5).ToString() + "&lvl=16&sp=point." + Math.Round(geoposition.Coordinate.Latitude, 5).ToString() + "_" + Math.Round(geoposition.Coordinate.Longitude, 5).ToString() + "_";

                        shareStatusTask.Show();
                    }
                    else
                    {
                        cm.setCenter(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude, 12);

                        List<Tuple<double, double>> locations = new List<Tuple<double, double>>();
                        locations.Add(new Tuple<double, double>(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude));

                        cm.addPushpins(locations);

                        load_Places(geoposition.Coordinate.Latitude, geoposition.Coordinate.Longitude);
                    }
                }
                catch
                {
                    // Something else happened while acquiring the location.
                    MessageBox.Show("Localización", "Error", MessageBoxButton.OK);
                }
            }
            else
                MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
        }

        private async void load_Places(double lat, double lng)
        {

            if (data.offlineData)
            {
                dbSQLite cn = new dbSQLite();
                cn.open();

                //Load all places
                string query = "SELECT * FROM drugstores";
                List<drugstores> placeInfo = cn.db.Query<drugstores>(query);

                for (int i = 0; i < placeInfo.Count -1; i++)
                {
                    var values = placeInfo[i];
                    List<Tuple<double, double, string, int>> locations = new List<Tuple<double, double, string, int>>();
                    locations.Add(new Tuple<double, double, string, int>(values.latitude, values.longitude, values.name, values.iddrugstore));

                    cm.addMultiplePushpins(locations);
                }
                cn.close();
            }
            else
            {
                if (cnnstatus.status())
                {
                    WebClient w = new WebClient();

                    Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        var drugstore = JsonConvert.DeserializeObject<List<Tuple<double, double, string, int>>>(r.EventArgs.Result);

                        for (int i = 0; i < drugstore.Count - 1; i++)
                        {
                            var values = drugstore[i];
                            List<Tuple<double, double, string, int>> locations = new List<Tuple<double, double, string, int>>();
                            locations.Add(new Tuple<double, double, string, int>(drugstore[i].Item1, drugstore[i].Item2, drugstore[i].Item3, drugstore[i].Item4));

                            cm.addMultiplePushpins(locations);
                        }
                    });
                    w.DownloadStringAsync(
                    new Uri("http://getNearLocations.php?lat=" + lat.ToString() + "&lng=" + lng.ToString()));
                }
            }
        }

        private void createAppBar(int multiple)
        {

            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton[] AppButtons = new ApplicationBarIconButton[multiple];
            
            ApplicationBarMenuItem[] AppMenu = new ApplicationBarMenuItem[4];

            for (int i = 0; i < 4; i++)
            { 
                AppMenu[i] = new ApplicationBarMenuItem();

                switch (i)
                {
                    case 0:
                        AppMenu[i].Text = "reportar...";
                        AppMenu[i].Click += new EventHandler(menuReport_Click);
                        break;
                    case 1:
                        AppMenu[i].Text = "perfil";
                        AppMenu[i].Click += new EventHandler(menuProfile_Click);
                        break;
                    case 2:
                        AppMenu[i].Text = "ayuda";
                        AppMenu[i].Click += new EventHandler(menuHelp_Click);
                        break;
                    case 3:
                        AppMenu[i].Text = "acerca de";
                        AppMenu[i].Click += new EventHandler(menuAbout_Click);
                        break;
                }

                ApplicationBar.MenuItems.Add(AppMenu[i]);
            }

            if (multiple == 1)
            {
                AppButtons[0] = new ApplicationBarIconButton();

                AppButtons[0].IconUri = new Uri("/Assets/AppBar/share.png", UriKind.Relative);
                AppButtons[0].Text = "compartir";
                AppButtons[0].Click += new EventHandler(btnShare_Click);

                ApplicationBar.Buttons.Add(AppButtons[0]);
            }
            else if (multiple > 1)
            {
                AppButtons[0] = new ApplicationBarIconButton();
                AppButtons[1] = new ApplicationBarIconButton();

                AppButtons[0].IconUri = new Uri("/Assets/AppBar/eye.png", UriKind.Relative);
                AppButtons[0].Text = "aerea";
                AppButtons[1].IconUri = new Uri("/Assets/AppBar/road.png", UriKind.Relative);
                AppButtons[1].Text = "carretera";

                AppButtons[0].Click += new EventHandler(road_Click);
                AppButtons[1].Click += new EventHandler(aerial_Click);

                ApplicationBar.Buttons.Add(AppButtons[0]);
                ApplicationBar.Buttons.Add(AppButtons[1]);
            }
            else
                ApplicationBar.Mode = ApplicationBarMode.Minimized;
        }

        private void road_Click(object sender, EventArgs e)
        {
            mapResult.CartographicMode = MapCartographicMode.Road;
        }

        private void aerial_Click(object sender, EventArgs e)
        {
            mapResult.CartographicMode = MapCartographicMode.Aerial;
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((Pivot)sender).SelectedIndex;

            switch(index)
            {
                case 0:
                    createAppBar(1);
                    break;
                case 1:
                    createAppBar(2);
                    break;
                case 2:
                    createAppBar(0);
                    break;
            }
        }
    }
}