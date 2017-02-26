namespace PlanVisual.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Bases;
    using Plan.DataClasses;
    using Tools;

    public class ChangesViewModel : ViewModelBase
    {
        private ObservableCollection<Change> changes;
        private ObservableCollection<Change> userPlanchanges;
        private bool userHasPlanChanges;

        public ChangesViewModel()
        {
            this.Load();
        }

        public ObservableCollection<Change> Changes
        {
            get
            {
                return this.changes;
            }

            set
            {
                this.changes = value;
                this.OnPropertyChanged(() => this.Changes);
            }
        }

        public ObservableCollection<Change> UserPlanChanges
        {
            get
            {
                return this.userPlanchanges;
            }

            set
            {
                this.userPlanchanges = value;
                this.OnPropertyChanged(() => this.UserPlanChanges);
            }
        }

        public bool UserHasPlanChanges
        {
            get
            {
                return this.userHasPlanChanges;
            }

            set
            {
                this.userHasPlanChanges = value;
                this.OnPropertyChanged(() => this.UserHasPlanChanges);
            }
        }

        private async void Load()
        {
            this.LoadingOn();
            this.Changes = new ObservableCollection<Change>(await this.DataDownloader.DownloadChanges());
            foreach (var c in this.Changes)
            {
                Improver.ChangesSplit(c);
            }

            this.UserPlanChanges = new ObservableCollection<Change> { this.Changes.Last() };
            this.UserHasPlanChanges = true;

            this.LoadingOff();
        }
    }
}