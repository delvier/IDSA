using System.Windows.Forms;
using IDSA.Models.Repository;
using Microsoft.Practices.ServiceLocation;
using System;
using IDSA.Views.ReportManagment;

namespace IDSA
{
	public partial class Shell : Form
	{
		public Shell(IViewProvider<MixedViewItemDescriptor> viewProvider)
		{
			InitializeComponent();

			foreach (var viewItem in viewProvider.GetViews())
			{
				if (viewItem.Type == EProjectionType.Tabbed)
				{
					var view = (Control)ServiceLocator.Current.GetInstance(viewItem.View);
					view.Dock = DockStyle.Fill;
					var tp = new TabPage(viewItem.Header);
					tp.Controls.Add(view);
					mainTabControl.TabPages.Add(tp);

				}
				else if (viewItem.Type == EProjectionType.Modal)
				{
                    EventHandler handlerOnClick = giveMeHandler(viewItem.View);
					var item = new ToolStripMenuItem(viewItem.Header, null, handlerOnClick);
					mainStripMenu.Items.Add(item);
				}
			}
		}

        public void Show(string text)
        {
            MessageBox.Show(text);
        }

        private EventHandler giveMeHandler(Type typeView)
        {
            return new EventHandler((s, e) =>
            {
                var form = new Form();
                var view = (Control)ServiceLocator.Current.GetService(typeView);
                form.Controls.Add(view);
                form.ShowDialog();
            });
        }

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			base.OnClosing(e);
			ServiceLocator.Current.GetInstance<IUnitOfWork>().Dispose();
		}
	}
}
