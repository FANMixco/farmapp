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
                MessageBoxResult msgR = MessageBox.Show("¿Desea usar información fuera de línea?", "Información", MessageBoxButton.OKCancel);

                if (msgR == MessageBoxResult.OK)
                    offlinedata = true;

                //to create user profile
                _profile.createUser(offlinedata);

                _profile.getStatus();

                //to set userData
                data = _profile.getUserInfo();

                //to create a new DB if user wants offline usage
                if (data.offlineData)
                    CreateDataBD();
            }
        }

        private void CreateDataBD()
        {
            try
            {
                dbSQLite cnn = new dbSQLite();
                cnn.createDB();

                cnn.open();

                #region addMedicine
                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1, name = "ABACAVIR", concentration = "300", units = "MG", price = "7.6287", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 2, name = "ACARBOSA", concentration = "50", units = "MG", price = "0.2688", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 3, name = "ACARBOSA", concentration = "100", units = "MG", price = "0.5288", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 4, name = "ACECLOFENACO", concentration = "100", units = "MG", price = "0.7236", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 5, name = "ACEMETACINA", concentration = "60", units = "MG", price = "0.9213", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 6, name = "ACEMETACINA", concentration = "90", units = "MG", price = "1.5881", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 7, name = "ACETAMINOFEN [PARACETAMOL]", concentration = "750", units = "MG", price = "0.2855", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 8, name = "ACETAMINOFEN [PARACETAMOL]", concentration = "1000", units = "MG", price = "0.3575", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 9, name = "ACETAMINOFEN [PARACETAMOL] + IBUPROFENO", concentration = "200", units = "MG", price = "0.3242", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 10, name = "ACETAMINOFEN [PARACETAMOL] + PRAMIVERINA", concentration = "500", units = "MG", price = "0.3752", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 11, name = "ACETAMINOFEN [PARACETAMOL] + TIZANIDINA", concentration = "350", units = "MG", price = "0.8574", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 12, name = "ACETAMINOFEN [PARACETAMOL] + TRAMADOL", concentration = "325", units = "MG", price = "1.244", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 13, name = "ACETAMINOFEN [PARACETAMOL] + TRAMADOL", concentration = "325", units = "MG/ 5 ML", price = "0.5287", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 14, name = "ACETAZOLAMIDA", concentration = "100", units = "MG", price = "0.3192", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 15, name = "ACETAZOLAMIDA", concentration = "250", units = "MG", price = "0.39", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 16, name = "ACETILCISTEINA", concentration = "100", units = "MG", price = "0.9928", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 17, name = "ACETILCISTEINA", concentration = "200", units = "MG/EFP", price = "1.1396", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 18, name = "ACETILCISTEINA", concentration = "600", units = "MG/EFP", price = "1.4766", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 19, name = "ACICLOVIR", concentration = "800", units = "MG", price = "1.8557", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 20, name = "ACICLOVIR", concentration = "200", units = "MG", price = "0.7585", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 21, name = "ACICLOVIR", concentration = "400", units = "MG", price = "1.3089", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 22, name = "ACICLOVIR", concentration = "200", units = "MG/ 5 ML", price = "0.187", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 23, name = "ACICLOVIR", concentration = "400", units = "MG/ 5 ML", price = "0.2717", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 24, name = "ACICLOVIR", concentration = "250", units = "MG/EFP", price = "26.7919", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 25, name = "ACIDO ACETILSALICILICO + CLOPIDOGREL", concentration = "100", units = "MG", price = "2.9136", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 26, name = "ACIDO ACETILSALICILICO + RAMIPRIL + SIMVASTATINA", concentration = "100", units = "MG", price = "1.0051", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 27, name = "ACIDO ACETILSALICILICO + RAMIPRIL + SIMVASTATINA", concentration = "100", units = "MG", price = "0.9939", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 28, name = "ACIDO ACETILSALICILICO + RAMIPRIL + SIMVASTATINA", concentration = "100", units = "MG", price = "1.0163", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 29, name = "ACIDO ACEXAMICO + NEOMICINA", concentration = "0", units = "%", price = "0.3551", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 30, name = "ACIDO ALENDRONICO", concentration = "70", units = "MG", price = "6.9777", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 31, name = "ACIDO ALENDRONICO + COLECALCIFEROL", concentration = "70", units = "MG+UI", price = "18.7021", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 32, name = "ACIDO ALENDRONICO + COLECALCIFEROL", concentration = "70", units = "MG+UI", price = "13.5867", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 33, name = "ACIDO BENZOICO + ALCANFOR + OPIUM + PIMPINELA ANISUM", concentration = "5", units = "MG", price = "1.1522", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 34, name = "ACIDO DODECIL SULFOACETICO + PROPILENGLICOL", concentration = "1", units = "%", price = "0.0673", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 35, name = "ACIDO FUSIDICO", concentration = "1", units = "%", price = "3.088", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 36, name = "ACIDO FUSIDICO + MOMETASONA", concentration = "2", units = "%", price = "1.047", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 37, name = "ACIDO GLICOLICO", concentration = "10", units = "%", price = "0.3797", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 38, name = "ACIDO GLICOLICO", concentration = "12", units = "%", price = "0.6287", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 39, name = "ACIDO HIALURONICO", concentration = "25", units = "MG/EFP", price = "71.5934", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 40, name = "ACIDO HIALURONICO", concentration = "0", units = "%", price = "1.2696", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 41, name = "ACIDO HIALURONICO", concentration = "0", units = "%", price = "0.1556", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 42, name = "ACIDO IBANDRONICO", concentration = "150", units = "MG", price = "41.2692", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 43, name = "ACIDO IBANDRONICO", concentration = "3", units = "MG/EFP", price = "153.673", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 44, name = "ACIDO IBANDRONICO", concentration = "6", units = "MG/EFP", price = "557.189", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 45, name = "ACIDO MEFENAMICO", concentration = "500", units = "MG", price = "0.5439", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 46, name = "ACIDO NALIDIXICO", concentration = "500", units = "MG", price = "0.4451", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 47, name = "ACIDO NALIDIXICO + FENAZOPIRIDINA", concentration = "500", units = "MG", price = "0.5714", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 48, name = "ACIDO NICOTINICO", concentration = "1000", units = "MG", price = "1.0413", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 49, name = "ACIDO PICOSULFURICO", concentration = "13", units = "MG/ML", price = "0.4225", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 50, name = "ACIDO PIPEMIDICO", concentration = "400", units = "MG", price = "0.7363", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 51, name = "ACIDO SALICILICO + ACIDO LACTICO", concentration = "17", units = "%", price = "0.417", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 52, name = "ACIDO TIOCTICO", concentration = "300", units = "MG", price = "0.7811", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 53, name = "ACIDO TIOCTICO", concentration = "600", units = "MG", price = "2.2546", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 54, name = "ACIDO VALPROICO", concentration = "400", units = "MG", price = "0.5385", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 55, name = "ACIDO VALPROICO", concentration = "500", units = "MG", price = "0.4998", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 56, name = "ACIDO VALPROICO", concentration = "200", units = "MG/ ML", price = "0.3236", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 57, name = "ACIDO VALPROICO", concentration = "250", units = "MG/ 5 ML", price = "0.199", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 58, name = "ACIDO VALPROICO", concentration = "500", units = "MG/EFP", price = "12.4387", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 59, name = "ACIDO VALPROICO", concentration = "200", units = "MG/ ML", price = "0.3451", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 60, name = "ACIDO ZOLEDRONICO", concentration = "4", units = "MG/EFP", price = "444.434", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 61, name = "ACIDO ZOLEDRONICO", concentration = "5", units = "MG/EFP", price = "711.694", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 62, name = "ADAPALENO", concentration = "0", units = "%", price = "0.5067", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 63, name = "ADAPALENO", concentration = "0", units = "%", price = "0.6043", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 64, name = "ADAPALENO + CLINDAMICINA", concentration = "0", units = "%", price = "0.8451", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 65, name = "ADEFOVIR DIPIVOXIL", concentration = "10", units = "MG", price = "8.1063", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 66, name = "AGOMELATINA", concentration = "25", units = "MG", price = "2.2038", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 67, name = "ALFA AMILASA", concentration = "3000", units = "UI", price = "0.4613", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 68, name = "ALFUZOSINA", concentration = "10", units = "MG", price = "2.4444", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 69, name = "ALISKIREN", concentration = "150", units = "MG", price = "2.0513", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 70, name = "ALISKIREN", concentration = "300", units = "MG", price = "2.3545", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 71, name = "ALISKIREN + HIDROCLOROTIAZIDA", concentration = "300", units = "MG", price = "2.2055", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 72, name = "ALISKIREN + HIDROCLOROTIAZIDA", concentration = "300", units = "MG", price = "2.246", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 73, name = "ALISKIREN + HIDROCLOROTIAZIDA", concentration = "150", units = "MG", price = "2.1957", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 74, name = "ALISKIREN + HIDROCLOROTIAZIDA", concentration = "150", units = "MG", price = "2.222", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 75, name = "ALIZAPRIDA", concentration = "50", units = "MG/EFP", price = "2.0861", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 76, name = "ALIZAPRIDA", concentration = "50", units = "MG", price = "1.1329", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 77, name = "ALOPURINOL", concentration = "100", units = "MG", price = "0.2056", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 78, name = "ALOPURINOL", concentration = "300", units = "MG", price = "0.4436", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 79, name = "ALPRAZOLAM", concentration = "1", units = "MG", price = "0.7917", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 80, name = "ALPRAZOLAM", concentration = "1", units = "MG", price = "0.3633", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 81, name = "ALPRAZOLAM", concentration = "1", units = "MG", price = "1.02", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 82, name = "ALPRAZOLAM", concentration = "1", units = "MG", price = "0.2656", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 83, name = "ALPRAZOLAM", concentration = "0", units = "MG", price = "0.2514", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 84, name = "ALPRAZOLAM", concentration = "2", units = "MG", price = "1.3137", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 85, name = "ALPROSTADIL", concentration = "20", units = "MG/EFP", price = "35.1326", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 86, name = "AMANTADINA", concentration = "100", units = "MG", price = "0.4791", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 87, name = "AMBROXOL", concentration = "75", units = "MG", price = "0.9658", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 88, name = "AMBROXOL", concentration = "30", units = "MG/ 5 ML", price = "0.0496", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 89, name = "AMBROXOL", concentration = "15", units = "MG/EFP", price = "1.128", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 90, name = "AMBROXOL + AMOXICILINA", concentration = "30", units = "MG", price = "1.3531", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 91, name = "AMBROXOL + CLENBUTEROL", concentration = "30", units = "MG", price = "0.6266", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 92, name = "AMBROXOL + CLENBUTEROL", concentration = "15", units = "MG/ 5 ML", price = "0.0902", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 93, name = "AMBROXOL + CLENBUTEROL", concentration = "8", units = "MG/ 5 ML", price = "0.0786", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 94, name = "AMBROXOL + CLENBUTEROL", concentration = "8", units = "MG/ ML", price = "0.3319", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 95, name = "AMBROXOL + FENOTEROL + BROMHEXINA", concentration = "8", units = "MG/ 5 ML", price = "0.0747", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 96, name = "AMBROXOL + LORATADINA", concentration = "30", units = "MG", price = "1.3107", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 97, name = "AMBROXOL + LORATADINA", concentration = "15", units = "MG", price = "0.8843", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 98, name = "AMBROXOL + LORATADINA", concentration = "30", units = "MG / 5 ML", price = "0.1685", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 99, name = "AMBROXOL + SALBUTAMOL", concentration = "8", units = "MG/ 5 ML", price = "0.0627", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 100, name = "AMBROXOL + TERBUTALINA", concentration = "2", units = "MG/5ML", price = "0.0797", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 101, name = "AMIKACINA", concentration = "500", units = "MG/EFP", price = "4.4551", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 102, name = "AMIKACINA", concentration = "1000", units = "MG/EFP", price = "14.5969", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 103, name = "AMILORIDA + HIDROCLOROTIAZIDA", concentration = "5", units = "MG", price = "0.472", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 104, name = "AMINOFILINA", concentration = "50", units = "MG/ 5 ML", price = "0.0924", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 105, name = "AMINOFILINA", concentration = "250", units = "MG/EFP", price = "0.7875", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 106, name = "AMINOFILINA", concentration = "200", units = "MG", price = "0.0881", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 107, name = "AMINOFILINA", concentration = "90", units = "MG/5ML", price = "0.1125", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 108, name = "AMIODARONA", concentration = "200", units = "MG", price = "0.4721", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 109, name = "AMIODARONA", concentration = "150", units = "MG/EFP", price = "2.8075", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 110, name = "AMISULPRIDA", concentration = "200", units = "MG", price = "2.9063", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 111, name = "AMITRIPTILINA", concentration = "25", units = "MG", price = "0.2748", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 112, name = "AMITRIPTILINA + CLORDIAZEPOXIDO", concentration = "25", units = "MG", price = "0.5161", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 113, name = "AMITRIPTILINA + CLORDIAZEPOXIDO", concentration = "13", units = "MG", price = "0.3631", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 114, name = "AMLODIPINA", concentration = "10", units = "MG", price = "1.0713", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 115, name = "AMLODIPINA", concentration = "5", units = "MG", price = "0.725", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 116, name = "AMLODIPINA + ATORVASTATINA", concentration = "5", units = "MG", price = "3.2273", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 117, name = "AMLODIPINA + ATORVASTATINA", concentration = "5", units = "MG", price = "2.6639", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 118, name = "AMLODIPINA + ATORVASTATINA", concentration = "5", units = "MG", price = "3.2721", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 119, name = "AMLODIPINA + BENAZEPRIL", concentration = "5", units = "MG", price = "0.788", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 120, name = "AMLODIPINA + BENAZEPRIL", concentration = "5", units = "MG", price = "0.6389", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 121, name = "AMLODIPINA + BENAZEPRIL", concentration = "3", units = "MG", price = "0.5389", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 122, name = "AMLODIPINA + HIDROCLOROTIAZIDA + VALSARTAN", concentration = "5", units = "MG", price = "2.1957", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 123, name = "AMLODIPINA + HIDROCLOROTIAZIDA + VALSARTAN", concentration = "10", units = "MG", price = "2.1499", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 124, name = "AMLODIPINA + HIDROCLOROTIAZIDA + VALSARTAN", concentration = "10", units = "MG", price = "2.0184", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 125, name = "AMLODIPINA + HIDROCLOROTIAZIDA + VALSARTAN", concentration = "5", units = "MG", price = "2.0143", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 126, name = "AMLODIPINA + HIDROCLOROTIAZIDA + VALSARTAN", concentration = "10", units = "MG", price = "2.1816", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 127, name = "AMLODIPINA + LOSARTAN", concentration = "5", units = "MG", price = "2.5917", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 128, name = "AMLODIPINA + LOSARTAN", concentration = "5", units = "MG", price = "2.5917", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 129, name = "AMLODIPINA + OLMESARTAN MEDOXOMILO", concentration = "5", units = "MG", price = "2.0528", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 130, name = "AMLODIPINA + OLMESARTAN MEDOXOMILO", concentration = "5", units = "MG", price = "2.0542", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 131, name = "AMLODIPINA + OLMESARTAN MEDOXOMILO", concentration = "10", units = "MG", price = "2.0465", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 132, name = "AMLODIPINA + PERINDOPRIL", concentration = "10", units = "MG", price = "1.4857", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 133, name = "AMLODIPINA + PERINDOPRIL", concentration = "10", units = "MG", price = "1.2765", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 134, name = "AMLODIPINA + PERINDOPRIL", concentration = "5", units = "MG", price = "1.4901", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 135, name = "AMLODIPINA + PERINDOPRIL", concentration = "5", units = "MG", price = "1.2761", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 136, name = "AMLODIPINA + VALSARTAN", concentration = "5", units = "MG", price = "1.8", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 137, name = "AMLODIPINA + VALSARTAN", concentration = "10", units = "MG", price = "2.0328", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 138, name = "AMLODIPINA + VALSARTAN", concentration = "10", units = "MG", price = "2.1337", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 139, name = "AMLODIPINA + VALSARTAN", concentration = "5", units = "MG", price = "2.1219", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 140, name = "AMLODIPINA + VALSARTAN", concentration = "5", units = "MG", price = "1.3424", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 141, name = "AMONIO + GUAIFENESINA + SULFAMETOXAZOL + TRIMETROPRIM", concentration = "25", units = "MG/ 5 ML", price = "0.1181", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 142, name = "AMOXICILINA", concentration = "875", units = "MG", price = "1.1763", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 143, name = "AMOXICILINA", concentration = "250", units = "MG", price = "0.0737", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 144, name = "AMOXICILINA", concentration = "500", units = "MG", price = "0.343", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 145, name = "AMOXICILINA", concentration = "1000", units = "MG", price = "1.3057", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 146, name = "AMOXICILINA", concentration = "250", units = "MG/ 5 ML", price = "0.0684", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 147, name = "AMOXICILINA", concentration = "375", units = "MG/ 5 ML", price = "0.1038", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 148, name = "AMOXICILINA", concentration = "750", units = "MG/ 5 ML", price = "0.1875", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 149, name = "AMOXICILINA", concentration = "125", units = "MG/ 5 ML", price = "0.0622", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 150, name = "AMOXICILINA", concentration = "500", units = "MG/ 5 ML", price = "0.0883", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 151, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "875", units = "MG", price = "1.8731", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 152, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "500", units = "MG", price = "1.6684", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 153, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "875", units = "MG", price = "2.3631", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 154, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "500", units = "MG", price = "1.9173", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 155, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "250", units = "MG/ 5 ML", price = "0.1963", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 156, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "125", units = "MG/ 5 ML", price = "0.1635", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 157, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "400", units = "MG/ 5 ML", price = "0.256", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 158, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "200", units = "MG/ 5 ML", price = "0.2512", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 159, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "600", units = "MG/ 5 ML", price = "0.303", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 160, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "1000", units = "MG/EFP", price = "13.6622", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 161, name = "AMOXICILINA + ACIDO CLAVULANICO", concentration = "125", units = "MG/ 5 ML", price = "0.1379", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 162, name = "AMOXICILINA + BROMHEXINA", concentration = "500", units = "MG", price = "1.4063", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 163, name = "AMOXICILINA + BROMHEXINA", concentration = "500", units = "MG/ 10 ML", price = "0.0893", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 164, name = "AMOXICILINA + BROMHEXINA", concentration = "250", units = "MG/ 5 ML", price = "0.0679", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 165, name = "AMOXICILINA + CLARITROMICINA + OMEPRAZOL", concentration = "1000", units = "MG", price = "22.3114", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 166, name = "AMOXICILINA + ESOMEPRAZOL + LEVOFLOXACINO", concentration = "1000", units = "MG", price = "0.7414", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 167, name = "AMOXICILINA + LANSOPRAZOL + LEVOFLOXACINO", concentration = "1000", units = "MG", price = "0.5865", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 168, name = "AMOXICILINA + PIVSULBACTAM", concentration = "875", units = "MG", price = "1.8345", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 169, name = "AMOXICILINA + PIVSULBACTAM", concentration = "1000", units = "MG/ 5 ML", price = "0.5757", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 170, name = "AMOXICILINA + PIVSULBACTAM", concentration = "250", units = "MG/ 5 ML", price = "0.5386", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 171, name = "AMOXICILINA + PIVSULBACTAM", concentration = "125", units = "MG/ 5 ML", price = "0.4608", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 172, name = "AMPICILINA", concentration = "1000", units = "MG/EFP", price = "0.7061", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 173, name = "AMPICILINA", concentration = "500", units = "MG/EFP", price = "3.9516", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 174, name = "AMPICILINA", concentration = "125", units = "MG/ 5 ML", price = "0.0202", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 175, name = "AMPICILINA", concentration = "250", units = "MG/ 5 ML", price = "0.0372", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 176, name = "AMPICILINA", concentration = "1000", units = "MG", price = "0.6273", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 177, name = "AMPICILINA", concentration = "500", units = "MG", price = "0.2965", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 178, name = "AMPICILINA + CLOXACILINA", concentration = "500", units = "MG", price = "0.2961", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 179, name = "AMPICILINA + SULBACTAM", concentration = "1000", units = "MG", price = "12.1117", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 180, name = "ANASTROZOL", concentration = "1", units = "MG", price = "7.716", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 181, name = "ANIDULAFUNGINA", concentration = "100", units = "MG/EFP", price = "388.7", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 182, name = "APREPITANT", concentration = "125", units = "MG", price = "29.8263", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 183, name = "ARIPIPRAZOL", concentration = "15", units = "MG", price = "3.2935", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 184, name = "ATAPULGITA + SULFAMETOXAZOL + TRIMETROPRIM", concentration = "100", units = "MG", price = "0.8787", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 185, name = "ATAPULGITA + SULFAMETOXAZOL + TRIMETROPRIM", concentration = "100", units = "MG/ 5 ML", price = "0.1695", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 186, name = "ATENOLOL", concentration = "50", units = "MG", price = "0.3106", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 187, name = "ATENOLOL", concentration = "100", units = "MG", price = "0.4457", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 188, name = "ATENOLOL + CLORTALIDONA", concentration = "100", units = "MG", price = "0.8678", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 189, name = "ATENOLOL + CLORTALIDONA", concentration = "50", units = "MG", price = "0.6753", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 190, name = "ATENOLOL + HIDROCLOROTIAZIDA", concentration = "50", units = "MG", price = "0.3069", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 191, name = "ATENOLOL + NIFEDIPINA", concentration = "50", units = "MG", price = "0.7557", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 192, name = "ATOMOXETINA", concentration = "10", units = "MG", price = "3.3504", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 193, name = "ATOMOXETINA", concentration = "18", units = "MG", price = "3.8708", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 194, name = "ATOMOXETINA", concentration = "25", units = "MG", price = "4.0934", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 195, name = "ATOMOXETINA", concentration = "40", units = "MG", price = "4.4565", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 196, name = "ATOMOXETINA", concentration = "60", units = "MG", price = "4.786", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 197, name = "ATORVASTATINA", concentration = "10", units = "MG", price = "0.9579", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 198, name = "ATORVASTATINA", concentration = "20", units = "MG", price = "1.3509", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 199, name = "ATORVASTATINA", concentration = "40", units = "MG", price = "1.8887", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 200, name = "ATORVASTATINA", concentration = "80", units = "MG", price = "2.1525", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 201, name = "ATORVASTATINA", concentration = "10", units = "MG", price = "1.8941", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 202, name = "ATORVASTATINA", concentration = "20", units = "MG", price = "2.9862", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 203, name = "ATORVASTATINA", concentration = "40", units = "MG", price = "2.9965", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 204, name = "ATORVASTATINA", concentration = "80", units = "MG", price = "3.6902", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 205, name = "ATORVASTATINA + EZETIMIBE", concentration = "20", units = "MG", price = "1.9468", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 206, name = "ATORVASTATINA + EZETIMIBE", concentration = "10", units = "MG", price = "1.502", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 207, name = "ATROPINA", concentration = "1", units = "MG/EFP", price = "2.3847", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 208, name = "ATROPINA", concentration = "1", units = "%", price = "0.8143", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 209, name = "ATROPINA", concentration = "0", units = "MG/EFP", price = "0.5375", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 210, name = "ATROPINA", concentration = "1", units = "MG/EFP", price = "0.4778", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 211, name = "ATROPINA + DIFENOXILATO", concentration = "1", units = "MG", price = "0.3126", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 212, name = "ATROPINA + ESCOPOLAMINA", concentration = "0", units = "MG", price = "0.0355", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 213, name = "ATROPINA + HIOSCIAMINA + FENOBARBITAL + ESCOPOLAMINA", concentration = "0", units = "MG/ 5 ML", price = "0.0287", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 214, name = "AZATIOPRINA", concentration = "50", units = "MG", price = "0.7965", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 215, name = "AZELASTINA", concentration = "0", units = "%", price = "1.8481", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 216, name = "AZITROMICINA", concentration = "500", units = "MG", price = "4.3702", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 217, name = "AZITROMICINA", concentration = "200", units = "MG/ 5 ML", price = "0.8252", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 218, name = "AZITROMICINA", concentration = "500", units = "MG/EFP", price = "26.7486", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 219, name = "AZITROMICINA", concentration = "250", units = "MG", price = "4.2056", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 220, name = "BACITRACINA + LIDOCAINA + NEOMICINA + POLIMIXINA B", concentration = "500", units = "UI+%+%+UI", price = "0.3654", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 221, name = "BACITRACINA + NEOMICINA + POLIMIXINA B", concentration = "40000", units = "UI+G+UI", price = "0.2931", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 222, name = "BACITRACINA + NEOMICINA + ZINC", concentration = "50000", units = "UI+G+G", price = "0.3659", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 223, name = "BECLOMETASONA", concentration = "0", units = "%", price = "0.3858", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 224, name = "BECLOMETASONA", concentration = "50", units = "MCG/ DOSIS", price = "0.0908", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 225, name = "BECLOMETASONA", concentration = "100", units = "MCG/ DOSIS", price = "0.251", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 226, name = "BECLOMETASONA", concentration = "250", units = "MCG/ DOSIS", price = "0.0969", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 227, name = "BECLOMETASONA", concentration = "50", units = "MCG/ DOSIS", price = "0.0833", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 228, name = "BECLOMETASONA", concentration = "1", units = "MG/ DOSIS", price = "0.0645", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 229, name = "BECLOMETASONA + CLIOQUINOL", concentration = "0", units = "MG/ ML", price = "1.1774", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 230, name = "BECLOMETASONA + SALBUTAMOL", concentration = "50", units = "MCG/ DOSIS", price = "0.0913", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 231, name = "BENSERAZIDA + LEVODOPA", concentration = "50", units = "MG", price = "1.1208", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 232, name = "BENZOATO DE BENCILO", concentration = "25", units = "%", price = "0.0276", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 233, name = "BESILATO CISATRACURIO", concentration = "20", units = "MG/EFP", price = "6.603", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 234, name = "BETAHISTINA", concentration = "6", units = "MG", price = "0.3819", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 235, name = "BETAHISTINA", concentration = "16", units = "MG", price = "0.9361", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 236, name = "BETAMETASONA + ACIDO FUSIDICO", concentration = "0", units = "%", price = "0.635", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 237, name = "BETAMETASONA + ACIDO FUSIDICO + KETOCONAZOL", concentration = "0", units = "%", price = "0.724", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 238, name = "BETAMETASONA + ACIDO SALICILICO", concentration = "0", units = "%", price = "0.6604", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 239, name = "BETAMETASONA + ACIDO SALICILICO", concentration = "0", units = "%", price = "0.7771", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 240, name = "BETAMETASONA + ACIDO SALICILICO", concentration = "0", units = "%", price = "0.2883", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 241, name = "BETAMETASONA + CALCIPOTRIOL", concentration = "5", units = "%", price = "1.1108", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 242, name = "BETAMETASONA + CLIOQUINOL + CLOTRIMAZOL + GENTAMICINA", concentration = "0", units = "%", price = "0.5193", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 243, name = "BETAMETASONA + CLIOQUINOL + GENTAMICINA + TOLNAFTATO", concentration = "0", units = "%", price = "0.7748", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 244, name = "BETAMETASONA + CLORANFENICOL", concentration = "0", units = "G/ ML", price = "0.7927", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 245, name = "BETAMETASONA + CLORANFENICOL", concentration = "0", units = "%", price = "0.5632", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 246, name = "BETAMETASONA + CLORFENAMINA", concentration = "0", units = "MG", price = "0.5254", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 247, name = "BETAMETASONA + CLOTRIMAZOL", concentration = "0", units = "%", price = "0.7715", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 248, name = "BETAMETASONA + CLOTRIMAZOL", concentration = "0", units = "%", price = "0.3932", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 249, name = "BETAMETASONA + CLOTRIMAZOL + NEOMICINA", concentration = "0", units = "%", price = "0.2903", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 250, name = "BETAMETASONA + DEXCLORFENIRAMINA", concentration = "0", units = "MG", price = "0.4952", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 251, name = "BETAMETASONA + DEXCLORFENIRAMINA", concentration = "0", units = "MG/ 5 ML", price = "0.1427", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 252, name = "BETAMETASONA + DOBESILATO DE CALCIO + LIDOCAINA", concentration = "0", units = "%", price = "0.5146", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 253, name = "BETAMETASONA + GENTAMICINA", concentration = "0", units = "%", price = "1.1666", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 254, name = "BETAMETASONA + GENTAMICINA", concentration = "0", units = "%", price = "3.0585", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 255, name = "BETAMETASONA + GENTAMICINA + CLIOQUINOL + TOLNAFTATO", concentration = "0", units = "%", price = "0.8723", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 256, name = "BETAMETASONA + GENTAMICINA + CLOTRIMAZOL", concentration = "0", units = "%", price = "0.4414", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 257, name = "BETAMETASONA + GENTAMICINA + KETOCONAZOL", concentration = "0", units = "%", price = "0.4794", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 258, name = "BETAMETASONA + GENTAMICINA + MICONAZOL", concentration = "10", units = "%", price = "0.6455", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 259, name = "BETAMETASONA + KETOCONAZOL", concentration = "0", units = "%", price = "0.5008", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 260, name = "BETAMETASONA + LIDOCAINA + ZINC", concentration = "0", units = "%", price = "0.3848", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 261, name = "BETAMETASONA + LORATADINA", concentration = "0", units = "MG", price = "1.6285", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 262, name = "BETAMETASONA + LORATADINA", concentration = "0", units = "MG/ 5 ML", price = "0.2405", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 263, name = "BETAMETASONA + NEOMICINA + POLIMIXINA B", concentration = "1", units = "MG+MG+UI", price = "0.7917", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 264, name = "BETAMETASONA + NEOMICINA + POLIMIXINA B", concentration = "1", units = "MG+MG+UI", price = "0.647", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 265, name = "BETAMETASONA + NEOMICINA + POLIMIXINA B", concentration = "0", units = "%+%+UI", price = "0.7917", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 266, name = "BETAMETASONA + SULFACETAMIDA", concentration = "0", units = "%", price = "0.7221", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 267, name = "BETAMETASONA DIPROPIONATO", concentration = "0", units = "%", price = "0.2548", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 268, name = "BETAMETASONA DIPROPIONATO", concentration = "0", units = "%", price = "0.216", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 269, name = "BETAMETASONA FOSFATO + BETAMETASONA DIPROPIONATO", concentration = "2", units = "MG/ EFP", price = "13.6053", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 270, name = "BETAMETASONA FOSFATO + BETAMETASONA DIPROPIONATO", concentration = "3", units = "MG/ EFP", price = "7.2122", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 271, name = "BETAMETASONA FOSFATO + BETAMETASONA DIPROPIONATO", concentration = "3", units = "MG/ EFP", price = "11.8896", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 272, name = "BETAMETASONA FOSFATO + BETAMETASONA DIPROPIONATO MICRONIZADO", concentration = "2", units = "MG/ ML", price = "15.1441", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 273, name = "BETAMETASONA FOSFATO DISODICO", concentration = "0", units = "%", price = "0.8352", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 274, name = "BETAMETASONA FOSFATO DISODICO", concentration = "8", units = "MG/ EFP", price = "5.1108", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 275, name = "BETAMETASONA FOSFATO DISODICO", concentration = "4", units = "MG/ EFP", price = "4.4162", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 276, name = "BETAMETASONA FOSFATO DISODICO", concentration = "1", units = "MG", price = "0.2634", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 277, name = "BETAMETASONA FOSFATO SODICO", concentration = "4", units = "MG/ EFP", price = "7.2353", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 278, name = "BETAMETASONA FOSFATO SODICO", concentration = "8", units = "MG/ EFP", price = "2.6678", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 279, name = "BETAMETASONA FOSFATO SODICO", concentration = "1", units = "MG/ ML", price = "0.1177", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 280, name = "BETAMETASONA FOSFATO SODICO", concentration = "1", units = "MG", price = "0.3793", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 281, name = "BETAMETASONA VALERATO", concentration = "0", units = "%", price = "0.2867", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 282, name = "BETAMETASONA VALERATO", concentration = "1", units = "%", price = "0.3068", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 283, name = "BETAMETASONA VALERATO", concentration = "1", units = "%", price = "0.1565", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 284, name = "BETAMETASONA VALERATO", concentration = "0", units = "%", price = "0.2432", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 285, name = "BETAXOLOL", concentration = "0", units = "%", price = "0.7046", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 286, name = "BETAXOLOL", concentration = "1", units = "%", price = "3.6007", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 287, name = "BICALUTAMIDA", concentration = "50", units = "MG", price = "8.5603", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 288, name = "BIFONAZOL", concentration = "1", units = "%", price = "0.5834", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 289, name = "BILASTINA", concentration = "20", units = "MG", price = "1.89", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 290, name = "BILIS + CELULASA + SIMETICONA + PANCREATINA", concentration = "25", units = "MG", price = "0.3744", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 291, name = "BIMATOPROST", concentration = "0", units = "%", price = "14.6497", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 292, name = "BIPERIDENO", concentration = "2", units = "MG", price = "0.3538", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 293, name = "BIPERIDENO", concentration = "4", units = "MG", price = "0.8058", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 294, name = "BIPERIDENO", concentration = "5", units = "MG/EFP", price = "3.0441", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 295, name = "BISACODILO", concentration = "5", units = "MG", price = "0.0718", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 296, name = "BISOPROLOL", concentration = "3", units = "MG", price = "0.8604", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 297, name = "BISOPROLOL", concentration = "5", units = "MG", price = "1.074", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 298, name = "BISOPROLOL", concentration = "10", units = "MG", price = "1.1712", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 299, name = "BISOPROLOL + HIDROCLOROTIAZIDA", concentration = "5", units = "MG", price = "1.2528", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 300, name = "BISOPROLOL + HIDROCLOROTIAZIDA", concentration = "10", units = "MG", price = "1.4642", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 301, name = "BISOPROLOL + HIDROCLOROTIAZIDA", concentration = "3", units = "MG", price = "1.1009", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 302, name = "BLEOMICINA", concentration = "15", units = "UI/ EFP", price = "56.4708", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 303, name = "BORTEZOMIB", concentration = "4", units = "MG/EFP", price = "1545.33", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 304, name = "BRIMONIDINA", concentration = "0", units = "%", price = "2.8059", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 305, name = "BRIMONIDINA", concentration = "0", units = "%", price = "2.9442", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 306, name = "BRIMONIDINA + DORZOLAMIDA + TIMOLOL", concentration = "0", units = "%", price = "8.3611", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 307, name = "BRINZOLAMIDA", concentration = "1", units = "%", price = "5.2705", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 308, name = "BRINZOLAMIDA + TIMOLOL", concentration = "1", units = "%", price = "7.1533", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 309, name = "BRIVUDINA", concentration = "125", units = "MG", price = "15.6925", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 310, name = "BROMAZEPAN", concentration = "2", units = "MG", price = "0.2809", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 311, name = "BROMAZEPAN", concentration = "3", units = "MG", price = "0.2634", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 312, name = "BROMAZEPAN", concentration = "6", units = "MG", price = "0.3762", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 313, name = "BROMAZEPAN", concentration = "3", units = "MG", price = "0.47", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 314, name = "BROMAZEPAN", concentration = "6", units = "MG", price = "0.67", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 315, name = "BROMAZEPAN + ACETAMINOFEN [PARACETAMOL]", concentration = "2", units = "MG", price = "0.1859", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 316, name = "BROMAZEPAN + CLIDINIO", concentration = "2", units = "MG", price = "0.2814", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 317, name = "BROMFENACO", concentration = "0", units = "%", price = "2.2905", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 318, name = "BROMFENIRAMINA", concentration = "4", units = "MG", price = "0.1413", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 319, name = "BROMFENIRAMINA + FENILEFRINA", concentration = "1", units = "MG/ 5 ML", price = "0.0408", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 320, name = "BROMHEXINA", concentration = "4", units = "MG/ 5 ML", price = "0.0436", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 321, name = "BROMHEXINA", concentration = "8", units = "MG/ 5 ML", price = "0.0576", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 322, name = "BROMHEXINA + DEXTROMETORFANO + SULFAMETOXAZOL + TRIMETROPRIM", concentration = "3", units = "MG/ 5 ML", price = "0.1044", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 323, name = "BROMHEXINA + FENOTEROL", concentration = "8", units = "MG/ 5 ML", price = "0.056", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 324, name = "BROMHEXINA + GUAIFENESINA + SALBUTAMOL", concentration = "4", units = "MG/ 5 ML", price = "0.0455", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 325, name = "BROMHEXINA + SALBUTAMOL", concentration = "4", units = "MG/ 5 ML", price = "0.0569", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 326, name = "BROMHEXINA + SULFAMETOXAZOL + TRIMETROPRIM", concentration = "3", units = "MG", price = "0.1929", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 327, name = "BROMHEXINA + SULFAMETOXAZOL + TRIMETROPRIM", concentration = "3", units = "MG/ 5 ML", price = "0.0328", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 328, name = "BROMHEXINA + TEOFILINA", concentration = "4", units = "MG/ 5 ML", price = "0.0564", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 329, name = "BROMOCRIPTINA", concentration = "3", units = "MG", price = "0.9713", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 330, name = "BROMOPRIDE + SIMETICONA + PANCREATINA", concentration = "5", units = "MG", price = "0.4206", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 331, name = "BROMURO DE IPRATROPIO", concentration = "0", units = "MG/ DOSIS", price = "0.0866", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 332, name = "BROMURO DE IPRATROPIO", concentration = "0", units = "MG/ DOSIS", price = "0.0748", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 333, name = "BROMURO DE IPRATROPIO", concentration = "0", units = "%", price = "0.6325", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 334, name = "BROMURO DE IPRATROPIO", concentration = "0", units = "MG/ ML", price = "0.6441", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 335, name = "BROMURO DE IPRATROPIO", concentration = "0", units = "MG/ ML", price = "0.5957", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 336, name = "BROMURO DE IPRATROPIO + SALBUTAMOL", concentration = "0", units = "MG", price = "0.1667", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 337, name = "BROMURO DE IPRATROPIO + SALBUTAMOL", concentration = "0", units = "MG/ 5 ML", price = "0.0469", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 338, name = "BROMURO DE IPRATROPIO + SALBUTAMOL", concentration = "0", units = "MG/ DOSIS", price = "0.12", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 339, name = "BROMURO DE IPRATROPIO + SALBUTAMOL", concentration = "1", units = "MG/ ML", price = "1.1412", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 340, name = "BROMURO DE IPRATROPIO + SALBUTAMOL", concentration = "0", units = "MG/ DOSIS", price = "0.0378", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 341, name = "BROMURO DE IPRATROPIO + SALBUTAMOL", concentration = "1", units = "MG/ ML", price = "0.4109", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 342, name = "BROMURO DE IPRATROPIO + SALBUTAMOL", concentration = "1", units = "MG/ ML", price = "0.6382", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 343, name = "BROMURO DE IPRATROPIO", concentration = "1", units = "MG / ML", price = "1.4107", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 344, name = "BROMURO DE PINAVERIO", concentration = "100", units = "MG", price = "1.1228", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 345, name = "BROMURO DE TIOTROPIO", concentration = "18", units = "MCG", price = "2.9565", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 346, name = "BROMURO DE VECURONIO", concentration = "4", units = "MG/EFP", price = "3.9304", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 347, name = "BUCLIZINA", concentration = "25", units = "MG", price = "0.1435", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 348, name = "BUCLIZINA", concentration = "5", units = "MG/ 5 ML", price = "0.036", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 349, name = "BUDESONIDA", concentration = "1", units = "MG/ ML", price = "2.9748", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 350, name = "BUDESONIDA", concentration = "0", units = "MG", price = "2.1556", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 351, name = "BUDESONIDA", concentration = "1", units = "MG/ ML", price = "2.9493", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 352, name = "BUDESONIDA", concentration = "32", units = "MCG/ DOSIS", price = "0.16", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 353, name = "BUDESONIDA", concentration = "200", units = "MCG/ DOSIS", price = "0.3536", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 354, name = "BUDESONIDA", concentration = "50", units = "MCG/ DOSIS", price = "0.1271", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 355, name = "BUDESONIDA", concentration = "64", units = "MCG/ DOSIS", price = "0.1778", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 356, name = "BUDESONIDA", concentration = "400", units = "MCG", price = "0.6842", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 357, name = "BUDESONIDA", concentration = "400", units = "MCG/ DOSIS", price = "0.0906", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 358, name = "BUDESONIDA", concentration = "50", units = "MCG", price = "2.1465", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 359, name = "BUDESONIDA + FORMOTEROL", concentration = "160", units = "MCG/ DOSIS", price = "0.4974", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 360, name = "BUDESONIDA + FORMOTEROL", concentration = "80", units = "MCG/ DOSIS", price = "0.4453", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 361, name = "BUDESONIDA + FORMOTEROL", concentration = "200", units = "MCG/ DOSIS", price = "1.1758", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 362, name = "BUDESONIDA + FORMOTEROL", concentration = "320", units = "MCG/ DOSIS", price = "1.065", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 363, name = "BUDESONIDA + FORMOTEROL", concentration = "400", units = "MCG/ DOSIS", price = "1.1588", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 364, name = "BUMETANIDA", concentration = "1", units = "MG", price = "0.4159", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 365, name = "BUMETANIDA", concentration = "1", units = "MG/EFP", price = "0.8401", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 366, name = "BUPIVACAINA", concentration = "1", units = "%", price = "0.2799", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 367, name = "BUPIVACAINA + DEXTROSA", concentration = "1", units = "%", price = "2.5194", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 368, name = "BUPIVACAINA + EPINEFRINA", concentration = "0", units = "%", price = "0.1906", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 369, name = "BUPROPION", concentration = "150", units = "MG", price = "1.9225", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 370, name = "BUPROPION", concentration = "300", units = "MG", price = "2.5827", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 371, name = "BUSPIRONA", concentration = "5", units = "MG", price = "0.5268", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 372, name = "BUSPIRONA", concentration = "10", units = "MG", price = "0.6824", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 373, name = "BUSPIRONA + CLIDINIO", concentration = "5", units = "MG", price = "0.4109", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 374, name = "BUTILHIOSCINA", concentration = "20", units = "MG/EFP", price = "2.7802", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 375, name = "BUTILHIOSCINA + ACETAMINOFEN [PARACETAMOL]", concentration = "2", units = "MG/ ML", price = "0.4802", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 376, name = "BUTILHIOSCINA + METAMIZOL SODICO", concentration = "4", units = "MG", price = "1.0304", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 377, name = "BUTILHIOSCINA + METAMIZOL SODICO", concentration = "7", units = "MG/ ML", price = "0.6406", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 378, name = "BUTILHIOSCINA + METAMIZOL SODICO", concentration = "10", units = "MG", price = "0.4604", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 379, name = "BUTILHIOSCINA + METAMIZOL SODICO", concentration = "10", units = "MG", price = "0.1205", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 380, name = "CABERGOLINA", concentration = "1", units = "MG", price = "7.9244", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 381, name = "CAFEDRINA + TEODRENALINA", concentration = "100", units = "MG", price = "0.3803", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 382, name = "CAFEINA + ACETAMINOFEN [PARACETAMOL] + ERGOTAMINA", concentration = "40", units = "MG", price = "0.3307", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 383, name = "CAFEINA + ERGOTAMINA", concentration = "100", units = "MG", price = "0.3123", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 384, name = "CAFEINA + ERGOTAMINA + IBUPROFENO", concentration = "100", units = "MG", price = "0.5292", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 385, name = "CAFEINA + METAMIZOL + ERGOTAMINA", concentration = "100", units = "MG", price = "0.496", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 386, name = "CALCIPOTRIOL", concentration = "0", units = "%", price = "1.0802", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 387, name = "CALCIPOTRIOL", concentration = "0", units = "%", price = "0.9819", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 388, name = "CANDESARTAN CILEXETILO", concentration = "8", units = "MG", price = "1.2078", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 389, name = "CANDESARTAN CILEXETILO", concentration = "16", units = "MG", price = "1.3087", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 390, name = "CANDESARTAN CILEXETILO", concentration = "32", units = "MG", price = "1.3014", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 391, name = "CANDESARTAN CILEXETILO + HIDROCLOROTIAZIDA", concentration = "16", units = "MG", price = "1.3163", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 392, name = "CANDESARTAN CILEXETILO + HIDROCLOROTIAZIDA", concentration = "32", units = "MG", price = "1.9177", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 393, name = "CANDESARTAN CILEXETILO + HIDROCLOROTIAZIDA", concentration = "32", units = "MG", price = "1.926", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 394, name = "CANDESARTAN CILEXETILO + HIDROCLOROTIAZIDA", concentration = "8", units = "MG", price = "1.2355", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 395, name = "CAPECITABINA", concentration = "500", units = "MG", price = "8.0375", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 396, name = "CAPTOPRIL", concentration = "25", units = "MG", price = "0.2429", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 397, name = "CAPTOPRIL", concentration = "50", units = "MG", price = "0.4113", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 398, name = "CARBAMAZEPINA", concentration = "200", units = "MG", price = "0.312", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 399, name = "CARBAMAZEPINA", concentration = "400", units = "MG", price = "0.4889", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 400, name = "CARBAMAZEPINA", concentration = "200", units = "MG", price = "0.6775", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 401, name = "CARBAMAZEPINA", concentration = "400", units = "MG", price = "1.1395", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 402, name = "CARBAMAZEPINA", concentration = "100", units = "MG/ 5 ML", price = "0.0955", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 403, name = "CARBENOXOLONA", concentration = "2", units = "%", price = "1.5666", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 404, name = "CARBIDOPA + LEVODOPA", concentration = "25", units = "MG", price = "1.1284", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 405, name = "CARBIDOPA + LEVODOPA", concentration = "50", units = "MG", price = "0.6354", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 406, name = "CARBIDOPA + LEVODOPA", concentration = "50", units = "MG", price = "1.2383", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 407, name = "CARBINOXAMINA + DEXTROMETORFANO", concentration = "2", units = "MG", price = "0.1296", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 408, name = "CARBOCISTEINA", concentration = "375", units = "MG", price = "0.4675", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 409, name = "CARBOCISTEINA", concentration = "250", units = "MG/ 5 ML", price = "0.061", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 410, name = "CARBOMER + MANITOL", concentration = "2", units = "%", price = "1.5534", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 411, name = "CARBOPLATINO", concentration = "150", units = "MG/EFP", price = "56.747", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 412, name = "CARBOPLATINO", concentration = "450", units = "MG/EFP", price = "170.241", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 413, name = "CARBOXIMETILCELULOSA", concentration = "1", units = "%", price = "1.0175", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 414, name = "CARBOXIMETILCELULOSA", concentration = "1", units = "%", price = "1.0185", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 415, name = "CARISOPRODOL + ACETAMINOFEN [PARACETAMOL]", concentration = "175", units = "MG", price = "0.347", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 416, name = "CARISOPRODOL + MELOXICAM", concentration = "200", units = "MG", price = "1.4927", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 417, name = "CARISOPRODOL + NAPROXENO", concentration = "200", units = "MG", price = "0.6172", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 418, name = "CARVEDILOL", concentration = "6", units = "MG", price = "0.529", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 419, name = "CARVEDILOL", concentration = "13", units = "MG", price = "0.6298", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 420, name = "CARVEDILOL", concentration = "25", units = "MG", price = "0.7472", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 421, name = "CEFACLOR", concentration = "500", units = "MG", price = "1.9759", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 422, name = "CEFACLOR", concentration = "250", units = "MG/ 5 ML", price = "0.248", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 423, name = "CEFADROXILO", concentration = "500", units = "MG", price = "0.7887", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 424, name = "CEFADROXILO", concentration = "125", units = "MG/ 5 ML", price = "0.1251", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 425, name = "CEFADROXILO", concentration = "250", units = "MG/ 5 ML", price = "0.1436", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 426, name = "CEFADROXILO", concentration = "500", units = "MG/ 5 ML", price = "0.3075", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 427, name = "CEFALEXINA", concentration = "500", units = "MG", price = "0.6494", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 428, name = "CEFALEXINA", concentration = "250", units = "MG/ 5 ML", price = "0.0965", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 429, name = "CEFAZOLINA", concentration = "1000", units = "MG/EFP", price = "1.3295", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 430, name = "CEFDINIR", concentration = "600", units = "MG", price = "5.2163", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 431, name = "CEFDINIR", concentration = "250", units = "MG/ 5 ML", price = "0.4485", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 432, name = "CEFEPIME", concentration = "1000", units = "MG/EFP", price = "4.6615", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 433, name = "CEFIXIMA", concentration = "200", units = "MG", price = "2.8875", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 434, name = "CEFIXIMA", concentration = "400", units = "MG", price = "4.7991", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 435, name = "CEFIXIMA", concentration = "100", units = "MG/ 5 ML", price = "0.4442", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 436, name = "CEFOTAXIMA", concentration = "1000", units = "MG/EFP", price = "9.3116", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 437, name = "CEFRADINE", concentration = "250", units = "MG/ 5 ML", price = "0.2029", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 438, name = "CEFTAZIDIMA", concentration = "1000", units = "MG/EFP", price = "12.2355", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 439, name = "CEFTRIAXONA", concentration = "500", units = "MG/EFP", price = "8.4338", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 440, name = "CEFTRIAXONA", concentration = "1000", units = "MG/EFP", price = "10.5166", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 441, name = "CEFTRIAXONA + LIDOCAINA", concentration = "1000", units = "MG+%/EFP", price = "12.3966", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 442, name = "CEFTRIAXONA + LIDOCAINA", concentration = "500", units = "MG+%/EFP", price = "9.1053", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 443, name = "CEFTRIAXONA", concentration = "250", units = "MG/EFP", price = "7.3475", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 444, name = "CEFUROXIMA", concentration = "750", units = "MG", price = "11.7275", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 445, name = "CEFUROXIMA AXETILO", concentration = "250", units = "MG", price = "1.5", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 446, name = "CEFUROXIMA AXETILO", concentration = "500", units = "MG", price = "2.4709", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 447, name = "CEFUROXIMA AXETILO", concentration = "125", units = "MG/ 5 ML", price = "0.21", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 448, name = "CEFUROXIMA AXETILO", concentration = "250", units = "MG/ 5 ML", price = "0.4075", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 449, name = "CEFUROXIMA AXETILO", concentration = "750", units = "MG/EFP", price = "11.7275", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 450, name = "CELECOXIB", concentration = "200", units = "MG", price = "1.538", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 451, name = "CETIRIZINA", concentration = "10", units = "MG/ ML", price = "0.7346", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 452, name = "CETRORELIX", concentration = "0", units = "MG/ EFP", price = "53.0815", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 453, name = "CICLOBENZAPRINA", concentration = "10", units = "MG", price = "0.5257", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 454, name = "CICLOFOSFAMIDA", concentration = "1000", units = "MG/EFP", price = "25.2517", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 455, name = "CICLOFOSFAMIDA", concentration = "500", units = "MG/EFP", price = "11.3672", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 456, name = "CICLOFOSFAMIDA", concentration = "50", units = "MG", price = "0.44", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 457, name = "CICLOPENTOLATO", concentration = "1", units = "%", price = "1.3625", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 458, name = "CICLOSPORINA", concentration = "0", units = "%", price = "4.2106", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 459, name = "CICLOSPORINA", concentration = "100", units = "MG/ ML", price = "7.1003", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 460, name = "CICLOSPORINA", concentration = "100", units = "MG", price = "7.8703", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 461, name = "CICLOSPORINA", concentration = "25", units = "MG", price = "2.4475", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 462, name = "CILASTATINA + IMIPENEM", concentration = "500", units = "MG/EFP", price = "29.7806", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 463, name = "CILOSTAZOL", concentration = "50", units = "MG", price = "0.525", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 464, name = "CILOSTAZOL", concentration = "100", units = "MG", price = "0.9833", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 465, name = "CIMETIDINA", concentration = "300", units = "MG", price = "0.1573", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 466, name = "CINARIZINA", concentration = "25", units = "MG", price = "0.1562", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 467, name = "CINARIZINA", concentration = "75", units = "MG", price = "0.4212", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 468, name = "CINARIZINA + DIHIDROERGOCRISTINA", concentration = "50", units = "MG", price = "0.524", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 469, name = "CINCOCAINA + DECUALINIO", concentration = "1", units = "%", price = "0.1775", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 470, name = "CINCOCAINA + POLICRESULENO", concentration = "5", units = "%", price = "1.4969", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 471, name = "CINCOCAINA + PREDNISOLONA", concentration = "2", units = "%", price = "0.7729", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 472, name = "CINCOCAINA + PREDNISOLONA", concentration = "1", units = "%", price = "0.7598", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 473, name = "CINITAPRIDA", concentration = "1", units = "MG", price = "0.5976", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 474, name = "CINITAPRIDA", concentration = "1", units = "MG/ 5 ML", price = "0.0583", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 475, name = "CINITAPRIDA + SIMETICONA + PANCREATINA", concentration = "1", units = "MG", price = "0.8788", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 476, name = "CIPERMETRINA", concentration = "0", units = "%", price = "0.0484", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 477, name = "CIPROFIBRATO", concentration = "100", units = "MG", price = "0.9148", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 478, name = "CIPROFLOXACINA", concentration = "750", units = "MG", price = "4.2547", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 479, name = "CIPROFLOXACINA", concentration = "500", units = "MG", price = "1.5304", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 480, name = "CIPROFLOXACINA", concentration = "1000", units = "MG", price = "6.6663", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 481, name = "CIPROFLOXACINA", concentration = "500", units = "MG", price = "3.7366", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 482, name = "CIPROFLOXACINA", concentration = "100", units = "MG/EFP", price = "26.7265", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 483, name = "CIPROFLOXACINA", concentration = "200", units = "MG/EFP", price = "29.4902", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 484, name = "CIPROFLOXACINA", concentration = "400", units = "MG/EFP", price = "51.4539", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 485, name = "CIPROFLOXACINA", concentration = "0", units = "%", price = "1.9065", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 486, name = "CIPROFLOXACINA", concentration = "0", units = "%", price = "2.2968", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 487, name = "CIPROFLOXACINA", concentration = "0", units = "%", price = "5.9913", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 488, name = "CIPROFLOXACINA + DEXAMETASONA", concentration = "0", units = "%", price = "3.8142", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 489, name = "CIPROFLOXACINA + FLUOCINOLONA", concentration = "0", units = "%", price = "1.4908", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 490, name = "CIPROFLOXACINA + HIDROCORTISONA", concentration = "0", units = "%", price = "1.5019", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 491, name = "CIPROFLOXACINA + HIDROCORTISONA", concentration = "2", units = "MG", price = "1.5594", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 492, name = "CIPROFLOXACINA + HIDROCORTISONA + LIDOCAINA", concentration = "0", units = "%", price = "1.2938", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 493, name = "CIPROHEPTADINA + COMPLEJO B", concentration = "4", units = "MG/ 5 ML", price = "0.0418", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 494, name = "CIPROTERONA", concentration = "50", units = "MG", price = "3.4907", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 495, name = "CIPROTERONA + ESTRADIOL", concentration = "1", units = "MG", price = "0.7614", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 496, name = "CIPROTERONA + ETINILESTRADIOL", concentration = "2", units = "MG", price = "0.6943", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 497, name = "CIPROTERONA + ETINILESTRADIOL", concentration = "2", units = "MG", price = "0.6411", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 498, name = "CISAPRIDA", concentration = "5", units = "MG", price = "0.3827", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 499, name = "CISAPRIDA", concentration = "25", units = "MG", price = "0.4814", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 500, name = "CISPLATINO", concentration = "50", units = "MG/EFP", price = "27.2147", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 501, name = "CITALOPRAM", concentration = "20", units = "MG", price = "1.2527", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 502, name = "CITARABINA", concentration = "100", units = "MG/EFP", price = "9.4964", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 503, name = "CITARABINA", concentration = "500", units = "MG/EFP", price = "42.978", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 504, name = "CITICOLINA", concentration = "500", units = "MG", price = "2.5213", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 505, name = "CITICOLINA", concentration = "100", units = "MG/ ML", price = "0.9559", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 506, name = "CITICOLINA", concentration = "1000", units = "MG/ EFP", price = "0.4863", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 507, name = "CITICOLINA", concentration = "1000", units = "MG/EFP", price = "8.3571", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 508, name = "CITICOLINA", concentration = "500", units = "MG/EFP", price = "4.4232", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 509, name = "CITIDINA + URIDINA", concentration = "10", units = "MG/EFP", price = "4.5708", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 510, name = "CITIDINA + URIDINA", concentration = "5", units = "MG", price = "0.4283", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 511, name = "CLARITROMICINA", concentration = "250", units = "MG", price = "1.9569", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 512, name = "CLARITROMICINA", concentration = "500", units = "MG", price = "2.2463", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 513, name = "CLARITROMICINA", concentration = "500", units = "MG", price = "4.7063", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 514, name = "CLARITROMICINA", concentration = "125", units = "MG/ 5 ML", price = "0.2699", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 515, name = "CLARITROMICINA", concentration = "250", units = "MG/ 5 ML", price = "0.47", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 516, name = "CLINDAMICINA", concentration = "300", units = "MG", price = "1.1041", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 517, name = "CLINDAMICINA", concentration = "75", units = "MG/ 5 ML", price = "0.1452", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 518, name = "CLINDAMICINA", concentration = "300", units = "MG/EFP", price = "3.9514", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 519, name = "CLINDAMICINA", concentration = "600", units = "MG/EFP", price = "4.5356", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 520, name = "CLINDAMICINA", concentration = "900", units = "MG/EFP", price = "4.8709", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 521, name = "CLINDAMICINA", concentration = "1", units = "%", price = "0.3839", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 522, name = "CLINDAMICINA", concentration = "2", units = "%", price = "0.3894", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 523, name = "CLINDAMICINA", concentration = "10", units = "MG/ ML", price = "0.3962", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 524, name = "CLINDAMICINA", concentration = "100", units = "MG/ OVULO", price = "3.9867", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 525, name = "CLINDAMICINA", concentration = "150", units = "MG", price = "0.9838", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 526, name = "CLINDAMICINA + CLOTRIMAZOL", concentration = "2", units = "%", price = "0.5925", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 527, name = "CLINDAMICINA + KETOCONAZOL", concentration = "2", units = "%", price = "0.6437", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 528, name = "CLINDAMICINA + KETOCONAZOL", concentration = "100", units = "MG /OVULO", price = "4.7625", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 529, name = "CLINDAMICINA + KETOCONAZOL", concentration = "100", units = "MG / OVULO", price = "7.8135", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 530, name = "CLIOQUINOL + CLOTRIMAZOL + HIDROCORTISONA + NEOMICINA", concentration = "3", units = "%", price = "0.1461", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 531, name = "CLIOQUINOL + HIDROCORTISONA", concentration = "3", units = "%", price = "0.3569", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 532, name = "CLOBAZAM", concentration = "10", units = "MG", price = "0.4113", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 533, name = "CLOBETASOL", concentration = "0", units = "%", price = "0.3621", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 534, name = "CLOBETASOL + MINOXIDIL + TRETINOINA", concentration = "0", units = "%", price = "0.2122", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 535, name = "CLOBETASOL + NEOMICINA", concentration = "50", units = "%", price = "0.159", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 536, name = "CLOMIFENO", concentration = "50", units = "MG", price = "2.1302", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 537, name = "CLOMIPRAMINA", concentration = "25", units = "MG", price = "0.5854", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 538, name = "CLOMIPRAMINA", concentration = "75", units = "MG", price = "2.4823", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 539, name = "CLONAZEPAM", concentration = "2", units = "MG", price = "0.3738", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 540, name = "CLONAZEPAM", concentration = "3", units = "MG/ ML", price = "1.0498", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 541, name = "CLONIDINA", concentration = "0", units = "MG", price = "0.2984", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 542, name = "CLONIXINATO DE LISINA", concentration = "100", units = "MG/EFP", price = "0.4697", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 543, name = "CLONIXINATO DE LISINA", concentration = "125", units = "MG", price = "0.4247", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 544, name = "CLONIXINATO DE LISINA + BUTILHIOSCINA", concentration = "125", units = "MG", price = "0.2476", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 545, name = "CLONIXINATO DE LISINA + BUTILHIOSCINA", concentration = "125", units = "MG/ EFP", price = "1.2414", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 546, name = "CLONIXINATO DE LISINA + CICLOBENZAPRINA", concentration = "125", units = "MG", price = "0.7299", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 547, name = "CLONIXINATO DE LISINA + CICLOBENZAPRINA", concentration = "125", units = "MG", price = "0.9629", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 548, name = "CLONIXINATO DE LISINA + ERGOTAMINA", concentration = "125", units = "MG", price = "0.563", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 549, name = "CLONIXINATO DE LISINA + ERGOTAMINA", concentration = "125", units = "MG", price = "1.0304", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 550, name = "CLONIXINATO DE LISINA + METAMIZOL", concentration = "10", units = "MG", price = "0.2197", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 551, name = "CLONIXINATO DE LISINA + ORFENADRINA + TRAMADOL", concentration = "125", units = "MG", price = "0.5869", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 552, name = "CLONIXINATO DE LISINA + PARGEVERINA (PROPINOXATO", concentration = "125", units = "MG", price = "0.3447", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 553, name = "CLONIXINATO DE LISINA + PARGEVERINA (PROPINOXATO", concentration = "100", units = "MG/EFP", price = "3.8026", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 554, name = "CLONIXINATO DE LISINA + PARGEVERINA (PROPINOXATO", concentration = "100", units = "MG/EFP", price = "5.2395", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 555, name = "CLONIXINATO DE LISINA + PARGEVERINA (PROPINOXATO", concentration = "125", units = "MG", price = "0.7627", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 556, name = "CLONIXINATO DE LISINA + TRAMADOL", concentration = "125", units = "MG", price = "0.6213", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 557, name = "CLONIXINATO DE LISINA + TRAMADOL", concentration = "125", units = "MG", price = "0.5811", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 558, name = "CLOPERASTINE", concentration = "18", units = "MG/ 5 ML", price = "0.0646", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 559, name = "CLOPIDOGREL", concentration = "300", units = "MG", price = "7.5888", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 560, name = "CLOPIDOGREL", concentration = "75", units = "MG", price = "1.8333", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 561, name = "CLORANFENICOL", concentration = "1000", units = "MG/EFP", price = "1.3181", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 562, name = "CLORANFENICOL", concentration = "1", units = "%", price = "0.3338", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 563, name = "CLORANFENICOL", concentration = "3", units = "MG/ UNIDAD", price = "0.0613", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 564, name = "CLORANFENICOL", concentration = "1", units = "%", price = "0.7893", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 565, name = "CLORANFENICOL", concentration = "1", units = "%", price = "0.59", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 566, name = "CLORANFENICOL", concentration = "10", units = "MG", price = "0.253", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 567, name = "CLORANFENICOL", concentration = "156", units = "MG/ 5 ML", price = "0.0981", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 568, name = "CLORANFENICOL", concentration = "250", units = "MG/ 5 ML", price = "0.0648", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 569, name = "CLORANFENICOL", concentration = "250", units = "MG", price = "0.0748", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 570, name = "CLORANFENICOL", concentration = "500", units = "MG", price = "0.0796", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 571, name = "CLORANFENICOL + BENZOCAINA", concentration = "0", units = "%", price = "0.1543", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 572, name = "CLORANFENICOL + COLAGENASA", concentration = "1", units = "%+UI", price = "0.9182", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 573, name = "CLORANFENICOL + DEXAMETASONA", concentration = "1", units = "%", price = "1.8731", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 574, name = "CLORANFENICOL + DEXAMETASONA", concentration = "1", units = "%", price = "1.5426", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 575, name = "CLORANFENICOL + DEXAMETASONA + FENILEFRINA", concentration = "0", units = "%", price = "1.8253", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 576, name = "CLORANFENICOL + DEXAMETASONA + NAFAZOLINA", concentration = "1", units = "%", price = "0.9479", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 577, name = "CLORANFENICOL + HIDROCORTISONA", concentration = "0", units = "%", price = "0.1946", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 578, name = "CLORANFENICOL + HIDROCORTISONA", concentration = "0", units = "%", price = "2.2445", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 579, name = "CLORANFENICOL + PREDNISOLONA", concentration = "3", units = "MG", price = "0.5768", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 580, name = "CLORANFENICOL + SULFACETAMIDA", concentration = "1", units = "%", price = "0.5692", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 581, name = "CLORDIAZEPOXIDO + CLIDINIO", concentration = "5", units = "MG", price = "0.3873", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 582, name = "CLORDIAZEPOXIDO + SIMETICONA + CLIDINIO", concentration = "5", units = "MG", price = "0.4475", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 583, name = "CLORFENAMINA + FENILEFRINA", concentration = "4", units = "MG/ 5 ML", price = "0.3386", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 584, name = "CLORFENAMINA + PREDNISOLONA", concentration = "1", units = "MG/ 5 ML", price = "0.0802", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 585, name = "CLORFENAMINA", concentration = "3", units = "MG/5ML", price = "0.063", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 586, name = "CLORFENIRAMINA", concentration = "8", units = "MG", price = "0.1979", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 587, name = "CLORFENIRAMINA", concentration = "8", units = "MG", price = "0.395", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 588, name = "CLORFENIRAMINA", concentration = "10", units = "MG/EFP", price = "3.4088", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 589, name = "CLORHEXIDINA + DEXAMETASONA + NISTATINA", concentration = "1", units = "%+%+UI", price = "0.25", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 590, name = "CLORMADINONA + ETINILESTRADIOL", concentration = "2", units = "MG", price = "0.8057", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 591, name = "CLORMADINONA + ETINILESTRADIOL", concentration = "2", units = "MG", price = "0.7121", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 592, name = "CLORMADINONA + ETINILESTRADIOL", concentration = "3", units = "MG", price = "0.7757", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 593, name = "CLORMEZANONA + METAMIZOL SODICO", concentration = "100", units = "MG", price = "0.3608", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 594, name = "CLOROQUINA", concentration = "250", units = "MG", price = "0.1116", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 595, name = "CLORPROMAZINA", concentration = "25", units = "MG", price = "0.198", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 596, name = "CLORPROMAZINA", concentration = "100", units = "MG", price = "0.5543", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 597, name = "CLORPROMAZINA", concentration = "50", units = "MG/EFP", price = "14.3963", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 598, name = "CLORPROMAZINA", concentration = "100", units = "MG", price = "0.6163", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 599, name = "CLORPROPAMIDA + METFORMINA", concentration = "125", units = "MG", price = "0.2774", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 600, name = "CLORURO DE SODIO", concentration = "20", units = "%", price = "0.0731", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 601, name = "CLORURO DE SODIO", concentration = "5", units = "%", price = "1.0828", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 602, name = "CLORURO DE SODIO", concentration = "5", units = "%", price = "1.7067", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 603, name = "CLOSTEBOL + NEOMICINA", concentration = "50", units = "%", price = "0.2276", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 604, name = "CLOSTEBOL + NEOMICINA", concentration = "50", units = "%", price = "0.2303", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 605, name = "CLOTRIMAZOL", concentration = "200", units = "MG/OVULO", price = "2.4403", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 606, name = "CLOTRIMAZOL", concentration = "500", units = "MG / OVULO", price = "2.3306", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 607, name = "CLOTRIMAZOL", concentration = "100", units = "MG/OVULO", price = "0.5622", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 608, name = "CLOTRIMAZOL + DEXAMETASONA", concentration = "1", units = "%", price = "0.0997", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 609, name = "CLOTRIMAZOL + DEXAMETASONA + GENTAMICINA", concentration = "20", units = "%", price = "0.4293", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 610, name = "CLOTRIMAZOL + DEXAMETASONA + NEOMICINA", concentration = "20", units = "%", price = "0.5749", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 611, name = "CLOTRIMAZOL + DEXAMETASONA + NEOMICINA", concentration = "1", units = "%", price = "0.4945", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 612, name = "CLOTRIMAZOL + METRONIDAZOL", concentration = "10", units = "%", price = "0.3942", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 613, name = "CLOTRIMAZOL + METRONIDAZOL", concentration = "100", units = "MG/OVULO", price = "1.4399", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 614, name = "CLOTRIMAZOL + SULFAFURAZOL", concentration = "50", units = "MG/OVULO", price = "1.6467", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 615, name = "CLOTRIMAZOL + TINIDAZOL", concentration = "100", units = "MG/OVULO", price = "0.4811", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 616, name = "CLOZAPINA", concentration = "25", units = "MG", price = "0.4725", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 617, name = "CLOZAPINA", concentration = "100", units = "MG", price = "1.6275", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 618, name = "CODEINA + ACETAMINOFEN [PARACETAMOL]", concentration = "30", units = "MG", price = "0.6849", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 619, name = "CODEINA + ACETAMINOFEN [PARACETAMOL]", concentration = "15", units = "MG", price = "0.2196", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 620, name = "CODEINA + DICLOFENACO POTASICO", concentration = "50", units = "MG", price = "1.0307", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 621, name = "CODEINA + DICLOFENACO SODICO", concentration = "50", units = "MG", price = "1.2423", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 622, name = "CODEINA + FENILTOLOXAMINA", concentration = "30", units = "MG", price = "0.7775", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 623, name = "CODEINA + GUAIFENESINA + FENILTOLOXAMINA", concentration = "30", units = "MG", price = "0.9605", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 624, name = "CODEINA + GUAIFENESINA + FENILTOLOXAMINA", concentration = "11", units = "MG/ 5 ML", price = "0.1663", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 625, name = "CODEINA + SULFOGUAYACOL", concentration = "3", units = "MG/ 5 ML", price = "0.0421", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 626, name = "COLCHICINA", concentration = "1", units = "MG", price = "0.4244", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 627, name = "COLESTIRAMINA", concentration = "4000", units = "MG/ EFP", price = "0.3267", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 628, name = "COMPLEJO B", concentration = "1", units = "MG/EFP", price = "3.6187", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 629, name = "COMPLEJO B", concentration = "10", units = "MG/ EFP", price = "5.173", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 630, name = "COMPLEJO B", concentration = "15", units = "MG/EFP", price = "5.6074", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 631, name = "COMPLEJO B", concentration = "25", units = "MG/ EFP", price = "8.6348", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 632, name = "COMPLEJO B", concentration = "5", units = "MG/EFP", price = "3.9108", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 633, name = "COMPLEJO B", concentration = "50", units = "MG/EFP", price = "7.9001", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 634, name = "COMPLEJO B", concentration = "10", units = "MG/ EFP", price = "7.0452", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 635, name = "COMPLEJO B", concentration = "25", units = "MG/ EFP", price = "10.5994", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 636, name = "COMPLEJO B + DEXAMETASONA", concentration = "0", units = "MG/ EFP", price = "6.0584", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 637, name = "COMPLEJO B + DEXAMETASONA + LIDOCAINA", concentration = "0", units = "MG/ EFP", price = "7.3349", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 638, name = "COMPLEJO B + DICLOFENACO", concentration = "0", units = "MG", price = "4.8196", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 639, name = "COMPLEJO B + DICLOFENACO + LIDOCAINA", concentration = "0", units = "MG/ EFP", price = "5.2991", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 640, name = "COMPLEJO B + DICLOFENACO + LIDOCAINA", concentration = "0", units = "MG/ EFP", price = "7.959", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 641, name = "COMPLEJO B + LIDOCAINA", concentration = "0", units = "MG/ EFP", price = "8.0815", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 642, name = "COMPLEJO B + LIDOCAINA", concentration = "0", units = "MG/ EFP", price = "3.2934", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 643, name = "COMPLEJO B + METAMIZOL SODICO", concentration = "0", units = "MG/EFP", price = "5.869", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 644, name = "DABIGATRAN ETEXILATO", concentration = "75", units = "MG", price = "1.7761", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 645, name = "DABIGATRAN ETEXILATO", concentration = "110", units = "MG", price = "1.7213", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 646, name = "DANAZOL", concentration = "200", units = "MG", price = "0.7013", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 647, name = "DEFERASIROX", concentration = "500", units = "MG", price = "62.7579", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 648, name = "DEFLAZACORT", concentration = "6", units = "MG", price = "1.2207", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 649, name = "DEFLAZACORT", concentration = "30", units = "MG", price = "3.9441", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 650, name = "DEFLAZACORT", concentration = "23", units = "MG/ ML", price = "2.2213", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 651, name = "DESLORATADINA", concentration = "3", units = "MG", price = "1.1393", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 652, name = "DESLORATADINA", concentration = "5", units = "MG", price = "1.3078", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 653, name = "DESLORATADINA", concentration = "3", units = "MG/ 5 ML", price = "0.1586", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 654, name = "DESLORATADINA", concentration = "5", units = "MG/ 5 ML", price = "0.1881", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 655, name = "DESOGESTREL", concentration = "0", units = "MG", price = "0.3975", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 656, name = "DESOGESTREL + ETINILESTRADIOL", concentration = "0", units = "MG", price = "0.5427", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 657, name = "DESONIDA", concentration = "0", units = "%", price = "0.6006", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 658, name = "DESONIDA", concentration = "0", units = "%", price = "0.7", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 659, name = "DESOXIMETASONA", concentration = "1", units = "%", price = "0.31", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 660, name = "DESVENLAFAXINA", concentration = "50", units = "MG", price = "2.9933", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 661, name = "DESVENLAFAXINA", concentration = "100", units = "MG", price = "3.7188", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 662, name = "DEXAMETASONA", concentration = "1", units = "MG", price = "0.2438", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 663, name = "DEXAMETASONA", concentration = "1", units = "MG", price = "0.1648", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 664, name = "DEXAMETASONA", concentration = "8", units = "MG/ EFP", price = "1.9407", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 665, name = "DEXAMETASONA", concentration = "0", units = "%", price = "0.2319", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 666, name = "DEXAMETASONA", concentration = "0", units = "%", price = "1.0041", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 667, name = "DEXAMETASONA", concentration = "4", units = "MG/ EFP", price = "1.6907", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 668, name = "DEXAMETASONA", concentration = "20", units = "MG/ EFP", price = "1.8496", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 669, name = "DEXAMETASONA + ACIDO SALICILICO", concentration = "0", units = "%", price = "0.5024", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 670, name = "DEXAMETASONA + ECONAZOL + METRONIDAZOL", concentration = "0", units = "%", price = "0.3467", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 671, name = "DEXAMETASONA + ECONAZOL + METRONIDAZOL", concentration = "0", units = "MG/OVULO", price = "1.7714", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 672, name = "DEXAMETASONA + FRAMICETINA", concentration = "1", units = "%", price = "0.4283", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 673, name = "DEXAMETASONA + GENTAMICINA", concentration = "0", units = "%", price = "1.7122", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 674, name = "DEXAMETASONA + GRAMICIDINA + NEOMICINA + POLIMIXINA B", concentration = "3", units = "MG+MG+MG+U", price = "1.3891", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 675, name = "DEXAMETASONA + KETOCONAZOL + NEOMICINA", concentration = "0", units = "%", price = "0.4126", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 676, name = "DEXAMETASONA + LIDOCAINA + COMPLEJO B", concentration = "4", units = "MG", price = "8.1877", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 677, name = "DEXAMETASONA + METAMIZOL SODICO + ACETAMINOFEN [PARACETAMOL]", concentration = "1", units = "MG", price = "0.0757", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 678, name = "DEXAMETASONA + METRONIDAZOL + MICONAZOL", concentration = "0", units = "MG+MG+%", price = "2.1811", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 679, name = "DEXAMETASONA + MOXIFLOXACINO", concentration = "0", units = "%", price = "4.5217", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 680, name = "DEXAMETASONA + NEOMICINA", concentration = "0", units = "%", price = "1.0511", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 681, name = "DEXAMETASONA + NEOMICINA", concentration = "0", units = "%", price = "1.7195", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 682, name = "DEXAMETASONA + NEOMICINA", concentration = "0", units = "%", price = "1.3792", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 683, name = "DEXAMETASONA + NEOMICINA", concentration = "0", units = "%", price = "1.7963", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 684, name = "DEXAMETASONA + NEOMICINA + POLIMIXINA B", concentration = "0", units = "%+%+UI", price = "3.4322", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 685, name = "DEXAMETASONA + NEOMICINA + POLIMIXINA B", concentration = "0", units = "%+%+UI", price = "5.3858", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 686, name = "DEXAMETASONA + NEOMICINA + POLIMIXINA B + FENILEFRINA", concentration = "0", units = "%+%+%+UI", price = "2.7432", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 687, name = "DEXAMETASONA + NISTATINA", concentration = "0", units = "MG+UI / OVULO", price = "0.3398", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 688, name = "DEXAMETASONA + SULFACETAMIDA", concentration = "0", units = "%", price = "0.8127", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 689, name = "DEXAMETASONA + SULFACETAMIDA", concentration = "0", units = "%", price = "0.9461", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 690, name = "DEXAMETASONA + TOBRAMICINA", concentration = "0", units = "%", price = "4.3638", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 691, name = "DEXAMETASONA + TOBRAMICINA", concentration = "0", units = "%", price = "2.8402", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 692, name = "DEXAMETASONA + TOBRAMICINA + NAFAZOLINA", concentration = "0", units = "%", price = "1.728", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 693, name = "DEXAMETASONA + TOBRAMICINA + NAFAZOLINA", concentration = "0", units = "%", price = "1.2035", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 694, name = "DEXKETOPROFENO TROMETAMOL", concentration = "25", units = "MG", price = "1.806", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 695, name = "DEXKETOPROFENO TROMETAMOL", concentration = "25", units = "MG/ EFP", price = "2.2213", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 696, name = "DEXKETOPROFENO TROMETAMOL", concentration = "50", units = "MG/EFP", price = "6.2106", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 697, name = "DEXTROMETORFANO", concentration = "15", units = "MG", price = "0.0575", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 698, name = "DEXTROMETORFANO + ACETAMINOFEN [PARACETAMOL] + DOXILAMINA + FENILEFRINA", concentration = "10", units = "MG", price = "0.2398", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 699, name = "DEXTROMETORFANO + ACETAMINOFEN [PARACETAMOL] + FENILEFRINA", concentration = "10", units = "MG", price = "0.3136", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 700, name = "DEXTROMETORFANO + EFEDRINA + GUAIFENESINA", concentration = "10", units = "MG/ 5 ML", price = "0.0393", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 701, name = "DEXTROPROPOXIFENO + ACETAMINOFEN [PARACETAMOL]", concentration = "65", units = "MG", price = "0.5544", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 702, name = "DEXTROPROPOXIFENO + ACETAMINOFEN [PARACETAMOL]", concentration = "60", units = "MG", price = "0.606", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 703, name = "DEXTROPROPOXIFENO + ACETAMINOFEN [PARACETAMOL]", concentration = "65", units = "MG", price = "0.5", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 704, name = "DEXTROPROPOXIFENO + METAMIZOL SODICO", concentration = "500", units = "MG", price = "0.4907", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 705, name = "DEXTROPROPOXIFENO + METAMIZOL SODICO", concentration = "98", units = "MG", price = "0.3595", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 706, name = "DEXTROSA [GLUCOSA]", concentration = "5", units = "%", price = "0.0063", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 707, name = "DEXTROSA [GLUCOSA]", concentration = "10", units = "%", price = "0.0032", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 708, name = "DEXTROSA [GLUCOSA]", concentration = "50", units = "%", price = "0.1208", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 709, name = "DIACEREINA", concentration = "50", units = "MG", price = "1.0715", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 710, name = "DIAZEPAM", concentration = "10", units = "MG", price = "0.2216", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 711, name = "DIAZEPAM", concentration = "10", units = "MG", price = "0.7452", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 712, name = "DIBITRATO DE ISOSORBIDE", concentration = "0", units = "%", price = "0.3787", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 713, name = "DICICLOVERINA + DOXILAMINA + PIRIDOXINA", concentration = "75", units = "MG", price = "0.3469", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 714, name = "DICLOFENAC POTASICO", concentration = "13", units = "MG", price = "0.9415", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 715, name = "DICLOFENAC SODICO", concentration = "13", units = "MG", price = "0.843", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 716, name = "DICLOFENACO + ACETAMINOFEN [PARACETAMOL]", concentration = "50", units = "MG", price = "0.2274", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 717, name = "DICLOFENACO + ACETAMINOFEN [PARACETAMOL]", concentration = "25", units = "MG", price = "0.2236", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 718, name = "DICLOFENACO + COMPLEJO B", concentration = "100", units = "MG", price = "1.0764", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 719, name = "DICLOFENACO + COMPLEJO B", concentration = "50", units = "MG", price = "0.3414", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 720, name = "DICLOFENACO + LIDOCAINA", concentration = "75", units = "MG/ EFP", price = "5.7426", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 721, name = "DICLOFENACO + ORFENADRINA", concentration = "25", units = "MG", price = "0.3466", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 722, name = "DICLOFENACO + PRIDINOL", concentration = "50", units = "MG/EFP", price = "5.615", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 723, name = "DICLOFENACO + TOBRAMICINA", concentration = "0", units = "%", price = "2.8957", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 724, name = "DICLOFENACO + TRAMADOL", concentration = "25", units = "MG", price = "1.5883", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 725, name = "DICLOFENACO POTASICO", concentration = "75", units = "MG/ EFP", price = "2.5218", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 726, name = "DICLOFENACO POTASICO", concentration = "10", units = "MG/ 5 ML", price = "0.0462", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 727, name = "DICLOFENACO POTASICO", concentration = "15", units = "MG/ ML", price = "0.3716", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 728, name = "DICLOFENACO POTASICO", concentration = "25", units = "MG/ 5 ML", price = "0.055", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 729, name = "DICLOFENACO POTASICO", concentration = "9", units = "MG/ 5 ML", price = "0.0693", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 730, name = "DICLOFENACO POTASICO", concentration = "100", units = "MG", price = "1.0916", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 731, name = "DICLOFENACO POTASICO", concentration = "100", units = "MG", price = "0.3265", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 732, name = "DICLOFENACO POTASICO", concentration = "25", units = "MG", price = "0.4524", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 733, name = "DICLOFENACO POTASICO", concentration = "50", units = "MG", price = "0.6366", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 734, name = "DICLOFENACO POTASICO", concentration = "75", units = "MG", price = "0.8239", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 735, name = "DICLOFENACO SODICO", concentration = "100", units = "MG / SUPOSITORIO", price = "0.8802", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 736, name = "DICLOFENACO SODICO", concentration = "50", units = "MG / SUPOSITORIO", price = "1.3825", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 737, name = "DICLOFENACO SODICO", concentration = "1", units = "MG/ ML", price = "2.3", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 738, name = "DICLOFENACO SODICO", concentration = "75", units = "MG/ EFP", price = "2.3239", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 739, name = "DICLOFENACO SODICO", concentration = "15", units = "MG/ ML", price = "0.3225", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 740, name = "DICLOFENACO SODICO", concentration = "9", units = "MG/ 5 ML", price = "0.0547", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 741, name = "DICLOFENACO SODICO", concentration = "100", units = "MG", price = "0.978", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 742, name = "DICLOFENACO SODICO", concentration = "75", units = "MG", price = "1.2453", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 743, name = "DICLOFENACO SODICO", concentration = "100", units = "MG", price = "0.673", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 744, name = "DICLOFENACO SODICO", concentration = "25", units = "MG", price = "0.2579", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 745, name = "DICLOFENACO SODICO", concentration = "50", units = "MG", price = "0.5311", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 746, name = "DICLOXACILINA", concentration = "500", units = "MG", price = "0.4816", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 747, name = "DICLOXACILINA", concentration = "125", units = "MG/ 5 ML", price = "0.1038", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 748, name = "DICLOXACILINA", concentration = "250", units = "MG/ 5 ML", price = "0.1397", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 749, name = "DICLOXACILINA", concentration = "250", units = "MG", price = "0.2045", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 750, name = "DIENOGEST", concentration = "2", units = "MG", price = "2.1786", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 751, name = "DIENOGEST + ETINILESTRADIOL", concentration = "2", units = "MG", price = "0.7949", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 752, name = "DIFENIDOL", concentration = "25", units = "MG", price = "0.243", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 753, name = "DIFLORASONA", concentration = "2", units = "%", price = "0.6408", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 754, name = "DIGOXINA", concentration = "0", units = "MG", price = "0.2317", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 755, name = "DIGOXINA", concentration = "1", units = "MG/EFP", price = "1.6263", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 756, name = "DIHIDROERGOCRISTINA + LOMIFILINA", concentration = "80", units = "MG", price = "0.9533", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 757, name = "DILOXANIDA", concentration = "200", units = "MG", price = "0.1834", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 758, name = "DILOXANIDA", concentration = "500", units = "MG", price = "0.2171", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 759, name = "DILOXANIDA", concentration = "250", units = "MG/ 5 ML", price = "0.077", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 760, name = "DILOXANIDA", concentration = "200", units = "MG/ 5 ML", price = "0.0685", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 761, name = "DILOXANIDA + METRONIDAZOL", concentration = "250", units = "MG", price = "0.2364", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 762, name = "DILOXANIDA + METRONIDAZOL", concentration = "250", units = "MG", price = "0.2273", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 763, name = "DILOXANIDA + METRONIDAZOL", concentration = "500", units = "MG", price = "0.3049", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 764, name = "DILOXANIDA + METRONIDAZOL", concentration = "100", units = "MG/ 5 ML", price = "0.0714", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 765, name = "DILOXANIDA + METRONIDAZOL", concentration = "125", units = "MG/ 5 ML", price = "0.0635", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 766, name = "DILOXANIDA + SECNIDAZOL", concentration = "5", units = "MG", price = "0.3801", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 767, name = "DILOXANIDA + TINIDAZOL", concentration = "500", units = "MG", price = "0.2066", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 768, name = "DILTIAZEM", concentration = "60", units = "MG", price = "0.4145", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 769, name = "DILTIAZEM", concentration = "90", units = "MG", price = "0.8196", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 770, name = "DILTIAZEM", concentration = "120", units = "MG", price = "0.7313", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 771, name = "DILTIAZEM", concentration = "180", units = "MG", price = "1.6454", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 772, name = "DILTIAZEM", concentration = "240", units = "MG", price = "1.624", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 773, name = "DIMENHIDRINATO", concentration = "15", units = "MG/ 5 ML", price = "0.1347", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 774, name = "DIMENHIDRINATO", concentration = "25", units = "MG/ 5 ML", price = "0.1438", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 775, name = "DIMENHIDRINATO", concentration = "25", units = "MG /SUPOSITORIO", price = "0.6881", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 776, name = "DIMENHIDRINATO", concentration = "50", units = "MG / SUPOSITORIO", price = "0.5793", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 777, name = "DIMENHIDRINATO", concentration = "100", units = "MG/EFP", price = "2.0678", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 778, name = "DIMENHIDRINATO", concentration = "250", units = "MG/EFP", price = "2.5264", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 779, name = "DINITRATO DE ISOSORBIDE", concentration = "5", units = "MG", price = "0.1206", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 780, name = "DINITRATO DE ISOSORBIDE", concentration = "10", units = "MG", price = "0.3388", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 781, name = "DINITRATO DE ISOSORBIDE", concentration = "40", units = "MG", price = "0.725", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 782, name = "DIOSMINA", concentration = "600", units = "MG", price = "1.135", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 783, name = "DIOSMINA + FLAVONA", concentration = "450", units = "MG", price = "0.7102", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 784, name = "DIOSMINA + HESPERIDINA", concentration = "450", units = "MG", price = "0.7638", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 785, name = "DIYODOHIDROXIQUINOLEINA + METRONIDAZOL", concentration = "210", units = "MG/ 5 ML", price = "0.0418", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 786, name = "DIYODOHIDROXIQUINOLEINA + NISTATINA", concentration = "4", units = "%+UI", price = "0.0878", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 787, name = "DOBESILATO DE CALCIO", concentration = "500", units = "MG", price = "1.0138", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 788, name = "DOBESILATO DE CALCIO + LIDOCAINA", concentration = "4", units = "%", price = "0.3002", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 789, name = "DOCETAXEL", concentration = "20", units = "MG/EFP", price = "195.975", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 790, name = "DOCETAXEL", concentration = "80", units = "MG/EFP", price = "814.403", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 791, name = "DOCUSATO + SENOSIDOS A Y B", concentration = "50", units = "MG", price = "0.559", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 792, name = "DOCUSATO + SORBITOL", concentration = "0", units = "%", price = "0.0899", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 793, name = "DOMPERIDONA", concentration = "10", units = "MG", price = "0.3591", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 794, name = "DOMPERIDONA", concentration = "5", units = "MG/ 5 ML", price = "0.1552", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 795, name = "DONEPEZILO", concentration = "5", units = "MG", price = "4.0004", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 796, name = "DONEPEZILO", concentration = "10", units = "MG", price = "4.0164", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 797, name = "DORIPENEM", concentration = "500", units = "MG/EFP", price = "62.8864", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 798, name = "DORZOLAMIDA", concentration = "2", units = "%", price = "5.758", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 799, name = "DORZOLAMIDA", concentration = "2", units = "%", price = "5.758", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 800, name = "DORZOLAMIDA + TIMOLOL", concentration = "2", units = "%", price = "5.8898", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 801, name = "DORZOLAMIDA + TIMOLOL", concentration = "2", units = "%", price = "8.484", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 802, name = "DOXAZOSINA", concentration = "2", units = "MG", price = "1.4191", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 803, name = "DOXAZOSINA", concentration = "4", units = "MG", price = "2.1015", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 804, name = "DOXICICLINA", concentration = "100", units = "MG", price = "0.705", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 805, name = "DOXICICLINA", concentration = "200", units = "MG", price = "1.0939", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 806, name = "DOXICICLINA", concentration = "50", units = "MG", price = "1.3294", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 807, name = "DOXILAMINA + HIOSCIAMINA", concentration = "10", units = "MG/ 5 ML", price = "0.4846", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 808, name = "DOXORRUBICINA", concentration = "10", units = "MG/EFP", price = "29.1154", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 809, name = "DOXORRUBICINA", concentration = "50", units = "MG/ EFP", price = "127.221", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 810, name = "DOXORRUBICINA PEGILADA", concentration = "20", units = "MG/EFP", price = "709.254", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 811, name = "DROPROPIZINA", concentration = "30", units = "MG", price = "0.9175", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 812, name = "DROPROPIZINA", concentration = "15", units = "MG/ 5 ML", price = "0.1162", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 813, name = "DROSPIRENONA + ESTRADIOL", concentration = "2", units = "MG", price = "0.9231", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 814, name = "DROSPIRENONA + ETINILESTRADIOL", concentration = "3", units = "MG", price = "0.781", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 815, name = "DULOXETINA", concentration = "30", units = "MG", price = "2.2946", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 816, name = "DULOXETINA", concentration = "60", units = "MG", price = "2.259", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 817, name = "DULOXETINA", concentration = "60", units = "MG", price = "3.5558", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 818, name = "DULOXETINA", concentration = "30", units = "MG", price = "3.0979", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 819, name = "DUTASTERIDE", concentration = "1", units = "MG", price = "1.8012", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 820, name = "EBASTINA", concentration = "20", units = "MG", price = "1.3125", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 821, name = "EMOLIENTE + LUBRICANTES + FENAZONA", concentration = "60", units = "%", price = "0.4177", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 822, name = "ENALAPRIL", concentration = "5", units = "MG", price = "0.2287", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 823, name = "ENALAPRIL", concentration = "10", units = "MG", price = "0.3175", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 824, name = "ENALAPRIL", concentration = "20", units = "MG", price = "0.5126", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 825, name = "ENALAPRIL", concentration = "3", units = "MG/EFP", price = "18.7372", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 826, name = "ENALAPRIL + NITRENDIPINO", concentration = "10", units = "MG", price = "1.5312", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 827, name = "ENOXOLONA + LEVOMENOL", concentration = "5", units = "%", price = "0.7644", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 828, name = "ENTACAPONA", concentration = "200", units = "MG", price = "2.14", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 829, name = "EPINASTINA", concentration = "20", units = "MG", price = "1.5161", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 830, name = "EPINASTINA", concentration = "10", units = "MG/ 5 ML", price = "0.2596", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 831, name = "EPINASTINA", concentration = "0", units = "%", price = "2.4862", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 832, name = "EPINEFRINA", concentration = "1", units = "MG/EFP", price = "1.2305", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 833, name = "EPINEFRINA + LIDOCAINA", concentration = "0", units = "MG/ EFP", price = "0.5855", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 834, name = "EPIRUBICINA", concentration = "10", units = "MG/EFP", price = "30.194", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 835, name = "EPIRUBICINA", concentration = "50", units = "MG/EFP", price = "143.793", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 836, name = "ERGOTAMINA + PROPIFENAZONA", concentration = "1", units = "MG", price = "0.5892", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 837, name = "ERITROMICINA", concentration = "500", units = "MG", price = "0.5002", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 838, name = "ERITROMICINA", concentration = "125", units = "MG/ 5 ML", price = "0.0485", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 839, name = "ERITROMICINA", concentration = "250", units = "MG/ 5 ML", price = "0.0756", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 840, name = "ERITROMICINA", concentration = "1", units = "%", price = "0.2212", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 841, name = "ERITROMICINA", concentration = "3", units = "%", price = "0.3173", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 842, name = "ERITROMICINA", concentration = "4", units = "%", price = "0.4693", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 843, name = "ERITROMICINA", concentration = "1", units = "%", price = "1.6022", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 844, name = "ERITROMICINA", concentration = "5", units = "%", price = "2.9892", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 845, name = "ERITROMICINA", concentration = "2", units = "%", price = "0.2", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 846, name = "ERITROMICINA", concentration = "1", units = "%", price = "2.1478", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 847, name = "ERITROMICINA", concentration = "200", units = "MG/ 5 ML", price = "0.0389", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 848, name = "ERITROMICINA", concentration = "250", units = "MG", price = "0.1536", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 849, name = "ERITROMICINA + TRETINOINA", concentration = "4", units = "%", price = "0.4563", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 850, name = "ERLOTINIB", concentration = "150", units = "MG", price = "106.041", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 851, name = "ERTAPENEM", concentration = "1000", units = "MG/EFP", price = "72.4331", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 852, name = "ESCITALOPRAM", concentration = "10", units = "MG", price = "2.1405", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 853, name = "ESCITALOPRAM", concentration = "20", units = "MG", price = "3.9011", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 854, name = "ESOMEPRAZOL", concentration = "20", units = "MG", price = "1.0949", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 855, name = "ESOMEPRAZOL", concentration = "40", units = "MG", price = "1.6994", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 856, name = "ESOMEPRAZOL", concentration = "40", units = "MG/EFP", price = "18.9759", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 857, name = "ESOMEPRAZOL", concentration = "10", units = "MG/ EFP", price = "1.86", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 858, name = "ESOMEPRAZOL", concentration = "20", units = "MG", price = "1.57", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 859, name = "ESOMEPRAZOL", concentration = "40", units = "MG", price = "2.46", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 860, name = "ESOMEPRAZOL + NAPROXENO", concentration = "20", units = "MG", price = "1.6248", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 861, name = "ESOMEPRAZOL", concentration = "10", units = "MG/EFP", price = "1.5672", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 862, name = "ESPIRONOLACTONA", concentration = "25", units = "MG", price = "0.5913", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 863, name = "ESPIRONOLACTONA", concentration = "100", units = "MG", price = "1.0125", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 864, name = "ESTRADIOL", concentration = "1", units = "MG", price = "0.3792", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 865, name = "ESTRADIOL", concentration = "1", units = "MG", price = "0.4352", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 866, name = "ESTRADIOL", concentration = "2", units = "MG", price = "0.4431", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 867, name = "ESTRADIOL", concentration = "5", units = "MG/EFP", price = "13.3938", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 868, name = "ESTRADIOL", concentration = "0", units = "%", price = "0.2638", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 869, name = "ESTRADIOL", concentration = "0", units = "%", price = "0.196", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 870, name = "ESTRADIOL", concentration = "50", units = "MCG/ PARCHE", price = "5.4242", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 871, name = "ESTRADIOL + HIDROXIPROGESTERONA", concentration = "5", units = "MG/EFP", price = "3.4122", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 872, name = "ESTRADIOL + HIDROXIPROGESTERONA", concentration = "10", units = "MG/ EFP", price = "6.5193", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 873, name = "ESTRADIOL + HIDROXIPROGESTERONA", concentration = "10", units = "MG/ EFP", price = "8", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 874, name = "ESTRADIOL + MEDROXIPROGESTERONA", concentration = "5", units = "MG/EFP", price = "10.6535", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 875, name = "ESTRADIOL + NORETISTERONA", concentration = "1", units = "MG", price = "0.2519", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 876, name = "ESTRADIOL + NORETISTERONA", concentration = "2", units = "MG", price = "0.6105", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 877, name = "ESTRADIOL + NORETISTERONA", concentration = "2", units = "MG", price = "0.8152", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 878, name = "ESTRADIOL + NORETISTERONA", concentration = "5", units = "MG/ EFP", price = "5.0069", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 879, name = "ESTRADIOL + NORETISTERONA", concentration = "3", units = "MG/ OVULO", price = "5.0766", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 880, name = "ESTRADIOL + NORETISTERONA", concentration = "5", units = "MG/ EFP", price = "6.93", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 881, name = "ESTRADIOL + NORGESTREL", concentration = "2", units = "MG", price = "0.6496", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 882, name = "ESTRADIOL + PRASTERONA", concentration = "4", units = "MG/EFP", price = "18.8368", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 883, name = "ESTRADIOL + PROGESTERONA", concentration = "30", units = "MG/EFP", price = "12.709", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 884, name = "ESTRADIOL + PROGESTERONA", concentration = "5", units = "MG/EFP", price = "5.5576", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 885, name = "ESTRADIOL VALERATO + DIENOGEST", concentration = "0", units = "MG", price = "25.0173", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 886, name = "ESTRIOL", concentration = "0", units = "%", price = "1.2898", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 887, name = "ESTRIOL", concentration = "1", units = "%", price = "1.5408", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 888, name = "ESTRIOL", concentration = "1", units = "MG/ OVULO", price = "1.3499", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 889, name = "ESZOPICLONA", concentration = "2", units = "MG", price = "1.0962", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 890, name = "ESZOPICLONA", concentration = "3", units = "MG", price = "0.9331", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 891, name = "ETAMSILATO", concentration = "500", units = "MG", price = "1.5914", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 892, name = "ETAMSILATO", concentration = "250", units = "MG/EFP", price = "4.0072", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 893, name = "ETILEFRINA", concentration = "5", units = "MG", price = "0.3692", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 894, name = "ETILEFRINA", concentration = "8", units = "MG/ ML", price = "0.4801", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 895, name = "ETILEFRINA", concentration = "10", units = "MG/EFP", price = "7.0417", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 896, name = "ETINILESTRADIOL + ETISTERONA", concentration = "0", units = "MG", price = "1.4407", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 897, name = "ETINILESTRADIOL + ETONOGESTREL", concentration = "0", units = "MG/ OVULO", price = "22.441", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 898, name = "ETINILESTRADIOL + GESTODENO", concentration = "0", units = "MG", price = "0.582", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 899, name = "ETINILESTRADIOL + GESTODENO", concentration = "0", units = "MG", price = "0.6058", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 900, name = "ETINILESTRADIOL + LEVONORGESTREL", concentration = "0", units = "MG", price = "0.242", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 901, name = "ETINILESTRADIOL + LEVONORGESTREL", concentration = "0", units = "MG", price = "0.3067", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 902, name = "ETINILESTRADIOL + LEVONORGESTREL", concentration = "0", units = "MG", price = "0.4418", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 903, name = "ETINILESTRADIOL + NORELGESTROMINA", concentration = "600", units = "MG/ OVULO", price = "9.2014", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 904, name = "ETINILESTRADIOL + NORETISTERONA", concentration = "0", units = "MG", price = "0.4022", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 905, name = "ETINILESTRADIOL + NORGESTIMATO", concentration = "0", units = "MG", price = "0.5118", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 906, name = "ETINILESTRADIOL + NORGESTREL", concentration = "50", units = "MCG+MG", price = "0.3603", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 907, name = "ETOFENAMATO", concentration = "1000", units = "MG/EFP", price = "4.2715", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 908, name = "ETOFENAMATO", concentration = "5", units = "%", price = "0.2651", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 909, name = "ETOPOSIDO", concentration = "100", units = "MG/EFP", price = "29.3734", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 910, name = "ETORICOXIB", concentration = "30", units = "MG", price = "2.0063", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 911, name = "ETORICOXIB", concentration = "60", units = "MG", price = "2.0775", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 912, name = "ETORICOXIB", concentration = "90", units = "MG", price = "2.6538", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 913, name = "ETORICOXIB", concentration = "120", units = "MG", price = "3.7238", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 914, name = "EVEROLIMUS", concentration = "0", units = "MG", price = "3.3991", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 915, name = "EVEROLIMUS", concentration = "1", units = "MG", price = "7.0208", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 916, name = "EVEROLIMUS", concentration = "1", units = "MG", price = "11.5636", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 917, name = "EVEROLIMUS", concentration = "10", units = "MG", price = "242.79", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 918, name = "EXEMESTANO", concentration = "25", units = "MG", price = "5.4125", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 919, name = "EZETIMIBA", concentration = "10", units = "MG", price = "1.8975", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 920, name = "EZETIMIBE + SIMVASTATINA", concentration = "10", units = "MG", price = "1.9921", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 921, name = "EZETIMIBE + SIMVASTATINA", concentration = "10", units = "MG", price = "3.5999", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 922, name = "EZETIMIBE + SIMVASTATINA", concentration = "10", units = "MG", price = "1.6867", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 923, name = "EZETIMIBE + SIMVASTATINA", concentration = "10", units = "MG", price = "4.373", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 924, name = "FAMOTIDINA", concentration = "20", units = "MG", price = "0.3799", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 925, name = "FAMOTIDINA", concentration = "40", units = "MG", price = "0.4361", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 926, name = "FELODIPINA", concentration = "5", units = "MG", price = "1.2362", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 927, name = "FELODIPINA", concentration = "10", units = "MG", price = "1.7986", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 928, name = "FENAZOPIRIDINA", concentration = "200", units = "MG", price = "0.2451", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 929, name = "FENILEFRINA + PREDNISOLONA", concentration = "0", units = "%", price = "1.6375", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 930, name = "FENILEFRINA + SULFACETAMIDA", concentration = "0", units = "%", price = "0.6432", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 931, name = "FENILEFRINA + TROPICAMIDA", concentration = "10", units = "%", price = "0.7129", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 932, name = "FENITOINA", concentration = "100", units = "MG", price = "0.1313", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 933, name = "FENITOINA", concentration = "125", units = "MG/ 5 ML", price = "0.1018", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 934, name = "FENITOINA", concentration = "250", units = "MG/EFP", price = "13.3627", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 935, name = "FENITOINA", concentration = "125", units = "MG/ 5 ML", price = "0.1068", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 936, name = "FENITOINA", concentration = "100", units = "MG", price = "0.2643", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 937, name = "FENOBARBITAL", concentration = "20", units = "MG", price = "0.2663", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 938, name = "FENOBARBITAL", concentration = "100", units = "MG", price = "0.0778", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 939, name = "FENOBARBITAL", concentration = "20", units = "MG/ 5 ML", price = "0.03", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 940, name = "FENOFIBRATO", concentration = "250", units = "MG", price = "0.8938", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 941, name = "FENOFIBRATO MICRONIZADO", concentration = "250", units = "MG", price = "0.6059", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 942, name = "FENOFIBRATO MICRONIZADO", concentration = "200", units = "MG", price = "0.6664", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 943, name = "FENOFIBRATO MICRONIZADO", concentration = "160", units = "MG", price = "1.0584", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 944, name = "FENOTEROL", concentration = "5", units = "MG", price = "0.4275", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 945, name = "FENOTEROL", concentration = "1", units = "MG/EFP", price = "7.1418", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 946, name = "FENOTEROL + BROMURO DE IPRATROPIO", concentration = "0", units = "MG/ DOSIS", price = "0.0747", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 947, name = "FENTANILO", concentration = "17", units = "MG/ PARCHE", price = "44.1038", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 948, name = "FENTANILO", concentration = "4", units = "MG/ PARCHE", price = "16.175", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 949, name = "FENTANILO", concentration = "8", units = "MG/ PARCHE", price = "27.4637", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 950, name = "FENTANILO", concentration = "13", units = "MG/ PARCHE", price = "31.1997", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 951, name = "FENTANILO", concentration = "0", units = "MG/EFP", price = "0.8724", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 952, name = "FENTANILO", concentration = "1", units = "MG/EFP", price = "9.6", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 953, name = "FEXOFENADINA", concentration = "180", units = "MG", price = "1.6001", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 954, name = "FEXOFENADINA", concentration = "120", units = "MG", price = "1.098", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 955, name = "FEXOFENADINA", concentration = "30", units = "MG/ 5 ML", price = "0.127", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 956, name = "FEXOFENADINA + FENILEFRINA", concentration = "60", units = "MG", price = "1.5953", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 957, name = "FEXOFENADINA + FENILEFRINA", concentration = "30", units = "MG/ 5 ML", price = "0.1622", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 958, name = "FINASTERIDA", concentration = "1", units = "MG", price = "2.141", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 959, name = "FINASTERIDA", concentration = "5", units = "MG", price = "2.1792", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 960, name = "FITOMENADIONA [VITAMINA K]", concentration = "10", units = "MG/EFP", price = "1.5", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 961, name = "FLAVOXATO", concentration = "200", units = "MG", price = "0.4926", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 962, name = "FLECAINIDA", concentration = "100", units = "MG", price = "0.8592", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 963, name = "FLUCONAZOL", concentration = "200", units = "MG", price = "7.2961", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 964, name = "FLUCONAZOL", concentration = "50", units = "MG/ 5 ML", price = "0.885", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 965, name = "FLUCONAZOL", concentration = "200", units = "MG/EFP", price = "47.6338", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 966, name = "FLUCONAZOL + TINIDAZOL", concentration = "150", units = "MG", price = "7.758", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 967, name = "FLUDARABINA", concentration = "50", units = "MG/EFP", price = "415.33", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 968, name = "FLUMAZENIL", concentration = "1", units = "MG/EFP", price = "46.6862", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 969, name = "FLUNARIZINA", concentration = "5", units = "MG", price = "0.5862", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 970, name = "FLUNARIZINA", concentration = "10", units = "MG", price = "0.6729", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 971, name = "FLUOCINONIDA", concentration = "0", units = "%", price = "0.5758", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 972, name = "FLUOCINONIDA + NEOMICINA + GRAMICIDINA + NISTATINA", concentration = "0", units = "%", price = "0.6208", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 973, name = "FLUOROMETOLONA", concentration = "0", units = "%", price = "2.7576", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 974, name = "FLUOROMETOLONA + NEOMICINA", concentration = "0", units = "%", price = "1.9556", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 975, name = "FLUOROMETOLONA + TETRIZOLINA", concentration = "1", units = "%", price = "1.6888", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 976, name = "FLUOROURACILO", concentration = "500", units = "MG/EFP", price = "12.385", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 977, name = "FLUOROURACILO", concentration = "5", units = "%", price = "1.0871", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 978, name = "FLUOXETINA", concentration = "20", units = "MG", price = "0.7974", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 979, name = "FLURBIPROFENO", concentration = "100", units = "MG", price = "0.8619", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 980, name = "FLUTAMIDA", concentration = "250", units = "MG", price = "1.4499", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 981, name = "FLUTICASONA", concentration = "0", units = "%", price = "1.0038", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 982, name = "FLUTICASONA", concentration = "125", units = "MCG/ DOSIS", price = "0.4827", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 983, name = "FLUTICASONA", concentration = "250", units = "MCG/ DOSIS", price = "0.6762", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 984, name = "FLUTICASONA", concentration = "50", units = "MCG/ DOSIS", price = "0.2211", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 985, name = "FLUTICASONA", concentration = "125", units = "MCG/ DOSIS", price = "0.5642", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 986, name = "FLUTICASONA", concentration = "250", units = "MCG/ DOSIS", price = "0.6762", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 987, name = "FLUTICASONA", concentration = "50", units = "MCG/ DOSIS", price = "0.3209", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 988, name = "FLUTICASONA + SALMETEROL", concentration = "125", units = "MCG/ DOSIS", price = "0.5599", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 989, name = "FLUTICASONA + SALMETEROL", concentration = "500", units = "MCG/ DOSIS", price = "1.2426", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 990, name = "FLUTICASONA + SALMETEROL", concentration = "50", units = "MCG/ DOSIS", price = "0.5328", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 991, name = "FLUTICASONA + SALMETEROL", concentration = "100", units = "MCG/ DOSIS", price = "1.1293", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 992, name = "FLUTICASONA + SALMETEROL", concentration = "250", units = "MCG/ DOSIS", price = "0.6117", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 993, name = "FLUTICASONA + SALMETEROL", concentration = "250", units = "MCG/ DOSIS", price = "1.1377", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 994, name = "FLUTICASONA MICRONIZADA", concentration = "0", units = "%", price = "1.0038", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 995, name = "FLUVOXAMINA", concentration = "100", units = "MG", price = "1.7417", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 996, name = "FOLINATO CALCICO", concentration = "50", units = "MG/EFP", price = "22.5", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 997, name = "FONDAPARINUX SODICO", concentration = "3", units = "MG/EFP", price = "20.0972", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 998, name = "FORMOTEROL", concentration = "9", units = "MCG/ DOSIS", price = "0.585", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 999, name = "FORMOTEROL", concentration = "12", units = "MCG/ DOSIS", price = "0.6372", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1000, name = "FOSFOMICINA", concentration = "500", units = "MG", price = "1.6172", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1001, name = "FOSFOMICINA", concentration = "3000", units = "MG/ EFP", price = "20.788", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1002, name = "FOSFOMICINA", concentration = "250", units = "MG/ 5 ML", price = "0.1637", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1003, name = "FOSFOMICINA + LIDOCAINA", concentration = "1000", units = "MG/ EFP", price = "7.718", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1004, name = "FOSFOMICINA + LIDOCAINA", concentration = "500", units = "MG/ EFP", price = "4.7605", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1005, name = "FROVATRIPTAN", concentration = "3", units = "MG", price = "11.6563", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1006, name = "FULVESTRANT", concentration = "250", units = "MG/EFP", price = "854.526", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1007, name = "FUROSEMIDA", concentration = "40", units = "MG", price = "0.1856", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1008, name = "FUROSEMIDA", concentration = "20", units = "MG/EFP", price = "1.1722", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1009, name = "FUROSEMIDA + ESPIRONOLACTONA", concentration = "20", units = "MG", price = "1.1929", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1010, name = "GABAPENTINA", concentration = "600", units = "MG", price = "1.9648", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1011, name = "GABAPENTINA", concentration = "300", units = "MG", price = "0.9818", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1012, name = "GABAPENTINA", concentration = "400", units = "MG", price = "1.0827", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1013, name = "GABAPENTINA", concentration = "800", units = "MG", price = "2.6822", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1014, name = "GABAPENTINA + COMPLEJO B", concentration = "300", units = "MG", price = "1.0705", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1015, name = "GALANTAMINA", concentration = "8", units = "MG", price = "5.6763", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1016, name = "GALANTAMINA", concentration = "16", units = "MG", price = "0.9831", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1017, name = "GANCICLOVIR", concentration = "500", units = "MG/EFP", price = "100.89", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1018, name = "GATIFLOXACINA", concentration = "0", units = "%", price = "2.6147", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1019, name = "GEMCITABINA", concentration = "200", units = "MG/EFP", price = "84.1626", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1020, name = "GEMCITABINA", concentration = "1000", units = "MG/EFP", price = "280.554", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1021, name = "GEMFIBROZIL", concentration = "300", units = "MG", price = "0.5495", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1022, name = "GEMFIBROZIL", concentration = "600", units = "MG", price = "0.6307", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1023, name = "GEMFIBROZIL", concentration = "900", units = "MG", price = "0.8725", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1024, name = "GENTAMICINA", concentration = "80", units = "MG/EFP", price = "2.4", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1025, name = "GENTAMICINA", concentration = "160", units = "MG/EFP", price = "4.6044", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1026, name = "GENTAMICINA", concentration = "0", units = "%", price = "1.2439", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1027, name = "GENTAMICINA", concentration = "0", units = "%", price = "2.4034", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1028, name = "GENTAMICINA", concentration = "0", units = "%", price = "0.6606", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1029, name = "GLIBENCLAMIDA", concentration = "5", units = "MG", price = "0.1595", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1030, name = "GLIBENCLAMIDA + METFORMINA", concentration = "3", units = "MG", price = "0.4608", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1031, name = "GLIBENCLAMIDA + METFORMINA", concentration = "1", units = "MG", price = "0.4017", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1032, name = "GLIBENCLAMIDA + METFORMINA", concentration = "5", units = "MG", price = "0.6042", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1033, name = "GLIBENCLAMIDA + METFORMINA", concentration = "5", units = "MG", price = "0.5165", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1034, name = "GLIBENCLAMIDA + METFORMINA", concentration = "5", units = "MG", price = "0.6991", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1035, name = "GLIBENCLAMIDA + METFORMINA", concentration = "5", units = "MG", price = "0.7951", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1036, name = "GLIBENCLAMIDA + METFORMINA", concentration = "3", units = "MG", price = "0.6921", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1037, name = "GLIBENCLAMIDA + METFORMINA", concentration = "1", units = "MG", price = "0.4336", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1038, name = "GLIBENCLAMIDA + METFORMINA", concentration = "5", units = "MG", price = "0.8864", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1039, name = "GLICLAZIDA", concentration = "30", units = "MG", price = "0.4482", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1040, name = "GLICLAZIDA", concentration = "80", units = "MG", price = "0.5586", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1041, name = "GLICLAZIDA", concentration = "60", units = "MG", price = "1.53", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1042, name = "GLIMEPIRIDA", concentration = "2", units = "MG", price = "0.6043", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1043, name = "GLIMEPIRIDA", concentration = "4", units = "MG", price = "1.0964", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1044, name = "GLIMEPIRIDA + METFORMINA", concentration = "4", units = "MG", price = "1.6087", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1045, name = "GLIMEPIRIDA + METFORMINA", concentration = "2", units = "MG", price = "0.901", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1046, name = "GLIMEPIRIDA + METFORMINA", concentration = "2", units = "MG", price = "0.8731", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1047, name = "GLIMEPIRIDA + METFORMINA", concentration = "1", units = "MG", price = "0.6409", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1048, name = "GLIPIZIDA", concentration = "5", units = "MG", price = "0.4592", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1049, name = "GLUCOSAMINA", concentration = "1500", units = "MG/ EFP", price = "1.0037", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1050, name = "GLUCOSAMINA + LIDOCAINA", concentration = "400", units = "MG/ EFP", price = "1.2531", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1051, name = "GLUCOSAMINA + MELOXICAM", concentration = "1500", units = "MG/ EFP", price = "2.3166", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1052, name = "GOMA GUAR + MACROGOL (S + PROPILENGLICOL", concentration = "5", units = "%", price = "0.9697", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1053, name = "GRANISETRON", concentration = "1", units = "MG", price = "10.6688", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1054, name = "GRANISETRON", concentration = "1", units = "MG/EFP", price = "22.6932", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1055, name = "GRANISETRON", concentration = "3", units = "MG/EFP", price = "22.6388", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1056, name = "GRISEOFULVINA", concentration = "500", units = "MG", price = "0.377", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1057, name = "GUAIFENESINA + NOSCAPINA", concentration = "1", units = "%", price = "0.6018", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1058, name = "GUAIFENESINA + SALBUTAMOL", concentration = "50", units = "MG/ 5 ML", price = "0.0431", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1059, name = "GUAIFENESINA + TEOFILINA", concentration = "50", units = "MG/ 5 ML", price = "0.0274", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1060, name = "HALOPERIDOL", concentration = "5", units = "MG", price = "0.5695", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1061, name = "HALOPERIDOL", concentration = "2", units = "MG/ ML", price = "0.4985", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1062, name = "HALOPERIDOL", concentration = "5", units = "MG/EFP", price = "3.9391", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1063, name = "HEXETIDINA + LIDOCAINA", concentration = "0", units = "%", price = "0.2824", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1064, name = "HEXETIDINA + LIDOCAINA + PENTOSANO POLISULFATO DE SODIO + ACETONIDO DE TRIAMCINOLONA", concentration = "2", units = "%", price = "0.5098", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1065, name = "HIDRALAZINA", concentration = "20", units = "MG/EFP", price = "11.1403", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1066, name = "HIDRALAZINA", concentration = "50", units = "MG", price = "1.0538", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1067, name = "HIDROCLOROTIAZIDA", concentration = "50", units = "MG", price = "0.1426", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1068, name = "HIDROCLOROTIAZIDA", concentration = "25", units = "MG", price = "0.1242", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1069, name = "HIDROCLOROTIAZIDA + ENALAPRIL", concentration = "13", units = "MG", price = "1.2445", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1070, name = "HIDROCLOROTIAZIDA + ENALAPRIL", concentration = "25", units = "MG", price = "0.7009", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1071, name = "HIDROCLOROTIAZIDA + ENALAPRIL", concentration = "10", units = "MG", price = "0.1158", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1072, name = "HIDROCLOROTIAZIDA + IRBESARTAN", concentration = "13", units = "MG", price = "1.4689", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1073, name = "HIDROCLOROTIAZIDA + IRBESARTAN", concentration = "25", units = "MG", price = "1.7255", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1074, name = "HIDROCLOROTIAZIDA + IRBESARTAN", concentration = "13", units = "MG", price = "1.3509", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1075, name = "HIDROCLOROTIAZIDA + IRBESARTAN", concentration = "25", units = "MG", price = "1.3886", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1076, name = "HIDROCLOROTIAZIDA + LISINOPRIL", concentration = "13", units = "MG", price = "1.4126", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1077, name = "HIDROCLOROTIAZIDA + LISINOPRIL", concentration = "13", units = "MG", price = "0.3851", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1078, name = "HIDROCLOROTIAZIDA + LOSARTAN", concentration = "25", units = "MG", price = "1.3245", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1079, name = "HIDROCLOROTIAZIDA + LOSARTAN", concentration = "13", units = "MG", price = "1.2745", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1080, name = "HIDROCLOROTIAZIDA + LOSARTAN", concentration = "13", units = "MG", price = "1.7565", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1081, name = "HIDROCLOROTIAZIDA + OLMESARTAN MEDOXOMILO", concentration = "13", units = "MG", price = "1.9482", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1082, name = "HIDROCLOROTIAZIDA + OLMESARTAN MEDOXOMILO", concentration = "13", units = "MG", price = "1.9548", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1083, name = "HIDROCLOROTIAZIDA + OLMESARTAN MEDOXOMILO", concentration = "25", units = "MG", price = "2.1233", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1084, name = "HIDROCLOROTIAZIDA + QUINAPRIL", concentration = "13", units = "MG", price = "1.5677", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1085, name = "HIDROCLOROTIAZIDA + RAMIPRIL", concentration = "13", units = "MG", price = "1.2416", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1086, name = "HIDROCLOROTIAZIDA + TELMISARTAN", concentration = "13", units = "MG", price = "2.2124", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1087, name = "HIDROCLOROTIAZIDA + TRIAMTERENO", concentration = "25", units = "MG", price = "0.3723", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1088, name = "HIDROCLOROTIAZIDA + TRIAMTERENO", concentration = "25", units = "MG", price = "0.522", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1089, name = "HIDROCLOROTIAZIDA + VALSARTAN", concentration = "13", units = "MG", price = "1.6342", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1090, name = "HIDROCLOROTIAZIDA + VALSARTAN", concentration = "13", units = "MG", price = "1.5283", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1091, name = "HIDROCLOROTIAZIDA + VALSARTAN", concentration = "13", units = "MG", price = "1.9488", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1092, name = "HIDROCLOROTIAZIDA + VALSARTAN", concentration = "25", units = "MG", price = "1.7811", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1093, name = "HIDROCLOROTIAZIDA + VALSARTAN", concentration = "25", units = "MG", price = "2.0488", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1094, name = "HIDROCLOROTIAZIDA + VALSARTAN", concentration = "25", units = "MG", price = "1.6068", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1095, name = "HIDROCLOROTIAZIDA + ZOFENOPRIL", concentration = "13", units = "MG", price = "1.2563", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1096, name = "HIDROCODONA + ACETAMINOFEN [PARACETAMOL]", concentration = "5", units = "MG", price = "0.9104", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1097, name = "HIDROCORTISONA", concentration = "100", units = "MG/EFP", price = "3.6357", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1098, name = "HIDROCORTISONA", concentration = "500", units = "MG/EFP", price = "10.2863", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1099, name = "HIDROCORTISONA + DINITRATO ISOSORBIDE + LIDOCAINA + ZINC", concentration = "0", units = "%", price = "0.5933", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1100, name = "HIDROCORTISONA + NATAMICINA + NEOMICINA", concentration = "1", units = "%", price = "0.4713", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1101, name = "HIDROCORTISONA + NEOMICINA + NISTATINA", concentration = "1", units = "%+%+IU", price = "0.1893", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1102, name = "HIDROCORTISONA + NEOMICINA + POLIMIXINA B", concentration = "10", units = "MG+MG+UI", price = "1.1584", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1103, name = "HIDROCORTISONA + NEOMICINA + POLIMIXINA B", concentration = "1", units = "%+%+UI", price = "0.5312", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1104, name = "HIDROCORTISONA + NEOMICINA + POLIMIXINA B", concentration = "1", units = "%+UI+UI", price = "1.4258", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1105, name = "HIDROQUINONA", concentration = "2", units = "%", price = "0.4907", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1106, name = "HIDROQUINONA", concentration = "4", units = "%", price = "0.5633", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1107, name = "HIDROQUINONA", concentration = "5", units = "%", price = "0.358", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1108, name = "HIDROSMINA", concentration = "200", units = "MG", price = "0.5431", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1109, name = "HIDROSMINA", concentration = "2", units = "%", price = "0.2395", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1110, name = "HIDROXICLOROQUINA", concentration = "400", units = "MG", price = "0.5613", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1111, name = "HIDROXIZINA", concentration = "10", units = "MG", price = "0.2267", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1112, name = "HIDROXIZINA", concentration = "25", units = "MG", price = "0.277", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1113, name = "HIDROXIZINA", concentration = "30", units = "MG", price = "0.355", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1114, name = "HIDROXIZINA", concentration = "10", units = "MG/ 5 ML", price = "0.0519", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1115, name = "HIDROXIZINA", concentration = "15", units = "MG/ 5 ML", price = "0.0563", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1116, name = "HIOSCIAMINA + FENAZOPIRIDINA + SULFAMETIZOL + TETRACICLINA", concentration = "50", units = "MG", price = "0.523", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1117, name = "HIOSCIAMINA + FENOBARBITAL", concentration = "0", units = "MG/ 5 ML", price = "0.0791", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1118, name = "HIPROMELOSA", concentration = "0", units = "%", price = "0.3413", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1119, name = "HIPROMELOSA", concentration = "0", units = "%", price = "1.0842", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1120, name = "HIPROMELOSA", concentration = "1", units = "%", price = "1.1911", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1121, name = "HOMATROPINA", concentration = "100", units = "MG/ 5 ML", price = "0.0499", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1122, name = "HOMATROPINA + PAPAVERINA", concentration = "2", units = "MG/ML", price = "0.0766", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1123, name = "IBUPROFENO", concentration = "400", units = "MG", price = "0.1829", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1124, name = "IBUPROFENO", concentration = "600", units = "MG", price = "0.307", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1125, name = "IBUPROFENO", concentration = "800", units = "MG", price = "0.2815", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1126, name = "IBUPROFENO", concentration = "600", units = "MG", price = "0.43", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1127, name = "IBUPROFENO + ORFENADRINA", concentration = "450", units = "MG", price = "0.3362", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1128, name = "IDARUBICINA", concentration = "5", units = "MG/EFP", price = "205.988", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1129, name = "IMATINIB", concentration = "100", units = "MG", price = "29.6913", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1130, name = "IMATINIB", concentration = "400", units = "MG", price = "111.032", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1131, name = "IMIDAPRIL", concentration = "10", units = "MG", price = "1.0663", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1132, name = "IMIPRAMINA", concentration = "10", units = "MG", price = "0.2444", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1133, name = "IMIPRAMINA", concentration = "25", units = "MG", price = "0.4051", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1134, name = "IMIQUIMOD", concentration = "5", units = "%", price = "23.0606", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1135, name = "INDACATEROL", concentration = "150", units = "MCG/ DOSIS", price = "2.2498", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1136, name = "INDACATEROL", concentration = "300", units = "MCG/ DOSIS", price = "2.5564", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1137, name = "INDAPAMIDA", concentration = "2", units = "MG", price = "0.6225", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1138, name = "INDAPAMIDA + PERINDOPRIL", concentration = "1", units = "MG", price = "1.7426", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1139, name = "INDOMETACINA", concentration = "25", units = "MG", price = "0.1992", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1140, name = "INDOMETACINA + ALUMINIO + MAGNESIO", concentration = "25", units = "MG", price = "0.1063", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1141, name = "INDOMETACINA + METOCARBAMOL", concentration = "25", units = "MG", price = "0.3607", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1142, name = "IOPROMIDA", concentration = "300", units = "MG/ML", price = "0.5033", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1143, name = "IOPROMIDA", concentration = "370", units = "MG/ML", price = "0.5543", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1144, name = "IRBESARTAN", concentration = "150", units = "MG", price = "1.1601", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1145, name = "IRBESARTAN", concentration = "300", units = "MG", price = "1.3316", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1146, name = "ISONICONATO DE DEXAMETASONA", concentration = "8", units = "MG/EFP", price = "10", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1147, name = "ISOPROPAMIDA YODURO + TRIFLUOPERAZINA", concentration = "10", units = "MG", price = "0.8732", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1148, name = "ISOTRETINOINA", concentration = "10", units = "MG", price = "1.5717", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1149, name = "ISOTRETINOINA", concentration = "20", units = "MG", price = "2.2489", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1150, name = "ISOTRETINOINA", concentration = "0", units = "%", price = "0.3604", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1151, name = "ISOTRETINOINA", concentration = "0", units = "%", price = "0.3846", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1152, name = "ISRADIPINA", concentration = "5", units = "MG", price = "1.5", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1153, name = "ITRACONAZOL", concentration = "100", units = "MG", price = "1.9672", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1154, name = "ITRACONAZOL + SECNIDAZOL", concentration = "33", units = "MG", price = "1.8348", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1155, name = "IVABRADINA", concentration = "5", units = "MG", price = "1.0615", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1156, name = "IVABRADINA", concentration = "8", units = "MG", price = "1.14", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1157, name = "IVERMECTINA", concentration = "6", units = "MG", price = "2.6138", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1158, name = "JOSAMICINA", concentration = "500", units = "MG", price = "1.2161", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1159, name = "JOSAMICINA", concentration = "750", units = "MG", price = "1.7024", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1160, name = "KETOCONAZOL", concentration = "200", units = "MG", price = "0.6726", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1161, name = "KETOCONAZOL", concentration = "100", units = "MG/ 5 ML", price = "0.1807", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1162, name = "KETOCONAZOL", concentration = "400", units = "MG/OVULO", price = "4.8309", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1163, name = "KETOCONAZOL + SECNIDAZOL", concentration = "40", units = "%", price = "0.38", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1164, name = "KETOPROFENO", concentration = "100", units = "MG", price = "0.1977", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1165, name = "KETOPROFENO", concentration = "150", units = "MG", price = "1.6129", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1166, name = "KETOPROFENO", concentration = "50", units = "MG", price = "0.7396", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1167, name = "KETOPROFENO", concentration = "1", units = "MG/ ML", price = "0.0637", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1168, name = "KETOPROFENO", concentration = "100", units = "MG/EFP", price = "6.5032", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1169, name = "KETOROLACO", concentration = "10", units = "MG", price = "0.7537", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1170, name = "KETOROLACO", concentration = "20", units = "MG", price = "1.2168", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1171, name = "KETOROLACO", concentration = "30", units = "MG/EFP", price = "4.208", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1172, name = "KETOROLACO", concentration = "60", units = "MG/EFP", price = "5.4454", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1173, name = "KETOROLACO", concentration = "1", units = "%", price = "1.8746", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1174, name = "KETOTIFENO", concentration = "1", units = "MG", price = "0.3471", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1175, name = "KETOTIFENO", concentration = "0", units = "%", price = "2.0505", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1176, name = "KETOTIFENO", concentration = "1", units = "MG/ 5 ML", price = "0.1161", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1177, name = "KETOTIFENO", concentration = "0", units = "%", price = "1.3698", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1178, name = "KETOTIFENO", concentration = "0", units = "%", price = "1.9774", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1179, name = "KETOTIFENO", concentration = "1", units = "%", price = "4.2635", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1180, name = "LACTULOSA", concentration = "1", units = "%", price = "0.0983", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1181, name = "LACTULOSA", concentration = "1", units = "%", price = "0.0972", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1182, name = "LAMIVUDINA", concentration = "150", units = "MG", price = "0.5988", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1183, name = "LAMIVUDINA + ZIDOVUDINA", concentration = "150", units = "MG", price = "8.5889", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1184, name = "LAMOTRIGINA", concentration = "25", units = "MG", price = "0.5563", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1185, name = "LAMOTRIGINA", concentration = "100", units = "MG", price = "1.5613", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1186, name = "LANSOPRAZOL", concentration = "30", units = "MG", price = "1.4791", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1187, name = "LANSOPRAZOL", concentration = "30", units = "MG/ EFP", price = "1.5032", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1188, name = "LANSOPRAZOL", concentration = "30", units = "MG", price = "0.5313", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1189, name = "LANSOPRAZOL + MOSAPRIDA", concentration = "30", units = "MG", price = "0.8619", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1190, name = "LAPATINIB", concentration = "250", units = "MG", price = "19.1189", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1191, name = "LAROPIPRANT + ACIDO NICOTINICO", concentration = "20", units = "MG", price = "0.9685", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1192, name = "LATANOPROST", concentration = "0", units = "%", price = "12.0131", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1193, name = "LATANOPROST", concentration = "0", units = "%", price = "15.372", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1194, name = "LATANOPROST + TIMOLOL", concentration = "0", units = "%", price = "16.0303", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1195, name = "LEFLUNOMIDA", concentration = "20", units = "MG", price = "3.4413", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1196, name = "LEPIDIUM MEYENII PANAX + GINSENG + TURNERA DIFFUSA", concentration = "20", units = "G", price = "0.3343", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1197, name = "LERCANIDIPINO", concentration = "10", units = "MG", price = "1.4813", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1198, name = "LERCANIDIPINO", concentration = "20", units = "MG", price = "2.0713", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1199, name = "LETROZOL", concentration = "3", units = "MG", price = "6.7765", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1200, name = "LEUPRORELINA", concentration = "4", units = "MG/EFP", price = "303.958", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1201, name = "LEUPRORELINA", concentration = "11", units = "MG/EFP", price = "611.699", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1202, name = "LEUPRORELINA", concentration = "23", units = "MG/EFP", price = "702.946", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1203, name = "LEVAMISOL", concentration = "50", units = "MG", price = "0.2167", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1204, name = "LEVAMISOL", concentration = "75", units = "MG", price = "0.5463", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1205, name = "LEVAMISOL", concentration = "150", units = "MG", price = "0.4002", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1206, name = "LEVAMISOL", concentration = "13", units = "MG/ 5 ML", price = "0.0525", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1207, name = "LEVETIRACETAM", concentration = "250", units = "MG", price = "1.0807", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1208, name = "LEVETIRACETAM", concentration = "500", units = "MG", price = "1.075", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1209, name = "LEVETIRACETAM", concentration = "1000", units = "MG", price = "1.91", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1210, name = "LEVETIRACETAM", concentration = "100", units = "MG/ ML", price = "0.1888", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1211, name = "LEVOCETIRIZINA", concentration = "5", units = "MG", price = "1.5331", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1212, name = "LEVOCETIRIZINA", concentration = "3", units = "MG/ 5 ML", price = "0.1948", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1213, name = "LEVOCETIRIZINA", concentration = "5", units = "MG/ ML", price = "0.3161", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1214, name = "LEVODROPROPIZINA", concentration = "30", units = "MG/ 5 ML", price = "0.1153", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1215, name = "LEVODROPROPIZINA", concentration = "60", units = "MG/ 5 ML", price = "0.4086", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1216, name = "LEVOFLOXACINO", concentration = "750", units = "MG", price = "6.3236", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1217, name = "LEVOFLOXACINO", concentration = "500", units = "MG", price = "3.8246", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1218, name = "LEVOFLOXACINO", concentration = "500", units = "MG/EFP", price = "43.5297", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1219, name = "LEVOFLOXACINO", concentration = "750", units = "MG/EFP", price = "79.1931", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1220, name = "LEVOFLOXACINO", concentration = "1", units = "%", price = "1.825", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1221, name = "LEVONORGESTREL", concentration = "2", units = "MG/TRATAMIENTO", price = "12.43", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1222, name = "LEVOSULPIRIDE", concentration = "25", units = "MG", price = "0.744", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1223, name = "LEVOSULPIRIDE", concentration = "25", units = "MG/ ML", price = "0.7812", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1224, name = "LEVOSULPIRIDE", concentration = "25", units = "MG/EFP", price = "2.094", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1225, name = "LEVOTIROXINA SODICA", concentration = "25", units = "MCG", price = "0.13", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1226, name = "LEVOTIROXINA SODICA", concentration = "50", units = "MCG", price = "0.1492", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1227, name = "LEVOTIROXINA SODICA", concentration = "75", units = "MCG", price = "0.3359", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1228, name = "LEVOTIROXINA SODICA", concentration = "100", units = "MCG", price = "0.1713", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1229, name = "LEVOTIROXINA SODICA", concentration = "125", units = "MCG", price = "0.3655", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1230, name = "LEVOTIROXINA SODICA", concentration = "150", units = "MCG", price = "0.3861", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1231, name = "LEVOTIROXINA SODICA", concentration = "175", units = "MCG", price = "0.4373", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1232, name = "LEVOTIROXINA SODICA", concentration = "200", units = "MCG", price = "0.4719", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1233, name = "LIDOCAINA", concentration = "1", units = "%", price = "1.6881", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1234, name = "LIDOCAINA", concentration = "2", units = "%", price = "3.1828", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1235, name = "LIDOCAINA", concentration = "2", units = "%", price = "2.6051", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1236, name = "LIDOCAINA + FENAZONA", concentration = "1", units = "%", price = "0.4821", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1237, name = "LIDOCAINA + NITROFURAL", concentration = "5", units = "%", price = "0.1478", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1238, name = "LIDOCAINA + PENICILINA G", concentration = "40", units = "MG+UI/ EFP", price = "7.1122", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1239, name = "LIDOCAINA + PENICILINA G BENZATINICA", concentration = "30", units = "MG+ UI/ EFP", price = "6.1924", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1240, name = "LIDOCAINA + PENICILINA G BENZATINICA", concentration = "35", units = "MG+ UI/ EFP", price = "6.5642", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1241, name = "LIDOCAINA + PENICILINA G SODICA", concentration = "40", units = "MG+UI/ EFP", price = "7.0881", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1242, name = "LIDOCAINA + POVIDONA YODADA", concentration = "3", units = "%", price = "0.4155", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1243, name = "LIMECICLINA", concentration = "300", units = "MG", price = "2.3088", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1244, name = "LINCOMICINA", concentration = "300", units = "MG/EFP", price = "3.1925", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1245, name = "LINCOMICINA", concentration = "600", units = "MG/EFP", price = "4.0647", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1246, name = "LINDANE", concentration = "5", units = "%", price = "0.1114", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1247, name = "LINESTRENOL", concentration = "1", units = "MG", price = "0.3138", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1248, name = "LINEZOLIDA", concentration = "600", units = "MG", price = "74.0313", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1249, name = "LINEZOLIDA", concentration = "600", units = "MG/EFP", price = "78.5557", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1250, name = "LISINOPRIL", concentration = "5", units = "MG", price = "0.6498", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1251, name = "LISINOPRIL", concentration = "10", units = "MG", price = "0.7823", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1252, name = "LISINOPRIL", concentration = "20", units = "MG", price = "0.84", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1253, name = "LISOZIMA", concentration = "30", units = "MG", price = "0.4788", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1254, name = "LOMEFLOXACINA", concentration = "400", units = "MG", price = "1.8", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1255, name = "LOMEFLOXACINA", concentration = "0", units = "%", price = "2.1721", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1256, name = "LOPERAMIDA", concentration = "2", units = "MG/ ML", price = "0.1717", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1257, name = "LOPINAVIR + RITONAVIR", concentration = "133", units = "MG", price = "4.9078", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1258, name = "LORATADINA + FENILEFRINA", concentration = "5", units = "MG", price = "1.8125", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1259, name = "LORATADINA + FENILEFRINA", concentration = "5", units = "MG", price = "0.8909", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1260, name = "LORATADINA + FENILEFRINA", concentration = "5", units = "MG", price = "1.3839", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1261, name = "LORAZEPAM", concentration = "1", units = "MG", price = "0.2163", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1262, name = "LORAZEPAM", concentration = "2", units = "MG", price = "0.3763", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1263, name = "L-ORNITINA L-ASPARTATO", concentration = "5000", units = "MG/ EFP", price = "3.5962", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1264, name = "L-ORNITINA L-ASPARTATO", concentration = "3000", units = "MG/ EFP", price = "1.784", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1265, name = "LOSARTAN", concentration = "100", units = "MG", price = "1.0252", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1266, name = "LOSARTAN", concentration = "50", units = "MG", price = "0.7249", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1267, name = "LOSARTAN POTASICO", concentration = "100", units = "MG", price = "1.7307", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1268, name = "LOSARTAN POTASICO", concentration = "50", units = "MG", price = "1.6773", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1269, name = "LOSARTAN POTASICO + HIDROCLOROTIAZIDA", concentration = "50", units = "MG", price = "1.7273", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1270, name = "LOSARTAN POTASICO + HIDROCLOROTIAZIDA", concentration = "100", units = "MG", price = "1.6833", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1271, name = "LOTEPREDNOL", concentration = "0", units = "%", price = "0.4659", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1272, name = "LOTEPREDNOL", concentration = "1", units = "%", price = "2.1191", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1273, name = "LOVASTATIN", concentration = "20", units = "MG", price = "0.7451", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1274, name = "MACROGOL (S + POTASIO + SODIO", concentration = "3", units = "MG", price = "0.0884", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1275, name = "MAGALDRATO + SIMETICONA", concentration = "800", units = "MG", price = "0.5181", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1276, name = "MAGALDRATO + SIMETICONA", concentration = "400", units = "MG/ 5 ML", price = "0.0614", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1277, name = "MAGNESIO", concentration = "2", units = "%", price = "0.1294", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1278, name = "MAPROTILINA", concentration = "25", units = "MG", price = "0.6259", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1279, name = "MAZINDOL", concentration = "2", units = "MG", price = "1.0242", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1280, name = "MEBENDAZOL + QUINFAMIDA", concentration = "300", units = "MG", price = "6.609", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1281, name = "MEBENDAZOL + QUINFAMIDA", concentration = "60", units = "MG/ ML", price = "1.3928", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1282, name = "MEBENDAZOL + QUINFAMIDA", concentration = "60", units = "MG/ ML", price = "1.321", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1283, name = "MECLOZINA + PIRIDOXINA", concentration = "25", units = "MG", price = "0.1725", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1284, name = "MECLOZINA + PIRIDOXINA", concentration = "8", units = "MG/ ML", price = "0.182", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1285, name = "MECLOZINA + PIRIDOXINA", concentration = "8", units = "MG", price = "0.1657", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1286, name = "MEDROXIPROGESTERONA", concentration = "5", units = "MG", price = "0.5339", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1287, name = "MEDROXIPROGESTERONA", concentration = "10", units = "MG", price = "1.0581", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1288, name = "MEDROXIPROGESTERONA", concentration = "150", units = "MG/EFP", price = "11.5298", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1289, name = "MELATONINA", concentration = "1", units = "MG", price = "0.1953", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1290, name = "MELATONINA", concentration = "3", units = "MG", price = "0.2132", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1291, name = "MELATONINA", concentration = "5", units = "MG", price = "0.3532", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1292, name = "MELATONINA", concentration = "5", units = "MG/ 5 ML", price = "0.1363", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1293, name = "MELATONINA + PIRIDOXINA", concentration = "3", units = "MG", price = "0.2284", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1294, name = "MELFALAN", concentration = "2", units = "MG", price = "1.0729", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1295, name = "MELOXICAM", concentration = "0", units = "%", price = "2.1542", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1296, name = "MELOXICAM", concentration = "15", units = "MG/EFP", price = "3.4372", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1297, name = "MELOXICAM", concentration = "15", units = "MG", price = "1.6286", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1298, name = "MELOXICAM", concentration = "15", units = "MG", price = "1.294", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1299, name = "MELOXICAM", concentration = "15", units = "MG", price = "1.3363", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1300, name = "MELOXICAM + METOCARBAMOL", concentration = "8", units = "MG", price = "1.1774", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1301, name = "MEMANTINA", concentration = "10", units = "MG", price = "0.7116", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1302, name = "MEPIRAMINA + NAFAZOLINA", concentration = "0", units = "%", price = "0.7125", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1303, name = "MEQUITAZINA", concentration = "10", units = "MG", price = "1.1996", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1304, name = "MEQUITAZINA", concentration = "3", units = "MG/ 5 ML", price = "0.2521", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1305, name = "MEROPENEM", concentration = "500", units = "MG/EFP", price = "36.094", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1306, name = "MEROPENEM", concentration = "1000", units = "MG/EFP", price = "63.6745", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1307, name = "MESALAZINA", concentration = "250", units = "MG", price = "0.9213", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1308, name = "MESALAZINA", concentration = "500", units = "MG", price = "1.4838", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1309, name = "MESTEROLONE", concentration = "25", units = "MG", price = "0.91", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1310, name = "METAMIZOL MAGNESICO", concentration = "2000", units = "MG/EFP", price = "2.0607", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1311, name = "METAMIZOL MAGNESICO", concentration = "2500", units = "MG/EFP", price = "1.5006", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1312, name = "METAMIZOL MAGNESICO", concentration = "500", units = "MG/EFP", price = "1.0635", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1313, name = "METAMIZOL MAGNESICO", concentration = "500", units = "MG", price = "0.2066", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1314, name = "METAMIZOL SODICO", concentration = "300", units = "MG / SUPOSITORIO", price = "0.7212", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1315, name = "METAMIZOL SODICO", concentration = "1000", units = "MG/EFP", price = "0.7027", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1316, name = "METAMIZOL SODICO", concentration = "2500", units = "MG/EFP", price = "0.6144", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1317, name = "METAMIZOL SODICO", concentration = "500", units = "MG/ ML", price = "0.418", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1318, name = "METAMIZOL SODICO", concentration = "1000", units = "MG", price = "0.6482", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1319, name = "METAMIZOL SODICO", concentration = "250", units = "MG", price = "0.0367", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1320, name = "METAMIZOL SODICO", concentration = "324", units = "MG", price = "0.0847", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1321, name = "METAMIZOL SODICO", concentration = "500", units = "MG", price = "0.1769", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1322, name = "METAMIZOL SODICO", concentration = "300", units = "MG", price = "0.0563", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1323, name = "METAMIZOL SODICO", concentration = "500", units = "MG/EFP", price = "0.0595", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1324, name = "METAMIZOL SODICO + ORFENADRINA", concentration = "500", units = "MG/EFP", price = "1.7556", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1325, name = "METAMIZOL SODICO + PRAMIVERINE", concentration = "2", units = "MG", price = "0.3628", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1326, name = "METAMIZOL SODICO + PRAMIVERINE", concentration = "1", units = "MG/ ML", price = "0.4043", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1327, name = "METAMIZOL SODIO + COMPLEJO B", concentration = "1000", units = "MG/EFP", price = "6.7368", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1328, name = "METFORMINA", concentration = "500", units = "MG", price = "0.2527", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1329, name = "METFORMINA", concentration = "850", units = "MG", price = "0.3578", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1330, name = "METFORMINA", concentration = "1000", units = "MG", price = "0.6179", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1331, name = "METFORMINA", concentration = "500", units = "MG", price = "0.4744", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1332, name = "METFORMINA", concentration = "750", units = "MG", price = "0.7312", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1333, name = "METFORMINA", concentration = "850", units = "MG", price = "0.7456", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1334, name = "METFORMINA", concentration = "1000", units = "MG", price = "0.8756", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1335, name = "METFORMINA", concentration = "1000", units = "MG", price = "0.7696", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1336, name = "METFORMINA", concentration = "500", units = "MG", price = "0.58", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1337, name = "METFORMINA", concentration = "850", units = "MG", price = "0.64", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1338, name = "METFORMINA", concentration = "500", units = "MG", price = "0.5579", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1339, name = "METFORMINA + SITAGLIPTINA", concentration = "500", units = "MG", price = "1.0523", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1340, name = "METFORMINA + SITAGLIPTINA", concentration = "1000", units = "MG", price = "1.133", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1341, name = "METFORMINA + VILDAGLIPTINA", concentration = "1000", units = "MG", price = "0.9345", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1342, name = "METFORMINA + VILDAGLIPTINA", concentration = "500", units = "MG", price = "0.902", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1343, name = "METFORMINA + VILDAGLIPTINA", concentration = "850", units = "MG", price = "0.9026", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1344, name = "METILDOPA", concentration = "250", units = "MG", price = "0.355", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1345, name = "METILDOPA", concentration = "500", units = "MG", price = "0.63", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1346, name = "METILFENIDATO", concentration = "10", units = "MG", price = "0.2679", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1347, name = "METILFENIDATO", concentration = "18", units = "MG", price = "2.01", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1348, name = "METILFENIDATO", concentration = "36", units = "MG", price = "2.9975", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1349, name = "METILFENIDATO", concentration = "54", units = "MG", price = "3.6188", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1350, name = "METILHIDROXIDO DE ATROPINA + HIOSCIAMINA + FENOBARBITAL + ESCOPOLAMINA", concentration = "0", units = "MG/ ML", price = "0.0222", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1351, name = "METILPREDNISOLONA", concentration = "4", units = "MG", price = "0.3059", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1352, name = "METILPREDNISOLONA", concentration = "16", units = "MG", price = "1.3089", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1353, name = "METILPREDNISOLONA", concentration = "40", units = "MG/EFP", price = "9.1283", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1354, name = "METILPREDNISOLONA", concentration = "80", units = "MG/EFP", price = "11.8971", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1355, name = "METILPREDNISOLONA", concentration = "500", units = "MG/EFP", price = "37.2492", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1356, name = "METILPREDNISOLONA", concentration = "1000", units = "MG/EFP", price = "73.1031", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1357, name = "METISOPRINOL", concentration = "500", units = "MG", price = "1.0501", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1358, name = "METISOPRINOL", concentration = "250", units = "MG/ 5 ML", price = "0.1227", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1359, name = "METOCARBAMOL", concentration = "100", units = "MG/EFP", price = "1.6344", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1360, name = "METOCARBAMOL", concentration = "500", units = "MG/EFP", price = "2.6007", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1361, name = "METOCARBAMOL", concentration = "1000", units = "MG/EFP", price = "1.8519", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1362, name = "METOCLOPRAMIDA", concentration = "10", units = "MG", price = "0.226", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1363, name = "METOCLOPRAMIDA", concentration = "3", units = "MG/ ML", price = "0.1298", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1364, name = "METOCLOPRAMIDA", concentration = "4", units = "MG/ ML", price = "0.2009", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1365, name = "METOCLOPRAMIDA", concentration = "5", units = "MG/ 5 ML", price = "0.0496", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1366, name = "METOCLOPRAMIDA", concentration = "10", units = "MG/ 5 ML", price = "0.041", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1367, name = "METOCLOPRAMIDA", concentration = "10", units = "MG/EFP", price = "1.1329", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1368, name = "METOCLOPRAMIDA", concentration = "10", units = "MG/ SUPOSITORIO", price = "0.9545", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1369, name = "METOCLOPRAMIDA", concentration = "20", units = "MG/ SUPOSITORIO", price = "0.5601", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1370, name = "METOCLOPRAMIDA", concentration = "10", units = "MG/ ML", price = "0.2328", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1371, name = "METOCLOPRAMIDA", concentration = "5", units = "MG/ ML", price = "0.1447", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1372, name = "METOCLOPRAMIDA", concentration = "5", units = "MG", price = "0.3125", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1373, name = "METOCLOPRAMIDA + SIMETICONA", concentration = "5", units = "MG", price = "0.3825", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1374, name = "METOCLOPRAMIDA + SIMETICONA + PANCREATINA", concentration = "5", units = "MG", price = "0.3337", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1375, name = "METOCLOPRAMIDA + SIMETICONA + PANCREATINA", concentration = "10", units = "MG", price = "0.2005", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1376, name = "METOPROLOL", concentration = "100", units = "MG", price = "1.0086", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1377, name = "METOPROLOL", concentration = "50", units = "MG", price = "0.3431", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1378, name = "METOPROLOL", concentration = "100", units = "MG", price = "0.5884", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1379, name = "METOTREXATO", concentration = "3", units = "MG", price = "0.6237", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1380, name = "METOTREXATO", concentration = "50", units = "MG/EFP", price = "13.6877", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1381, name = "METOXALENO", concentration = "10", units = "MG", price = "0.6959", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1382, name = "METOXALENO", concentration = "0", units = "%", price = "0.6737", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1383, name = "METRONIDAZOL", concentration = "250", units = "MG", price = "0.2569", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1384, name = "METRONIDAZOL", concentration = "400", units = "MG", price = "0.2543", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1385, name = "METRONIDAZOL", concentration = "500", units = "MG", price = "0.2949", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1386, name = "METRONIDAZOL", concentration = "125", units = "MG/ 5 ML", price = "0.0373", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1387, name = "METRONIDAZOL", concentration = "250", units = "MG/ 5 ML", price = "0.0506", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1388, name = "METRONIDAZOL", concentration = "500", units = "MG/EFP", price = "10.4661", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1389, name = "METRONIDAZOL", concentration = "1", units = "%", price = "0.3319", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1390, name = "METRONIDAZOL", concentration = "500", units = "MG/OVULO", price = "0.7411", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1391, name = "METRONIDAZOL + MICONAZOL", concentration = "75", units = "%", price = "1.7658", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1392, name = "METRONIDAZOL + NIFUROXAZIDA", concentration = "600", units = "MG", price = "0.5852", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1393, name = "METRONIDAZOL + NISTATINA", concentration = "50", units = "%+UI", price = "0.4298", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1394, name = "METRONIDAZOL + NISTATINA", concentration = "500", units = "MG+UI", price = "1.0483", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1395, name = "METRONIDAZOL + NISTATINA + SULFACETAMIDA", concentration = "1", units = "%", price = "0.1598", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1396, name = "MICOFENOLATO MOFETIL", concentration = "500", units = "MG", price = "2.7", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1397, name = "MICOFENOLATO MOFETIL", concentration = "250", units = "MG", price = "2.505", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1398, name = "MICONAZOL", concentration = "400", units = "MG/OVULO", price = "4.3103", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1399, name = "MICONAZOL + TINIDAZOL", concentration = "100", units = "MG / OVULO", price = "4.3814", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1400, name = "MICONAZOL", concentration = "400", units = "MG", price = "4.3103", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1401, name = "MIDAZOLAM", concentration = "8", units = "MG", price = "0.3488", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1402, name = "MIDAZOLAM", concentration = "15", units = "MG", price = "0.7463", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1403, name = "MIDAZOLAM", concentration = "15", units = "MG/EFP", price = "6.3816", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1404, name = "MINOCICLINA", concentration = "50", units = "MG", price = "0.7663", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1405, name = "MINOCICLINA", concentration = "100", units = "MG", price = "1.3897", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1406, name = "MIRTAZAPINA", concentration = "30", units = "MG", price = "2.1422", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1407, name = "MODAFINILO", concentration = "100", units = "MG", price = "1.9025", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1408, name = "MODAFINILO", concentration = "200", units = "MG", price = "2.4645", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1409, name = "MOMETASONA", concentration = "50", units = "MCG/ DOSIS", price = "0.3683", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1410, name = "MOMETASONA", concentration = "0", units = "%", price = "0.9447", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1411, name = "MOMETASONA", concentration = "200", units = "MCG/ DOSIS", price = "1.1205", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1412, name = "MOMETASONA", concentration = "400", units = "MCG/ DOSIS", price = "1.6835", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1413, name = "MONONITRATO DE ISOSORBIDE", concentration = "10", units = "MG", price = "0.1718", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1414, name = "MONONITRATO DE ISOSORBIDE", concentration = "20", units = "MG", price = "0.4688", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1415, name = "MONONITRATO DE ISOSORBIDE", concentration = "40", units = "MG", price = "0.6066", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1416, name = "MONONITRATO DE ISOSORBIDE", concentration = "50", units = "MG", price = "0.8213", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1417, name = "MONTELUKAST", concentration = "5", units = "MG", price = "1.3349", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1418, name = "MONTELUKAST", concentration = "10", units = "MG", price = "2.2659", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1419, name = "MONTELUKAST", concentration = "4", units = "MG", price = "1.312", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1420, name = "MONTELUKAST", concentration = "4", units = "MG", price = "2.4157", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1421, name = "MONTELUKAST", concentration = "5", units = "MG", price = "2.451", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1422, name = "MORFINA", concentration = "10", units = "MG/EFP", price = "3.4331", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1423, name = "MOSAPRIDA", concentration = "3", units = "MG", price = "0.2555", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1424, name = "MOSAPRIDA", concentration = "5", units = "MG", price = "0.4304", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1425, name = "MOSAPRIDA", concentration = "5", units = "MG/ ML", price = "0.182", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1426, name = "MOSAPRIDA + SIMETICONA", concentration = "3", units = "MG", price = "0.3956", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1427, name = "MOXIFLOXACINO", concentration = "400", units = "MG", price = "6.8563", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1428, name = "MOXIFLOXACINO", concentration = "1", units = "%", price = "3.3625", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1429, name = "MOXIFLOXACINO", concentration = "400", units = "MG/ EFP", price = "52.1772", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1430, name = "MUPIROCINA", concentration = "2", units = "%", price = "0.631", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1431, name = "N6-FURFURILADENINA", concentration = "0", units = "%", price = "1.0551", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1432, name = "NABUMETONA", concentration = "500", units = "MG", price = "0.8786", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1433, name = "NABUMETONA", concentration = "750", units = "MG", price = "1.4075", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1434, name = "NADIFLOXACINO", concentration = "1", units = "%", price = "0.4255", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1435, name = "NAFAZOLINA", concentration = "1", units = "MG/ ML", price = "0.1638", cat = "Aerosoles nasales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1436, name = "NAFAZOLINA + ZINC", concentration = "0", units = "%", price = "0.8744", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1437, name = "NALBUFINA", concentration = "10", units = "MG/ EFP", price = "6.8388", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1438, name = "NANDROLONA", concentration = "50", units = "MG/ ML", price = "17.6323", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1439, name = "NAPROXENO", concentration = "275", units = "MG", price = "0.4529", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1440, name = "NAPROXENO", concentration = "500", units = "MG", price = "0.6588", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1441, name = "NAPROXENO", concentration = "550", units = "MG", price = "0.7267", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1442, name = "NAPROXENO", concentration = "125", units = "MG/ 5 ML", price = "0.0786", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1443, name = "NAPROXENO + ACETAMINOFEN [PARACETAMOL]", concentration = "275", units = "MG", price = "0.5516", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1444, name = "NAPROXENO + ACETAMINOFEN [PARACETAMOL]", concentration = "125", units = "MG/ 5 ML", price = "0.1327", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1445, name = "NAPROXENO + SUMATRIPTAN", concentration = "85", units = "MG", price = "6.4968", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1446, name = "NATEGLINIDA", concentration = "120", units = "MG", price = "0.6775", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1447, name = "NEBIVOLOL", concentration = "3", units = "MG", price = "0.81", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1448, name = "NEBIVOLOL", concentration = "5", units = "MG", price = "1.4703", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1449, name = "NEBIVOLOL", concentration = "10", units = "MG", price = "1.9063", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1450, name = "NEOMICINA + POLIMIXINA B + FENILEFRINA", concentration = "35000", units = "UI", price = "0.7605", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1451, name = "NEOMICINA + RETINOL", concentration = "350", units = "MG+UI", price = "0.1616", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1452, name = "NEOMICINA + SULFADIAZINA", concentration = "1", units = "%", price = "0.0611", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1453, name = "NEOSTIGMINA", concentration = "1", units = "MG/ EFP", price = "1.3155", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1454, name = "NEPAFENACO", concentration = "0", units = "%", price = "2.8863", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1455, name = "NICLOSAMIDA", concentration = "500", units = "MG", price = "1.5563", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1456, name = "NIFEDIPINA", concentration = "10", units = "MG", price = "0.1263", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1457, name = "NIFEDIPINA", concentration = "10", units = "MG", price = "1.0504", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1458, name = "NIFEDIPINA", concentration = "20", units = "MG", price = "0.4596", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1459, name = "NIFEDIPINA", concentration = "30", units = "MG", price = "0.7663", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1460, name = "NIFEDIPINA", concentration = "60", units = "MG", price = "2.2558", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1461, name = "NIFEDIPINA", concentration = "30", units = "MG", price = "1.4208", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1462, name = "NIFUROXAZIDA", concentration = "200", units = "MG", price = "0.5006", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1463, name = "NIFUROXAZIDA", concentration = "400", units = "MG", price = "0.5746", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1464, name = "NIFUROXAZIDA", concentration = "220", units = "MG/ 5 ML", price = "0.0856", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1465, name = "NIFURTIMOX", concentration = "120", units = "MG", price = "0.4813", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1466, name = "NIMESULIDA", concentration = "100", units = "MG", price = "0.9919", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1467, name = "NIMESULIDA", concentration = "50", units = "MG/ 5 ML", price = "0.1782", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1468, name = "NIMODIPINO", concentration = "30", units = "MG", price = "0.5903", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1469, name = "NIMODIPINO", concentration = "60", units = "MG", price = "1.285", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1470, name = "NIMODIPINO", concentration = "10", units = "MG/ EFP", price = "34.1874", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1471, name = "NISTATINA", concentration = "100000", units = "UI/ ML", price = "0.1619", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1472, name = "NITAZOXANIDA", concentration = "500", units = "MG", price = "1.9837", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1473, name = "NITROFURANTOINA", concentration = "50", units = "MG", price = "0.6073", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1474, name = "NITROFURANTOINA", concentration = "100", units = "MG", price = "0.6616", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1475, name = "NITROFURANTOINA", concentration = "100", units = "MG", price = "0.9048", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1476, name = "NITROFURANTOINA + PARGEVERINA", concentration = "75", units = "MG", price = "0.516", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1477, name = "NITROGLICERINA", concentration = "50", units = "MG/ EFP", price = "14.3935", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1478, name = "NOREPINEFRINA", concentration = "4", units = "MG/ EFP", price = "20.625", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1479, name = "NORFLOXACINO", concentration = "400", units = "MG", price = "0.5923", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1480, name = "OCTREOTIDA", concentration = "0", units = "MG/ EFP", price = "23.42", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1481, name = "OCTREOTIDA", concentration = "30", units = "MG/ EFP", price = "3274.25", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1482, name = "OCTREOTIDA", concentration = "0", units = "MG/ EFP", price = "12.3005", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1483, name = "OCTREOTIDA", concentration = "20", units = "MG/ EFP", price = "1899.92", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1484, name = "OFLOXACINA", concentration = "400", units = "MG", price = "3.4735", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1485, name = "OFLOXACINA", concentration = "400", units = "MG/ EFP", price = "35.8723", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1486, name = "OFLOXACINA", concentration = "0", units = "%", price = "1.9838", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1487, name = "OFLOXACINA", concentration = "0", units = "%", price = "2.511", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1488, name = "OLANZAPINA", concentration = "5", units = "MG", price = "3.5086", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1489, name = "OLANZAPINA", concentration = "10", units = "MG", price = "5.8985", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1490, name = "OLANZAPINA", concentration = "10", units = "MG/ EFP", price = "17.1648", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1491, name = "OLANZAPINA", concentration = "10", units = "MG", price = "10.3287", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1492, name = "OLANZAPINA", concentration = "5", units = "MG", price = "5.3618", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1493, name = "OLMESARTAN MEDOXOMILO", concentration = "20", units = "MG", price = "1.6175", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1494, name = "OLMESARTAN MEDOXOMILO", concentration = "40", units = "MG", price = "1.7888", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1495, name = "OLOPATADINA", concentration = "0", units = "%", price = "4.3638", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1496, name = "OLOPATADINA", concentration = "0", units = "%", price = "8.4788", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1497, name = "OMEPRAZOL", concentration = "40", units = "MG", price = "2.3698", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1498, name = "OMEPRAZOL", concentration = "20", units = "MG", price = "0.7806", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1499, name = "OMEPRAZOL", concentration = "40", units = "MG/ EFP", price = "11.3399", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1500, name = "ONDANSETRON", concentration = "4", units = "MG", price = "1.775", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1501, name = "ONDANSETRON", concentration = "8", units = "MG", price = "3.1763", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1502, name = "ONDANSETRON", concentration = "4", units = "MG/ EFP", price = "13.1806", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1503, name = "ONDANSETRON", concentration = "8", units = "MG/ EFP", price = "19.5632", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1504, name = "OPIO + ACIDO BENZOICO + ALCANFOR + ESENCIA DE ANIS + CAOLIN + PECTINA", concentration = "0", units = "MG/ ML", price = "0.0572", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1505, name = "ORFENADRINA", concentration = "100", units = "MG", price = "0.3516", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1506, name = "ORFENADRINA", concentration = "60", units = "MG/ EFP", price = "2.4066", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1507, name = "ORFENADRINA + ACETAMINOFEN [PARACETAMOL]", concentration = "35", units = "MG", price = "0.4278", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1508, name = "ORFENADRINA + ACETAMINOFEN [PARACETAMOL]", concentration = "50", units = "MG", price = "0.349", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1509, name = "ORFENADRINA", concentration = "30", units = "MG/EFP", price = "2.0966", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1510, name = "ORLISTAT", concentration = "120", units = "MG", price = "1.2573", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1511, name = "OXACILINA", concentration = "1000", units = "MG/ EFP", price = "3.0071", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1512, name = "OXALIPLATINO", concentration = "50", units = "MG/ EFP", price = "283.395", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1513, name = "OXALIPLATINO", concentration = "100", units = "MG/ EFP", price = "528.529", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1514, name = "OXANTEL + PIRANTEL", concentration = "100", units = "MG", price = "1.0749", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1515, name = "OXCARBAZEPINA", concentration = "300", units = "MG", price = "0.9505", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1516, name = "OXCARBAZEPINA", concentration = "600", units = "MG", price = "1.819", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1517, name = "OXCARBAZEPINA", concentration = "300", units = "MG/ 5 ML", price = "0.145", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1518, name = "OXETACAINE", concentration = "5", units = "MG", price = "0.1625", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1519, name = "OXIBUTININA", concentration = "5", units = "MG", price = "0.7275", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1520, name = "OXIBUTININA", concentration = "10", units = "MG", price = "1.9163", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1521, name = "OXICODONA", concentration = "10", units = "MG", price = "2.11", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1522, name = "OXICODONA", concentration = "20", units = "MG", price = "2.97", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1523, name = "OXICODONA", concentration = "40", units = "MG", price = "6.8525", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1524, name = "OXITETRACICLINA", concentration = "1", units = "%", price = "0.3087", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1525, name = "OXITETRACICLINA", concentration = "500", units = "MG", price = "0.6251", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1526, name = "OXITETRACICLINA + POLIMIXINA B", concentration = "3", units = "%+UI", price = "0.322", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1527, name = "OXITETRACICLINA + POLIMIXINA B", concentration = "1", units = "%+UI", price = "0.6048", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1528, name = "OXITETRACICLINA + POLIMIXINA B", concentration = "3", units = "%+UI", price = "0.5771", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1529, name = "OXITOCINA", concentration = "5", units = "UI/EFP", price = "1.1416", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1530, name = "OXITOCINA", concentration = "10", units = "UI/EFP", price = "1.3104", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1531, name = "PACLITAXEL", concentration = "30", units = "MG/ EFP", price = "67.7607", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1532, name = "PACLITAXEL", concentration = "150", units = "MG/ EFP", price = "300.818", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1533, name = "PALIPERIDONA", concentration = "3", units = "MG", price = "8.4013", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1534, name = "PALIPERIDONA", concentration = "6", units = "MG", price = "8.9163", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1535, name = "PALIPERIDONA", concentration = "9", units = "MG", price = "12.3838", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1536, name = "PALONOSETRON", concentration = "0", units = "MG/ EFP", price = "106.027", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1537, name = "PANCREATINA", concentration = "150", units = "MG", price = "0.7957", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1538, name = "PANCREATINA", concentration = "300", units = "MG", price = "0.2317", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1539, name = "PANCREATINA", concentration = "400", units = "MG", price = "0.6088", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1540, name = "PANCREATINA + BROMELINA + DIMETILPOLISILOXANO", concentration = "250", units = "MG", price = "0.3247", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1541, name = "PANTOPRAZOL MAGNESICO", concentration = "40", units = "MG", price = "2.8877", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1542, name = "PANTOPRAZOL SODICO", concentration = "20", units = "MG", price = "1.6196", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1543, name = "PANTOPRAZOL SODICO", concentration = "40", units = "MG", price = "1.9724", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1544, name = "PANTOPRAZOL SODICO", concentration = "40", units = "MG/ EFP", price = "17.167", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1545, name = "PARECOXIB", concentration = "40", units = "MG/ EFP", price = "10.4081", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1546, name = "PARGEVERINA [PROPINOXATO]", concentration = "30", units = "MG/ EFP", price = "4.3588", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1547, name = "PARGEVERINA [PROPINOXATO]", concentration = "10", units = "MG/ ML", price = "0.3465", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1548, name = "PARGEVERINA [PROPINOXATO]", concentration = "5", units = "MG/ ML", price = "0.219", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1549, name = "PARGEVERINA [PROPINOXATO]", concentration = "10", units = "MG", price = "0.3927", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1550, name = "PARGEVERINA [PROPINOXATO]", concentration = "15", units = "MG", price = "0.5633", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1551, name = "PARGEVERINA [PROPINOXATO]", concentration = "20", units = "MG", price = "0.6354", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1552, name = "PARGEVERINA [PROPINOXATO]", concentration = "5", units = "MG", price = "0.2615", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1553, name = "PARICALCITOL", concentration = "0", units = "MG/ EFP", price = "36.2374", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1554, name = "PAROMOMICINA [AMINOSIDINA]", concentration = "250", units = "MG", price = "0.7374", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1555, name = "PAROMOMICINA [AMINOSIDINA]", concentration = "125", units = "MG/ 5 ML", price = "0.0953", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1556, name = "PAROXETINA", concentration = "13", units = "MG", price = "1.282", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1557, name = "PAROXETINA", concentration = "25", units = "MG", price = "2.4799", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1558, name = "PAROXETINA", concentration = "13", units = "MG", price = "1.0458", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1559, name = "PAROXETINA", concentration = "20", units = "MG", price = "1.5285", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1560, name = "PAROXETINA", concentration = "25", units = "MG", price = "2.0576", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1561, name = "PELARGONIUM SIDOIDES", concentration = "80", units = "%", price = "0.5795", cat = "Gotas oticas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1562, name = "PEMETREXED", concentration = "500", units = "MG/ EFP", price = "2023.08", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1563, name = "PENICILINA G BENZATINICA", concentration = "600000", units = "UI/ EFP", price = "5.5831", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1564, name = "PENICILINA G PROCAINICA", concentration = "1200000", units = "UI/ EFP", price = "3.6407", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1565, name = "PENICILINA G PROCAINICA", concentration = "2400000", units = "UI/ EFP", price = "5.8796", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1566, name = "PENICILINA G PROCAINICA", concentration = "4000000", units = "UI/ EFP", price = "3.0336", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1567, name = "PENICILINA G PROCAINICA Y SODICA + PROBENECID", concentration = "4800000", units = "UI+MG/ EFP", price = "4.6978", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1568, name = "PENICILINA G SODICA", concentration = "5", units = "%", price = "0.1346", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1569, name = "PENTOXIFILINA", concentration = "400", units = "MG", price = "0.45", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1570, name = "PENTOXIFILINA", concentration = "400", units = "MG", price = "0.8213", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1571, name = "PENTOXIFILINA", concentration = "20", units = "MG/ ML", price = "0.5188", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1572, name = "PERINDOPRIL", concentration = "4", units = "MG", price = "1.0885", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1573, name = "PERINDOPRIL", concentration = "5", units = "MG", price = "1.1901", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1574, name = "PERINDOPRIL", concentration = "8", units = "MG", price = "1.52638", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1575, name = "PERINDOPRIL", concentration = "10", units = "MG", price = "1.5828", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1576, name = "PEROXIDO BENZOILO", concentration = "5", units = "%", price = "0.2043", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1577, name = "PEROXIDO BENZOILO", concentration = "10", units = "%", price = "0.2003", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1578, name = "PEROXIDO BENZOILO + CLINDAMICINA", concentration = "5", units = "%", price = "1.0216", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1579, name = "PICOSULFATO SODICO", concentration = "5", units = "MG/ ML", price = "0.0807", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1580, name = "PICOSULFATO SODICO", concentration = "8", units = "MG/ ML", price = "0.3591", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1581, name = "PICOSULFATO SODICO", concentration = "5", units = "MG", price = "0.2795", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1582, name = "PIDOTIMOD", concentration = "400", units = "MG/ 7 ML", price = "0.4916", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1583, name = "PIDOTIMOD", concentration = "800", units = "MG/ 7 ML", price = "0.7729", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1584, name = "PIOGLITAZONA", concentration = "15", units = "MG", price = "1.7962", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1585, name = "PIOGLITAZONA", concentration = "30", units = "MG", price = "3.1906", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1586, name = "PIOGLITAZONA", concentration = "45", units = "MG", price = "3.765", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1587, name = "PIPERACILINA + TAZOBACTAM", concentration = "4000", units = "MG/ EFP", price = "35.3959", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1588, name = "PIPERAZINA", concentration = "100", units = "MG/ 5 ML", price = "0.0825", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1589, name = "PIPERAZINA", concentration = "500", units = "MG/ 5 ML", price = "0.0151", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1590, name = "PIPERAZINA", concentration = "100", units = "MG", price = "0.3071", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1591, name = "PIRACETAM", concentration = "800", units = "MG", price = "0.6189", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1592, name = "PIRACETAM", concentration = "800", units = "MG/ EFP", price = "0.0525", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1593, name = "PIRACETAM", concentration = "1600", units = "MG/ 15 ML", price = "0.0523", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1594, name = "PIRACETAM + VINCAMINA", concentration = "1200", units = "MG", price = "0.6151", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1595, name = "PIRACETAM", concentration = "400", units = "MG/5ML", price = "0.0457", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1596, name = "PIRIDOSTIGMINA", concentration = "60", units = "MG", price = "0.9105", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1597, name = "PIRIMETAMINA", concentration = "25", units = "MG", price = "0.6975", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1598, name = "PIRISUDANOL", concentration = "300", units = "MG", price = "0.7567", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1599, name = "PIROXICAM", concentration = "20", units = "MG/ EFP", price = "1.9865", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1600, name = "PIROXICAM", concentration = "40", units = "MG/ EFP", price = "4.288", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1601, name = "PIROXICAM", concentration = "10", units = "MG", price = "0.3917", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1602, name = "PIROXICAM", concentration = "20", units = "MG", price = "0.9051", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1603, name = "PIROXICAM", concentration = "40", units = "MG", price = "1.0232", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1604, name = "POLICRESULENO", concentration = "2", units = "%", price = "0.3846", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1605, name = "POLICRESULENO", concentration = "1", units = "%", price = "1.1545", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1606, name = "POLICRESULENO", concentration = "41", units = "%", price = "1.0125", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1607, name = "POLICRESULENO", concentration = "0", units = "G /OVULO", price = "2.4944", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1608, name = "POLIDOCANOL", concentration = "3", units = "%", price = "31.25", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1609, name = "POLIDOCANOL", concentration = "3", units = "%", price = "10.335", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1610, name = "POTASIO", concentration = "20", units = "MEQ/EFP", price = "0.4602", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1611, name = "POVIDONA", concentration = "1", units = "%", price = "0.7389", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1612, name = "POVIDONA", concentration = "5", units = "%", price = "1.1668", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1613, name = "POVIDONA", concentration = "1000", units = "MG/ 5 ML", price = "0.1062", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1614, name = "PRAMIPREXOL", concentration = "0", units = "MG", price = "5.6822", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1615, name = "PRAMIPREXOL", concentration = "1", units = "MG", price = "5.6822", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1616, name = "PRAMIPREXOL", concentration = "2", units = "MG", price = "5.6822", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1617, name = "PRAMIPREXOL", concentration = "3", units = "MG", price = "5.6822", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1618, name = "PRAMIPREXOL", concentration = "0", units = "MG", price = "0.8775", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1619, name = "PRAMIPREXOL", concentration = "1", units = "MG", price = "1.6949", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1620, name = "PRAMIPREXOL", concentration = "1", units = "MG", price = "1.0391", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1621, name = "PRASUGREL", concentration = "10", units = "MG", price = "3.4045", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1622, name = "PREDNISOLONA", concentration = "5", units = "MG", price = "0.2782", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1623, name = "PREDNISOLONA", concentration = "10", units = "MG", price = "0.5188", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1624, name = "PREDNISOLONA", concentration = "20", units = "MG", price = "1.1004", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1625, name = "PREDNISOLONA", concentration = "50", units = "MG", price = "1.4681", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1626, name = "PREDNISOLONA", concentration = "5", units = "MG/ 5 ML", price = "0.1435", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1627, name = "PREDNISOLONA", concentration = "15", units = "MG/ 5 ML", price = "0.1859", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1628, name = "PREDNISOLONA", concentration = "1", units = "%", price = "1.9761", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1629, name = "PREDNISOLONA", concentration = "1", units = "%", price = "5.5831", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1630, name = "PREDNISOLONA + SULFACETAMIDA", concentration = "0", units = "%", price = "2.0271", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1631, name = "PREDNISOLONA + SULFACETAMIDA", concentration = "1", units = "%", price = "1.2146", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1632, name = "PREDNISOLONA + SULFACETAMIDA + FENILEFRINA", concentration = "0", units = "%", price = "2.0224", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1633, name = "PREDNISONA", concentration = "5", units = "MG", price = "0.425", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1634, name = "PREDNISONA", concentration = "20", units = "MG", price = "0.9575", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1635, name = "PREDNISONA", concentration = "50", units = "MG", price = "0.5869", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1636, name = "PREDNISONA", concentration = "5", units = "MG/ 5 ML", price = "0.1238", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1637, name = "PREDNISONA", concentration = "20", units = "MG/ 5 ML", price = "0.2833", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1638, name = "PREGABALINA", concentration = "75", units = "MG", price = "1.4255", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1639, name = "PREGABALINA", concentration = "150", units = "MG", price = "1.523", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1640, name = "PREGABALINA", concentration = "300", units = "MG", price = "2.1946", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1641, name = "PREGABALINA", concentration = "150", units = "MG", price = "2.1425", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1642, name = "PREGABALINA", concentration = "300", units = "MG", price = "3.0388", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1643, name = "PREGABALINA", concentration = "75", units = "MG", price = "2.1689", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1644, name = "PROGESTERONA", concentration = "100", units = "MG", price = "0.6363", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1645, name = "PROGESTERONA", concentration = "200", units = "MG", price = "1.3163", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1646, name = "PROGESTERONA", concentration = "100", units = "MG/ EFP", price = "3.605", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1647, name = "PROGESTERONA", concentration = "8", units = "%", price = "2.4979", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1648, name = "PROPAFENONA", concentration = "150", units = "MG", price = "0.5689", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1649, name = "PROPILTIOURACILO", concentration = "50", units = "MG", price = "0.2689", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1650, name = "PROPOFOL", concentration = "200", units = "MG/ EFP", price = "11.2", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1651, name = "PROPOFOL", concentration = "500", units = "MG/ EFP", price = "44.2142", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1652, name = "PROPRANOLOL", concentration = "10", units = "MG", price = "0.1297", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1653, name = "PROPRANOLOL", concentration = "80", units = "MG", price = "0.3675", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1654, name = "PROPRANOLOL", concentration = "40", units = "MG", price = "0.1772", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1655, name = "QUETIAPINA", concentration = "300", units = "MG", price = "5.0807", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1656, name = "QUETIAPINA", concentration = "50", units = "MG", price = "2.24", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1657, name = "QUETIAPINA", concentration = "100", units = "MG", price = "2.43", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1658, name = "QUETIAPINA", concentration = "200", units = "MG", price = "3.7058", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1659, name = "QUETIAPINA", concentration = "25", units = "MG", price = "1.29", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1660, name = "QUETIAPINA", concentration = "300", units = "MG", price = "5.55", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1661, name = "QUETIAPINA", concentration = "400", units = "MG", price = "6.9071", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1662, name = "RACECADOTRILO", concentration = "100", units = "MG", price = "1.0063", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1663, name = "RACECADOTRILO", concentration = "1000", units = "MG", price = "0.4322", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1664, name = "RACECADOTRILO", concentration = "10", units = "MG/ EFP", price = "0.6928", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1665, name = "RACECADOTRILO", concentration = "30", units = "MG/ EFP", price = "0.6946", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1666, name = "RAMIPRIL", concentration = "3", units = "MG", price = "0.98", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1667, name = "RAMIPRIL", concentration = "5", units = "MG", price = "1.1657", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1668, name = "RAMIPRIL", concentration = "10", units = "MG", price = "1.86", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1669, name = "RANELATO DE ESTRONCIO", concentration = "2000", units = "MG/ EFP", price = "2.7694", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1670, name = "RANITIDINA", concentration = "300", units = "MG", price = "0.6479", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1671, name = "RANITIDINA", concentration = "40", units = "MG/ ML", price = "0.2098", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1672, name = "RANITIDINA", concentration = "150", units = "MG/ 10 ML", price = "0.2184", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1673, name = "RANITIDINA", concentration = "50", units = "MG/ EFP", price = "1.811", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1674, name = "RANOLAZINA", concentration = "1000", units = "MG", price = "2.4511", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1675, name = "RANOLAZINA", concentration = "500", units = "MG", price = "2.4512", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1676, name = "RASAGILINA", concentration = "1", units = "MG", price = "1.9246", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1677, name = "REMIFENTANIL", concentration = "2", units = "MG", price = "17.853", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1678, name = "RETAPAMULINA", concentration = "1", units = "%", price = "2.0905", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1679, name = "RIBAVIRINA", concentration = "100", units = "MG/5ML", price = "0.3068", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1680, name = "RIBAVIRINA", concentration = "8", units = "%", price = "1.5637", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1681, name = "RIBAVIRINA", concentration = "100", units = "MG/ EFP", price = "7.0013", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1682, name = "RIBAVIRINA", concentration = "200", units = "MG", price = "6.4702", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1683, name = "RILUZOL", concentration = "50", units = "MG", price = "16.92", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1684, name = "RISPERIDONA", concentration = "1", units = "MG", price = "1.127", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1685, name = "RISPERIDONA", concentration = "2", units = "MG", price = "2.2166", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1686, name = "RISPERIDONA", concentration = "3", units = "MG", price = "3.2328", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1687, name = "RISPERIDONA", concentration = "25", units = "MG/ EFP", price = "188.401", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1688, name = "RISPERIDONA", concentration = "38", units = "MG/ EFP", price = "275.006", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1689, name = "RISPERIDONA", concentration = "1", units = "MG", price = "0.681", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1690, name = "RITODRINA", concentration = "50", units = "MG/ EFP", price = "4.3649", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1691, name = "RITODRINA", concentration = "10", units = "MG", price = "0.6117", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1692, name = "RIVASTIGMINA", concentration = "2", units = "MG", price = "1.9956", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1693, name = "RIVASTIGMINA", concentration = "3", units = "MG", price = "2.2907", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1694, name = "RIVASTIGMINA", concentration = "5", units = "MG", price = "2.46", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1695, name = "RIVASTIGMINA", concentration = "6", units = "MG", price = "2.5813", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1696, name = "RIVASTIGMINA", concentration = "9", units = "MG/PARCHE", price = "4.773", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1697, name = "RIVASTIGMINA", concentration = "18", units = "MG/PARCHE", price = "5.4788", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1698, name = "ROCIVERINA", concentration = "20", units = "MG/ EFP", price = "2.4135", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1699, name = "ROCIVERINA", concentration = "10", units = "MG", price = "0.343", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1700, name = "ROSUVASTATINA", concentration = "5", units = "MG", price = "1.3879", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1701, name = "ROSUVASTATINA", concentration = "10", units = "MG", price = "1.1181", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1702, name = "ROSUVASTATINA", concentration = "20", units = "MG", price = "1.7699", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1703, name = "ROSUVASTATINA", concentration = "40", units = "MG", price = "2.997", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1704, name = "ROSUVASTATINA", concentration = "10", units = "MG", price = "1.8277", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1705, name = "ROSUVASTATINA", concentration = "20", units = "MG", price = "2.89", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1706, name = "RUPATADINA", concentration = "10", units = "MG", price = "2.0588", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1707, name = "RUSCOGENIN + TRIMEBUTINA", concentration = "1", units = "%", price = "0.3727", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1708, name = "SALBUTAMOL", concentration = "2", units = "MG", price = "0.1963", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1709, name = "SALBUTAMOL", concentration = "4", units = "MG", price = "0.2253", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1710, name = "SALBUTAMOL", concentration = "5", units = "MG/ ML", price = "0.5495", cat = "Liquidos para nebulizar", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1711, name = "SALBUTAMOL", concentration = "2", units = "MG/ 5 ML", price = "0.034", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1712, name = "SALBUTAMOL", concentration = "100", units = "MCG/ DOSIS", price = "0.0315", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1713, name = "SALBUTAMOL", concentration = "200", units = "MCG/ DOSIS", price = "0.0316", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1714, name = "SECNIDAZOL", concentration = "125", units = "MG/ 5 ML", price = "0.2306", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1715, name = "SECNIDAZOL", concentration = "250", units = "MG/ 5 ML", price = "0.2646", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1716, name = "SECNIDAZOL", concentration = "500", units = "MG/ EFP", price = "0.2861", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1717, name = "SECNIDAZOL", concentration = "750", units = "MG/ EFP", price = "0.3151", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1718, name = "SECNIDAZOL", concentration = "125", units = "MG", price = "6.8306", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1719, name = "SECNIDAZOL", concentration = "150", units = "MG/ 5 ML", price = "0.4065", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1720, name = "SECNIDAZOL", concentration = "1000", units = "MG", price = "3.9568", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1721, name = "SERTRALINA", concentration = "50", units = "MG", price = "1.1233", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1722, name = "SERTRALINA", concentration = "100", units = "MG", price = "1.5621", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1723, name = "SERTRALINA", concentration = "100", units = "MG", price = "3.8648", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1724, name = "SERTRALINA", concentration = "50", units = "MG", price = "2.4956", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1725, name = "SEVOFLURANO", concentration = "100", units = "%", price = "1.2682", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1726, name = "SILDENAFIL", concentration = "50", units = "MG", price = "6.504", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1727, name = "SILDENAFIL", concentration = "100", units = "MG", price = "10.0736", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1728, name = "SILDENAFIL", concentration = "25", units = "MG", price = "1.5834", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1729, name = "SIMETICONA [DIMETICONA]", concentration = "20", units = "MG/ 0.3 ML", price = "0.1156", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1730, name = "SIMETICONA [DIMETICONA]", concentration = "40", units = "MG/ ML", price = "0.1326", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1731, name = "SIMETICONA [DIMETICONA]", concentration = "50", units = "MG/ ML", price = "0.2031", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1732, name = "SIMETICONA [DIMETICONA]", concentration = "100", units = "MG/ ML", price = "0.2331", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1733, name = "SIMETICONA + BROMURO DE PINAVERIO", concentration = "300", units = "MG", price = "1.6802", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1734, name = "SIMETICONA + METOCLOPRAMIDA", concentration = "5", units = "MG", price = "0.3945", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1735, name = "SIMETICONA + PANCREATINA", concentration = "80", units = "MG", price = "0.2853", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1736, name = "SIMETICONA + PANCREATINA", concentration = "40", units = "MG", price = "0.1425", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1737, name = "SIMVASTATINA", concentration = "40", units = "MG", price = "1.2944", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1738, name = "SIMVASTATINA", concentration = "80", units = "MG", price = "2.3", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1739, name = "SIMVASTATINA", concentration = "10", units = "MG", price = "0.7742", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1740, name = "SIMVASTATINA", concentration = "20", units = "MG", price = "1.2011", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1741, name = "SITAGLIPTINA", concentration = "100", units = "MG", price = "2.1218", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1742, name = "SULBUTIAMINA", concentration = "200", units = "MG", price = "0.5555", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1743, name = "SULFABENZAMIDA + SULFACETAMIDA + SULFADIAZINA + UREA", concentration = "4", units = "%", price = "0.1991", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1744, name = "SULFACETAMIDA", concentration = "10", units = "%", price = "0.3712", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1745, name = "SULFACETAMIDA + SULFADIAZINA + SULFADIMIDINA", concentration = "4", units = "%", price = "0.186", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1746, name = "SULFACETAMIDA + SULFADIAZINA + SULFANILAMIDA", concentration = "3", units = "%", price = "0.0787", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1747, name = "SULFACETAMIDA + SULFADIAZINA + SULFANILAMIDA + UREA", concentration = "3", units = "%", price = "0.1567", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1748, name = "SULFACETAMIDA + SULFANILAMIDA + SULFATIAZOL", concentration = "3", units = "%", price = "0.2221", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1749, name = "SULFACETAMIDA + SULFANILAMIDA + SULFATIAZOL", concentration = "3", units = "G / OVULO", price = "0.7206", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1750, name = "SULFAMETOXAZOL + TRIMETROPRIM", concentration = "800", units = "MG", price = "0.7502", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1751, name = "SULFAMETOXAZOL + TRIMETROPRIM", concentration = "400", units = "MG", price = "0.3867", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1752, name = "SULFAMETOXAZOL + TRIMETROPRIM", concentration = "200", units = "MG/ 5 ML", price = "0.0585", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1753, name = "SULFAMETOXAZOL + TRIMETROPRIM", concentration = "800", units = "MG/ 5 ML", price = "0.2576", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1754, name = "SULFAMETOXAZOL + TRIMETROPRIM", concentration = "120", units = "MG/ 5 ML", price = "0.0495", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1755, name = "SULFAMETOXAZOL + TRIMETROPRIM", concentration = "400", units = "MG/ EFP", price = "5.8415", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1756, name = "SULFAMETOXAZOL + TRIMETROPRIM + GUAIFENESINA + CLORFENAMINA + FENILEFRINA", concentration = "200", units = "MG/ 5 ML", price = "0.0238", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1757, name = "SULFAMETOXAZOL + TRIMETROPRIM + SULFOGUAYACOL", concentration = "25", units = "MG/ ML", price = "0.0765", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1758, name = "SULFASALAZINA", concentration = "500", units = "MG", price = "0.1888", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1759, name = "SULPIRIDA", concentration = "50", units = "MG", price = "0.4425", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1760, name = "SULPIRIDA", concentration = "200", units = "MG", price = "1.3765", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1761, name = "SULPIRIDA", concentration = "25", units = "MG/ 5 ML", price = "0.08", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1762, name = "SULTAMICILINA", concentration = "375", units = "MG", price = "2.1797", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1763, name = "SULTAMICILINA", concentration = "250", units = "MG/ 5 ML", price = "0.3277", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1764, name = "TADALAFIL", concentration = "20", units = "MG", price = "8.2743", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1765, name = "TADALAFIL", concentration = "20", units = "MG", price = "16.3366", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1766, name = "TAMOXIFENO", concentration = "10", units = "MG", price = "0.6225", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1767, name = "TAMOXIFENO", concentration = "20", units = "MG", price = "1.295", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1768, name = "TAMSULOSINA", concentration = "0", units = "MG", price = "1.5051", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1769, name = "TAMSULOSINA", concentration = "0", units = "MG", price = "2.8818", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1770, name = "TELMISARTAN", concentration = "80", units = "MG", price = "2.0034", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1771, name = "TEMOZOLOMIDA", concentration = "100", units = "MG", price = "156.821", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1772, name = "TEMOZOLOMIDA", concentration = "250", units = "MG", price = "385.834", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1773, name = "TENOXICAM", concentration = "20", units = "MG", price = "0.9464", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1774, name = "TEOFILINA", concentration = "50", units = "MG/ 5 ML", price = "0.0215", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1775, name = "TEOFILINA", concentration = "100", units = "MG", price = "0.3844", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1776, name = "TEOFILINA", concentration = "125", units = "MG", price = "0.2433", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1777, name = "TEOFILINA", concentration = "250", units = "MG", price = "0.2961", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1778, name = "TEOFILINA", concentration = "300", units = "MG", price = "0.477", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1779, name = "TEOFILINA", concentration = "150", units = "MG", price = "0.1365", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1780, name = "TEOFILINA", concentration = "250", units = "MG", price = "0.15", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1781, name = "TERAZOSINA", concentration = "1", units = "MG/ ML", price = "0.1598", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1782, name = "TERAZOSINA", concentration = "2", units = "MG", price = "1.2094", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1783, name = "TERAZOSINA", concentration = "5", units = "MG", price = "1.9469", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1784, name = "TERBINAFINA", concentration = "250", units = "MG", price = "2.6551", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1785, name = "TETRACICLINA", concentration = "250", units = "MG", price = "0.0446", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1786, name = "TETRACICLINA", concentration = "500", units = "MG", price = "0.1047", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1787, name = "TIAMINA", concentration = "1000", units = "MG/ EFP", price = "2.26", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1788, name = "TIBOLONA", concentration = "3", units = "MG", price = "0.933", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1789, name = "TICAGRELOR", concentration = "90", units = "MCG", price = "1.906", cat = "Aerosoles y pulverizados inhalados", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1790, name = "TIGECICLINA", concentration = "50", units = "MG/ EFP", price = "100.771", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1791, name = "TIMOLOL", concentration = "1", units = "%", price = "1.6165", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1792, name = "TIMOLOL", concentration = "0", units = "%", price = "2.0011", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1793, name = "TIMOLOL", concentration = "1", units = "%", price = "8.208", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1794, name = "TIMOLOL + TRAVOPROST", concentration = "1", units = "%", price = "16.4256", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1795, name = "TINIDAZOL", concentration = "1000", units = "MG", price = "2.7163", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1796, name = "TINIDAZOL + TIOCONAZOL", concentration = "150", units = "MG / OVULO", price = "2.007", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1797, name = "TIROPRAMIDE", concentration = "100", units = "MG", price = "0.3055", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1798, name = "TIZANIDINA", concentration = "2", units = "MG", price = "0.6525", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1799, name = "TIZANIDINA", concentration = "4", units = "MG", price = "1.0225", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1800, name = "TOBRAMICINA", concentration = "0", units = "%", price = "3.1297", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1801, name = "TOLNAFTATO", concentration = "1", units = "%", price = "0.6481", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1802, name = "TOLTERODINA", concentration = "2", units = "MG", price = "1.105", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1803, name = "TOLTERODINA", concentration = "4", units = "MG", price = "2.5438", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1804, name = "TOPIRAMATO", concentration = "25", units = "MG", price = "0.488", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1805, name = "TOPIRAMATO", concentration = "50", units = "MG", price = "0.9058", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1806, name = "TOPIRAMATO", concentration = "100", units = "MG", price = "1.5936", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1807, name = "TORASEMIDA", concentration = "5", units = "MG", price = "0.4575", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1808, name = "TORASEMIDA", concentration = "10", units = "MG", price = "0.5268", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1809, name = "TRAMADOL", concentration = "100", units = "MG/ EFP", price = "0.7543", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1810, name = "TRAMADOL", concentration = "50", units = "MG/ EFP", price = "1.3441", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1811, name = "TRAMADOL", concentration = "100", units = "MG/ ML", price = "1.0883", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1812, name = "TRAMADOL", concentration = "100", units = "MG", price = "1.67", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1813, name = "TRAMADOL", concentration = "150", units = "MG", price = "1.9323", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1814, name = "TRAMADOL", concentration = "50", units = "MG", price = "1.5251", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1815, name = "TRAMADOL", concentration = "100", units = "MG", price = "0.7767", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1816, name = "TRAMADOL", concentration = "50", units = "MG", price = "0.4965", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1817, name = "TRAMADOL", concentration = "500", units = "MG", price = "0.8331", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1818, name = "TRANDOLAPRIL + VERAPAMILO", concentration = "2", units = "MG", price = "2.196", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1819, name = "TRAVOPROST", concentration = "0", units = "%", price = "14.4393", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1820, name = "TRETINOINA", concentration = "10", units = "MG", price = "4.0625", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1821, name = "TRETINOINA", concentration = "0", units = "%", price = "0.3936", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1822, name = "TRETINOINA", concentration = "0", units = "%", price = "0.3986", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1823, name = "TRETINOINA", concentration = "0", units = "%", price = "0.4251", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1824, name = "TRETINOINA", concentration = "0", units = "%", price = "0.4672", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1825, name = "TRIAMCINOLONA", concentration = "1", units = "%", price = "1.1649", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1826, name = "TRIAZOLAM", concentration = "1", units = "MG", price = "0.4744", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1827, name = "TRIFLUSAL", concentration = "300", units = "MG", price = "2.2175", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1828, name = "TRIMEBUTINA", concentration = "100", units = "MG", price = "0.3684", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1829, name = "TRIMEBUTINA", concentration = "200", units = "MG", price = "0.8375", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1830, name = "TRIMEBUTINA", concentration = "300", units = "MG", price = "1.16", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1831, name = "TRIMEBUTINA", concentration = "48", units = "MG/ 10 ML", price = "0.0474", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1832, name = "TRIMEBUTINA", concentration = "200", units = "MG/ 15 ML", price = "0.0863", cat = "Liquidos orales", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1833, name = "TRIMEBUTINA", concentration = "50", units = "MG/ EFP", price = "3.7892", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1834, name = "TRIMEBUTINA", concentration = "300", units = "MG/ EFP", price = "4.1578", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1835, name = "TRIMETAZIDINA", concentration = "20", units = "MG", price = "0.22", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1836, name = "TRIMETAZIDINA", concentration = "30", units = "MG", price = "0.3125", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1837, name = "TRIMETAZIDINA", concentration = "35", units = "MG", price = "0.5238", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1838, name = "TROMANTADINA", concentration = "1", units = "%", price = "1.0776", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1839, name = "TROPICAMIDA", concentration = "1", units = "%", price = "1.08", cat = "Gotas oftalmicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1840, name = "UREA", concentration = "20", units = "%", price = "0.2335", cat = "Cremas ungüentos y otras aplicaciones topicas", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1841, name = "VALACICLOVIR", concentration = "500", units = "MG", price = "3.03", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1842, name = "VALPROATO SEMISODICO", concentration = "125", units = "MG", price = "0.2877", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1843, name = "VALPROATO SEMISODICO", concentration = "500", units = "MG", price = "0.895", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1844, name = "VALPROATO SEMISODICO [DIVALPROATO SODICO]", concentration = "250", units = "MG", price = "0.6758", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1845, name = "VALPROATO SEMISODICO [DIVALPROATO SODICO]", concentration = "500", units = "MG", price = "0.9025", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1846, name = "VALSARTAN", concentration = "80", units = "MG", price = "1.1254", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1847, name = "VALSARTAN", concentration = "160", units = "MG", price = "1.3118", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1848, name = "VALSARTAN", concentration = "320", units = "MG", price = "1.7638", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1849, name = "VANCOMICINA", concentration = "500", units = "MG/ EFP", price = "6.8569", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1850, name = "VARDENAFILO", concentration = "10", units = "MG", price = "10.8525", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1851, name = "VARDENAFILO", concentration = "20", units = "MG", price = "14.386", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1852, name = "VENLAFAXINA", concentration = "75", units = "MG", price = "2.2681", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1853, name = "VENLAFAXINA", concentration = "150", units = "MG", price = "2.7252", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1854, name = "VENLAFAXINA", concentration = "150", units = "MG", price = "4.0648", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1855, name = "VENLAFAXINA", concentration = "75", units = "MG", price = "3.2225", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1856, name = "VERAPAMILO", concentration = "80", units = "MG", price = "0.2794", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1857, name = "VERAPAMILO", concentration = "120", units = "MG", price = "0.7964", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1858, name = "VERAPAMILO", concentration = "240", units = "MG", price = "1.5563", cat = "Tabletas de liberacion retardada", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1859, name = "VILDAGLIPTINA", concentration = "50", units = "MG", price = "0.9", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1860, name = "VINCRISTINA", concentration = "1", units = "MG/ ML", price = "20.7638", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1861, name = "VORICONAZOL", concentration = "200", units = "MG", price = "43.1217", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1862, name = "VORICONAZOL", concentration = "200", units = "MG/ EFP", price = "145.486", cat = "Liquidos inyectables", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1863, name = "WARFARINA", concentration = "5", units = "MG", price = "0.4457", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1864, name = "YOHIMBINA", concentration = "5", units = "MG", price = "0.3865", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1865, name = "ZIDOVUDINA", concentration = "100", units = "MG", price = "1.1305", cat = "Tabletas y similares", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new med_medicine() { idmedicine = 1866, name = "ZIDOVUDINA", concentration = "50", units = "MG/ 5 ML", price = "0.0725", cat = "Liquidos orales", status = "I" });
                });
                #endregion

                #region addStates
                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "AHUACHAPAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "SANTA ANA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "SONSONATE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "CHALATENANGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "LA LIBERTAD", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "SAN SALVADOR", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "CUSCATLAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "LA PAZ", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "CABAÑAS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "SAN VICENTE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "USULUTAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "SAN MIGUEL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "MORAZAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new states() { name = "LA UNION", status = "I" });
                });
                #endregion

                #region addCities
                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "AHUACHAPAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "APANECA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "ATIQUIZAYA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "CONCEPCION DE ATACO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "EL REFUGIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "GUAYMANGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "JUJUTLA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "SAN FRANCISCO MENENDEZ", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "SAN LORENZO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "SAN PEDRO PUXTLA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "TACUBA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 1, name = "TURIN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "CANDELARIA DE LA FRONTERA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "COATEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "CHALCHUAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "EL CONGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "EL PORVENIR", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "MASAHUAT", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "METAPAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "SAN ANTONIO PAJONAL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "SAN SEBASTIAN SALITRILLO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "SANTA ANA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "SANTA ROSA GUACHIPILIN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "SANTIAGO DE LA FRONTERA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 2, name = "TEXISTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "ACAJUTLA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "ARMENIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "CALUCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "CUISNAHUAT", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "SANTA ISABEL ISHUATAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "IZALCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "JUAYUA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "NAHUIZALCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "NAHULINGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "SALCOATITAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "SAN ANTONIO DEL MONTE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "SAN JULIAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "SANTA CATARINA MASAHUAT", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "SANTO DOMINGO DE GUZMAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "SONSONATE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 3, name = "SONZACATE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "AGUA CALIENTE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "ARCATAO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "AZACUALPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "CITALA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "COMALAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "CONCEPCION QUEZALTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "CHALATENANGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "DULCE NOMBRE DE MARIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "EL CARRIZAL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "EL PARAISO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "LA LAGUNA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "LA PALMA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "LA REINA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "LAS VUELTAS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "NOMBRE DE JESUS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "NUEVA CONCEPCION", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "NUEVA TRINIDAD", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "OJOS DE AGUA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "POTONICO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN ANTONIO DE LA CRUZ", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN ANTONIO LOS RANCHOS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN FERNANDO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN FRANCISCO LEMPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN FRANCISCO MORAZAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN IGNACIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN ISIDRO LABRADOR", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "CANCASQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "LAS FLORES", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN LUIS DEL CARMEN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN MIGUEL DE MERCEDES", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SAN RAFAEL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "SANTA RITA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 4, name = "TEJUTLA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "ANTIGUO CUSCATLAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "CIUDAD ARCE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "COLON", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "COMASAGUA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "CHILTIUPAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "HUIZUCAR", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "JAYAQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "JICALAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "LA LIBERTAD", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "NUEVO CUSCATLAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "SANTA TECLA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "QUEZALTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "SACACOYO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "SAN JOSE VILLANUEVA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "SAN JUAN OPICO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "SAN MATIAS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "SAN PABLO TACACHICO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "TAMANIQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "TALNIQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "TEOTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "TEPECOYO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 5, name = "ZARAGOZA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "AGUILARES", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "APOPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "AYUTUXTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "CUSCATANCINGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "EL PAISNAL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "GUAZAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "ILOPANGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "MEJICANOS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "NEJAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "PANCHIMALCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "ROSARIO DE MORA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "SAN MARCOS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "SAN MARTIN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "SAN SALVADOR", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "SANTIAGO TEXACUANGOS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "SANTO TOMAS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "SOYAPANGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "TONACATEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 6, name = "CIUDAD DELGADO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "CANDELARIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "COJUTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "EL CARMEN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "EL ROSARIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "MONTE SAN JUAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "ORATORIO DE CONCEPCION", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SAN BARTOLOME PERULAPIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SAN CRISTOBAL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SAN JOSE GUAYABAL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SAN PEDRO PERULAPAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SAN RAFAEL CEDROS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SAN RAMON", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SANTA CRUZ ANALQUITO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SANTA CRUZ MICHAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "SUCHITOTO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 7, name = "TENANCINGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "CUYULTITAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "EL ROSARIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "JERUSALEN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "MERCEDES LA CEIBA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "OLOCUILTA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "PARAISO DE OSORIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN ANTONIO MASAHUAT", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN EMIGDIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN FRANCISCO CHINAMECA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN JUAN NONUALCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN JUAN TALPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN JUAN TEPEZONTES", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN LUIS TALPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN MIGUEL TEPEZONTES", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN PEDRO MASAHUAT", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN PEDRO NONUALCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN RAFAEL OBRAJUELO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SANTA MARIA OSTUMA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SANTIAGO NONUALCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "TAPALHUACA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "ZACATECOLUCA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 8, name = "SAN LUIS LA HERRADURA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "CINQUERA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "GUACOTECTI", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "ILOBASCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "JUTIAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "SAN ISIDRO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "SENSUNTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "TEJUTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "VICTORIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 9, name = "DOLORES", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "APASTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "GUADALUPE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "SAN CAYETANO ISTEPEQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "SANTA CLARA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "SANTO DOMINGO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "SAN ESTEBAN CATARINA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "SAN ILDEFONSO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "SAN LORENZO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "SAN SEBASTIAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "SAN VICENTE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "TECOLUCA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "TEPETITAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 10, name = "VERAPAZ", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "ALEGRIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "BERLIN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "CALIFORNIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "CONCEPCION BATRES", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "EL TRIUNFO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "EREGUAYQUIN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "ESTANZUELAS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "JIQUILISCO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "JUCUAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "JUCUARAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "MERCEDES UMAÑA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "NUEVA GRANADA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "OZATLAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "PUERTO EL TRIUNFO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "SAN AGUSTIN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "SAN BUENA VENTURA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "SAN DIONISIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "SANTA ELENA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "SAN FRANCISCO JAVIER", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "SANTA MARIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "SANTIAGO DE MARIA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "TECAPAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 11, name = "USULUTAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "CAROLINA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "CIUDAD BARRIOS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "COMACARAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "CHAPELTIQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "CHINAMECA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "CHIRILAGUA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "EL TRANSITO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "LOLOTIQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "MONCAGUA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "NUEVA GUADALUPE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "NUEVO EDEN DE SAN JUAN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "QUELEPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "SAN ANTONIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "SAN GERARDO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "SAN JORGE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "SAN LUIS DE LA REINA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "SAN MIGUEL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "SAN RAFAEL ORIENTE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "SESORI", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 12, name = "ULUAZAPA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "ARAMBALA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "CACAOPERA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "CORINTO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "CHILANGA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "DELICIAS DE CONCEPCION", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "EL DIVISADERO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "EL ROSARIO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "GUALOCOCTI", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "GUATAJIAGUA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "JOATECA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "JOCOAITIQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "JOCORO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "LOLOTIQUILLO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "MEANGUERA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "OSCICALA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "PERQUIN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "SAN CARLOS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "SAN FERNANDO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "SAN FRANCISCO GOTERA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "SAN ISIDRO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "SAN SIMON", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "SENSEMBRA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "SOCIEDAD", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "TOROLA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "YAMABAL", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 13, name = "YOLOAIQUIN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "ANAMOROS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "BOLIVAR", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "CONCEPCION DE ORIENTE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "CONCHAGUA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "EL CARMEN", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "EL SAUCE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "INTIPUCA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "LA UNION", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "LISLIQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "MEANGUERA DEL GOLFO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "NUEVA ESPARTA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "PASAQUINA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "POLOROS", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "SAN ALEJO", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "SAN JOSE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "SANTA ROSA DE LIMA", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "YAYANTIQUE", status = "I" });
                }); cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new cities() { idstate = 14, name = "YUCUAIQUIN", status = "I" });
                });
                #endregion

                #region addDrugstores

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new drugstores() { iddrugstore = 1, name = "Farmacia San Nicolás, Las Cascadas", address = "Centro comercial Las Cascadas, local L-110, Intersección Avenida Jerusalén y carretera Panamericana", idcity = 5, status = "I", rating=5 });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new drugstores() { iddrugstore = 2, name = "Farmacia las Américas, Las Palmas", address = " km 121/2 carretera al Puerto De La Libertad centr. comer. Las Palmas shopping center local nº 8", idcity = 5, status = "I", rating = 5 });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new drugstores() { iddrugstore = 3, name = "Farmacia las Américas, Sinai", address = "29 Calle Oriente, nº 405", idcity = 6, status = "I", rating = 5 });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new drugstores() { iddrugstore = 4, name = "Farmacia Economicas, Las Cascadas", address = "Centro comercial Las Cascadas", idcity = 5, status = "I", rating = 5 });
                });
                #endregion

                #region addMedDrug
                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 1, idmedicine = 1, iddrugstore = 1, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 2, idmedicine = 1, iddrugstore = 3, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 3, idmedicine = 3, iddrugstore = 2, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 4, idmedicine = 5, iddrugstore = 4, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 5, idmedicine = 8, iddrugstore = 1, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 6, idmedicine = 1, iddrugstore = 2, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 7, idmedicine = 2, iddrugstore = 3, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 8, idmedicine = 8, iddrugstore = 1, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 1, idmedicine = 3, iddrugstore = 4, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 1, idmedicine = 5, iddrugstore = 1, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 1, idmedicine = 7, iddrugstore = 3, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 1, idmedicine = 7, iddrugstore = 2, status = "I" });
                });

                cnn.db.RunInTransaction(() =>
                {
                    cnn.db.Insert(new medDrug() { idMeddrug = 1, idmedicine = 1, iddrugstore = 1, status = "I" });
                });
                #endregion

                cnn.close();

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
                    new Uri("http://getSMedicines.php?name=" + queryLike));
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
                dbSQLite cn = new dbSQLite();
                cn.open();

                string query = "SELECT * FROM drugstores WHERE name like '%" + queryLike + "%'";
                drugstore = cn.db.Query<drugstores>(query);

                if (drugstore.Count > 0)
                    llsResultsDS.ItemsSource = drugstore;
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
                    new Uri("http://getSDrugstores.php?name=" + queryLike));
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