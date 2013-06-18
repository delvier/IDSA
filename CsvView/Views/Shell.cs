using System.Windows.Forms;
using IDSA.Models.Repository;
using Microsoft.Practices.ServiceLocation;

namespace IDSA
{
    public partial class Shell : Form
    {
        public Shell(IViewProvider viewProvider)
        {
            InitializeComponent();
            if (viewProvider.ProjectionType == EProjectionType.Tabbed)
            {
                //menuStrip1.Visible = false;

                foreach (var vd in viewProvider.GetViews())
                {
                    var view = (Control)ServiceLocator.Current.GetInstance(vd.View);
                    view.Dock = DockStyle.Fill;
                    var tp = new TabPage(vd.Header);
                    tp.Controls.Add(view);
                    tabControl1.TabPages.Add(tp);
                }
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            //ServiceLocator.Current.GetInstance<EFUnitOfWork>().Dispose();
        }
    }
}
