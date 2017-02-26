namespace PlanVisual.Bases
{
    using System;

    using Plan;
    using Plan.Downloaders;

    using Prism.Mvvm;

    public class ViewModelBase : BindableBase
    {
        private bool isBusy;       

        public ViewModelBase()
        {
            this.DataDownloader = LessonPlanDataDownloader.Instance;
            //this.DataDownloader.ErrorOccured += this.OnError;
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

        protected ILessonPlanDataDownloader DataDownloader { get; private set; }

        public void LoadingOn()
        {
            this.IsBusy = true;
        }

        public void LoadingOff()
        {
            this.IsBusy = false;
        }

        private void OnError(Exception exception)
        {
            
        }
    }
}
