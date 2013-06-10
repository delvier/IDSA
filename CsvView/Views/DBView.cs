using System;
using System.Windows.Forms;
using IDSA.Presenters;
using Microsoft.Practices.Prism.Events;
using IDSA;
using IDSA.Events;

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

        private readonly DbViewPresenter presenter;
        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Ctor and OnLoad

        public DBView()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new DbViewPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<DbViewPresenter>();
            eventAggregator = ServiceLocator.Instance.Resolve<IEventAggregator>();

            eventAggregator.GetEvent<DatabaseCreatedEvent>()
                .Subscribe(DatabaseCreatedAction);
            //ServiceLocator.Instance.Resolve<EventDbCreate>().DbCreateDone += DBView_DbCreateDone;
            ServiceLocator.Instance.Resolve<EventDbUpdate>().DbUpdateDone += DBView_DbUpdateDone;
        }

        #endregion

        #region Delegates implementation

        private void DatabaseCreatedAction(bool isCreated)
        {
            DBView_DbCreateDone();
        }

        private void DBView_DbCreateDone()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DBView_DbCreateDone()));
            }
            else
            {
                // Instead of Invoke() we can add this below:
                //Label.CheckForIllegalCrossThreadCalls = false;
                this.Info.Text = presenter.dbCreateDone();
                this.companyBindingSource.DataSource = presenter.GetAllCompanies();
                this.button1.Visible = true;
                this.button1.Refresh();
            }
        }

        private void DBView_DbUpdateDone()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DBView_DbUpdateDone()));
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
            presenter.CleanDatabase();
            presenter.CreateDatabase();
            RefreshProgessBar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshProgessBar();
            if (this.addReportsCheckBox.Checked)
                presenter.AddReports(this.trackBar1.Value);
            else
                presenter.AddCompanies(this.trackBar1.Value);
            RefreshProgessBar();
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            presenter.CleanDatabase();
            //var id = "WWL";
            //var query = db.Companies
            //            .Where(c => c.Symbol == id)
            //            .SelectMany(r => r.Reports,
            //                (spolka, raport) => new
            //                {
            //                    spolka.Name,
            //                    raport.KeyId.Year,
            //                    raport.NetProfit
            //                });

            //var query = db.Companies.Include("Reports").Where(c => c.Symbol == id);
        }
        #endregion

        #region Inside Events behaviour
        private void addReportsCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            eventAggregator.GetEvent<DatabaseCreatedEvent>().Publish(this.addReportsCheckBox.Checked);
            this.button1.Text = this.addReportsCheckBox.Checked ? "Add reports" : "Add companies";
            this.trackBar1.Maximum = this.addReportsCheckBox.Checked ? 16000 : 952;
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
