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
        private UserInfo data = new UserInfo();
        private manageProfile _profile = new manageProfile();
        private status deserialized;

        public updateData()
        {
            //to set userData
            _profile.getStatus();

            data = _profile.getUserInfo();
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

        public async void updateInfo(DateTime lDate)
        {
            WebClient[] w = new WebClient[4];

            for (int i = 0; i < 4; i++)
                w[i] = new WebClient();

            //check city data and if it's necesary update
            if (deserialized.updateCity != data.updateCity)
            {
                Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w[0], "DownloadStringCompleted")
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
                w[0].DownloadStringAsync(new Uri("http://getCities.php?lastDate=" + lDate.ToString()));
            }

            //check company data and if it's necesary update
            if (deserialized.updateDrugstore != data.updateDrugstore)
            {
                Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w[1], "DownloadStringCompleted")
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

                        checkMedDrug(lDate.ToString());
                    });
                w[1].DownloadStringAsync(new Uri("http://getDrugstores.php?lastDate=" + lDate.ToString()));
            }

            //check Historical Prices data and if it's necesary update
            if (deserialized.updateMedicine != data.updateMedicine)
            {
                Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w[2], "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        var des = JsonConvert.DeserializeObject<List<med_medicine>>(r.EventArgs.Result);

                        dbSQLite cn = new dbSQLite();
                        cn.open();

                        //Load countries with info
                        string table = "med_medicine";
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
                w[2].DownloadStringAsync(new Uri("http://getMedicines.php?lastDate=" + lDate.ToString()));
            }

            //check Products data and if it's necesary update
            if (deserialized.updateState != data.updateState)
            {
                Observable
                    .FromEvent<DownloadStringCompletedEventArgs>(w[3], "DownloadStringCompleted")
                    .Subscribe(r =>
                    {
                        var des = JsonConvert.DeserializeObject<List<states>>(r.EventArgs.Result);

                        dbSQLite cn = new dbSQLite();
                        cn.open();

                        //Load countries with info
                        string table = "states";
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
                w[3].DownloadStringAsync(new Uri("http://getStates.php?lastDate=" + lDate.ToString()));
            }

        }

        private void actionsMedicines(med_medicine usingData, string option, string table, string SQL_Complement="")
        {
            dbSQLite cnn = new dbSQLite();
            cnn.open();

            switch (option)
            {
                case "I":
                    cnn.db.RunInTransaction(() =>
                    {
                        cnn.db.Insert(new med_medicine() { name = usingData.name, cat = usingData.cat, concentration= usingData.concentration, price= usingData.price, idmedicine=usingData.idmedicine, units=usingData.units, status = "I" });
                    });
                    break;
                default:
                    var existing = cnn.db.Query<med_medicine>("SELECT * FROM " + table + " WHERE " + SQL_Complement).FirstOrDefault();
                    if (existing != null)
                    {
                        existing.name = usingData.name;
                        existing.status = usingData.status;
                        existing.units = usingData.units;
                        existing.price = usingData.price;

                        cnn.db.RunInTransaction(() =>
                        {
                            cnn.db.Update(existing);
                        });
                    }
                    break;
            }
            cnn.close();
        }

        private void actionsDrugstores(drugstores usingData, string option, string table, string SQL_Complement = "")
        {
            dbSQLite cnn = new dbSQLite();
            cnn.open();

            switch (option)
            {
                case "I":
                    cnn.db.RunInTransaction(() =>
                    {
                        cnn.db.Insert(new drugstores() { name = usingData.name, address = usingData.address, description = usingData.description, idcity = usingData.idcity, iddrugstore = usingData.iddrugstore, latitude = usingData.latitude, longitude = usingData.longitude, rating = usingData.rating, telephones = usingData.telephones, status = "I" });
                    });
                    break;
                default:
                    var existing = cnn.db.Query<drugstores>("SELECT * FROM " + table + " WHERE " + SQL_Complement).FirstOrDefault();
                    if (existing != null)
                    {
                        existing.name = usingData.name;
                        existing.telephones = usingData.telephones;
                        existing.rating = usingData.rating;
                        existing.longitude = usingData.longitude;
                        existing.latitude = usingData.latitude;
                        existing.idcity = usingData.idcity;
                        existing.description = usingData.description;
                        existing.address = usingData.address;
                        existing.status = usingData.status;

                        cnn.db.RunInTransaction(() =>
                        {
                            cnn.db.Update(existing);
                        });
                    }
                    break;
            }
            cnn.close();
        }

        private async void checkMedDrug(string lDate)
        {
            WebClient w = new WebClient();

            Observable
                .FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
                .Subscribe(r =>
                {
                    var des = JsonConvert.DeserializeObject<List<medDrug>>(r.EventArgs.Result);

                    dbSQLite cn = new dbSQLite();
                    cn.open();

                    //Load countries with info
                    string table = "medDrug";
                    string query = "SELECT * FROM " + table;
                    List<medDrug> curr = cn.db.Query<medDrug>(query);

                    //to check data to update, delete or insert
                    for (int j = 0; j < des.Count; j++)
                    {
                        var usingData = des[j];

                        string SQL_OPT = " idMeddrug=" + usingData.idMeddrug;

                        switch (des[j].status)
                        {
                            case "I":
                                if (des[j].idMeddrug > curr[curr.Count].idMeddrug)
                                    actionsMedDrug(usingData, "I", table, SQL_OPT);
                                break;
                            default:
                                actionsMedDrug(usingData, usingData.status, table, SQL_OPT);
                                break;
                        }
                    }
                    cn.close();
                });
            w.DownloadStringAsync(new Uri("http://getMedrug.php?lastDate=" + lDate));
        }

        private void actionsMedDrug(medDrug usingData, string option, string table, string SQL_Complement = "")
        {
            dbSQLite cnn = new dbSQLite();
            cnn.open();

            switch (option)
            {
                case "I":
                    cnn.db.RunInTransaction(() =>
                    {
                        cnn.db.Insert(new medDrug() { iddrugstore = usingData.iddrugstore, idMeddrug = usingData.idMeddrug, idmedicine = usingData.idmedicine , status = "I" });
                    });
                    break;
                default:
                    var existing = cnn.db.Query<medDrug>("SELECT * FROM " + table + " WHERE " + SQL_Complement).FirstOrDefault();
                    if (existing != null)
                    {
                        existing.iddrugstore = usingData.iddrugstore;
                        existing.idmedicine = usingData.idmedicine;
                        usingData.status = usingData.status;

                        cnn.db.RunInTransaction(() =>
                        {
                            cnn.db.Update(existing);
                        });
                    }
                    break;
            }
            cnn.close();
        }


        private void actionsCities(cities usingData, string option, string table, string SQL_Complement = "")
        {
            dbSQLite cnn = new dbSQLite();
            cnn.open();

            switch (option)
            {
                case "I":
                    cnn.db.RunInTransaction(() =>
                    {
                        cnn.db.Insert(new cities() { idstate = usingData.idstate, name = usingData.name, status = "I" });
                    });
                    break;
                default:
                    var existing = cnn.db.Query<cities>("SELECT * FROM " + table + " WHERE " + SQL_Complement).FirstOrDefault();
                    if (existing != null)
                    {
                        existing.idstate = usingData.idstate;
                        existing.name = usingData.name;
                        existing.status = usingData.status;

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

        private void actionsStates(states usingData, string option, string table, string SQL_Complement = "")
        {
            dbSQLite cnn = new dbSQLite();
            cnn.open();

            switch (option)
            {
                case "I":
                    cnn.db.RunInTransaction(() =>
                    {
                        cnn.db.Insert(new states() { name = usingData.name, status = "I" });
                    });
                    break;
                default:
                    var existing = cnn.db.Query<states>("SELECT * FROM " + table + " WHERE " + SQL_Complement).FirstOrDefault();
                    if (existing != null)
                    {
                        existing.name = usingData.name;
                        existing.status = usingData.status;

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
