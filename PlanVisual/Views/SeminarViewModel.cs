namespace PlanVisual.Views
{
    using System.Collections.ObjectModel;

    using Plan;

    using PlanVisual.Bases;

    using Prism.Mvvm;

    public class SeminarViewModel : ViewModelBase
    {
        private ObservableCollection<Classes> seminars;

        public SeminarViewModel()
        {
            this.Load();
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
            this.LoadingOff();

        }
    }
}