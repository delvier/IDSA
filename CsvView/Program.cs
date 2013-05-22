using System;
using System.Windows.Forms;

namespace IDSA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ServiceLocator.Instance.Register<IViewProvider>(new TabbedViewProvider());
            ServiceLocator.Instance.Register(new Shell(ServiceLocator.Instance.Resolve<IViewProvider>()));
            Application.Run(ServiceLocator.Instance.Resolve<Shell>());
        }
    }
}
