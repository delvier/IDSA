using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using IDSA.Models;
using IDSA.Services;
using IDSA.Views;
using System.Data;
using System.Windows.Forms;
using IDSA.Modules.DataCalculation;
using Microsoft.Practices.ServiceLocation;
using System.Reflection;
using IDSA.Modules.CachedListContainer;

namespace IDSA.Presenters
{
    class CompaniesPresenter
    {
        Companies view;
        private readonly ICacheService _cache;
        private readonly IChartService _chartService;
        private readonly ICalculationService _calculationService;
        private readonly IDataService<ICompany> _companyDataService; //to delete later on.

        //public IDataCalculation<RzisBase> _dataCalculationService { get; set; }

        private Company _cmpSelected { get; set; }
        public IList<RzisBase> _cmpSelectedReportsList { get; set; }
        private ViewModeType finDataViewMode { get; set; } // maybe add view mode into dataCalulationService?
        private float _terminalValue { get; set; }

        public CompaniesPresenter(Companies view, IChartService chartService, ICalculationService calulationService)
        {
            this.view = view;
            this._companyDataService = (IDataService<Company>)(new CompanyDataService());
            //this._dataCalculationService = new RzisBaseDataCaluclation();

            this._chartService = chartService;
            this._cache = ServiceLocator.Current.GetInstance<ICacheService>();
            this._calculationService = calulationService;
            this.finDataViewMode = ViewModeType.Seperate;
            
            //delegateConstruct
            this.SelectedCmpReportsChangedEvent += this.SelectAllReports;
            this.SelectedCmpReportsChangedEvent += this.ReportsRecalculationIfNeeded;
            this.SelectedCmpReportsChangedEvent += this.RaiseTvCalculationPerform;
            this.SelectedCmpReportsChangedEvent += this.SelectFilterOnReports;
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
                _chartService.RecalcXValues(_cmpSelected.Reports
                                        .OrderByDescending(r => r.Year)
                                        .ThenByDescending(r => r.Quarter)
                                        .Take(e.selectQuantity).ToList());
            }
            else
                _chartService.RecalcXValues(_cmpSelected.Reports.ToList());
            this.ChartChangeNow("Sales");
        }

        internal void ChartChangeNow(String headerName)
        {
            _chartService.RecalcYValues(headerName);
            view.ChartRedraw(_chartService.GetxValues(), _chartService.GetyValues());
        }

        #endregion

        public IBindingList GetDbCompanies()
        {
            var cmpBindList = new BindingList<Company>(_cache.GetAll());
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
                return new BindingList<Company>(_cache.GetAll());
        }

        public void SetCmpSelected(Company company)
        {
            _cmpSelected = company;
            this.UpdatePanel2();
        }

        public Company GetSelectedCompany()
        {
            return _cmpSelected;
        }

        public void UpdatePanel2()
        {
            view.RefreshView_Panel2(_cmpSelected);
        }

        public string GetTerminalValue()
        {
            return String.Format("TV: {0:F3}", _terminalValue);
        }

        #region ChangedEvent & Delegates

        public delegate void SelectedCmpReportsChangedDelegate(object sender, SelectedCmpReportsChangedEventArgs e);
        public delegate void ViewModeChangeDelegate(object sender, RaiseViewModeChangeEventArgs e);
        public delegate void DataRecalculationRequestDelegate(object sender, EventArgs e);
        public event SelectedCmpReportsChangedDelegate SelectedCmpReportsChangedEvent;
        public event DataRecalculationRequestDelegate DataRecalculationRequestEvent;
        public event ViewModeChangeDelegate ViewModeChangeEvent;

        public void SelectFilterOnReports(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            if (e != null)
            {
                FilterSelectReports(e.selectQuantity);
            }
        }
        public void SelectAllReports(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            if (e != null)
            {
                SelectReports(0);
            }
        }
        public void SelectProperReports(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            if (e != null)
            {
                SelectReports(e.selectQuantity);
            }
        }
        public void ViewModeChange(object sender, RaiseViewModeChangeEventArgs e)
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
        public void RaiseTvCalculationPerform(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            if (finDataViewMode == ViewModeType.Seperate)
                TvCalculationPerform(sender, e);
        }
        public void TvCalculationPerform(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            _terminalValue = _calculationService.GetTerminalValue(_cmpSelected);
        }
        public void SelectedCmpReportsCalucalte(object sender, EventArgs e)
        {
            //_dataCalculationService.SetData(_cmpSelectedReportsList);
            //_dataCalculationService.CalculationPerform();
            //_cmpSelectedReportsList = _dataCalculationService.GetData();
        }
        public void RaiseSelectedCmpChange(Companies sender, SelectedCmpReportsChangedEventArgs e)
        {
            SelectedCmpReportsChangedEvent(sender, e);
        }

        public void RaiseDataRecalculation(Companies sender, EventArgs e)
        {
            DataRecalculationRequestEvent(sender, e);
        }

        internal void RaiseViewModeChange(Companies sender, RaiseViewModeChangeEventArgs e)
        {
            ViewModeChangeEvent(sender, e);
        }
        #endregion

        #region dbModel & _privateData Queries
        public void FilterSelectReports(int numberToShow)
        {
            if (numberToShow != 0)
            {
                _cmpSelectedReportsList = _cmpSelectedReportsList.Take(numberToShow)
                                                                 .ToList<RzisBase>();
            }
        }
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
                                            Sales = r.IncomeStatement.Sales,
                                            OwnSaleCosts = r.IncomeStatement.OwnSaleCosts,
                                            EarningOnSales = r.IncomeStatement.EarningOnSales,
                                            EBIT = r.IncomeStatement.EBIT,
                                            EarningBeforeTaxes = r.IncomeStatement.EarningBeforeTaxes,
                                            NetProfit = r.IncomeStatement.NetProfit
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
                                Sales = r.IncomeStatement.Sales,
                                OwnSaleCosts = r.IncomeStatement.OwnSaleCosts,
                                EarningOnSales = r.IncomeStatement.EarningOnSales,
                                EBIT = r.IncomeStatement.EBIT,
                                EarningBeforeTaxes = r.IncomeStatement.EarningBeforeTaxes,
                                NetProfit = r.IncomeStatement.NetProfit
                            }
                            )
                            .ToList<RzisBase>();
            else
                return (new List<RzisBase>());
        }

        public static void SelectData(IList<Report> reports, PropertyInfo classProperty)
        {
            // TODO: START HERE.
            //http://stackoverflow.com/questions/8990231/how-can-i-create-a-dynamic-select-on-an-ienumerablet-at-runtime
            //reports.Select();
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



        internal void testBtnClick()
        {
            //TODO: New ReportsDataCalculation (FinData - Oriented).
            //ReportDataCalculation.CalculateToQurater(_cmpSelected.Reports);
        }
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
