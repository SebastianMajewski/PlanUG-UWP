namespace PlanVisual.Views
{
    using System.Collections.ObjectModel;

    using Plan;

    using PlanVisual.Bases;

    using Prism.Mvvm;

    public class FacultyViewModel : ViewModelBase
    {
        private ObservableCollection<Classes> faculties;

        public FacultyViewModel()
        {
            this.Load();
        }

        public ObservableCollection<Classes> Faculties
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

        private async void Load()
        {
            this.LoadingOn();
            this.Faculties = new ObservableCollection<Classes>(await this.DataDownloader.DownloadPlanFaculty());
            this.LoadingOff();
        }
    }
}