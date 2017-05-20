namespace PlanVisual.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Bases;
    using Plan.PlanServiceReference;
    using Plan.Service;
    using PlanDatabase;
    using PlanDatabase.Entities;

    using Prism.Commands;

    public class SettingsViewModel : ViewModelBase
    {
        private readonly IPlanRepository repository;
        private ObservableCollection<Setting> studentSettings;
        private Setting selectedStudentSetting;
        private ObservableCollection<Specialization> specializations;
        private Specialization selectedSpecjalization;
        private ObservableCollection<Group> groups;
        private Group selectedGroup;
        private bool specjalizationsVisibility;
        private bool groupsVisibility;
        private bool lectoratesVisibility;
        private ObservableCollection<string> lectorates;
        private string selectedLectorate;
        private ObservableCollection<PlanSelect> seminars;
        private PlanSelect selectedSeminar;
        private bool seminarsVisibility;
        private bool facultiesVisibility;
        private ObservableCollection<PlanSelect> faculties;
        private ObservableCollection<PlanSelect> selectedFaculties;
        private DelegateCommand selectedCommand;

        private DelegateCommand saveStudentSettingsCommand;

        public SettingsViewModel()
        {
            this.repository = new PlanRepository();
        }

        public DelegateCommand SelectedCommand => this.selectedCommand ?? (this.selectedCommand = new DelegateCommand(this.Load));

        public ObservableCollection<Setting> StudentSettings
        {
            get
            {
                return this.studentSettings;
            }

            set
            {
                this.studentSettings = value;
                this.OnPropertyChanged(() => this.StudentSettings);
            }
        }

        public Setting SelectedStudentSetting
        {
            get
            {
                return this.selectedStudentSetting;
            }

            set
            {
                this.selectedStudentSetting = value;
                this.OnPropertyChanged(() => this.SelectedStudentSetting);
                if (value != null)
                {
                    this.Specializations = new ObservableCollection<Specialization>(this.selectedStudentSetting.Specjalizations);
                    if (this.Specializations.Count == 1)
                    {
                        this.SelectedSpecjalization = this.Specializations[0];
                        this.SpecjalizationsVisibility = false;
                    }
                    else
                    {
                        this.SpecjalizationsVisibility = true;
                    }

                    if (this.selectedStudentSetting.Seminars != null)
                    {
                        this.Seminars = new ObservableCollection<PlanSelect>(this.selectedStudentSetting.Seminars);
                        this.SeminarsVisibility = true;
                    }
                    else
                    {
                        this.SeminarsVisibility = false;
                    }

                    if (this.selectedStudentSetting.Faculties != null)
                    {
                        this.Faculties = new ObservableCollection<PlanSelect>(this.selectedStudentSetting.Faculties);
                        this.FacultiesVisibility = true;
                    }
                    else
                    {
                        this.FacultiesVisibility = false;
                    }
                }
                else
                {
                    this.SeminarsVisibility = false;
                    this.FacultiesVisibility = false;
                    this.SpecjalizationsVisibility = false;
                }

                this.SaveStudentSettingsCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool SpecjalizationsVisibility
        {
            get
            {
                return this.specjalizationsVisibility;
            }

            set
            {
                this.specjalizationsVisibility = value;
                this.OnPropertyChanged(() => this.SpecjalizationsVisibility);
            }
        }

        public ObservableCollection<Specialization> Specializations
        {
            get
            {
                return this.specializations;
            }

            set
            {
                this.specializations = value;
                this.OnPropertyChanged(() => this.Specializations);
            }
        }

        public Specialization SelectedSpecjalization
        {
            get
            {
                return this.selectedSpecjalization;
            }

            set
            {
                this.selectedSpecjalization = value;
                this.OnPropertyChanged(() => this.SelectedSpecjalization);
                if (value != null)
                {
                    if (this.selectedSpecjalization.Groups != null)
                    {
                        this.Groups = new ObservableCollection<Group>(this.selectedSpecjalization.Groups);
                        if (this.Groups.Count == 1)
                        {
                            this.SelectedGroup = this.Groups[0];
                            this.GroupsVisibility = false;
                        }
                        else if (this.Groups.Count == 0)
                        {
                            this.GroupsVisibility = false;
                            this.SelectedGroup = null;
                        }
                        else
                        {
                            this.GroupsVisibility = true;
                        }
                    }
                    else
                    {
                        this.GroupsVisibility = false;
                        this.SelectedGroup = null;
                    }
                }
                else
                {
                    this.GroupsVisibility = false;
                    this.SelectedGroup = null;
                }

                this.SaveStudentSettingsCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool GroupsVisibility
        {
            get
            {
                return this.groupsVisibility;
            }

            set
            {
                this.groupsVisibility = value;
                this.OnPropertyChanged(() => this.GroupsVisibility);
            }
        }

        public ObservableCollection<Group> Groups
        {
            get
            {
                return this.groups;
            }

            set
            {
                this.groups = value;
                this.OnPropertyChanged(() => this.Groups);
            }
        }

        public Group SelectedGroup
        {
            get
            {
                return this.selectedGroup;
            }

            set
            {
                this.selectedGroup = value;
                this.OnPropertyChanged(() => this.SelectedGroup);
                if (this.selectedGroup != null)
                {
                    if (this.selectedGroup.Lectorates == null || this.selectedGroup.Lectorates.Count == 0)
                    {
                        this.Lectorates = null;
                        this.LectoratesVisibility = false;
                        this.SelectedLectorate = null;
                    }
                    else if (this.selectedGroup.Lectorates.Count == 1)
                    {
                        this.Lectorates = new ObservableCollection<string>(this.selectedGroup.Lectorates);
                        this.LectoratesVisibility = false;
                        this.SelectedLectorate = this.Lectorates[0];
                    }
                    else
                    {
                        this.Lectorates = new ObservableCollection<string>(this.selectedGroup.Lectorates);
                        this.LectoratesVisibility = true;
                    }
                }
                else
                {
                    this.LectoratesVisibility = false;
                }

                this.SaveStudentSettingsCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool LectoratesVisibility
        {
            get
            {
                return this.lectoratesVisibility;
            }

            set
            {
                this.lectoratesVisibility = value;
                this.OnPropertyChanged(() => this.LectoratesVisibility);
            }
        }

        public ObservableCollection<string> Lectorates
        {
            get
            {
                return this.lectorates;
            }

            set
            {
                this.lectorates = value;
                this.OnPropertyChanged(() => this.Lectorates);
            }
        }

        public string SelectedLectorate
        {
            get
            {
                return this.selectedLectorate;
            }

            set
            {
                this.selectedLectorate = value;
                this.OnPropertyChanged(() => this.SelectedLectorate);
                this.SaveStudentSettingsCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool SeminarsVisibility
        {
            get
            {
                return this.seminarsVisibility;
            }

            set
            {
                this.seminarsVisibility = value;
                this.OnPropertyChanged(() => this.SeminarsVisibility);
            }
        }

        public ObservableCollection<PlanSelect> Seminars
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

        public PlanSelect SelectedSeminar
        {
            get
            {
                return this.selectedSeminar;
            }

            set
            {
                this.selectedSeminar = value;
                this.OnPropertyChanged(() => this.SelectedSeminar);
                this.SaveStudentSettingsCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool FacultiesVisibility
        {
            get
            {
                return this.facultiesVisibility;
            }

            set
            {
                this.facultiesVisibility = value;
                this.OnPropertyChanged(() => this.FacultiesVisibility);
            }
        }

        public ObservableCollection<PlanSelect> Faculties
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

        public ObservableCollection<PlanSelect> SelectedFaculties
        {
            get
            {
                return this.selectedFaculties;
            }

            set
            {
                this.selectedFaculties = value;
                this.OnPropertyChanged(() => this.SelectedFaculties);
            }
        }

        public DelegateCommand SaveStudentSettingsCommand
            =>
            this.saveStudentSettingsCommand
            ?? (this.saveStudentSettingsCommand = new DelegateCommand(this.SaveStudentSettings, this.CanSaveStudentSettings));

        private async void SaveStudentSettings()
        {          
            var setting = new StudentSetting
            {
                Symbol = this.SelectedStudentSetting.Symbol,
                Speciality = this.SelectedSpecjalization.Symbol,
                Group = this.SelectedGroup?.Number,
                Lectorate = this.SelectedLectorate,
                Seminar = this.SelectedSeminar?.LinkSuffix,
                SeminarPrefix = this.SelectedStudentSetting.SeminarPrefix,
                FacultyPrefix = this.SelectedStudentSetting.FacultyPrefix,
                Faculties = this.SelectedFaculties.Select(x => x.LinkSuffix).ToList()
            };

            this.LoadingOn();
            await this.repository.UpdateStudentSettings(setting);
            this.LoadingOff();
        }

        private bool CanSaveStudentSettings()
        {
            return this.SelectedStudentSetting != null && this.SelectedSpecjalization != null && (!(this.Groups?.Count > 0) || this.SelectedGroup != null) && (!(this.Lectorates?.Count > 0) || this.SelectedLectorate != null) && (!(this.Seminars?.Count > 0) || this.Seminars != null);
        }

        private async void Load()
        {
            this.LoadingOn();
            var connection = new ServiceConnection();
            var settings = await connection.GetSettings();
            this.StudentSettings = new ObservableCollection<Setting>(settings);
            var setting = await this.repository.GetStudentSetting();
            if (setting != null)
            {
                this.SelectedStudentSetting = this.StudentSettings?.FirstOrDefault(x => x.Symbol == setting.Symbol);
                this.SelectedSpecjalization = this.Specializations?.FirstOrDefault(x => x.Symbol == setting.Speciality);
                if (setting.Group != null)
                {
                    this.SelectedGroup = this.Groups?.FirstOrDefault(x => x.Number == setting.Group);
                }

                if (setting.Lectorate != null)
                {
                    this.SelectedLectorate = this.Lectorates?.FirstOrDefault(x => x == setting.Lectorate);
                }

                if (setting.Seminar != null)
                {
                    this.SelectedSeminar = this.Seminars?.FirstOrDefault(x => x.LinkSuffix == setting.Seminar);
                }

                if (setting.Faculties != null && setting.Faculties.Count != 0)
                {
                    this.SelectedFaculties = new ObservableCollection<PlanSelect>();
                    foreach (var settingFaculty in setting.Faculties)
                    {
                        var faculty = this.Faculties.FirstOrDefault(x => x.LinkSuffix == settingFaculty);
                        if (faculty != null)
                        {
                            this.SelectedFaculties.Add(faculty);
                        }
                    }
                }
            }

            this.LoadingOff();
        }
    }
}