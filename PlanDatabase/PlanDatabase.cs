namespace PlanDatabase
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Entities;

    using SQLite.Net;
    using SQLite.Net.Platform.WinRT;

    internal interface IPlanDatabase
    {
        Task<List<DatabaseClasses>> GetAllClasseses();

        Task<DatabaseClasses> GetClasseses(int id);

        Task UpdateClasseses(DatabaseClasses classes);

        Task DeleteClasses(int id);

        Task AddClasses(DatabaseClasses classes);

        Task UpdateStudentSetting(StudentSetting setting);

        Task<StudentSetting> GetStudentSetting();
    }

    internal class PlanDatabase : IPlanDatabase
    {
        private static PlanDatabase planDatabase;

        private readonly string databasePath = Path.Combine(
            Windows.Storage.ApplicationData.Current.LocalFolder.Path,
            "planDb.sqlite");

        private PlanDatabase()
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            if (!File.Exists(this.databasePath))
            {
                this.CreateDatabase();
            }
            try
            {
                connection.Get<StudentSetting>(0);
                connection.Table<DatabaseClasses>();
            }
            catch (Exception)
            {
                connection.Close();
                File.Delete(this.databasePath);
                this.CreateDatabase();
            }
        }

        public static PlanDatabase Instance => planDatabase ?? (planDatabase = new PlanDatabase());

        public Task<List<DatabaseClasses>> GetAllClasseses()
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        return connection.Table<DatabaseClasses>().ToList();
                    });
        }

        public Task<DatabaseClasses> GetClasseses(int id)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        return connection.Get<DatabaseClasses>(id);
                    });
        }

        public Task UpdateClasseses(DatabaseClasses classes)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        connection.Update(classes);
                    });
        }

        public Task DeleteClasses(int id)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        connection.Delete(id);
                    });
        }

        public Task AddClasses(DatabaseClasses classes)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        connection.Insert(classes);
                    });
        }

        public Task UpdateStudentSetting(StudentSetting setting)
        {
            return Task.Factory.StartNew(
                () =>
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
                    });
        }

        public Task<StudentSetting> GetStudentSetting()
        {
            return Task.Factory.StartNew(
                () =>
                {
                    var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                    try
                    {
                        return connection.Get<StudentSetting>(0);
                    }
                    catch {}
                    return null;
                });           
        }

        private void CreateDatabase()
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            connection.CreateTable<DatabaseClasses>();
            connection.CreateTable<StudentSetting>();
        }
    }
}
