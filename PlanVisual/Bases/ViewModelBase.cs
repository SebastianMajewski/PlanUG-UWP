namespace PlanVisual.Bases
{
    using System;

    using Plan;
    using Plan.RestClient;
    using Plan.Service;

    using Prism.Mvvm;

    public class ViewModelBase : BindableBase
    {
        private bool isBusy;       

        public ViewModelBase()
        {
            this.Service = new ServiceConnection(new RestClient());
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            private set
            {
                this.isBusy = value;
                this.OnPropertyChanged(() => this.IsBusy);
            }
        }

        protected IServiceConnection Service { get; private set; }

        public void LoadingOn()
        {
            this.IsBusy = true;
        }

        public void LoadingOff()
        {
            this.IsBusy = false;
        }
    }
}
