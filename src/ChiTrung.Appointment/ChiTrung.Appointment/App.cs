using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using ChiTrung.Appointment.Views;
using Xamarin.Forms;

namespace ChiTrung.Appointment
{
    public class App : FormsApplication
    {
        private readonly SimpleContainer container;

        public App(SimpleContainer container)
        {
            Initialize();

            this.container = container;

            // TODO: Register additional viewmodels and services
            container
                .PerRequest<MainViewModel>()
                .PerRequest<LoginViewModel>();            

            //DisplayRootView<MainView>();
            DisplayRootView<LoginView>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
