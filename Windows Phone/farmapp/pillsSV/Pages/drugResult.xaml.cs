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
using Telerik.Windows.Controls;
using Microsoft.Phone.Maps.Controls;

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

            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "5b810a60-9962-4e48-a3c0-2f41a27a7961";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "lPWk0ZKoahL1w2CbtCGKDw";
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string lat = NavigationContext.QueryString["lat"];
            string lng = NavigationContext.QueryString["lng"];
            string id = NavigationContext.QueryString["id"];

            createMap cm = new createMap(mapLocation);

            if (!(String.IsNullOrEmpty(lat) && String.IsNullOrEmpty(lng)))
            {
                List<Tuple<double, double>> locations = new List<Tuple<double, double>>();
                locations.Add(new Tuple<double, double>(Double.Parse(NavigationContext.QueryString["lat"]), Double.Parse(NavigationContext.QueryString["lng"])));

                cm.setCenter(Double.Parse(NavigationContext.QueryString["lat"]), Double.Parse(NavigationContext.QueryString["lng"]), 14);
                cm.addPushpins(locations);
            }

            _profile.getStatus();

            data = _profile.getUserInfo();

            List<drugstores> drugstore;

            if (data.offlineData)
            {
                try
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
                catch (Exception ex)
                {
                    Console.Write(ex);
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
                try
                {

                    dbSQLite cn = new dbSQLite();
                    cn.open();

                    string query = "SELECT (name || ', ' || concentration || units) name FROM med_medicine INNER JOIN medDrug ON med_medicine.idmedicine=medDrug.idmedicine WHERE iddrugstore=" + id;
                    medicine = cn.db.Query<med_medicine>(query);

                    if (medicine.Count > 0)
                        llsResultsM.ItemsSource = medicine;
                    cn.close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
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
            if (cnnstatus.status())
            {
                TextBlock lblComment = new TextBlock();
                TextBox txtComment = new TextBox();
                RadRating iRatingComment = new RadRating();

                lblComment.Text = "Ingrese el comentario:";
                txtComment.Text = "";
                iRatingComment.Value = 0;

                StackPanel container = new StackPanel
                {
                    Orientation = System.Windows.Controls.Orientation.Vertical
                };

                container.Margin = new System.Windows.Thickness { Bottom = 0, Left = 12, Right = 0, Top = 12 };

                container.Children.Add(lblComment);
                container.Children.Add(txtComment);
                container.Children.Add(iRatingComment);

                CustomMessageBox messageBox = new CustomMessageBox()
                {
                    Title = "Comentario",
                    Content = container,
                    RightButtonContent = "Cancelar",
                    LeftButtonContent = "Aceptar"
                };

                messageBox.Show();

                messageBox.Dismissed += (s2, e2) =>
                {
                    switch (e2.Result)
                    {
                        case CustomMessageBoxResult.RightButton:
                            break;
                        case CustomMessageBoxResult.LeftButton:
                            saveComment(txtComment.Text, iRatingComment.Value);
                            break;
                    }
                };
            }
            else
                MessageBox.Show("Necesita tener conexión a internet para está opción.", "Error", MessageBoxButton.OK);
        }

        private void saveComment(string comment, double value)
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
                    case "1":
                        string lat = NavigationContext.QueryString["lat"];
                        string lng = NavigationContext.QueryString["lng"];
                        string id = NavigationContext.QueryString["id"];

                        NavigationService.Navigate(new Uri(string.Format("/pages/drugResult.xaml?id=" + id + "&lat=" + lat + "&lng=" + lng + "&random={0}" + "&nocache=" + Environment.TickCount + "&Refresh=true", Guid.NewGuid()), UriKind.Relative));
                        break;
                }
            });
            w.DownloadStringAsync(
            new Uri("http://addComment.php?comment=" + comment + "&value=" + value));
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

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pivot = ((Pivot)sender).SelectedIndex;

            if (pivot == 0 || pivot == 1 || pivot == 3)
                createAppBar(1, pivot);
            else
                createAppBar(2, pivot);
        }

        private void createAppBar(int multiple, int pivot)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton[] AppButtons = new ApplicationBarIconButton[multiple];

            ApplicationBarMenuItem[] AppMenu = new ApplicationBarMenuItem[3];

            for (int i = 0; i < 3; i++)
            {
                AppMenu[i] = new ApplicationBarMenuItem();

                switch (i)
                {
                    case 0:
                        AppMenu[i].Text = "perfil";
                        AppMenu[i].Click += new EventHandler(menuProfile_Click);
                        break;
                    case 1:
                        AppMenu[i].Text = "ayuda";
                        AppMenu[i].Click += new EventHandler(menuHelp_Click);
                        break;
                    case 2:
                        AppMenu[i].Text = "acerca de";
                        AppMenu[i].Click += new EventHandler(menuAbout_Click);
                        break;
                }

                ApplicationBar.MenuItems.Add(AppMenu[i]);
            }

            if (pivot == 0 || pivot == 1 || pivot == 3)
            {
                AppButtons[0] = new ApplicationBarIconButton();

                AppButtons[0].IconUri = new Uri("/Assets/AppBar/add.png", UriKind.Relative);
                AppButtons[0].Text = "comentario";
                AppButtons[0].Click += new EventHandler(btnComment_Click);

                ApplicationBar.Buttons.Add(AppButtons[0]);

            }
            else
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

                //menu extra para la vista de mapa
                ApplicationBarMenuItem AppMenuExtra = new ApplicationBarMenuItem();
                AppMenuExtra.Text = "comentario";
                AppMenuExtra.Click += new EventHandler(btnComment_Click);
                ApplicationBar.MenuItems.Add(AppMenuExtra);

            }

            if (pivot < 2)
                ApplicationBar.Mode = ApplicationBarMode.Minimized;
        }
        private void road_Click(object sender, EventArgs e)
        {
            mapLocation.CartographicMode = MapCartographicMode.Road;
        }

        private void aerial_Click(object sender, EventArgs e)
        {
            mapLocation.CartographicMode = MapCartographicMode.Aerial;
        }
    }
}