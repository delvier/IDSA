using System;
using System.Windows.Forms;
using IDSA.Presenters;

namespace IDSA
{
    public interface IDbView
    {
        //void Refresh();
        //void AddCompany(Company company);
        //void AddCompany(List<Company> companies)
        void UpdateProgressBar(int percent);
        void UpdateLabel(string p);
    }

    public partial class DBView : UserControl, IDbView
    {
        private DbViewPresenter presenter;

        public DBView()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new DbViewPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<DbViewPresenter>();

            ServiceLocator.Instance.Resolve<DbCreate>().DbCreateDone += DBView_DbCreateDone;
            ServiceLocator.Instance.Resolve<DbUpdate>().DbUpdateDone += new DbUpdateDelegate(DBView_DbUpdateDone);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // change introduced only for testing purposes
            this.Select.Text = "Clean";
        }

        #region Delegates implementation

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

        #region Inside Events behaviour
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Text = this.checkBox1.Checked ? "Add reports" : "Add companies";
            this.trackBar1.Maximum = this.checkBox1.Checked ? 16000 : 952;
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

        public void UpdateProgressBar(int percent)
        {
            this.progressBar.Value = (percent > 100) ? 100 : percent;
            this.progressBar.Refresh();
        }

        private void RefreshProgessBar()
        {
            this.progressBar.Visible = this.progressBar.Visible ? false : true;
            this.progressBar.Refresh();
        }

        public void UpdateLabel(string text)
        {
            this.Info.Text += text;
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
            if (this.checkBox1.Checked)
                presenter.AddReports(this.trackBar1.Value);
            else
                presenter.AddCompanies(this.trackBar1.Value);
            RefreshProgessBar();
        }
        
        private void Select_Click(object sender, EventArgs e)
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

            //var companies = query.ToList();
            //foreach (var item in companies)
            //{
            //    //TODO:
            //}

            //var query = db.Companies.Include("Reports").Where(c => c.Symbol == id);
        }
        #endregion
    }
}
