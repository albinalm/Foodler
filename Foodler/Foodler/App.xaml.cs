using Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Foodler
{
    public partial class App : Application
    {
        static IContainer container;
        static readonly ContainerBuilder builder = new ContainerBuilder();
        public App()
        {
            //DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);
            InitializeComponent();
            MainPage = new AppShell();
        }
        public static void RegisterType<T>() where T : class
        {
            builder.RegisterType<T>();
        }
        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>().As<TInterface>();
        }
        public static void BuildContainer()
        {
            container = builder.Build();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
