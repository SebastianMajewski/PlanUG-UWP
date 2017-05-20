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
                connection.Table<StudentSetting>().Any();
                connection.Table<DatabaseClasses>().Any();
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
                        var value = connection.Table<DatabaseClasses>().ToList();
                        connection.Close();
                        return value;
                    });
        }

        public Task<DatabaseClasses> GetClasseses(int id)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        var value = connection.Get<DatabaseClasses>(id);
                        connection.Close();
                        return value;
                    });
        }

        public Task UpdateClasseses(DatabaseClasses classes)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        connection.Update(classes);
                        connection.Close();
                    });
        }

        public Task DeleteClasses(int id)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        connection.Delete(id);
                        connection.Close();
                    });
        }

        public Task AddClasses(DatabaseClasses classes)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        connection.Insert(classes);
                        connection.Close();
                    });
        }

        public Task UpdateStudentSetting(StudentSetting setting)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
                        if (!connection.Table<StudentSetting>().Any())
                        {
                            connection.Insert(setting);
                        }
                        else
                        {
                            connection.Update(setting);
                        }

                        connection.Close();
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
                        var value = connection.Table<StudentSetting>().FirstOrDefault();
                        connection.Close();
                        return value;
                    }
                    catch
                    {
                        // ignored
                    }

                    connection.Close();
                    return null;
                });           
        }

        private void CreateDatabase()
        {
            var connection = new SQLiteConnection(new SQLitePlatformWinRT(), this.databasePath);
            connection.CreateTable<DatabaseClasses>();
            connection.CreateTable<StudentSetting>();
            connection.Close();
        }
    }
}
