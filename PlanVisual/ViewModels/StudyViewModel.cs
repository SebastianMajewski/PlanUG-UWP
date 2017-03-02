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
    using Plan.PlanServiceReference;

    using PlanVisual.Tools;

    using Prism.Commands;

    public class StudyViewModel : ViewModelBase
    {
        private ObservableCollection<ExtendedClasses> classes;
        private ObservableCollection<PlanSelect> options;
        private IEnumerable<IGrouping<object, ExtendedClasses>> groupedclasses;
        private DelegateCommand selectedCommand;
        private DelegateCommand<PlanSelect> applyCommand;
        private bool formVisibled;
        private string filter;

        public DelegateCommand SelectedCommand => this.selectedCommand ?? (this.selectedCommand = new DelegateCommand(this.Load));

        public DelegateCommand<PlanSelect> ApplyCommand => this.applyCommand ?? (this.applyCommand = new DelegateCommand<PlanSelect>(this.OptionSelected));

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

            set
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
            this.Options = new ObservableCollection<PlanSelect>(await this.Service.GetPlanForStudiesOptions());
            this.LoadingOff();
            this.FormVisibled = true;           
        }

        private async void OptionSelected(PlanSelect option)
        {
            this.FormVisibled = false;
            this.LoadingOn();
            this.Classes = new ObservableCollection<ExtendedClasses>(await this.Service.GetPlanForStudies(option));
            foreach (var f in this.Classes)
            {
                Improver.LecturerSplit(f);
            }

            this.ChangeGroupByProperty(this.Filter);
            this.LoadingOff();
        }

        private void ChangeGroupByProperty(string propertyName)
        {
            if (this.Classes.ItemType().HasProperty(propertyName))
            {
                this.GroupedClasses = this.Classes.GroupBy(c => c.PropertyValue(propertyName)).OrderBy(x => x.Key);
            }
        }

        private void ChangeGroupByProperty<T, TP>(Expression<Func<T, TP>> expression) where T : class
        {
            // this.ChangeGroupByProperty(TypeHelpers.PropertyName(expression));
            this.Filter = TypeHelpers.PropertyName(expression);
        }
    }
}
