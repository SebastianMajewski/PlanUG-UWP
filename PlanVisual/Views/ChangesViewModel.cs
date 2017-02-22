namespace PlanVisual.Views
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;

    using Plan;

    using PlanVisual.Bases;
    using PlanVisual.Tools;

    public class ChangesViewModel : ViewModelBase
    {
        private ObservableCollection<Change> changes;

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

        private async void Load()
        {
            this.LoadingOn();
            this.Changes = new ObservableCollection<Change>(await this.DataDownloader.DownloadChanges());
            foreach (var c in this.Changes)
            {
                Improver.ChangesSplit(c);
            }

            this.LoadingOff();
        }
    }
}