using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using IDSA.Models;
using IDSA.Models.Repository;
using IDSA.Services;
using IDSA.Views;
using System.Data;
using System.Windows.Forms;
using IDSA.Modules.DataCalculation;

namespace IDSA.Presenters
{
    class VCompanyPresenter
    {
        VCompany view;
        private IUnitOfWork dbModel;
        private IChartService chartService;
        private readonly IDataService<ICompany> _companyDataService;
        private IEnumerable<ICompany> _cmpData;
        private Company _cmpSelected { get; set; }
        public IList<RzisBase> _cmpSelectedReportsList { get; set; }
        public IDataCalculation<RzisBase> _dataCalculationService { get; set; }
        private ViewModeType finDataViewMode { get; set; } // maybe add view mode into dataCalulationService?

        public VCompanyPresenter(VCompany view)
        {
            this._companyDataService = (IDataService<Company>)(new CompanyDataService());
            this.view = view;
            this._dataCalculationService = new ReportDataCaluclation();
            this.chartService = new ChartService();
            this.finDataViewMode = ViewModeType.Seperate;

            //delegateConstruct
            this.SelectedCmpReportsChangedEvent += this.SelectProperReports;
            this.SelectedCmpReportsChangedEvent += this.ReportsRecalculationIfNeeded;
            this.SelectedCmpReportsChangedEvent += view.SelectedCmpReportsChanged;
            this.SelectedCmpReportsChangedEvent += this.ChartChange;
            this.DataRecalculationRequestEvent += this.SelectedCmpReportsCalucalte;
            this.DataRecalculationRequestEvent += view.SelectedCmpReportsChanged;
            this.ViewModeChangeEvent += this.ViewModeChange;
        }

        #region Internal Chart Methods

        internal void ChartChange(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            if (e.selectQuantity != 0)
            {
                chartService.RecalcXValues(_cmpSelected.Reports
                                        .OrderByDescending(r => r.Year)
                                        .ThenByDescending(r => r.Quarter)
                                        .Take(e.selectQuantity).ToList());
            }
            else
                chartService.RecalcXValues(_cmpSelected.Reports.ToList());
            this.ChartChangeNow("Sales");
        }

        internal void ChartChangeNow(String headerName)
        {
            chartService.RecalcYValues(headerName);
            view.ChartRedraw(chartService.GetxValues(), chartService.GetyValues());
        }

        #endregion

        public IBindingList GetDbCompanies()
        {
            var cmpBindList = new BindingList<Company>();
            if (dbModel == null)
                dbModel = ServiceLocator.Instance.Resolve<IUnitOfWork>();
            cmpBindList = dbModel.Companies.GetAll();
            return cmpBindList;
        }

        public IBindingList GetFilterBox(string lookForCompany)
        {
            var cmpBoxElements = view.GetCmpBoxItems();
            var showList = new BindingList<Company>();

            if (!string.IsNullOrEmpty(lookForCompany))
            {
                foreach (Company ele in cmpBoxElements)
                {
                    if (ele.Name.Contains(lookForCompany) || ele.Shortcut.Contains(lookForCompany))
                    {
                        showList.Add(ele);
                    }
                }
                return showList;
            }
            else
                return dbModel.Companies.GetAll(); ;
        }

        public void SetCmpSelected(Company company)
        {
            _cmpSelected = company;
            this.UpdatePanel2();
        }

        public void UpdatePanel2()
        {
            view.RefreshView_Panel2(_cmpSelected);
        }


        #region ChangedEvent & Delegates

        public delegate void SelectedCmpReportsChangedDelegate(object sender, SelectedCmpReportsChangedEventArgs e);
        public delegate void ViewModeChangeDelegate(object sender, RaiseViewModeChangeEventArgs e);
        public delegate void DataRecalculationRequestDelegate(object sender, EventArgs e);
        public event SelectedCmpReportsChangedDelegate SelectedCmpReportsChangedEvent;
        public event DataRecalculationRequestDelegate DataRecalculationRequestEvent;
        public event ViewModeChangeDelegate ViewModeChangeEvent;
        public void SelectProperReports(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            if (e != null)
            {
                SelectReports(e.selectQuantity);
            }
        }
        public void ViewModeChange (object sender, RaiseViewModeChangeEventArgs e)
        {
            this.finDataViewMode = e._viewMode;
        }
        public void ReportsRecalculationIfNeeded(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            if (finDataViewMode == ViewModeType.Seperate)
            {
                SelectedCmpReportsCalucalte(sender, new EventArgs());
            }
        }
        public void SelectedCmpReportsCalucalte(object sender, EventArgs e)
        {
            _dataCalculationService.SetData(_cmpSelectedReportsList);
            _dataCalculationService.CalculationPerform();
            _cmpSelectedReportsList = _dataCalculationService.GetData();
        }
        public void RaiseSelectedCmpChange(VCompany sender, SelectedCmpReportsChangedEventArgs e)
        {
            SelectedCmpReportsChangedEvent(sender, e);
        }

        public void RaiseDataRecalculation(VCompany sender, EventArgs e)
        {
            DataRecalculationRequestEvent(sender, e);
        }

        internal void RaiseViewModeChange(VCompany sender, RaiseViewModeChangeEventArgs e)
        {
            ViewModeChangeEvent(sender, e);
        }
        #endregion

        #region DataModel Queries

        public void SelectReports(int takeNumber)
        {
            if (takeNumber > 0)
            {
                _cmpSelectedReportsList = _cmpSelected.Reports
                                        .OrderByDescending(r => r.Year) // orderBy  Year-Quarter. - best overView.
                                        .ThenByDescending(r => r.Quarter)
                                        .Take(takeNumber)
                                        .Select(r => new RzisBase
                                        {
                                            Year = r.Year,
                                            Quarter = r.Quarter,
                                            Sales = r.Sales,
                                            OwnSaleCosts = r.OwnSaleCosts,
                                            EarningOnSales = r.EarningOnSales,
                                            EarningBeforeTaxes = r.EarningBeforeTaxes,
                                            EBIT = r.EBIT,
                                            NetProfit = r.NetProfit
                                        }
                                        )
                                        .ToList<RzisBase>();
            }
            else
            {
                _cmpSelectedReportsList = GetBaseSelectCmpReports();
            }

        }

        public IList<RzisBase> GetBaseSelectCmpReports()
        {
            // CodeRestructure, instead of database new query used _cmpselected.Reports -IEnumerable and LINQ it.
            if (!_cmpSelected.Equals(null))
                return _cmpSelected.Reports
                            .OrderByDescending(r => r.Year) // orderBy  Year-Quarter. - best overView.
                            .ThenByDescending(r => r.Quarter)
                            .Select(r => new RzisBase
                            {
                                Year = r.Year,
                                Quarter = r.Quarter,
                                Sales = r.Sales,
                                OwnSaleCosts = r.OwnSaleCosts,
                                EarningOnSales = r.EarningOnSales,
                                EarningBeforeTaxes = r.EarningBeforeTaxes,
                                EBIT = r.EBIT,
                                NetProfit = r.NetProfit
                            }
                            )
                            .ToList<RzisBase>();
            else
                return (new List<RzisBase>());
        }

        #endregion

        #region Some Presenter Utilities Procedure

        //Converts the DataGridView to DataTable
        public static DataTable DataGridView2DataTable(DataGridView dgv, String tblName, int minRow = 0)
        {

            DataTable dt = new DataTable(tblName);

            // Header columns
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                DataColumn dc = new DataColumn(column.Name.ToString());
                dc.DataType = column.ValueType;
                dt.Columns.Add(dc);
            }

            // Data cells
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    //Type theType = row.Cells[j].Value.GetType();
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value; // this is evil we lost our type ! which we figth for.
                }
                dt.Rows.Add(dr);
            }

            // Related to the bug arround min size when using ExcelLibrary for export
            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = "  ";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion

        #region Test Data Generation
        public IEnumerable GetTestCompanies()
        {
            _cmpData = _companyDataService.GetData().Take(100).ToList();
            return _cmpData;
        }

        public IBindingList GetTestBindList()
        {
            var rnd = new Random();
            var testData = new BindingList<Company>();
            for (int i = 0; i < rnd.Next(5, 15); i++)
            {
                testData.Add(
                    new Company
                    {
                        Name = "Types" + i
                    });
            }
            return testData;
        }

        #endregion
    }

    #region PresenterChangedEventArgs - Classes
    public class SelectedCmpReportsChangedEventArgs
    {
        //public IList selectedCmpReportsList { get; set; }
        public int selectQuantity { get; set; }

        public SelectedCmpReportsChangedEventArgs() { }
        public SelectedCmpReportsChangedEventArgs(int selectQuantity)
        {
            this.selectQuantity = selectQuantity;
        }
    }
    public class RaiseViewModeChangeEventArgs
    {
        public ViewModeType _viewMode { get; set; }
        public RaiseViewModeChangeEventArgs()
        {
            this._viewMode = ViewModeType.Seperate;
        }
        public RaiseViewModeChangeEventArgs(ViewModeType viewMode)
        {
            this._viewMode = viewMode;
        }
    }
    public enum ViewModeType
    {
        Seperate,
        Cumulative
    }
    #endregion

}
