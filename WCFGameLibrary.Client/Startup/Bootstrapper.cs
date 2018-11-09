using Autofac;
using WCFGameLibrary.Services;

namespace WCFGameLibrary.Client.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<WCFGameLibraryService>().As<IWCFGameLibraryService>();

            return builder.Build();
        }
    }
}
