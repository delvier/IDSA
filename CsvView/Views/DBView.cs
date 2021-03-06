using IDSA.Events;
using IDSA.Presenters;
using Microsoft.Practices.Prism.Events;
using System;
using System.Windows.Forms;

namespace IDSA.Views
{
    public interface IDbView
    {
        void UpdateLabel(string p);
        void UpdateProgressBar(int percent);
    }

    public partial class DBView : UserControl, IDbView
    {
        #region Fields and Props

        private readonly DBPresenter presenter;
        
        #endregion

        #region Ctor

        public DBView(IEventAggregator eventAggregator)
        {
            presenter = new DBPresenter(this, eventAggregator);
            
            eventAggregator.GetEvent<DatabaseCreatedEvent>().Subscribe(DatabaseCreatedAction);
            eventAggregator.GetEvent<DatabaseUpdatedEvent>().Subscribe(DatabaseUpdatedAction);
            InitializeComponent();
        }

        #endregion

        #region Event Delegates implementation

        private void DatabaseCreatedAction(bool isCreated)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DatabaseCreatedAction(isCreated)));
            }
            else
            {
                // Instead of Invoke() we can add this below:
                //Label.CheckForIllegalCrossThreadCalls = false;
                this.Info.Text = presenter.dbUpdateDone();
                this.companyBindingSource.DataSource = presenter.GetAllCompanies();
                this.button1.Visible = true;
                this.button1.Refresh();
            }
        }

        private void DatabaseUpdatedAction(bool isUpdated)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DatabaseUpdatedAction(isUpdated)));
            }
            else
            {
                this.Info.Text = presenter.dbUpdateDone();
            }
        }

        #endregion

        #region Public Methods

        public void UpdateLabel(string text)
        {
            this.Info.Text += text;
        }

        public void UpdateProgressBar(int percent)
        {
            this.progressBar.Value = (percent > 100) ? 100 : percent;
            this.progressBar.Refresh();
        }

        #endregion

        #region Private Methods

        private void RefreshProgessBar()
        {
            this.progressBar.Visible = this.progressBar.Visible ? false : true;
            this.progressBar.Refresh();
        }

        #region Buttons service
        private void companyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.companyDataGridView.Refresh();
            this.reportsDataGridView.Refresh();
            presenter.SaveDatabase();
        }

        private void CreateDatabase_Click(object sender, EventArgs e)
        {
            RefreshProgessBar();
            presenter.CreateDatabase();
            RefreshProgessBar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshProgessBar();
            if (this.addReportsCheckBox.Checked)
                presenter.AddReportsFasta2(this.trackBar1.Value);
            else
                presenter.AddCompaniesFasta(this.trackBar1.Value);
            RefreshProgessBar();
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            presenter.CleanDatabase();
        }
        #endregion

        #region Inside Events behaviour
        private void addReportsCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Text = this.addReportsCheckBox.Checked ? "Add reports" : "Add companies";
            this.trackBar1.Maximum = this.addReportsCheckBox.Checked ? 16408 : 886;
            if (this.trackBar1.Value >= this.trackBar1.Maximum)
                this.textBox1.Text = "" + this.trackBar1.Value;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = "" + this.trackBar1.Value;
            this.toolTip1.SetToolTip(this.trackBar1, this.trackBar1.Value.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TODO: there should be check value in textBox
            if (this.textBox1.Text != "")
                this.trackBar1.Value = int.Parse(this.textBox1.Text);
        }
        #endregion

        #endregion
    }
}
