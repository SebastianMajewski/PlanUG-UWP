namespace PlanVisual.Views
{
    using Microsoft.Practices.Unity;

    using Plan;

    using PlanVisual.Bases;

    using Prism.Mvvm;

    public class MainPageViewModel : ViewModelBase
    {
        private ChangesViewModel changesContext;
        private SeminarViewModel seminarContext;
        private FacultyViewModel facultyContext;
        private SettingsViewModel settingsContext; 

        public MainPageViewModel() : base()
        {
            this.ChangesContext = new ChangesViewModel();
            this.SeminarContext = new SeminarViewModel();
            this.FacultyContext = new FacultyViewModel();
            this.SettingsContext = new SettingsViewModel();
        }

        public ChangesViewModel ChangesContext
        {
            get
            {
                return this.changesContext;
            }

            set
            {
                this.changesContext = value;
                this.OnPropertyChanged(() => this.ChangesContext);
            }
        }

        public FacultyViewModel FacultyContext
        {
            get
            {
                return this.facultyContext;
            }

            set
            {
                this.facultyContext = value;
                this.OnPropertyChanged(() => this.FacultyContext);
            }
        }

        public SeminarViewModel SeminarContext
        {
            get
            {
                return this.seminarContext;
            }

            set
            {
                this.seminarContext = value;
                this.OnPropertyChanged(() => this.ChangesContext);
            }
        }

        public SettingsViewModel SettingsContext
        {
            get
            {
                return this.settingsContext;
            }

            set
            {
                this.settingsContext = value;
                this.OnPropertyChanged(() => this.SettingsContext);
            }
        }
    }
}