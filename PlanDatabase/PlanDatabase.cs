namespace PlanDatabase
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Entities;
    using SQLite.Net;
    using SQLite.Net.Platform.WinRT;

    internal class PlanDatabase
    {
        private static PlanDatabase planDatabase;
        private readonly string databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "planDb.sqlite");

        private PlanDatabase()
        {
            if (!File.Exists(this.databasePath))
            {
                this.CreateDatabase();
            }
        }

        public static PlanDatabase Instance => planDatabase ?? (planDatabase = new PlanDatabase());

        public List<DatabaseClasses> GetAllClasseses()
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            return connection.Table<DatabaseClasses>().ToList();
        }

        public DatabaseClasses GetClasseses(int id)
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            return connection.Get<DatabaseClasses>(id);
        }

        public void UpdateClasseses(DatabaseClasses classes)
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            connection.Update(classes);
        }

        public void DeleteClasses(DatabaseClasses classes)
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            connection.Delete(classes);
        }

        public void AddClasses(DatabaseClasses classes)
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            connection.Insert(classes);
        }

        public void UpdateStudentSetting(StudentSetting setting)
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            if (connection.Get<StudentSetting>(0) == null)
            {
                connection.Insert(setting);
            }
            else
            {
                connection.Update(setting);
            }
        }

        public StudentSetting GetStudentSetting()
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            return connection.Get<StudentSetting>(0);
        }

        private void CreateDatabase()
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            connection.CreateTable<DatabaseClasses>();
            connection.CreateTable<StudentSetting>();
        }
    }
}
