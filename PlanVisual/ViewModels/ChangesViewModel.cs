namespace PlanVisual.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.ServiceModel;

    using Windows.UI.Popups;

    using Bases;
    using Plan.DataClasses;
    using Plan.ServiceReference;

    using Prism.Commands;
    using Tools;

    public class ChangesViewModel : ViewModelBase
    {
        private ObservableCollection<ExtendedChange> changes;
        private ObservableCollection<ExtendedChange> userPlanchanges;
        private bool userHasPlanChanges;
        private DelegateCommand selectedCommand;

        public ObservableCollection<ExtendedChange> Changes
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

        public ObservableCollection<ExtendedChange> UserPlanChanges
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

        public DelegateCommand SelectedCommand => this.selectedCommand ?? (this.selectedCommand = new DelegateCommand(this.Load));

        private async void Load()
        {
            this.LoadingOn();
            try
            {
                this.Changes = new ObservableCollection<ExtendedChange>(await this.Service.GetChanges());
            }
            catch (FaultException<ServiceFault> f)
            {
                await new MessageDialog(f.Detail.Type.ToString()).ShowAsync();
            }
            catch (Exception e)
            {
                await new MessageDialog(e.Message).ShowAsync();
            }
            finally
            {
                this.Changes = new ObservableCollection<ExtendedChange>();
            }

            foreach (var c in this.Changes)
            {
                Improver.ChangesSplit(c);
            }

            //this.UserPlanChanges = new ObservableCollection<ExtendedChange> { this.Changes.Last() };
            //this.UserHasPlanChanges = true;

            this.LoadingOff();
        }
    }
}