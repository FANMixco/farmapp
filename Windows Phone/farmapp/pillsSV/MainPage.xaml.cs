using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using pillsSV.Resources;
using sqlite.Classes;
using pillsSV.Classes;
using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using Microsoft.Phone.Tasks;

namespace pillsSV
{

    public partial class MainPage : PhoneApplicationPage
    {
        private UserInfo data = new UserInfo();
        private manageProfile _profile = new manageProfile();
        private bool offlinedata = false;
        private cnnStatus cnnstatus = new cnnStatus();
        public MainPage()
        {
            InitializeComponent();


            if (getUserData() == false)
            {
                MessageBoxResult msgR = MessageBox.Show("¿Desea usar información fuera de línea? Esto puede tardar un promedio de 5-10 minutos.", "Información", MessageBoxButton.OKCancel);

                if (msgR == MessageBoxResult.OK)
                {
                    offlinedata = true;
                    MessageBox.Show("Por favor no apague su dispositivo ni cambie de aplicación durante el proceso.");
                }

                //to create user profile
                _profile.createUser(offlinedata);

                //to set userData
                _profile.getStatus();

                data = _profile.getUserInfo();

                //to create a new DB if user wants offline usage
                if (data.offlineData)
                {
                    CreateDataBD();

                    if (cnnstatus.status())
                        updateCurrentData();
                    return;
                }
            }

            if (cnnstatus.status())
                if (data.autoUpdate)
                    if (data.nextUpdate >= DateTime.Now)
                        updateCurrentData();
        }

        private async void updateCurrentData()
        {
            MessageBoxResult msgR = MessageBox.Show("¿Desea actulizar la información?", "Actualizar", MessageBoxButton.OKCancel);

            if (msgR == MessageBoxResult.OK)
            {
                offlinedata = true;
                MessageBox.Show("Por favor no apague su dispositivo ni cambie de aplicación durante el proceso.");

                updateData uData = new updateData();

                bool resultData = await uData.checkData();

                if (resultData)
                    uData.updateInfo(data.lastUpdate);

                data.lastUpdate = DateTime.Now;
                data.nextUpdate = DateTime.Now.AddDays(15);

                _profile.updateProfile(data);
            }
        }

        private void CreateDataBD()
        {
            try
            {
                createDB cDB = new createDB();

                _profile.updateFirstTime();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        private bool getUserData()
        {
            bool rResult = _profile.getStatus();

            return rResult;
        }

        private void txtName_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txtResult = (TextBox)sender;
            string queryLike = txtResult.Text;
            List<med_medicine> medicine;

            if (data.offlineData)
            {
                dbSQLite cn = new dbSQLite();
                cn.open();

                string query = "SELECT * FROM med_medicine WHERE name like '%" + queryLike + "%'";
                medicine = cn.db.Query<med_medicine>(query);

                if (medicine.Count > 0)
                    llsResultsM.ItemsSource = medicine;
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
                    new Uri("http://farmapp.azurewebsites.net/farmapp/getCoincidences/" + queryLike));
                }
                else
                    MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
            }
        }

        private void llsResultsM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector item = (LongListSelector)sender;
            if (item.SelectedItem != null)
            {
                med_medicine p = item.SelectedItem as med_medicine;

                string url = "/Pages/medResult.xaml?id=" + p.idmedicine.ToString();
                NavigationService.Navigate(new Uri(url, UriKind.Relative));
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            data = _profile.getUserInfo();
        }

        private void txtDrugStore_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txtResult = (TextBox)sender;
            string queryLike = txtResult.Text;
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
                                    WHERE drugstores.name like '%" + queryLike + "%'";
                    drugstore = cn.db.Query<drugstores>(query);

                    if (drugstore.Count > 0)
                        llsResultsDS.ItemsSource = drugstore;
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
                    new Uri("http://farmapp.azurewebsites.net/drugstores/getCoincidences/" + queryLike));
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

        private void btnLike_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask review = new MarketplaceReviewTask();
            review.Show();
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
            ShareStatusTask shareStatusTask = new ShareStatusTask();

            shareStatusTask.Status = "Descarga Farmapps y mejora tú vida desde el Windows Store.";

            shareStatusTask.Show();
        }
    }
}