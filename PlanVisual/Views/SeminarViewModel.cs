namespace PlanVisual.Views
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using Bases;
    using Helpers;
    using Plan;

    public class SeminarViewModel : ViewModelBase
    {
        private ObservableCollection<Classes> seminars;
        private IEnumerable<IGrouping<object, Classes>> groupedSeminars;

        public SeminarViewModel()
        {
            this.Load();
        }

        public IEnumerable<IGrouping<object, Classes>> GroupedSeminars
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

        public ObservableCollection<Classes> Seminars
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

        private async void Load()
        {
            this.LoadingOn();
            this.Seminars = new ObservableCollection<Classes>(await this.DataDownloader.DownloadPlanSeminars());
            this.ChangeGroupByProperty((Classes c) => c.Day);
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