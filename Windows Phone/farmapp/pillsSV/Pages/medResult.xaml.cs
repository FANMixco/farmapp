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

namespace pillsSV.pages
{
    public partial class medResult : PhoneApplicationPage
    {
        private UserInfo data = new UserInfo();
        private manageProfile _profile = new manageProfile();
        private cnnStatus cnnstatus = new cnnStatus();
        public medResult()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string id = NavigationContext.QueryString["id"];

            _profile.getStatus();

            data = _profile.getUserInfo();

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

                    string query = "SELECT drugstores.iddrugstore, name, address, rating, latitude, longitude FROM drugstores INNER JOIN medDrug ON drugstores.iddrugstore = medDrug.iddrugstore WHERE medDrug.idmedicine=" + id;
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
            GetSinglePositionAsync();
        }

        public async void GetSinglePositionAsync()
        {
            if (cnnstatus.status())
            {
                Windows.Devices.Geolocation.Geolocator geolocator = null;
                Windows.Devices.Geolocation.Geoposition geoposition = null;

                try
                {

                    geolocator = new Windows.Devices.Geolocation.Geolocator();

                    geoposition = await geolocator.GetGeopositionAsync();

                    ShareStatusTask shareStatusTask = new ShareStatusTask();

                    shareStatusTask.Status = "@Defensoria_910 #Abuso " + txtName.Text + " http://bing.com/maps/?cp=" + Math.Round(geoposition.Coordinate.Latitude, 5).ToString() + "~" + Math.Round(geoposition.Coordinate.Longitude, 5).ToString() + "&lvl=16&sp=point." + Math.Round(geoposition.Coordinate.Latitude, 5).ToString() + "_" + Math.Round(geoposition.Coordinate.Longitude, 5).ToString() + "_";

                    shareStatusTask.Show();
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
    }
}