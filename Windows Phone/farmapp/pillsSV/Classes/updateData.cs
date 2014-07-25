using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using pillsSV.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sqlite.Classes
{
    public class updateData
    {
        private UserInfo data;
        private status deserialized;

        public updateData()
        {
            //to get user information from staticData
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("user.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
                    data = (UserInfo)serializer.Deserialize(stream);
                }
            }

        }

        public async Task<bool> checkData()
        {
            bool dataReturn = false;
            WebClient w = new WebClient();

            Observable
                .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                .Subscribe(r =>
                {
                    deserialized = JsonConvert.DeserializeObject<status>(r.EventArgs.Result);

                    if (deserialized.updateCity != data.updateCity || deserialized.updateDrugstore != data.updateDrugstore || deserialized.updateMedicine != data.updateMedicine || deserialized.updateState != data.updateState)
                        dataReturn = true;
                });
            w.DownloadStringAsync(new Uri("http://getStatus.php"));

            return dataReturn;
        }

        public async void updateInfo()
        {
            WebClient[] w = new WebClient[4];

            for (int i = 0; i < 4; i++)
                w[i] = new WebClient();

            //check city data and if it's necesary update
            if (deserialized.updateCity != data.updateCity)
            {
                Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        var des = JsonConvert.DeserializeObject<List<cities>>(r.EventArgs.Result);

                        dbSQLite cn = new dbSQLite();
                        cn.open();

                        //Load countries with info
                        string table = "cities";
                        string query = "SELECT * FROM " + table;
                        List<cities> curr = cn.db.Query<cities>(query);

                        //to check data to update, delete or insert
                        for (int j = 0; j < des.Count; j++)
                        {
                            var usingData = des[j];

                            string SQL_OPT = " idcity=" + usingData.idcity;

                            switch (des[j].status)
                            {
                                case "I":
                                    if (des[j].idcity > curr[curr.Count].idcity)
                                        actionsCities(usingData, "I", table, SQL_OPT);
                                    break;
                                default:
                                    actionsCities(usingData, usingData.status, table, SQL_OPT);
                                    break;
                            }
                        }
                        cn.close();
                    });
                w[0].DownloadStringAsync(new Uri("http://getCities.php"));
            }

            //check company data and if it's necesary update
            if (deserialized.updateDrugstore != data.updateDrugstore)
            {
                Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        var des = JsonConvert.DeserializeObject<List<drugstores>>(r.EventArgs.Result);

                        dbSQLite cn = new dbSQLite();
                        cn.open();

                        //Load countries with info
                        string table = "drugstores";
                        string query = "SELECT * FROM " + table;
                        List<drugstores> curr = cn.db.Query<drugstores>(query);

                        //to check data to update, delete or insert
                        for (int j = 0; j < des.Count; j++)
                        {
                            var usingData = des[j];

                            string SQL_OPT = " iddrugstore=" + usingData.iddrugstore;

                            switch (des[j].status)
                            {
                                case "I":
                                    if (des[j].iddrugstore > curr[curr.Count].iddrugstore)
                                        actionsDrugstores(usingData, "I", table, SQL_OPT);
                                    break;
                                default:
                                    actionsDrugstores(usingData, usingData.status, table, SQL_OPT);
                                    break;
                            }
                        }
                        cn.close();
                    });
                w[1].DownloadStringAsync(new Uri("http://getDrugstores.php"));
            }

            //check Historical Prices data and if it's necesary update
            if (deserialized.updateMedicine != data.updateMedicine)
            {
                Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        var des = JsonConvert.DeserializeObject<List<med_medicine>>(r.EventArgs.Result);

                        dbSQLite cn = new dbSQLite();
                        cn.open();

                        //Load countries with info
                        string table = "drugstores";
                        string query = "SELECT * FROM " + table;
                        List<med_medicine> curr = cn.db.Query<med_medicine>(query);

                        //to check data to update, delete or insert
                        for (int j = 0; j < des.Count; j++)
                        {
                            var usingData = des[j];

                            string SQL_OPT = " idmedicine=" + usingData.idmedicine;

                            switch (des[j].status)
                            {
                                case "I":
                                    if (des[j].idmedicine > curr[curr.Count].idmedicine)
                                        actionsMedicines(usingData, "I", table, SQL_OPT);
                                    break;
                                default:
                                    actionsMedicines(usingData, usingData.status, table, SQL_OPT);
                                    break;
                            }
                        }
                        cn.close();

                    });
                w[2].DownloadStringAsync(new Uri("http://getMedicines.php"));
            }

            //check Products data and if it's necesary update
            if (deserialized.updateState != data.updateState)
            {
                Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        var des = JsonConvert.DeserializeObject<List<states>>(r.EventArgs.Result);

                        dbSQLite cn = new dbSQLite();
                        cn.open();

                        //Load countries with info
                        string table = "products";
                        string query = "SELECT * FROM " + table;
                        List<states> curr = cn.db.Query<states>(query);

                        //to check data to update, delete or insert
                        for (int j = 0; j < des.Count; j++)
                        {
                            var usingData = des[j];

                            string SQL_OPT = " idstate=" + usingData.idstate;

                            switch (des[j].status)
                            {
                                case "I":
                                    if (des[j].idstate > curr[curr.Count].idstate)
                                        actionsStates(usingData, "I", table, SQL_OPT);
                                    break;
                                default:
                                    actionsStates(usingData, usingData.status, table, SQL_OPT);
                                    break;
                            }
                        }
                        cn.close();
                    });
                w[3].DownloadStringAsync(new Uri("http://getProducts.php"));
            }

        }

        private void actionsMedicines(med_medicine usingData, string p, string table, string SQL_OPT)
        {
            throw new NotImplementedException();
        }

        private void actionsDrugstores(drugstores usingData, string p, string table, string SQL_OPT)
        {
            throw new NotImplementedException();
        }

        private void actionsCities(cities data, string option, string table, string SQL_Complement = "")
        {
            dbSQLite cnn = new dbSQLite();
            cnn.open();

            switch (option)
            {
                case "I":
                    cnn.db.RunInTransaction(() =>
                    {
                        cnn.db.Insert(new cities() { idstate = data.idstate, name = data.name, status = "I" });
                    });
                    break;
                default:
                    var existing = cnn.db.Query<cities>("SELECT * FROM " + table + " WHERE " + SQL_Complement).FirstOrDefault();
                    if (existing != null)
                    {
                        existing.idstate = data.idstate;
                        existing.name = data.name;
                        existing.status = data.status;

                        cnn.db.RunInTransaction(() =>
                        {
                            cnn.db.Update(existing);
                        });
                    }
                    break;
                /*case "D":
                    if (existing != null)
                    {
                        cnn.db.RunInTransaction(() =>
                        {
                            cnn.db.Delete(existing);
                        });
                    }
                    break;*/
            }
            cnn.close();
        }

        private void actionsStates(states data, string option, string table, string SQL_Complement = "")
        {
            dbSQLite cnn = new dbSQLite();
            cnn.open();

            switch (option)
            {
                case "I":
                    cnn.db.RunInTransaction(() =>
                    {
                        cnn.db.Insert(new states() { name = data.name, status = "I" });
                    });
                    break;
                default:
                    var existing = cnn.db.Query<states>("SELECT * FROM " + table + " WHERE " + SQL_Complement).FirstOrDefault();
                    if (existing != null)
                    {
                        existing.name = data.name;
                        existing.status = data.status;

                        cnn.db.RunInTransaction(() =>
                        {
                            cnn.db.Update(existing);
                        });
                    }
                    break;
            }
            cnn.close();
        }

      
    }
}
