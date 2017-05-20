namespace PlanVisual.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Bases;
    using Helpers;
    using Plan.DataClasses;
    using Plan.PlanServiceReference;
    using PlanDatabase;
    using PlanDatabase.Entities;
    using Prism.Commands;
    using Tools;

    public class ForStudentViewModel : ViewModelBase
    {
        private readonly PlanRepository repository;
        private ObservableCollection<ExtendedClasses> classes;
        private ObservableCollection<PlanSelect> options;
        private IEnumerable<IGrouping<object, ExtendedClasses>> groupedclasses;
        private DelegateCommand selectedCommand;
        private DelegateCommand configureCommand;
        private bool formVisibled;
        private string filter;
        private StudentSetting setting;

        public ForStudentViewModel()
        {
            this.repository = new PlanRepository();
        }

        public DelegateCommand SelectedCommand => this.selectedCommand ?? (this.selectedCommand = new DelegateCommand(this.Load));

        public DelegateCommand ConfigureCommand => this.configureCommand ?? (this.configureCommand = new DelegateCommand(this.NavigateConfigure));

        public ObservableCollection<ExtendedClasses> Classes
        {
            get
            {
                return this.classes;
            }

            set
            {
                this.classes = value;
                this.OnPropertyChanged(() => this.Classes);
            }
        }

        public ObservableCollection<PlanSelect> Options
        {
            get
            {
                return this.options;
            }

            set
            {
                this.options = value;
                this.OnPropertyChanged(() => this.Options);
            }
        }

        public bool FormVisibled
        {
            get
            {
                return this.formVisibled;
            }

            private set
            {
                this.formVisibled = value;
                this.OnPropertyChanged(() => this.FormVisibled);
            }
        }

        public IEnumerable<IGrouping<object, ExtendedClasses>> GroupedClasses
        {
            get
            {
                return this.groupedclasses;
            }

            set
            {
                this.groupedclasses = value;
                this.OnPropertyChanged(() => this.GroupedClasses);
            }
        }

        public string Filter
        {
            get
            {
                return this.filter ?? "Subject";
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.filter = value;
                    this.ChangeGroupByProperty(value);
                    this.OnPropertyChanged(() => this.Filter);
                }
            }
        }

        private async void Load()
        {
            this.LoadingOn();
            this.setting = await this.repository.GetStudentSetting();
            if (this.setting != null)
            {
                this.FormVisibled = false;
                var c = await this.Service.GetPlanForStudent(this.ConvertSetting(this.setting));
                this.Classes = new ObservableCollection<ExtendedClasses>(c);
                this.ChangeGroupByProperty(this.Filter);
            }
            else
            {
                this.FormVisibled = true;
            }

            this.LoadingOff();       
        }

        private void NavigateConfigure()
        {
            var item = PivotNavigator.Instance.Items.First(x => x.ItemName == "Settings");
            PivotNavigator.Instance.NavigateToItem(item);
        }

        private void ChangeGroupByProperty(string propertyName)
        {
            if (this.Classes.ItemType().HasProperty(propertyName))
            {
                this.GroupedClasses = this.Classes.GroupBy(c => c.PropertyValue(propertyName)).OrderBy(x => x.Key);
            }
        }

/*
        private void ChangeGroupByProperty<T, TP>(Expression<Func<T, TP>> expression) where T : class
        {
            // this.ChangeGroupByProperty(TypeHelpers.PropertyName(expression));
            this.Filter = TypeHelpers.PropertyName(expression);
        }
*/

        private PlanForStudentSetting ConvertSetting(StudentSetting set)
        {
            return new PlanForStudentSetting
            {
                Faculties = set.Faculties,
                FacultyPrefix = set.FacultyPrefix,
                Group = set.Group,
                Lectorate = set.Lectorate,
                SeminarPrefix = set.SeminarPrefix,
                Seminar = set.Seminar,
                Speciality = set.Speciality,
                Symbol = set.Symbol
            };
        }
    }
}
