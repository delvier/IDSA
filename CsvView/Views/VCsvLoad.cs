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
        private CachedCsvReader csv;

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

        // I dont know if passing type throw few function's and making it dependent on each other is good...
        private void loadCsvData<T>()
        {
            // TODO: Przeniesc dane z OpenDialog() tutaj, chyba ze  bedzie wykorzystywany w tym view w wielu miejscach
            csv = presenter.LoadCsvFile(OpenDialog());
            if (csv != null)
            {
                csvDataGrid.DataSource = csv;
                //Task.Factory.StartNew(() => presenter.AddCompany(csv.ToList())); //dispose crash task, task runs 
                                                                                   //infinite when app close some dispose problem occurs
                prepareGridHeaders<T>();
                //TODO: change place for Dispose()
                //csv.Dispose();
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
            if (csv.FieldCount == Enum.GetNames(typeof(CsvEnums._company)).Length)
            {
                csvTask = Task.Factory.StartNew(() =>
                        presenter.AddCompany(csv.ToList()),
                        System.Threading.CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext()
                    );
            }
            else
                csvTask = Task.Factory.StartNew(() =>
                        presenter.AddReport(csv.ToList()),
                        System.Threading.CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext()
                    );
            csvTask.ContinueWith((o) => csv.Dispose());
            //presenter.saveDb<datatype>();
        }
    }
}
