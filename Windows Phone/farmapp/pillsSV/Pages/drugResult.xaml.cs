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
using Newtonsoft.Json;
using Microsoft.Phone.Reactive;

namespace pillsSV.pages
{
    public partial class drugResult : PhoneApplicationPage
    {
        private UserInfo data = new UserInfo();
        private manageProfile _profile = new manageProfile();
        private cnnStatus cnnstatus = new cnnStatus();
        public drugResult()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string lat = NavigationContext.QueryString["lat"];
            string lng = NavigationContext.QueryString["lng"];
            string id = NavigationContext.QueryString["id"];

            createMap cm = new createMap(mapLocation);

            if (String.IsNullOrWhiteSpace(lat) && String.IsNullOrWhiteSpace(lng))
            {
                List<Tuple<double, double>> locations = new List<Tuple<double, double>>();
                locations.Add(new Tuple<double, double>(Double.Parse(NavigationContext.QueryString["lat"]), Double.Parse(NavigationContext.QueryString["lng"])));

                cm.addPushpins(locations);
            }

            _profile.getStatus();

            data = _profile.getUserInfo();

            List<drugstores> drugstore;

            if (data.offlineData)
            {
                dbSQLite cn = new dbSQLite();
                cn.open();

                string query = "SELECT * FROM drugstores WHERE iddrugstore=" + id;
                drugstore = cn.db.Query<drugstores>(query);

                if (drugstore.Count > 0)
                {
                    txtName.Text = drugstore[0].name;
                    lblADescription.Text = drugstore[0].description;
                    lblAddress.Text = drugstore[0].address;
                    iRating.Value = drugstore[0].rating;
                    setDrugstores(id);
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
                        drugstore = JsonConvert.DeserializeObject<List<drugstores>>(r.EventArgs.Result);

                        if (drugstore.Count > 0)
                        {
                            txtName.Text = drugstore[0].name;
                            lblADescription.Text = drugstore[0].description;
                            lblAddress.Text = drugstore[0].address;
                            iRating.Value = drugstore[0].rating;
                            setDrugstores(id);
                        }
                    });
                    w.DownloadStringAsync(
                    new Uri("http://getFDrugstore.php?id=" + id));
                }
                else
                    MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
            }
        }

        private void setDrugstores(string id)
        {
            List<med_medicine> medicine;

            if (data.offlineData)
            {
                dbSQLite cn = new dbSQLite();
                cn.open();

                string query = "SELECT * FROM med_medicine WHERE idmedicine=" + id;
                medicine = cn.db.Query<med_medicine>(query);

                if (medicine.Count > 0)
                    llsResultsM.ItemsSource = medicine;
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
                        medicine = JsonConvert.DeserializeObject<List<med_medicine>>(r.EventArgs.Result);

                        if (medicine.Count > 0)
                            llsResultsM.ItemsSource = medicine;
                    });
                    w.DownloadStringAsync(
                    new Uri("http://getSMedicines.php?id=" + id));
                }
                else
                    MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
            }
        }

        private void btnComment_Click(object sender, EventArgs e)
        {

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
    }
}