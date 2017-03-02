namespace PlanVisual.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Bases;
    using Helpers;
    using Plan.DataClasses;

    using PlanVisual.Tools;

    using Prism.Commands;

    public class SeminarViewModel : ViewModelBase
    {
        private ObservableCollection<ExtendedClasses> seminars;
        private IEnumerable<IGrouping<object, ExtendedClasses>> groupedSeminars;
        private DelegateCommand selectedCommand;
        private string filter;

        public SeminarViewModel()
        {
        }

        public DelegateCommand SelectedCommand => this.selectedCommand ?? (this.selectedCommand = new DelegateCommand(this.Load));

        public IEnumerable<IGrouping<object, ExtendedClasses>> GroupedSeminars
        {
            get
            {
                return this.groupedSeminars;
            }

            set
            {
                this.groupedSeminars = value;
                this.OnPropertyChanged(() => this.GroupedSeminars);
            }
        }

        public ObservableCollection<ExtendedClasses> Seminars
        {
            get
            {
                return this.seminars;
            }

            set
            {
                this.seminars = value;
                this.OnPropertyChanged(() => this.Seminars);
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
            this.Seminars = new ObservableCollection<ExtendedClasses>(await this.Service.GetPlanSeminars());
            foreach (var f in this.Seminars)
            {
                Improver.LecturerSplit(f);
            }

            this.ChangeGroupByProperty(this.Filter);
            this.LoadingOff();
        }

        private void ChangeGroupByProperty(string propertyName)
        {
            if (this.Seminars.ItemType().HasProperty(propertyName))
            {
                this.GroupedSeminars = this.Seminars.GroupBy(c => c.PropertyValue(propertyName)).OrderBy(x => x.Key);
            }           
        }

        private void ChangeGroupByProperty<T, TP>(Expression<Func<T, TP>> expression) where T : class
        {
            this.ChangeGroupByProperty(TypeHelpers.PropertyName(expression));
        }
    }
}