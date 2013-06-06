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

namespace IDSA.Presenters
{
    class VCompanyPresenter
    {
        VCompany view;
        private IUnitOfWork dbModel;

        private readonly IDataService<ICompany> _companyDataService;
        private IEnumerable<ICompany> _cmpData;
        private Company _cmpSelected { get; set; }
        public IList _cmpSelectedReportsList { get; set; }
        public ObservableListSource<IList> _cmpSelectedReportsObsList { get; set;}

        public VCompanyPresenter(VCompany view)
        {
            this._companyDataService = (IDataService<Company>)(new CompanyDataService());
            this.view = view;
            this._cmpSelectedReportsObsList = new ObservableListSource<IList>();
        }

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
            this.SetFullReports();
            this.UpdatePanel2();
        }

        public void UpdatePanel2()
        {
            view.RefreshView_Panel2(_cmpSelected);
        }

        #region DataModel Queries
        public IQueryable GetBaseReportQuery()
        {
            return null;
            //return _cmpSelected.Reports
            //    .Where(r => r.CompanyId == _cmpSelected.Id)
            //    .OrderByDescending(r => r.Year) // orderBy  Year-Quarter. - best overView.
            //    .ThenByDescending(r => r.Quarter);
        }
        public void SetFullReports()
        {
            _cmpSelectedReportsObsList.Add(GetBaseSelectCmpReports());
        }
        public void SetLast4QReports()
        {
            _cmpSelectedReportsList = _cmpSelected.Reports
                                        .Where(r => r.CompanyId == _cmpSelected.Id)
                                        .OrderByDescending(r => r.Year) // orderBy  Year-Quarter. - best overView.
                                        .ThenByDescending(r => r.Quarter)
                                        .Take(4)
                                        .Select(r => new
                                        {
                                            r.Year, // how to export this to some types ?
                                            r.Quarter,
                                            r.Sales,
                                            r.OwnSaleCosts,
                                            r.EarningOnSales,
                                            r.EarningBeforeTaxes,
                                            r.EBIT,
                                            r.NetParentProfit,
                                            r.NetProfit
                                        }
                                        )
                                        .ToList();
                                        
        }
        public IList GetBaseSelectCmpReports()
        {
            // CodeRestructure, instead of database new query used _cmpselected.Reports -IEnumerable and LINQ it.
            if (!_cmpSelected.Equals(null))
                return _cmpSelected.Reports
                            .Where(r => r.CompanyId == _cmpSelected.Id)
                            .OrderByDescending(r => r.Year) // orderBy  Year-Quarter. - best overView.
                            .ThenByDescending(r => r.Quarter)
                            .Select(r => new
                            {
                                r.Year, // how to export this to some types ?
                                r.Quarter,
                                r.Sales,
                                r.OwnSaleCosts,
                                r.EarningOnSales,
                                r.EarningBeforeTaxes,
                                r.EBIT,
                                r.NetParentProfit,
                                r.NetProfit
                            }
                            )
                            .ToList();
            else
                return (new List<Report>());
        }
        public IList GetSelectedCmpReports1()
        {
            if (dbModel != null)
                return _cmpSelected.Reports
                     .Where(r => r.CompanyId == _cmpSelected.Id)
                     .OrderByDescending(r => r.Year) // orderBy  Year-Quarter. - best overView.
                     .ThenByDescending(r => r.Quarter).Select(x => x.Sales)
                     .ToList();
            else
                return (new List<Report>());
        }
        #endregion

        public IList GetSelectedCmpReports()
        {
            return _cmpSelectedReportsObsList.ToList();
        }

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
}
