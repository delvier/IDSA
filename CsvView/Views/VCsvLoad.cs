using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDSA.Presenters;
using LumenWorks.Framework.IO.Csv;

namespace IDSA
{
    public interface IVCsvLoad
    {
        //void SetControler(CsvViewController ctr);
        //void LoadCsvFile();
        void BoxMsg(string s);
        string OpenDialog();
        void RefreshView();
        //OpenFileDialog dialog { get; set; }
    }

    public partial class VCsvLoad : UserControl, IVCsvLoad
    {
        private VCsvLoadPresenter presenter;
        //private CachedCsvReader csv;

        public VCsvLoad()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new VCsvLoadPresenter(this)); 
            presenter = ServiceLocator.Instance.Resolve<VCsvLoadPresenter>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            presenter.OnLoad();
        }

        private void prepareGridHeaders<T>()
        {
            var collection = presenter.getHeaders<T>(csvDataGrid.Columns.Count);
            foreach (var element in collection)
            {
                csvDataGrid.Columns[collection.IndexOf(element)].HeaderText = element.ToString();
            }
        }

        private void loadCsvData<T>()
        {
            if (presenter.LoadCsvFile(OpenDialog())) // if file loaded successfull
            {
                csvDataGrid.DataSource = presenter.GetCsvModel();
                prepareGridHeaders<T>();
            }
        }

        private void loadCsv_Click(object sender, EventArgs e)
        {
            loadCsvData<CsvEnums._company>();
        }

        private void loadFinData_Click(object sender, EventArgs e)
        {
            loadCsvData<CsvEnums._financialData>();
        }

        public void BoxMsg(string s)
        {
            MessageBox.Show(s);
        }

        public string OpenDialog()
        {
            using (var tmpDialog = new OpenFileDialog())
            {
                if (tmpDialog.ShowDialog() == DialogResult.OK)
                {
                    return tmpDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }

        private void baseView_Click(object sender, EventArgs e)
        {
            //presenter.selectColumns();
        }

        public void RefreshView()
        {
            //presenter.
        }

        private void saveDb_Click(object sender, EventArgs e)
        {
            //Task.WaitAll();
            Task csvTask;
            if (presenter.GetCsvModel().FieldCount == Enum.GetNames(typeof(CsvEnums._company)).Length)
            {
                csvTask = Task.Factory.StartNew(() =>
                        presenter.AddCompany(presenter.GetCsvModel().ToList()),
                        System.Threading.CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext()
                    );
            }
            else
                csvTask = Task.Factory.StartNew(() =>
                        presenter.AddReport(presenter.GetCsvModel().ToList()),
                        System.Threading.CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext()
                    );
            csvTask.ContinueWith((o) => presenter.GetCsvModel().Dispose());
            //presenter.saveDb<datatype>();
        }
    }
}
