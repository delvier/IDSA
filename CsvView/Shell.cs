using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
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
                    vd.View.Dock = DockStyle.Fill;
                    var tp = new TabPage(vd.Header);
                    tp.Controls.Add(vd.View);
                    tabControl1.TabPages.Add(tp);
                }
            }
        }
    }
}
