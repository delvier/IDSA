using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDSA.Presenters;

namespace IDSA
{
    public interface IVCsvLoad
    {
        void BoxMsg(string s);
        void RefreshView();
        string OpenDialog();
        void InitCsvDataBox();
    }

    public partial class CsvLoad : UserControl, IVCsvLoad
    {
        private CsvLoadPresenter presenter;
        //private CachedCsvReader csv;

        public CsvLoad()
        {
            presenter = new CsvLoadPresenter(this);
            InitializeComponent();
            //ServiceLocator.Instance.Register(new VCsvLoadPresenter(this));
            //presenter = ServiceLocator.Instance.Resolve<VCsvLoadPresenter>();
            this.InitCsvDataBox(); // just init data type enum list
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            presenter.OnLoad();
        }

        private void prepareGridHeaders()
        {
            var collection = presenter.getHeaders();
            foreach (var element in collection)
            {
                csvDataGrid.Columns[collection.IndexOf(element)].HeaderText = element.ToString();
            }
        }

        private void loadCsvData(CsvEnums.DataType typeOf)
        {
            if (presenter.LoadCsvFile(OpenDialog(), typeOf)) // if file loaded successfull
            {
                csvDataGrid.DataSource = presenter.GetCsvData();
                this.prepareGridHeaders();
            }
        }

        private void loadCsv_Click(object sender, EventArgs e)
        {
            presenter.dataType = (CsvEnums.DataType)Enum.Parse(typeof(CsvEnums.DataType), CsvDataTypeBox.SelectedItem.ToString());
            this.loadCsvData(presenter.dataType);
        }

        private void loadFinData_Click(object sender, EventArgs e)
        {
            this.loadCsvData(CsvEnums.DataType.Financial);
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

        public void RefreshView()
        {
            csvDataGrid.DataSource = presenter.GetCsvData();
        }

        private void saveDb_Click(object sender, EventArgs e)
        {
            if (!presenter.ValidCsvModel()) //if InvalidModel.
            {
                BoxMsg("Model data invalid");
                return;
            }
            //Task.WaitAll();
            Task csvTask;
            if (presenter.dataType == CsvEnums.DataType.Company)
            {
                csvTask = Task.Factory.StartNew(() =>
                        presenter.AddCompany(presenter.GetCsvData().ToList()),
                        System.Threading.CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext()
                    );
                csvTask.ContinueWith((o) => presenter.GetCsvData().Dispose());
            }
            else if (presenter.dataType == CsvEnums.DataType.Financial)
            {
                csvTask = Task.Factory.StartNew(() =>
                    presenter.AddReport(presenter.GetCsvData().ToList()),
                    System.Threading.CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext()
                );
                csvTask.ContinueWith((o) => presenter.GetCsvData().Dispose());    
            }
            
            //presenter.saveDb<datatype>();
        }


        public void InitCsvDataBox()
        {
            CsvDataTypeBox.DataSource = Enum.GetNames(typeof(CsvEnums.DataType));
        }
    }
}
