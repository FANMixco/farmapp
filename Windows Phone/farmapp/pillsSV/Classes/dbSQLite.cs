using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlite.Classes
{
    public class dbSQLite
    {
        private string dbPath;
        public SQLiteConnection db;

        public dbSQLite()
        {
            this.dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
        }

        public void close()
        {
            db.Close();
        }

        public void createDB()
        {
            if (!FileExists("db.sqlite").Result)
            {
                open();
                using (this.db)
                {
                    this.db.CreateTable<states>();
                    this.db.CreateTable<cities>();
                    this.db.CreateTable<med_medicine>();
                    this.db.CreateTable<drugstores>();
                    this.db.CreateTable<medDrug>();
                }
            }
        }

        public void open()
        {
            this.db = new SQLiteConnection(dbPath);
        }

        private async Task<bool> FileExists(string fileName)
        {
            var result = false;
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                result = true;
            }
            catch { }

            return result;
        }
    }
}
