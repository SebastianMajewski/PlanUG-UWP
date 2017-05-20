namespace PlanDatabase
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Plan.DataClasses;
    using Plan.PlanServiceReference;
    using Plan.Tools;

    public interface IPlanRepository
    {
        Task<List<ExtendedClasses>> GetAllUserClasses();

        Task<ExtendedClasses> GetUserClasses(int id);

        Task DeleteUserClasses(ExtendedClasses classes);

        Task UpdateUserClasses(ExtendedClasses classes);

        Task AddUserClasses(ExtendedClasses classes);

        Task UpdateStudentSettings(StudentSetting setting);

        Task<StudentSetting> GetStudentSetting();
    }

    public class PlanRepository : IPlanRepository
    {
        private readonly IPlanDatabase database;

        public PlanRepository()
        {
            this.database = PlanDatabase.Instance;
        }

        public async Task<List<ExtendedClasses>> GetAllUserClasses()
        {
            var classes = await this.database.GetAllClasseses();
            return classes.Select(this.ToExtendedClasses).ToList();
        }

        public async Task<ExtendedClasses> GetUserClasses(int id)
        {
            return this.ToExtendedClasses(await this.database.GetClasseses(id));
        }

        public async Task DeleteUserClasses(ExtendedClasses classes)
        {
            if (classes.AssociatedId != null)
            {
                await this.database.DeleteClasses(classes.AssociatedId.Value);
            }
        }

        public async Task UpdateUserClasses(ExtendedClasses classes)
        {
            await this.database.UpdateClasseses(this.ToDatabaseClasses(classes));
        }

        public async Task AddUserClasses(ExtendedClasses classes)
        {
            await this.database.AddClasses(this.ToDatabaseClasses(classes));
        }

        public async Task UpdateStudentSettings(StudentSetting setting)
        {
            await this.database.UpdateStudentSetting(setting);
        }

        public async Task<StudentSetting> GetStudentSetting()
        {
            return await this.database.GetStudentSetting();
        }

        private ExtendedClasses ToExtendedClasses(DatabaseClasses classes)
        {
            if (classes.Id == null)
            {
                classes.Id = default(int);
            }

            return new ExtendedClasses(classes.Id.Value)
            {
                Subject = classes.Subject,
                Comments = classes.Comments,
                Day = classes.Day.ToDayObject(),
                DateTo = classes.DateTo,
                Group = classes.Group,
                Hours = new TimeInterval { TimeFrom = classes.TimeFrom, TimeTo = classes.TimeTo },
                Lecturer = classes.Lecturer,
                Room = classes.Room,
                Type = classes.Type.ToClassesTypeObject()
            };
        }

        private DatabaseClasses ToDatabaseClasses(ExtendedClasses classes)
        {
            return new DatabaseClasses
            {
                Id = classes.AssociatedId,
                Comments = classes.Comments,
                DateTo = classes.DateTo,
                Day = (Day)classes.Day.Day,
                Group = classes.Group,
                Lecturer = classes.Lecturer,
                Room = classes.Room,
                Subject = classes.Subject,
                TimeFrom = classes.Hours.TimeFrom,
                TimeTo = classes.Hours.TimeTo,
                Type = (ClassesType)classes.Type.Type,
                IsUserDefined = classes.IsUserDefined
            };
        }
    }
}
