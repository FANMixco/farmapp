using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace pillsSV.Classes
{
    public class UserInfo
    {
        public string iduser { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime updateCity { get; set; }
        public DateTime updateState { get; set; }
        public DateTime updateDrugstore { get; set; }
        public DateTime updateMedicine { get; set; }
        public bool offlineData { get; set; }
        public bool firstTime { get; set; }
        public bool autoUpdate { get; set; }
        public int updateFrequency { get; set; }
        public DateTime lastUpdate { get; set; }
        public DateTime nextUpdate { get; set; }
    }

    public class manageProfile
    {
        private UserInfo data;
        public bool getStatus()
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("user.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
                        data = (UserInfo)serializer.Deserialize(stream);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UserInfo getUserInfo()
        {
            return data;
        }

        private UserInfo GeneratePersonData(bool offlinedata)
        {
            UserInfo dataInfo = new UserInfo();
            UserInfo ui = new UserInfo();

            //asign basic values
            ui.iduser = "";
            ui.name = "";
            ui.email = "";
            ui.offlineData = offlinedata;
            ui.lastUpdate = new DateTime(2014, 07, 24);
            ui.updateFrequency = 15;
            ui.nextUpdate = DateTime.Now.AddDays(15);
            ui.autoUpdate = true;
            ui.firstTime = true;
            dataInfo = ui;
            return dataInfo;
        }

        public void updateFirstTime()
        {

        }

        public void updateProfile(UserInfo updatedData)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                //Open existing file
                if (myIsolatedStorage.FileExists("user.xml"))
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("user.xml", FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<UserInfo>));
                        using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                        {
                            serializer.Serialize(xmlWriter, updatedData);
                        }
                    }
                }
            }
        }

        public void createUser(bool offlinedata)
        {
            //Initialize the session here
            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("user.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        //set values from User
                        serializer.Serialize(xmlWriter, GeneratePersonData(offlinedata));
                    }
                }
            }

        }
    }
}
