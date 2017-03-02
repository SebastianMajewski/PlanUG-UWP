namespace PlanVisual.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using Bases;
    using Helpers;
    using Plan.DataClasses;

    using PlanVisual.Tools;

    using Prism.Commands;

    public class FacultyViewModel : ViewModelBase
    {
        private ObservableCollection<ExtendedClasses> faculties;
        private IEnumerable<IGrouping<object, ExtendedClasses>> groupedFaculty;
        private DelegateCommand selectedCommand;
        private string filter;

        public FacultyViewModel()
        {
        }

        public DelegateCommand SelectedCommand => this.selectedCommand ?? (this.selectedCommand = new DelegateCommand(this.Load));

        public ObservableCollection<ExtendedClasses> Faculties
        {
            get
            {
                return this.faculties;
            }

            set
            {
                this.faculties = value;
                this.OnPropertyChanged(() => this.Faculties);
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

        public IEnumerable<IGrouping<object, ExtendedClasses>> GroupedFaculty
        {
            get
            {
                return this.groupedFaculty;
            }

            set
            {
                this.groupedFaculty = value;
                this.OnPropertyChanged(() => this.GroupedFaculty);
            }
        }

        private async void Load()
        {
            this.LoadingOn();
            this.Faculties = new ObservableCollection<ExtendedClasses>(await this.Service.GetPlanFaculty());
            foreach (var f in this.Faculties)
            {
                Improver.LecturerSplit(f);
            }

            this.ChangeGroupByProperty(this.Filter);
            this.LoadingOff();
        }

        private void ChangeGroupByProperty(string propertyName)
        {
            if (this.Faculties.ItemType().HasProperty(propertyName))
            {
                this.GroupedFaculty = this.Faculties.GroupBy(c => c.PropertyValue(propertyName)).OrderBy(x => x.Key);
            }
        }

        private void ChangeGroupByProperty<T, TP>(Expression<Func<T, TP>> expression) where T : class
        {
            this.ChangeGroupByProperty(TypeHelpers.PropertyName(expression));
        }
    }
}